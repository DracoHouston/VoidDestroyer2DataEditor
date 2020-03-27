using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Drawing;

namespace VoidDestroyer2DataEditor
{
    enum TagNameReportNodeTypes
    {
        plaintext,
        realnumber,
        integer,
        vector,
        color,
        datastructure
    }

    class TagNameReportEntry
    {
        public int UseNum;
        public TagNameReportNodeTypes NodeType;
        public bool IsList;
        public Dictionary<string, TagNameReportEntry> DataStructureProperties;
        public Dictionary<string, int> UsageWithinThisDataStructure;

        public TagNameReportEntry()
        {
            DataStructureProperties = new Dictionary<string, TagNameReportEntry>();
            UsageWithinThisDataStructure = new Dictionary<string, int>();
            UseNum = 0;
            NodeType = TagNameReportNodeTypes.integer;
            IsList = false;
        }

        public override string ToString()
        {
            return UseNum.ToString() + " Type: " + NodeType.ToString();
        }
    }
    //A library of static helpers for parsing VD2 data
    //At the basic level, all values are strings of plaintext
    //They are stored within XML Nodes, as attributes
    //The purpose of the data is described by the XML Node name
    //The Attribute name is almost always attr1, storing a single value
    //In some cases like 3D Vectors each component is stored as an attribute, in this case named 'x', 'y' and 'z'
    //Helpers exist for common types for loading into an object in memory. 
    //All integer values will attempt to read as the appropriate type of integer
    //If this fails they read the value as a real number and cast to their integer type
    //Boolean values are read as floats, then set to true if the value is greater than 0
    //Data structures have their own specialized helper functions within this class.
    //'Discovery Helpers' exist to read through all files and discover tags
    static class ParseHelpers
    {       

        ////////////////////////////////////////////////////////////////////////////////
        // FILE HELPERS
        ////////////////////////////////////////////////////////////////////////////////

        //Loads in the data file first as text, makes the XML standards compliant, and returns the loaded XML document.
        public static XmlDocument SafeLoadVD2DataXMLFile(string inPath)
        {
            XmlDocument result = null;
            if (File.Exists(inPath))
            {
                //VD2 xml files do not have a root node, which greatly upsets the dotnet xml parser for not being standards compliant
                //We simply read in the file as plaintext lines and insert the root node as an attributeless tag called 'docroot'
                //This is done by adding an opening tag (<docroot>) at line 1 (line 0 is always the xml doc header)
                //and a closing tag (</docroot>) at the end.
                //Once done the text can be dumped to a file temporarily and loaded into memory as a nodegraph 'XmlDocument' object
                //This way, we leave the game data files alone.
                List<string> xmltextlines = File.ReadAllLines(inPath).ToList();
                xmltextlines.Insert(1, "<docroot>");
                xmltextlines.Add("</docroot>");
                //There is a single weapon file that has tags that are not standards compliant, setting a value to a name instead of an attribute.
                //We look for the 2 lines and fix them before reading, or the parser gets rather cross at us.
                for (int i = 0; i < xmltextlines.Count; i++)
                {
                    if (xmltextlines[i].StartsWith("<minimumShipClass="))
                    {
                        xmltextlines.Insert(i, xmltextlines[i].Substring(0, 17) + " attr1" + xmltextlines[i].Substring(17));
                        xmltextlines.RemoveAt(i + 1);
                    }
                    if (xmltextlines[i].StartsWith("<disableRate="))
                    {
                        xmltextlines.Insert(i, xmltextlines[i].Substring(0, 12) + " attr1" + xmltextlines[i].Substring(12));
                        xmltextlines.RemoveAt(i + 1);
                    }

                    //Here we look for literal '&', Paul makes no use of the xml reference system and all '&' he uses in the files are the character '&'
                    //XML, however, has other ideas. If you have ever wondered why web things sometimes show you '&amp;', this is why.
                    //An '&' is the opening for a special character, similar to the escape character ('\') system in c strings
                    //So, to preserve the meaning of these literal '&' characters we must feed the standards compliant parser
                    //the special character for a literal '&', which is '&amp;'. Basically, it is XMLs version of '\\'.
                    //This process will likely need to be reversed on save, unless it turns out in testing that VD2 behaves :(
                    xmltextlines[i] = xmltextlines[i].Replace("&", "&amp;");
                }

                File.WriteAllLines("TempLoadStage.xml", xmltextlines);
                result = new XmlDocument();
                result.Load("TempLoadStage.xml");
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////
        // ATTRIBUTE HELPERS
        ////////////////////////////////////////////////////////////////////////////////

        //Gets the value of an attribute at this index from an XML Node as a string of plaintext. 
        //Very important! All parse helpers end up here eventually.
        public static string GetStringFromXMLNodeAttributeAtIndex(int inAttributeIndex, XmlNode inXMLNode)
        {
            string result = "";
            if (inXMLNode.Attributes.Count > inAttributeIndex)
            {
                result = inXMLNode.Attributes[inAttributeIndex].InnerText;
            }
            return result;
        }

        //Gets the value of an attribute with a certain name from an XML Node as a string of plaintext.
        public static string GetStringFromXMLNodeAttributeWithName(string inAttributeName, XmlNode inXMLNode)
        {
            string result = "";
            int i = 0;
            for (i = 0; i < inXMLNode.Attributes.Count; i++)
            {
                if (inXMLNode.Attributes[i].Name == inAttributeName)
                {
                    result = GetStringFromXMLNodeAttributeAtIndex(i, inXMLNode);
                    break; //stop looking now.
                }
            }
            return result ;
        }



        //Gets the value of an attribute at this index from an XML Node as a real number. 
        public static float GetFloatFromXMLNodeAttributeAtIndex(int inAttributeIndex, XmlNode inXMLNode)
        {
            float result = 0;
            float.TryParse(GetStringFromXMLNodeAttributeAtIndex(inAttributeIndex, inXMLNode), out result);
            return result;
        }

        //Gets the value of an attribute with a certain name from an XML Node as a real number.
        public static float GetFloatFromXMLNodeAttributeWithName(string inAttributeName, XmlNode inXMLNode)
        {
            float result = 0;
            float.TryParse(GetStringFromXMLNodeAttributeWithName(inAttributeName, inXMLNode), out result);
            return result;
        }



        //Gets the value of an attribute at this index from an XML Node as an integer. 
        public static int GetInt32FromXMLNodeAttributeAtIndex(int inAttributeIndex, XmlNode inXMLNode)
        {
            int result = 0;
            if (!(int.TryParse(GetStringFromXMLNodeAttributeAtIndex(inAttributeIndex, inXMLNode), out result)))
            {
                result = (int)GetFloatFromXMLNodeAttributeAtIndex(inAttributeIndex, inXMLNode);
            }
            return result;
        }

        //Gets the value of an attribute with a certain name from an XML Node as an integer.
        public static int GetInt32FromXMLNodeAttributeWithName(string inAttributeName, XmlNode inXMLNode)
        {
            int result = 0;
            if (!(int.TryParse(GetStringFromXMLNodeAttributeWithName(inAttributeName, inXMLNode), out result)))
            {
                result = (int)GetFloatFromXMLNodeAttributeWithName(inAttributeName, inXMLNode);
            }
            return result;
        }



        //Gets the value of an attribute at this index from an XML Node as a boolean. 
        public static bool GetBoolFromXMLNodeAttributeAtIndex(int inAttributeIndex, XmlNode inXMLNode)
        {
            bool result = false;
            if (GetFloatFromXMLNodeAttributeAtIndex(inAttributeIndex, inXMLNode) > 0)
            {
                result = true;
            }
            return result;
        }

        //Gets the value of an attribute with a certain name from an XML Node as a boolean.
        public static bool GetBoolFromXMLNodeAttributeWithName(string inAttributeName, XmlNode inXMLNode)
        {
            bool result = false;
            if (GetFloatFromXMLNodeAttributeWithName(inAttributeName, inXMLNode) > 0)
            {
                result = true;
            }
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////
        // MULTI ATTRIBUTE HELPERS
        ////////////////////////////////////////////////////////////////////////////////

        //Gets the value of 3 attributes representing a 3D Vector, named x, y and z from an XML Node as a Vector3D.
        public static Vector3D GetVector3DFromXMLNode(XmlNode inXMLNode)
        {
            Vector3D result = new Vector3D();
            result.x = GetFloatFromXMLNodeAttributeWithName("x", inXMLNode);
            result.y = GetFloatFromXMLNodeAttributeWithName("y", inXMLNode);
            result.z = GetFloatFromXMLNodeAttributeWithName("z", inXMLNode);
            return result;
        }

        //Get values with this name from the child nodes of this xml node, as 3D vectors. 
        //Used for properties that are in a collection. See GetVector3DFromXMLNodeNamedChild for a single value as a 3D vector.
        public static List<Vector3D> GetVector3DListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<Vector3D> result = new List<Vector3D>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetVector3DFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        public static List<Vector3D> GetVector3DListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<Vector3D> result = new List<Vector3D>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetVector3DFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first value with this name from the child nodes of this xml node, as a 3D vector. 
        //Used for properties that are not in a collection. See GetVector3DListFromXMLNodeNamedChildren for collections of 3D vectors.
        public static Vector3D GetVector3DFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            Vector3D result = new Vector3D();
            List<Vector3D> results = GetVector3DListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static Vector3D GetVector3DFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            Vector3D result = new Vector3D();
            bool exists = false;
            List<Vector3D> results = GetVector3DListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                exists = true;
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Gets the value of 4 attributes representing a Color, named r, g, b and a from an XML Node as a ColorF.
        public static ColorF GetColorFromXMLNode(XmlNode inXMLNode)
        {
            ColorF result = new ColorF();
            result.r = GetFloatFromXMLNodeAttributeWithName("r", inXMLNode);
            result.g = GetFloatFromXMLNodeAttributeWithName("g", inXMLNode);
            result.b = GetFloatFromXMLNodeAttributeWithName("b", inXMLNode);
            result.a = GetFloatFromXMLNodeAttributeWithName("a", inXMLNode);
            return result;
        }

        //Get values with this name from the child nodes of this xml node, as Colors. 
        //Used for properties that are in a collection. See GetColorFromXMLNodeNamedChild for a single value as a Color.
        public static List<ColorF> GetColorListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<ColorF> result = new List<ColorF>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetColorFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first value with this name from the child nodes of this xml node, as a Color. 
        //Used for properties that are not in a collection. See GetColorListFromXMLNodeNamedChildren for collections of 3D vectors.
        public static ColorF GetColorFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            ColorF result = new ColorF();
            bool exists = false;
            List<ColorF> results = GetColorListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        ////////////////////////////////////////////////////////////////////////////////
        // FIRST ATTRIBUTE HELPERS
        ////////////////////////////////////////////////////////////////////////////////

        //Gets the value of a single attribute as a string of plaintext
        //Only returns the first attribute, which is usually the only attribute
        //By convention this attribute is named 'attr1' but this is not necessary to check.
        public static string GetStringFromXMLNode(XmlNode inXMLNode)
        {
            string result = "";
            result = GetStringFromXMLNodeAttributeAtIndex(0, inXMLNode);

            return result;
        }

        //Get values with this name from the child nodes of this xml node, as strings of plaintext. 
        //Used for properties that are in a collection. See GetStringFromXMLNodeNamedChild for a single value as a string of plaintext.
        public static List<string> GetStringListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<string> result = new List<string>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetStringFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        public static List<string> GetStringListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<string> result = new List<string>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetStringFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first value with this name from the child nodes of this xml node, as a string of plaintext. 
        //Used for properties that are not in a collection. See GetStringListFromXMLNodeNamedChildren for collections of strings of plaintext.
        public static string GetStringFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            string result = "";
            List<string> results = GetStringListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static string GetStringFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            string result = "";
            bool exists = false;
            List<string> results = GetStringListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Gets the value of a single attribute as a real number
        //Only returns the first attribute, which is usually the only attribute
        //By convention this attribute is named 'attr1' but this is not necessary to check.
        public static float GetFloatFromXMLNode(XmlNode inXMLNode)
        {
            float result = GetFloatFromXMLNodeAttributeAtIndex(0, inXMLNode);
            return result;
        }

        //Get values with this name from the child nodes of this xml node, as real numbers. 
        //Used for properties that are in a collection. See GetFloatFromXMLNodeNamedChild for a single value as a real number.
        public static List<float> GetFloatListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<float> result = new List<float>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetFloatFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        public static List<float> GetFloatListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<float> result = new List<float>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetFloatFromXMLNode(CurrentChildNode));
                    exists = true;
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first value with this name from the child nodes of this xml node, as a real number. 
        //Used for properties that are not in a collection. See GetFloatListFromXMLNodeNamedChildren for collections of real numbers.
        public static float GetFloatFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            float result = 0;
            List<float> results = GetFloatListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static float GetFloatFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            float result = 0;
            bool exists = false;
            List<float> results = GetFloatListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Gets the value of a single attribute as a boolean
        //Only returns the first attribute, which is usually the only attribute
        //By convention this attribute is named 'attr1' but this is not necessary to check.
        public static bool GetBoolFromXMLNode(XmlNode inXMLNode)
        {
            bool result = GetBoolFromXMLNodeAttributeAtIndex(0, inXMLNode);

            return result;
        }

        //Get values with this name from the child nodes of this xml node, as booleans. 
        //Used for properties that are in a collection. See GetBoolFromXMLNodeNamedChild for a single value as a boolean.
        public static List<bool> GetBoolListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<bool> result = new List<bool>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetBoolFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        public static List<bool> GetBoolListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<bool> result = new List<bool>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true; 
                    result.Add(GetBoolFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first value with this name from the child nodes of this xml node, as a boolean. 
        //Used for properties that are not in a collection. See GetBoolListFromXMLNodeNamedChildren for collections of booleans.
        public static bool GetBoolFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            bool result = false;
            List<bool> results = GetBoolListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static bool GetBoolFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            bool result = false;
            bool exists = false;
            List<bool> results = GetBoolListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Gets the value of a single attribute as an integer
        //Only returns the first attribute, which is usually the only attribute
        //By convention this attribute is named 'attr1' but this is not necessary to check.
        public static int GetInt32FromXMLNode(XmlNode inXMLNode)
        {
            int result = GetInt32FromXMLNodeAttributeAtIndex(0, inXMLNode);
            return result;
        }

        //Get values with this name from the child nodes of this xml node, as integers. 
        //Used for properties that are in a collection. See GetInt32FromXMLNodeNamedChild for a single value as an integer.
        public static List<int> GetInt32ListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<int> result = new List<int>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetInt32FromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        public static List<int> GetInt32ListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<int> result = new List<int>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetInt32FromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first value with this name from the child nodes of this xml node, as an integer. 
        //Used for properties that are not in a collection. See GetBoolListFromXMLNodeNamedChildren for collections of integers.
        public static int GetInt32FromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            int result = 0;
            List<int> results = GetInt32ListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static int GetInt32FromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            int result = 0;
            bool exists = false;
            List<int> results = GetInt32ListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////
        // DATA FILE HELPERS
        ////////////////////////////////////////////////////////////////////////////////

        //Get the values of all nodes in this document with a certain name as strings of plaintext
        //Used for properties that are in a collection. See GetStringFromVD2Data for a single value as a string of plaintext
        public static List<string> GetStringListFromVD2Data(XmlDocument inXML, string inTagName)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<string> results = new List<string>();
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                results.Add(GetStringFromXMLNode(xmlnodes[i]));
            }

            return results;
        }

        public static List<string> GetStringListFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<string> results = new List<string>();
            bool exists = false;
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                exists = true;
                results.Add(GetStringFromXMLNode(xmlnodes[i]));
            }

            outExists = exists;
            return results;
        }

        //Get the first value of a node in this document with a certain name as a string of plaintext
        //Used for properties that are not in a collection. See GetStringListFromVD2Data for a collection of values as strings of plaintext
        public static string GetStringFromVD2Data(XmlDocument inXML, string inTagName)
        {
            string result = "";
            List<string> results = GetStringListFromVD2Data(inXML, inTagName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static string GetStringFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            string result = "";
            bool exists = false;
            List<string> results = GetStringListFromVD2Data(inXML, inTagName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Get the values of all nodes in this document with a certain name as real numbers
        //Used for properties that are in a collection. See GetFloatFromVD2Data for a single value as a real number
        public static List<float> GetFloatListFromVD2Data(XmlDocument inXML, string inTagName)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<float> result = new List<float>();
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                XmlNode CurrentNode = xmlnodes[i];
                if (CurrentNode.Name == inTagName)
                {
                    result.Add(GetFloatFromXMLNode(CurrentNode));
                }
            }

            return result;
        }

        public static List<float> GetFloatListFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<float> result = new List<float>();
            bool exists = false;
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                XmlNode CurrentNode = xmlnodes[i];
                if (CurrentNode.Name == inTagName)
                {
                    exists = true;
                    result.Add(GetFloatFromXMLNode(CurrentNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first value of a node in this document with a certain name as a real number
        //Used for properties that are not in a collection. See GetFloatListFromVD2Data for a collection of values as real numbers
        public static float GetFloatFromVD2Data(XmlDocument inXML, string inTagName)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            float result = 0;
            List<float> results = GetFloatListFromVD2Data(inXML, inTagName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static float GetFloatFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            float result = 0;
            bool exists = false;
            List<float> results = GetFloatListFromVD2Data(inXML, inTagName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Get the values of all nodes in this document with a certain name as integers
        //Used for properties that are in a collection. See GetInt32FromVD2Data for a single value as an integer
        public static List<int> GetInt32ListFromVD2Data(XmlDocument inXML, string inTagName)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<int> results = new List<int>();
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                results.Add(GetInt32FromXMLNode(xmlnodes[i]));
            }

            return results;
        }

        public static List<int> GetInt32ListFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<int> results = new List<int>();
            bool exists = false;
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                exists = true;
                results.Add(GetInt32FromXMLNode(xmlnodes[i]));
            }

            outExists = exists;
            return results;
        }

        //Get the first value of a node in this document with a certain name as an integer
        //Used for properties that are not in a collection. See GetInt32ListFromVD2Data for a collection of values as integers
        public static int GetInt32FromVD2Data(XmlDocument inXML, string inTagName)
        {
            int result = 0;
            List<int> results = GetInt32ListFromVD2Data(inXML, inTagName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static int GetInt32FromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            int result = 0;
            bool exists = false;
            List<int> results = GetInt32ListFromVD2Data(inXML, inTagName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Get the values of all nodes in this document with a certain name as integers
        //Used for properties that are in a collection. See GetInt32FromVD2Data for a single value as an integer
        public static List<bool> GetBoolListFromVD2Data(XmlDocument inXML, string inTagName)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<bool> results = new List<bool>();
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                results.Add(GetBoolFromXMLNode(xmlnodes[i]));
            }

            return results;
        }

        public static List<bool> GetBoolListFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<bool> results = new List<bool>();
            bool exists = false;
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                exists = true;
                results.Add(GetBoolFromXMLNode(xmlnodes[i]));
            }

            outExists = exists;
            return results;
        }

        //Get the first value of a node in this document with a certain name as an integer
        //Used for properties that are not in a collection. See GetInt32ListFromVD2Data for a collection of values as integers
        public static bool GetBoolFromVD2Data(XmlDocument inXML, string inTagName)
        {
            bool result = false;
            List<bool> results = GetBoolListFromVD2Data(inXML, inTagName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static bool GetBoolFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            bool result = false;
            bool exists = false;
            List<bool> results = GetBoolListFromVD2Data(inXML, inTagName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        //Get the values of all nodes in this document with a certain name as integers
        //Used for properties that are in a collection. See GetInt32FromVD2Data for a single value as an integer
        public static List<Vector3D> GetVector3DListFromVD2Data(XmlDocument inXML, string inTagName)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<Vector3D> results = new List<Vector3D>();
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                results.Add(GetVector3DFromXMLNode(xmlnodes[i]));
            }

            return results;
        }

        public static List<Vector3D> GetVector3DListFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<Vector3D> results = new List<Vector3D>();
            bool exists = false;
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                exists = true;
                results.Add(GetVector3DFromXMLNode(xmlnodes[i]));
            }

            outExists = exists;
            return results;
        }

        //Get the first value of a node in this document with a certain name as an integer
        //Used for properties that are not in a collection. See GetInt32ListFromVD2Data for a collection of values as integers
        public static Vector3D GetVector3DFromVD2Data(XmlDocument inXML, string inTagName)
        {
            Vector3D result = new Vector3D();
            List<Vector3D> results = GetVector3DListFromVD2Data(inXML, inTagName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        public static Vector3D GetVector3DFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            Vector3D result = new Vector3D();
            bool exists = false;
            List<Vector3D> results = GetVector3DListFromVD2Data(inXML, inTagName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }



        public static List<ColorF> GetColorListFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName(inTagName);
            List<ColorF> results = new List<ColorF>();
            bool exists = false;
            int i = 0;
            for (i = 0; i < xmlnodes.Count; i++)
            {
                exists = true;
                results.Add(GetColorFromXMLNode(xmlnodes[i]));
            }

            outExists = exists;
            return results;
        }

        public static ColorF GetColorFromVD2Data(XmlDocument inXML, string inTagName, out bool outExists)
        {
            ColorF result = new ColorF();
            bool exists = false;
            List<ColorF> results = GetColorListFromVD2Data(inXML, inTagName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////
        // DISCOVERY HELPERS
        ////////////////////////////////////////////////////////////////////////////////

        public static TagNameReportEntry UpdateTagNameReportEntry(TagNameReportEntry inEntry, XmlNode inNode, Dictionary<string, int> inWithinUsage, out Dictionary<string, int> outWithinUsage)
        {
            inEntry.UseNum = inEntry.UseNum + 1;
            float floatparseresult;
            int intparseresult;
            if (inNode.Attributes.Count == 1)
            {
                if ((inEntry.NodeType != TagNameReportNodeTypes.plaintext) && (float.TryParse(inNode.Attributes[0].InnerText, out floatparseresult)))
                {
                    if ((inEntry.NodeType != TagNameReportNodeTypes.realnumber) && (int.TryParse(inNode.Attributes[0].InnerText, out intparseresult)))
                    {
                        inEntry.NodeType = TagNameReportNodeTypes.integer;
                    }
                    else
                    {
                        inEntry.NodeType = TagNameReportNodeTypes.realnumber;
                    }
                }
                else
                {
                    inEntry.NodeType = TagNameReportNodeTypes.plaintext;
                }
            }
            else if (inNode.Attributes.Count == 3)
            {
                inEntry.NodeType = TagNameReportNodeTypes.vector;
            }
            else if (inNode.Attributes.Count == 4)
            {
                inEntry.NodeType = TagNameReportNodeTypes.color;
            }
            else if (inNode.Attributes.Count == 0)
            {
                inEntry.NodeType = TagNameReportNodeTypes.datastructure;
                if (inNode.ChildNodes.Count > 0)
                {
                    inEntry.UsageWithinThisDataStructure.Clear();
                    for (int i = 0; i < inNode.ChildNodes.Count; i++)
                    {
                        if ((inNode.ChildNodes[i].Name != "note_to_self") && !(inNode.ChildNodes[i].Name.StartsWith("_")))
                        {
                            TagNameReportEntry currentchildentry = new TagNameReportEntry();
                            if (inEntry.DataStructureProperties.ContainsKey(inNode.ChildNodes[i].Name))
                            {
                                inEntry.DataStructureProperties.TryGetValue(inNode.ChildNodes[i].Name, out currentchildentry);
                            }
                            currentchildentry = ParseHelpers.UpdateTagNameReportEntry(currentchildentry, inNode.ChildNodes[i], inEntry.UsageWithinThisDataStructure, out inEntry.UsageWithinThisDataStructure);
                            inEntry.DataStructureProperties.Remove(inNode.ChildNodes[i].Name);
                            inEntry.DataStructureProperties.Add(inNode.ChildNodes[i].Name, currentchildentry);
                        }
                    }

                }
            }
            List<string> listtagnameblacklist = new List<string>();
            listtagnameblacklist.Add("missionRankRequired");//there is a single erroneous double use of this in tug.xml because Paul hates me.
            listtagnameblacklist.Add("shipClassSize");//one ship file has this twice and it is a mistake to make it a list
            listtagnameblacklist.Add("cockpitActualPos");//one ship file has this twice and it is a mistake to make it a list
            listtagnameblacklist.Add("yaw");//one ship file has this twice in a turret def and it is a mistake to make it a list
            listtagnameblacklist.Add("backgroundColor");//most of the faction files have this duplicated twice, the same values, clearly copy paste error.
            listtagnameblacklist.Add("cloudsColor");//most of the faction files have this duplicated twice, the same values, clearly copy paste error.
            bool OnTagNameBlacklistForLists = false;
            for (int blacklistidx = 0; blacklistidx < listtagnameblacklist.Count; blacklistidx++)
            {
                if (listtagnameblacklist[blacklistidx] == inNode.Name)
                {
                    OnTagNameBlacklistForLists = true;
                }
            }
            if ((inWithinUsage.ContainsKey(inNode.Name)) && (!OnTagNameBlacklistForLists))
            {
                int useageinthisfile;
                inWithinUsage.TryGetValue(inNode.Name, out useageinthisfile);
                useageinthisfile = useageinthisfile + 1;
                if (useageinthisfile > 1)
                {
                    inEntry.IsList = true;
                }
            }
            else
            {
                if (!OnTagNameBlacklistForLists)
                {
                    inWithinUsage.Add(inNode.Name, 1);
                }
            }
            outWithinUsage = inWithinUsage;
            return inEntry;
        }

        public static void GetTagNameListWithUseNumberReportFromXMLFiles(string inPath, string inReportName, out Dictionary<string, TagNameReportEntry> outRootTagResults, out Dictionary<string, Dictionary<string, TagNameReportEntry>> outChildTagResults)
        {
            Dictionary<string, TagNameReportEntry> roottagresults = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> childtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            List<string> reporttextlines = new List<string>();
            int i = 0;
            if (Directory.Exists(inPath))
            {
                List<string> files = Directory.EnumerateFiles(inPath).ToList();

                for (i = 0; i < files.Count; i++)
                {
                    Dictionary<string, int> UsageWithinThisFile = new Dictionary<string, int>();
                    List<string> xmltextlines = File.ReadAllLines(files[i]).ToList();
                    xmltextlines.Insert(1, "<docroot>");
                    xmltextlines.Add("</docroot>");
                    File.WriteAllLines("TempLoadStage.xml", xmltextlines);
                    XmlDocument XMLfile = new XmlDocument();
                    XMLfile.Load("TempLoadStage.xml");
                    XmlNodeList nodelist = XMLfile.DocumentElement.ChildNodes;
                    int nodeindex = 0;
                    for (nodeindex = 0; nodeindex < nodelist.Count; nodeindex++)
                    {
                        if (roottagresults.ContainsKey(nodelist[nodeindex].Name))
                        {
                            TagNameReportEntry currententry = new TagNameReportEntry();
                            roottagresults.TryGetValue(nodelist[nodeindex].Name, out currententry);
                            currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);

                            roottagresults.Remove(nodelist[nodeindex].Name);
                            roottagresults.Add(nodelist[nodeindex].Name, currententry);
                        }
                        else
                        {
                            TagNameReportEntry currententry = new TagNameReportEntry();

                            currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);

                            roottagresults.Add(nodelist[nodeindex].Name, currententry);
                        }

                        if (nodelist[nodeindex].ChildNodes.Count > 0)
                        {
                            int childindex = 0;
                            if (nodelist[nodeindex].Name == "debrisInfo")
                            {
                                int debrisindex = 0;
                                for (debrisindex = 0; debrisindex < nodelist[nodeindex].ChildNodes.Count; debrisindex++)
                                {
                                    for (childindex = 0; childindex < nodelist[nodeindex].ChildNodes[debrisindex].ChildNodes.Count; childindex++)
                                    {
                                        if (childtagresults.ContainsKey(nodelist[nodeindex].Name))
                                        {
                                            Dictionary<string, TagNameReportEntry> childdictionary = new Dictionary<string, TagNameReportEntry>();
                                            childtagresults.TryGetValue(nodelist[nodeindex].Name, out childdictionary);
                                            if (childdictionary.ContainsKey(nodelist[nodeindex].ChildNodes[debrisindex].ChildNodes[childindex].Name))
                                            {
                                                TagNameReportEntry currententry = new TagNameReportEntry();
                                                childdictionary.TryGetValue(nodelist[nodeindex].ChildNodes[debrisindex].ChildNodes[childindex].Name, out currententry);
                                                currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);
                                                childdictionary.Remove(nodelist[nodeindex].ChildNodes[debrisindex].ChildNodes[childindex].Name);
                                                childdictionary.Add(nodelist[nodeindex].ChildNodes[debrisindex].ChildNodes[childindex].Name, currententry);
                                            }
                                            else
                                            {
                                                TagNameReportEntry currententry = new TagNameReportEntry();
                                                currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);
                                                childdictionary.Add(nodelist[nodeindex].ChildNodes[debrisindex].ChildNodes[childindex].Name, currententry);
                                            }
                                            childtagresults.Remove(nodelist[nodeindex].Name);
                                            childtagresults.Add(nodelist[nodeindex].Name, childdictionary);
                                        }
                                        else
                                        {
                                            TagNameReportEntry currententry = new TagNameReportEntry();
                                            currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);
                                            Dictionary<string, TagNameReportEntry> childdictionary = new Dictionary<string, TagNameReportEntry>();
                                            childdictionary.Add(nodelist[nodeindex].ChildNodes[debrisindex].ChildNodes[childindex].Name, currententry);
                                            childtagresults.Add(nodelist[nodeindex].Name, childdictionary);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (childindex = 0; childindex < nodelist[nodeindex].ChildNodes.Count; childindex++)
                                {
                                    if (childtagresults.ContainsKey(nodelist[nodeindex].Name))
                                    {
                                        Dictionary<string, TagNameReportEntry> childdictionary = new Dictionary<string, TagNameReportEntry>();
                                        childtagresults.TryGetValue(nodelist[nodeindex].Name, out childdictionary);
                                        if (childdictionary.ContainsKey(nodelist[nodeindex].ChildNodes[childindex].Name))
                                        {
                                            TagNameReportEntry currententry = new TagNameReportEntry();
                                            childdictionary.TryGetValue(nodelist[nodeindex].ChildNodes[childindex].Name, out currententry);
                                            currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);
                                            childdictionary.Remove(nodelist[nodeindex].ChildNodes[childindex].Name);
                                            childdictionary.Add(nodelist[nodeindex].ChildNodes[childindex].Name, currententry);
                                        }
                                        else
                                        {
                                            TagNameReportEntry currententry = new TagNameReportEntry();
                                            currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);
                                            childdictionary.Add(nodelist[nodeindex].ChildNodes[childindex].Name, currententry);
                                        }
                                        childtagresults.Remove(nodelist[nodeindex].Name);
                                        childtagresults.Add(nodelist[nodeindex].Name, childdictionary);
                                    }
                                    else
                                    {
                                        TagNameReportEntry currententry = new TagNameReportEntry();
                                        currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);
                                        Dictionary<string, TagNameReportEntry> childdictionary = new Dictionary<string, TagNameReportEntry>();
                                        childdictionary.Add(nodelist[nodeindex].ChildNodes[childindex].Name, currententry);
                                        childtagresults.Add(nodelist[nodeindex].Name, childdictionary);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            outRootTagResults = roottagresults;
            outChildTagResults = childtagresults;
            reporttextlines.Add("Report on tag names and usage for path: " + inPath);

            for (i = 0; i < roottagresults.Count; i++)
            {
                KeyValuePair<string, TagNameReportEntry> currentresult = roottagresults.ElementAt(i);
                reporttextlines.Add(currentresult.Key + " Usage: " + currentresult.Value.ToString());
            }

            reporttextlines.Add("");
            reporttextlines.Add("Nodes with child nodes follow:");

            for (i = 0; i < childtagresults.Count; i++)
            {
                reporttextlines.Add("");
                KeyValuePair<string, Dictionary<string, TagNameReportEntry>> currentresult = childtagresults.ElementAt(i);
                reporttextlines.Add(currentresult.Key + " has child nodes! Count: " + currentresult.Value.Count.ToString());
                if (currentresult.Key == "debrisInfo")
                {
                    reporttextlines.Add("debrisInfo is a special data structure tag, it contains data structures called debris.");
                    reporttextlines.Add("Below is actually the child tags of debris, debrisInfo tags only contain one or more debris tags");
                }
                reporttextlines.Add("Child node names:");
                int childindex = 0;
                for (childindex = 0; childindex < currentresult.Value.Count; childindex++)
                {
                    KeyValuePair<string, TagNameReportEntry> currentchildresult = currentresult.Value.ElementAt(childindex);
                    reporttextlines.Add(currentchildresult.Key + " Usage: " + currentchildresult.Value.ToString());
                }
            }
            reporttextlines.Add("Report ends.");
            File.WriteAllLines(inReportName, reporttextlines);
        }





        public static void CombinedTagReport(List<Dictionary<string, TagNameReportEntry>> rootreports, List<Dictionary<string, Dictionary<string, TagNameReportEntry>>> childreports, string inReportName)
        {
            List<string> reporttextlines = new List<string>();
            Dictionary<string, TagNameReportEntry> rootreport = new Dictionary<string, TagNameReportEntry>();
            Dictionary<string, Dictionary<string, TagNameReportEntry>> childreport = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            int reportindex = 0;
            for (reportindex = 0; reportindex < rootreports.Count; reportindex++)
            {
                int tagindex = 0;
                for (tagindex = 0; tagindex < rootreports[reportindex].Count; tagindex++)
                {
                    if (rootreport.ContainsKey(rootreports[reportindex].ElementAt(tagindex).Key))
                    {
                        TagNameReportEntry currentreport = new TagNameReportEntry();
                        rootreport.TryGetValue(rootreports[reportindex].ElementAt(tagindex).Key, out currentreport);
                        currentreport.UseNum += rootreports[reportindex].ElementAt(tagindex).Value.UseNum;
                        if ((rootreports[reportindex].ElementAt(tagindex).Value.NodeType < currentreport.NodeType) && ((currentreport.NodeType < TagNameReportNodeTypes.vector) && (rootreports[reportindex].ElementAt(tagindex).Value.NodeType < TagNameReportNodeTypes.vector)))
                        {
                            currentreport.NodeType = rootreports[reportindex].ElementAt(tagindex).Value.NodeType;
                        }
                        rootreport.Remove(rootreports[reportindex].ElementAt(tagindex).Key);
                        rootreport.Add(rootreports[reportindex].ElementAt(tagindex).Key, currentreport);
                    }
                    else
                    {
                        TagNameReportEntry currentreport = new TagNameReportEntry();
                        currentreport.UseNum = rootreports[reportindex].ElementAt(tagindex).Value.UseNum;
                        currentreport.NodeType = rootreports[reportindex].ElementAt(tagindex).Value.NodeType;
                        rootreport.Add(rootreports[reportindex].ElementAt(tagindex).Key, currentreport);
                    }
                }
            }

            for (reportindex = 0; reportindex < childreports.Count; reportindex++)
            {
                int tagindex = 0;
                for (tagindex = 0; tagindex < childreports[reportindex].Count; tagindex++)
                {
                    if (childreport.ContainsKey(childreports[reportindex].ElementAt(tagindex).Key))
                    {
                        //replace
                        Dictionary<string, TagNameReportEntry> currentchild = childreports[reportindex].ElementAt(tagindex).Value;
                        Dictionary<string, TagNameReportEntry> currentchildtotal = new Dictionary<string, TagNameReportEntry>();
                        childreport.TryGetValue(childreports[reportindex].ElementAt(tagindex).Key, out currentchildtotal);
                        int childindex = 0;
                        for (childindex = 0; childindex < currentchild.Count; childindex++)
                        {
                            if (currentchildtotal.ContainsKey(currentchild.ElementAt(childindex).Key))
                            {
                                //replace in subdictionary
                                TagNameReportEntry currentreport = new TagNameReportEntry();
                                currentchildtotal.TryGetValue(currentchild.ElementAt(childindex).Key, out currentreport);

                                currentreport.UseNum += currentchild.ElementAt(childindex).Value.UseNum;
                                if ((currentchild.ElementAt(childindex).Value.NodeType < currentreport.NodeType) && ((currentreport.NodeType < TagNameReportNodeTypes.vector) && (currentchild.ElementAt(childindex).Value.NodeType < TagNameReportNodeTypes.vector)))
                                {
                                    currentreport.NodeType = currentchild.ElementAt(childindex).Value.NodeType;
                                }
                                currentchildtotal.Remove(currentchild.ElementAt(childindex).Key);
                                currentchildtotal.Add(currentchild.ElementAt(childindex).Key, currentreport);
                                childreport.Remove(childreports[reportindex].ElementAt(tagindex).Key);
                                childreport.Add(childreports[reportindex].ElementAt(tagindex).Key, currentchildtotal);

                            }
                            else
                            {
                                //add to subdictionary
                                currentchildtotal.Add(currentchild.ElementAt(childindex).Key, currentchild.ElementAt(childindex).Value);
                                childreport.Remove(childreports[reportindex].ElementAt(tagindex).Key);
                                childreport.Add(childreports[reportindex].ElementAt(tagindex).Key, currentchildtotal);
                            }

                        }
                    }
                    else
                    {
                        //add
                        childreport.Add(childreports[reportindex].ElementAt(tagindex).Key, childreports[reportindex].ElementAt(tagindex).Value);
                    }
                }
            }

            reporttextlines.Add("Combined total report. Name: " + inReportName);
            reporttextlines.Add("");
            reporttextlines.Add("Root tags:");
            reporttextlines.Add("");

            for (reportindex = 0; reportindex < rootreport.Count; reportindex++)
            {
                reporttextlines.Add(rootreport.ElementAt(reportindex).Key + " Usage: " + rootreport.ElementAt(reportindex).Value.ToString());
            }

            reporttextlines.Add("");
            reporttextlines.Add("Nodes with child nodes follow:");

            for (reportindex = 0; reportindex < childreport.Count; reportindex++)
            {
                reporttextlines.Add("");
                KeyValuePair<string, Dictionary<string, TagNameReportEntry>> currentresult = childreport.ElementAt(reportindex);
                reporttextlines.Add(currentresult.Key + " has child nodes! Count: " + currentresult.Value.Count.ToString());
                if (currentresult.Key == "debrisInfo")
                {
                    reporttextlines.Add("debrisInfo is a special data structure tag, it contains data structures called debris.");
                    reporttextlines.Add("Below is actually the child tags of debris, debrisInfo tags only contain one or more debris tags");
                }
                reporttextlines.Add("Child node names:");
                int childindex = 0;
                for (childindex = 0; childindex < currentresult.Value.Count; childindex++)
                {
                    KeyValuePair<string, TagNameReportEntry> currentchildresult = currentresult.Value.ElementAt(childindex);
                    reporttextlines.Add(currentchildresult.Key + " Usage: " + currentchildresult.Value.ToString());
                }
            }

            reporttextlines.Add("Report ends.");
            File.WriteAllLines(inReportName, reporttextlines);
        }        
    }
}
 