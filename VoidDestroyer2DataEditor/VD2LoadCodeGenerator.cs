using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace VoidDestroyer2DataEditor
{
    static class VD2LoadCodeGenerator
    {

        public static List<string> AddDataStructureClassLines(List<string> inTextLines, KeyValuePair<string, TagNameReportEntry> inDataStructure)
        {
            bool skipnewline = false;
            List<KeyValuePair<string, TagNameReportEntry>> datastructurestrings = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructureints = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurefloats = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurebools = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurevectors = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructuredatastructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructureliststrings = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistints = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistfloats = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistbools = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistvectors = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistdatastructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            inTextLines.Add("    [TypeConverter(typeof(" + inDataStructure.Key + "DataStructureConverter))]");
            inTextLines.Add("    class " + inDataStructure.Key + "DataStructure");
            inTextLines.Add("    {");
            int propidx = 0;
                
            for (propidx = 0; propidx < inDataStructure.Value.DataStructureProperties.Keys.Count; propidx++)
            {
                TagNameReportEntry currentdatastructureproperty = new TagNameReportEntry();
                inDataStructure.Value.DataStructureProperties.TryGetValue(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), out currentdatastructureproperty);

                //KeyValuePair<string, TagNameReportEntry> currentresult = datastructures.ElementAt(i);

                switch (currentdatastructureproperty.NodeType)
                {
                    case TagNameReportNodeTypes.plaintext:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructureliststrings.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructurestrings.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    case TagNameReportNodeTypes.integer:
                        if (inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx).StartsWith("b"))
                        {
                            if (currentdatastructureproperty.IsList)
                            {
                                datastructurelistbools.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                            else
                            {
                                datastructurebools.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                        }
                        else
                        {
                            if (currentdatastructureproperty.IsList)
                            {
                                datastructurelistints.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                            else
                            {
                                datastructureints.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                        }
                        break;
                    case TagNameReportNodeTypes.realnumber:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructurelistfloats.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructurefloats.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    case TagNameReportNodeTypes.vector:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructurelistvectors.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructurevectors.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    case TagNameReportNodeTypes.datastructure:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructurelistdatastructures.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructuredatastructures.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    default:
                        break;
                }
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines.Add("        string _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines.Add("        List<string> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines.Add("        int _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines.Add("        List<int> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines.Add("        float _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines.Add("        List<float> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines.Add("        bool _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines.Add("        List<bool> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines.Add("        Vector3D _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines.Add("        List<Vector3D> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines.Add("        " + currentresult.Key + "DataStructure _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines.Add("        List<" + currentresult.Key + "DataStructure> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            
            skipnewline = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a plaintext string\"), Category(\"Plaintext Strings\")]");
                inTextLines.Add("        public string " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a collection of plaintext strings\"), Category(\"Plaintext String Collections\")]");
                inTextLines.Add("        public List<string> " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is an integer\"), Category(\"Integers\")]");
                inTextLines.Add("        public int " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a collection of integers\"), Category(\"Integer Collections\")]");
                inTextLines.Add("        public List<int> " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a real number\"), Category(\"Real Numbers\")]");
                inTextLines.Add("        public float " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a collection of real numbers\"), Category(\"Real Number Collections\")]");
                inTextLines.Add("        public List<float> " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a boolean value\"), Category(\"Booleans\")]");
                inTextLines.Add("        public bool " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a collection of boolean values\"), Category(\"Boolean Collections\")]");
                inTextLines.Add("        public List<bool> " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a 3D vector\"), Category(\"3D Vectors\")]");
                inTextLines.Add("        public Vector3D " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a collection of 3D vectors\"), Category(\"3D Vector Collections\")]");
                inTextLines.Add("        public List<Vector3D> " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a datastructure\"), Category(\"Data Structures\")]");
                inTextLines.Add("        public " + currentresult.Key + "DataStructure " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines.Add("        [Description(\"" + currentresult.Key + " is a collection of datastructures\"), Category(\"Data Structure Collection\")]");
                inTextLines.Add("        public List<" + currentresult.Key + "DataStructure> " + currentresult.Key);
                inTextLines.Add("        {");
                inTextLines.Add("            get => _" + currentresult.Key + ";");
                inTextLines.Add("            set => _" + currentresult.Key + " = value;");
                inTextLines.Add("        }");
                inTextLines.Add("");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }

            inTextLines.Add("");
            inTextLines.Add("        public " + inDataStructure.Key + "DataStructure()");
            inTextLines.Add("        {");
            skipnewline = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = \"\";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new List<string>();");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = 0;");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new List<int>();");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = 0;");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new List<float>();");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = false;");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new List<bool>();");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new Vector3D();");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new List<Vector3D>();");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new " + currentresult.Key + "DataStructure();");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }

            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {
               
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = new List<" + currentresult.Key + "DataStructure>();");
            }

            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        public " + inDataStructure.Key + "DataStructure(");
            bool isfirstarg = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "string in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "List<string> in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "int in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "List<int> in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "float in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "List<float> in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "bool in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "List<bool> in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "Vector3D in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "List<Vector3D> in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key + "DataStructure in" + currentresult.Key;
            }

            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += "List<" + currentresult.Key + "DataStructure> in" + currentresult.Key;
            }
            inTextLines[inTextLines.Count - 1] += ")";
            inTextLines.Add("        {");

            skipnewline = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }

            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {

                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = in" + currentresult.Key + ";");
            }

            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        public " + inDataStructure.Key + "DataStructure(" + inDataStructure.Key + "DataStructure inCopyFrom)");
            inTextLines.Add("        {");

            skipnewline = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }

            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {

                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines.Add("            _" + currentresult.Key + " = inCopyFrom." + currentresult.Key + ";");
            }

            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        public override string ToString()");
            inTextLines.Add("        {");
            inTextLines.Add("            int i = 0;");
            inTextLines.Add("            string result = \"\";");
            isfirstarg = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines.Add("            result += _" + currentresult.Key + ";");
            }
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines.Add("            for (i = 0; i < _" + currentresult.Key + ".Count; i++)");
                inTextLines.Add("            {");
                inTextLines.Add("                result += _" + currentresult.Key + "[i];");
                inTextLines.Add("                if (_" + currentresult.Key + ".Count - i != 1)");
                inTextLines.Add("                {");
                inTextLines.Add("                    result += \", \";");
                inTextLines.Add("                }");
                inTextLines.Add("            }");
                
                //inTextLines[inTextLines.Count - 1] += "List<string> in" + currentresult.Key;
            }
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines.Add("            result += _" + currentresult.Key + ".ToString();");
            }
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines.Add("            for (i = 0; i < _" + currentresult.Key + ".Count; i++)");
                inTextLines.Add("            {");
                inTextLines.Add("                result += _" + currentresult.Key + "[i].ToString();");
                inTextLines.Add("                if (_" + currentresult.Key + ".Count - i != 1)");
                inTextLines.Add("                {");
                inTextLines.Add("                    result += \", \";");
                inTextLines.Add("                }");
                inTextLines.Add("            }");
            }
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines.Add("            result += _" + currentresult.Key + ".ToString();");
            }
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines.Add("            for (i = 0; i < _" + currentresult.Key + ".Count; i++)");
                inTextLines.Add("            {");
                inTextLines.Add("                result += _" + currentresult.Key + "[i].ToString();");
                inTextLines.Add("                if (_" + currentresult.Key + ".Count - i != 1)");
                inTextLines.Add("                {");
                inTextLines.Add("                    result += \", \";");
                inTextLines.Add("                }");
                inTextLines.Add("            }");
            }
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines.Add("            result += _" + currentresult.Key + ".ToString();");
            }
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines.Add("            for (i = 0; i < _" + currentresult.Key + ".Count; i++)");
                inTextLines.Add("            {");
                inTextLines.Add("                result += _" + currentresult.Key + "[i].ToString();");
                inTextLines.Add("                if (_" + currentresult.Key + ".Count - i != 1)");
                inTextLines.Add("                {");
                inTextLines.Add("                    result += \", \";");
                inTextLines.Add("                }");
                inTextLines.Add("            }");
            }
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines.Add("            result += _" + currentresult.Key + ".ToString();");
            }
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines.Add("            for (i = 0; i < _" + currentresult.Key + ".Count; i++)");
                inTextLines.Add("            {");
                inTextLines.Add("                result += _" + currentresult.Key + "[i].ToString();");
                inTextLines.Add("                if (_" + currentresult.Key + ".Count - i != 1)");
                inTextLines.Add("                {");
                inTextLines.Add("                    result += \", \";");
                inTextLines.Add("                }");
                inTextLines.Add("            }");
            }
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines.Add("            result += _" + currentresult.Key + ".ToString();");
            }

            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines.Add("            result += \", \";");
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines.Add("            for (i = 0; i < _" + currentresult.Key + ".Count; i++)");
                inTextLines.Add("            {");
                inTextLines.Add("                result += _" + currentresult.Key + "[i].ToString();");
                inTextLines.Add("                if (_" + currentresult.Key + ".Count - i != 1)");
                inTextLines.Add("                {");
                inTextLines.Add("                    result += \", \";");
                inTextLines.Add("                }");
                inTextLines.Add("            }");
            }
            //inTextLines[inTextLines.Count - 1] += ")";
            inTextLines.Add("            return result;");
            inTextLines.Add("        }");
            inTextLines.Add("    }");
            inTextLines.Add("");
            inTextLines.Add("    public class " + inDataStructure.Key + "DataStructureConverter : TypeConverter");
            inTextLines.Add("    {");
            inTextLines.Add("        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)");
            inTextLines.Add("        {");
            inTextLines.Add("            if (destinationType == typeof(string))");
            inTextLines.Add("            {");
            inTextLines.Add("                return true;");
            inTextLines.Add("            }");
            inTextLines.Add("            return base.CanConvertTo(context, destinationType);");
            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)");
            inTextLines.Add("        {");
            inTextLines.Add("            if (destinationType == typeof(string))");
            inTextLines.Add("            {");
            inTextLines.Add("                return value.ToString();");
            inTextLines.Add("            }");
            inTextLines.Add("            return base.ConvertTo(context, culture, value, destinationType);");
            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        public override bool GetPropertiesSupported(ITypeDescriptorContext context)");
            inTextLines.Add("        {");
            inTextLines.Add("            return true;");
            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)");
            inTextLines.Add("        {");
            inTextLines.Add("            return TypeDescriptor.GetProperties(value);");
            inTextLines.Add("        }");
            inTextLines.Add("    }");
            inTextLines.Add("");

            for (int childidx = 0; childidx < datastructuredatastructures.Count; childidx++)
            {
                inTextLines = AddDataStructureClassLines(inTextLines, datastructuredatastructures[childidx]);
            }
            for (int childidx = 0; childidx < datastructurelistdatastructures.Count; childidx++)
            {
                inTextLines = AddDataStructureClassLines(inTextLines, datastructurelistdatastructures[childidx]);
            }
            return inTextLines;
        }

        public static List<string> AddDataStructureParseHelpersLines(List<string> inTextLines, KeyValuePair<string, TagNameReportEntry> inDataStructure)
        {
            bool skipnewline = false;
            List<KeyValuePair<string, TagNameReportEntry>> datastructurestrings = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructureints = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurefloats = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurebools = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurevectors = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructuredatastructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructureliststrings = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistints = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistfloats = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistbools = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistvectors = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructurelistdatastructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            
            
            int propidx = 0;

            for (propidx = 0; propidx < inDataStructure.Value.DataStructureProperties.Keys.Count; propidx++)
            {
                TagNameReportEntry currentdatastructureproperty = new TagNameReportEntry();
                inDataStructure.Value.DataStructureProperties.TryGetValue(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), out currentdatastructureproperty);

                //KeyValuePair<string, TagNameReportEntry> currentresult = datastructures.ElementAt(i);

                switch (currentdatastructureproperty.NodeType)
                {
                    case TagNameReportNodeTypes.plaintext:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructureliststrings.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructurestrings.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    case TagNameReportNodeTypes.integer:
                        if (inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx).StartsWith("b"))
                        {
                            if (currentdatastructureproperty.IsList)
                            {
                                datastructurelistbools.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                            else
                            {
                                datastructurebools.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                        }
                        else
                        {
                            if (currentdatastructureproperty.IsList)
                            {
                                datastructurelistints.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                            else
                            {
                                datastructureints.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                            }
                        }
                        break;
                    case TagNameReportNodeTypes.realnumber:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructurelistfloats.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructurefloats.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    case TagNameReportNodeTypes.vector:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructurelistvectors.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructurevectors.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    case TagNameReportNodeTypes.datastructure:
                        if (currentdatastructureproperty.IsList)
                        {
                            datastructurelistdatastructures.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        else
                        {
                            datastructuredatastructures.Add(new KeyValuePair<string, TagNameReportEntry>(inDataStructure.Value.DataStructureProperties.Keys.ElementAt(propidx), currentdatastructureproperty));
                        }
                        break;
                    default:
                        break;
                }
            }

            for (int childidx = 0; childidx < datastructuredatastructures.Count; childidx++)
            {
                inTextLines = AddDataStructureParseHelpersLines(inTextLines, datastructuredatastructures[childidx]);
            }
            for (int childidx = 0; childidx < datastructurelistdatastructures.Count; childidx++)
            {
                inTextLines = AddDataStructureParseHelpersLines(inTextLines, datastructurelistdatastructures[childidx]);
            }

            inTextLines.Add("        //Gets the value of child nodes to get a '" + inDataStructure.Key + "' data structure as a " + inDataStructure.Key + "DataStructure.");
            inTextLines.Add("        public static " + inDataStructure.Key + "DataStructure Get" + inDataStructure.Key + "DataStructureFromXMLNode(XmlNode inXMLNode)");
            inTextLines.Add("        {");
            skipnewline = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines.Add("            string " + currentresult.Key + " = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines.Add("            List<string> " + currentresult.Key + " = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines.Add("            int " + currentresult.Key + " = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines.Add("            List<int> " + currentresult.Key + " = ParseHelpers.GetInt32ListFromXMLNodeNamedChildren(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines.Add("            float " + currentresult.Key + " = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines.Add("            List<float> " + currentresult.Key + " = ParseHelpers.GetFloatListFromXMLNodeNamedChildren(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines.Add("            bool " + currentresult.Key + " = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines.Add("            List<bool> " + currentresult.Key + " = ParseHelpers.GetBoolListFromXMLNodeNamedChildren(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines.Add("            Vector3D " + currentresult.Key + " = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines.Add("            List<Vector3D> " + currentresult.Key + " = ParseHelpers.GetVector3DListFromXMLNodeNamedChildren(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines.Add("            " + currentresult.Key + "DataStructure " + currentresult.Key + " = DataStructureParseHelpers.Get" + currentresult.Key + "DataStructureFromXMLNodeNamedChild(inXMLNode, \"" + currentresult.Key + "\");");                
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            skipnewline = true;
            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines.Add("            List<" + currentresult.Key + "DataStructure> " + currentresult.Key + " = DataStructureParseHelpers.Get" + currentresult.Key + "DataStructureListFromXMLNodeNamedChildren(inXMLNode, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                inTextLines.Add("");
            }
            inTextLines.Add("            " + inDataStructure.Key + "DataStructure result = new " + inDataStructure.Key + "DataStructure(");
            bool isfirstarg = true;
            for (propidx = 0; propidx < datastructurestrings.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurestrings.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructureliststrings.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureliststrings.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructureints.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructureints.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistints.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistints.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurefloats.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurefloats.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistfloats.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistfloats.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurebools.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurebools.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistbools.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistbools.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurevectors.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurevectors.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructurelistvectors.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistvectors.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            for (propidx = 0; propidx < datastructuredatastructures.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructuredatastructures.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }

            for (propidx = 0; propidx < datastructurelistdatastructures.Count; propidx++)
            {
                if (!isfirstarg)
                {
                    inTextLines[inTextLines.Count - 1] += ", ";
                }
                isfirstarg = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructurelistdatastructures.ElementAt(propidx);
                inTextLines[inTextLines.Count - 1] += currentresult.Key;
            }
            inTextLines[inTextLines.Count - 1] += ");";
            inTextLines.Add("");
            inTextLines.Add("            return result;");
            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        //Get data structures with this name from the child nodes of this xml node, as a list of '" + inDataStructure.Key + "' data structures. ");
            inTextLines.Add("        //Used for properties that are in a collection. See Get" + inDataStructure.Key + "DataStructureFromXMLNodeNamedChild for a single '" + inDataStructure.Key + "' data structure.");
            inTextLines.Add("        public static List<" + inDataStructure.Key + "DataStructure> Get" + inDataStructure.Key + "DataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)");
            inTextLines.Add("        {");
            inTextLines.Add("            List<" + inDataStructure.Key + "DataStructure> result = new List<" + inDataStructure.Key + "DataStructure>();");
            inTextLines.Add("            int childindex = 0;");
            inTextLines.Add("            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)");
            inTextLines.Add("            {");
            inTextLines.Add("                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];");
            inTextLines.Add("                if (CurrentChildNode.Name == inChildNodeName)");
            inTextLines.Add("                {");
            inTextLines.Add("                    result.Add(Get" + inDataStructure.Key + "DataStructureFromXMLNode(CurrentChildNode));");
            inTextLines.Add("                }");
            inTextLines.Add("            }");
            inTextLines.Add("");
            inTextLines.Add("            return result;");
            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        //Get the first data structure with this name from the child nodes of this xml node, as a '" + inDataStructure.Key + "' data structure. ");
            inTextLines.Add("        //Used for properties that are not in a collection. See Get" + inDataStructure.Key + "DataStructureListFromXMLNodeNamedChildren for collections of '" + inDataStructure.Key + "' data structures.");
            inTextLines.Add("        public static " + inDataStructure.Key + "DataStructure Get" + inDataStructure.Key + "DataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)");
            inTextLines.Add("        {");
            inTextLines.Add("            " + inDataStructure.Key + "DataStructure result = new " + inDataStructure.Key + "DataStructure();");
            inTextLines.Add("            List <" + inDataStructure.Key + "DataStructure> results = Get" + inDataStructure.Key + "DataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);");
            inTextLines.Add("            if (results.Count > 0)");
            inTextLines.Add("            {");
            inTextLines.Add("                result = results[0];");
            inTextLines.Add("            }");
            inTextLines.Add("");
            inTextLines.Add("            return result;");
            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        //Gets a list of '" + inDataStructure.Key + "' data structures from a definition XML");
            inTextLines.Add("        //Used for data structures that are in a collection. See Get" + "DataStructureFromVD2Data for a single '" + inDataStructure.Key + "' data structure");
            inTextLines.Add("        public static List<" + inDataStructure.Key + "DataStructure> Get" + inDataStructure.Key + "DataStructureListFromVD2Data(XmlDocument inXML)");
            inTextLines.Add("        {");
            inTextLines.Add("            XmlNodeList xmlnodes = inXML.GetElementsByTagName(\"" + inDataStructure.Key + "\");");
            inTextLines.Add("            List <" + inDataStructure.Key + "DataStructure> result = new List<" + inDataStructure.Key + "DataStructure>();");
            inTextLines.Add("            int nodeindex = 0;");
            inTextLines.Add("            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)");
            inTextLines.Add("            {");
            inTextLines.Add("                XmlNode currentnode = xmlnodes[nodeindex];");            
            inTextLines.Add("                " + inDataStructure.Key + "DataStructure currentdata = DataStructureParseHelpers.Get" + inDataStructure.Key + "DataStructureFromXMLNode(currentnode);");
            inTextLines.Add("                result.Add(currentdata);");
            inTextLines.Add("            }");
            inTextLines.Add("            return result;");
            inTextLines.Add("        }");
            inTextLines.Add("");
            inTextLines.Add("        //Gets the first '" + inDataStructure.Key + "' data structure from a definition XML");
            inTextLines.Add("        //Used for data structures that are not in a collection. See Get" + inDataStructure.Key + "DataStructureListFromVD2Data for a collection of '" + inDataStructure.Key + "' data structures");
            inTextLines.Add("        public static " + inDataStructure.Key + "DataStructure Get" + inDataStructure.Key + "DataStructureFromVD2Data(XmlDocument inXML)");
            inTextLines.Add("        {");
            inTextLines.Add("            List <" + inDataStructure.Key + "DataStructure> results = Get" + inDataStructure.Key + "DataStructureListFromVD2Data(inXML);");
            inTextLines.Add("            " + inDataStructure.Key + "DataStructure result = new " + inDataStructure.Key + "DataStructure();");
            inTextLines.Add("");
            inTextLines.Add("            if (results.Count > 0)");
            inTextLines.Add("            {");
            inTextLines.Add("                result = results[0];");
            inTextLines.Add("            }");
            inTextLines.Add("            return result;");
            inTextLines.Add("        }");
            //skipnewline = true;
            

            
            return inTextLines;
        }

        public static void GenerateCodeFilesFromXMLFiles()
        {
            List<KeyValuePair<string, TagNameReportEntry>> DataStructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<string> folderlist = new List<string>();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Drones");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Fighters");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\GunShips");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Corvettes");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Frigates");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Destroyers");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Cruisers");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Carriers");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Dreads");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "ShipData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Upgrades");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "PrimaryUpgradeData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Ships\\Upgrades\\Active");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "ActiveUpgradeData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "WeaponData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Ammo");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "AmmoData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Hangars");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "HangarData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Launchers");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "LauncherData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Missiles");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "MissileData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Mines");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "MineData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Weapons\\Turrets");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "TurretData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\AreaOfEffect");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "AreaOfEffectData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Asteroids");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "AsteroidData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Bases");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "BaseData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Characters");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "CharacterData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Cockpits");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "CockpitData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Debris");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "DebrisData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Dialog");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "DialogData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\DockedMovingElements");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "DockedMovingElementData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Doors");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "DoorData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Effects");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "EffectData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Effects\\Particles");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "ParticleData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Explosions");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "ExplosionData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Factions");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "FactionData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Music");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "MusicData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Other");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "OtherObjectData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Shields");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "ShieldData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Skyboxes");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "SkyboxData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Sounds");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Sounds\\Interior");
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Sounds\\UI");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "SoundData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Stations");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "StationData", DataStructures, out DataStructures);
            folderlist.Clear();
            folderlist.Add("C:\\Steam\\steamapps\\common\\Void Destroyer 2\\Data\\Suns");
            VD2LoadCodeGenerator.GenerateDataClassFromXMLFiles(folderlist, "SunData", DataStructures, out DataStructures); 
                
                
                

            List<string> datastructurefiletextlines = new List<string>();
            datastructurefiletextlines.Add("using System;");
            datastructurefiletextlines.Add("using System.Collections.Generic;");
            datastructurefiletextlines.Add("using System.Linq;");
            datastructurefiletextlines.Add("using System.Text;");
            datastructurefiletextlines.Add("using System.Threading.Tasks;");
            datastructurefiletextlines.Add("using System.Xml;");
            datastructurefiletextlines.Add("using System.IO;");
            datastructurefiletextlines.Add("using System.ComponentModel;");
            datastructurefiletextlines.Add("using System.Globalization;");
            datastructurefiletextlines.Add("");
            datastructurefiletextlines.Add("namespace VoidDestroyer2DataEditor");
            datastructurefiletextlines.Add("{");
            for (int propidx = 0; propidx < DataStructures.Count; propidx++)
            {
                datastructurefiletextlines = VD2LoadCodeGenerator.AddDataStructureClassLines(datastructurefiletextlines, DataStructures[propidx]);
            }
            datastructurefiletextlines.Add("}");
            File.WriteAllLines("DataStructures.cs" , datastructurefiletextlines);

            List<string> datastructureparsehelpersfiletextlines = new List<string>();
            datastructureparsehelpersfiletextlines.Add("using System;");
            datastructureparsehelpersfiletextlines.Add("using System.Collections.Generic;");
            datastructureparsehelpersfiletextlines.Add("using System.Linq;");
            datastructureparsehelpersfiletextlines.Add("using System.Text;");
            datastructureparsehelpersfiletextlines.Add("using System.Xml;");
            datastructureparsehelpersfiletextlines.Add("using System.IO;");
            datastructureparsehelpersfiletextlines.Add("");
            datastructureparsehelpersfiletextlines.Add("namespace VoidDestroyer2DataEditor");
            datastructureparsehelpersfiletextlines.Add("{");
            datastructureparsehelpersfiletextlines.Add("    static class DataStructureParseHelpers");
            datastructureparsehelpersfiletextlines.Add("    {");
            for (int propidx = 0; propidx < DataStructures.Count; propidx++)
            {
                datastructurefiletextlines = VD2LoadCodeGenerator.AddDataStructureParseHelpersLines(datastructureparsehelpersfiletextlines, DataStructures[propidx]);
            }
            datastructurefiletextlines.Add("    }");
            datastructurefiletextlines.Add("}");
            File.WriteAllLines("DataStructureParseHelpers.cs", datastructurefiletextlines);
        }

        public static List<KeyValuePair<string, TagNameReportEntry>> MergeIntoGlobalDatastructures(List<KeyValuePair<string, TagNameReportEntry>> inGlobalDataStructures, List<KeyValuePair<string, TagNameReportEntry>> inLocalDataStructures)
        {
            /*if ((inGlobalDataStructures[globalidx].Value.NodeType < inLocalDataStrucutres[i].Value.NodeType) && ((inLocalDataStrucutres[i].Value.NodeType < TagNameReportNodeTypes.vector) && (inGlobalDataStructures[globalidx].Value.NodeType < TagNameReportNodeTypes.vector)))
            {
                inLocalDataStrucutres[i].Value.NodeType = inGlobalDataStructures[globalidx].Value.NodeType;
            }*/
            for (int i = 0; i < inLocalDataStructures.Count; i++)
            {
                bool globalcontains = false;
                for (int globalidx = 0; globalidx < inGlobalDataStructures.Count; globalidx++)
                {
                    if (inGlobalDataStructures[globalidx].Key == inLocalDataStructures[i].Key)
                    {
                        globalcontains = true;
                        List<KeyValuePair<string, TagNameReportEntry>> localprops = inLocalDataStructures[i].Value.DataStructureProperties.ToList();
                        List<KeyValuePair<string, TagNameReportEntry>> globalprops = inGlobalDataStructures[globalidx].Value.DataStructureProperties.ToList();
                        globalprops = VD2LoadCodeGenerator.MergeIntoGlobalDatastructures(globalprops, localprops);
                        Dictionary<string, TagNameReportEntry> globalpropsdictionary = new Dictionary<string, TagNameReportEntry>();
                        for (int j = 0; j < globalprops.Count; j++)
                        {
                            globalpropsdictionary.Add(globalprops[j].Key, globalprops[j].Value);
                        }

                        inGlobalDataStructures[globalidx].Value.DataStructureProperties = globalpropsdictionary;
                    }
                }
                if (!globalcontains)
                {
                    inGlobalDataStructures.Add(inLocalDataStructures[i]);
                }
            }
            return inGlobalDataStructures;
        }

        public static void GenerateDataClassFromXMLFiles(List<string> inPath, string inClassName, List<KeyValuePair<string, TagNameReportEntry>> inDataStructures, out List<KeyValuePair<string, TagNameReportEntry>> outDataStructures)
        {
            Dictionary<string, TagNameReportEntry> roottagresults = new Dictionary<string, TagNameReportEntry>();
            //Dictionary<string, Dictionary<string, TagNameReportEntry>> childtagresults = new Dictionary<string, Dictionary<string, TagNameReportEntry>>();
            List<string> reporttextlines = new List<string>();
            int i = 0;
            List<string> files = new List<string>();
            for (int pathidx = 0; pathidx < inPath.Count; pathidx++)
            {
                if (Directory.Exists(inPath[pathidx]))
                {
                    files.AddRange(Directory.EnumerateFiles(inPath[pathidx]).ToList());
                }
            }

            for (i = 0; i < files.Count; i++)
            {
                Dictionary<string, int> UsageWithinThisFile = new Dictionary<string, int>();

                XmlDocument XMLfile = ParseHelpers.SafeLoadVD2DataXMLFile(files[i]);

                if (XMLfile != null)
                {
                    XmlNodeList nodelist = XMLfile.DocumentElement.ChildNodes;

                    int nodeindex = 0;
                    for (nodeindex = 0; nodeindex < nodelist.Count; nodeindex++)
                    {
                        if ((nodelist[nodeindex].Name != "note_to_self") && !(nodelist[nodeindex].Name.StartsWith("_")))
                        {
                            TagNameReportEntry currententry = new TagNameReportEntry();
                            if (roottagresults.ContainsKey(nodelist[nodeindex].Name))
                            {
                                roottagresults.TryGetValue(nodelist[nodeindex].Name, out currententry);
                            }
                            currententry = ParseHelpers.UpdateTagNameReportEntry(currententry, nodelist[nodeindex], UsageWithinThisFile, out UsageWithinThisFile);
                            if (currententry.NodeType == TagNameReportNodeTypes.datastructure)
                            {

                            }

                            if (roottagresults.ContainsKey(nodelist[nodeindex].Name))
                            {
                                roottagresults.Remove(nodelist[nodeindex].Name);
                            }
                            roottagresults.Add(nodelist[nodeindex].Name, currententry);
                        }
                    }
                }
            }

            //yes i know this is just a dictionary, im in a fucking hurry here.
            List<KeyValuePair<string, TagNameReportEntry>> strings = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> ints = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> floats = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> bools = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> vectors = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> datastructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> liststrings = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> listints = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> listfloats = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> listbools = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> listvectors = new List<KeyValuePair<string, TagNameReportEntry>>();
            List<KeyValuePair<string, TagNameReportEntry>> listdatastructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            for (i = 0; i < roottagresults.Count; i++)
            {
                KeyValuePair<string, TagNameReportEntry> currentresult = roottagresults.ElementAt(i);

                switch (currentresult.Value.NodeType)
                {
                    case TagNameReportNodeTypes.plaintext:
                        if (currentresult.Value.IsList)
                        {
                            liststrings.Add(currentresult);
                        }
                        else
                        {
                            strings.Add(currentresult);
                        }
                        break;
                    case TagNameReportNodeTypes.integer:
                        if ((currentresult.Key.StartsWith("b")) || (currentresult.Key  == "isMassInfinite"))
                        {
                            if (currentresult.Value.IsList)
                            {
                                listbools.Add(currentresult);
                            }
                            else
                            {
                                bools.Add(currentresult);
                            }
                        }
                        else
                        {
                            if (currentresult.Value.IsList)
                            {
                                listints.Add(currentresult);
                            }
                            else
                            {
                                ints.Add(currentresult);
                            }
                        }
                        break;
                    case TagNameReportNodeTypes.realnumber:
                        if (currentresult.Value.IsList)
                        {
                            listfloats.Add(currentresult);
                        }
                        else
                        {
                            floats.Add(currentresult);
                        }
                        break;
                    case TagNameReportNodeTypes.vector:
                        if (currentresult.Value.IsList)
                        {
                            listvectors.Add(currentresult);
                        }
                        else
                        {
                            vectors.Add(currentresult);
                        }
                        break;
                    case TagNameReportNodeTypes.datastructure:
                        if (currentresult.Value.IsList)
                        {
                            listdatastructures.Add(currentresult);
                        }
                        else
                        {
                            datastructures.Add(currentresult);
                        }
                        break;
                    default:
                        break;
                }
            }
            List<KeyValuePair<string, TagNameReportEntry>> totaldatastructures = new List<KeyValuePair<string, TagNameReportEntry>>();
            totaldatastructures.AddRange(datastructures);
            totaldatastructures.AddRange(listdatastructures);
            inDataStructures = VD2LoadCodeGenerator.MergeIntoGlobalDatastructures(inDataStructures, totaldatastructures);
            outDataStructures = inDataStructures;
            bool skipnewline = true;
            reporttextlines.Add("using System;");
            reporttextlines.Add("using System.Collections.Generic;");
            reporttextlines.Add("using System.Linq;");
            reporttextlines.Add("using System.Text;");
            reporttextlines.Add("using System.Threading.Tasks;");
            reporttextlines.Add("using System.Xml;");
            reporttextlines.Add("using System.IO;");
            reporttextlines.Add("using System.ComponentModel;");
            reporttextlines.Add("");
            reporttextlines.Add("namespace VoidDestroyer2DataEditor");
            reporttextlines.Add("{");
            reporttextlines.Add("    class " + inClassName + " : VD2Data");
            reporttextlines.Add("    {");
            skipnewline = true;
            for (i = 0; i < strings.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = strings.ElementAt(i);
                reporttextlines.Add("        string _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < liststrings.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = liststrings.ElementAt(i);
                reporttextlines.Add("        List<string> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < ints.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = ints.ElementAt(i);
                reporttextlines.Add("        int _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listints.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listints.ElementAt(i);
                reporttextlines.Add("        List<int> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < floats.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = floats.ElementAt(i);
                reporttextlines.Add("        float _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listfloats.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listfloats.ElementAt(i);
                reporttextlines.Add("        List<float> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < bools.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = bools.ElementAt(i);
                reporttextlines.Add("        bool _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listbools.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listbools.ElementAt(i);
                reporttextlines.Add("        List<bool> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < vectors.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = vectors.ElementAt(i);
                reporttextlines.Add("        Vector3D _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listvectors.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listvectors.ElementAt(i);
                reporttextlines.Add("        List<Vector3D> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < datastructures.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructures.ElementAt(i);
                reporttextlines.Add("        " + currentresult.Key + "DataStructure _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listdatastructures.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listdatastructures.ElementAt(i);
                reporttextlines.Add("        List<" + currentresult.Key + "DataStructure> _" + currentresult.Key + ";");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < strings.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = strings.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a plaintext string\"), Category(\"Plaintext Strings\")]");
                reporttextlines.Add("        public string " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < liststrings.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = liststrings.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a collection of plaintext strings\"), Category(\"Plaintext String Collections\")]");
                reporttextlines.Add("        public List<string> " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < ints.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = ints.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is an integer\"), Category(\"Integers\")]");
                reporttextlines.Add("        public int " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listints.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listints.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a collection of integers\"), Category(\"Integer Collections\")]");
                reporttextlines.Add("        public List<int> " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < floats.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = floats.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a real number\"), Category(\"Real Numbers\")]");
                reporttextlines.Add("        public float " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listfloats.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listfloats.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a collection of real numbers\"), Category(\"Real Number Collections\")]");
                reporttextlines.Add("        public List<float> " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < bools.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = bools.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a boolean value\"), Category(\"Booleans\")]");
                reporttextlines.Add("        public bool " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listbools.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listbools.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a collection of boolean values\"), Category(\"Boolean Collections\")]");
                reporttextlines.Add("        public List<bool> " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < vectors.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = vectors.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a 3D vector\"), Category(\"3D Vectors\")]");
                reporttextlines.Add("        public Vector3D " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listvectors.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listvectors.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a collection of 3D vectors\"), Category(\"3D Vector Collections\")]");
                reporttextlines.Add("        public List<Vector3D> " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < datastructures.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructures.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a datastructure\"), Category(\"Data Structures\")]");
                reporttextlines.Add("        public "  + currentresult.Key + "DataStructure " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            for (i = 0; i < listdatastructures.Count; i++)
            {
                KeyValuePair<string, TagNameReportEntry> currentresult = listdatastructures.ElementAt(i);
                reporttextlines.Add("        [Description(\"" + currentresult.Key + " is a collection of datastructures\"), Category(\"Data Structure Collections\")]");
                reporttextlines.Add("        public List<" + currentresult.Key + "DataStructure> " + currentresult.Key);
                reporttextlines.Add("        {");
                reporttextlines.Add("            get => _" + currentresult.Key + ";");
                reporttextlines.Add("            set => _" + currentresult.Key + " = value;");
                reporttextlines.Add("        }");
                reporttextlines.Add("");
            }
            reporttextlines.Add("");
            reporttextlines.Add("        public " + inClassName + "(string inPath) : base(inPath)");
            reporttextlines.Add("        {");
            reporttextlines.Add("            if (DataXMLDoc != null)");
            reporttextlines.Add("            {");
            skipnewline = true;
            for (i = 0; i < strings.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = strings.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetStringFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < liststrings.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = liststrings.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetStringListFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < ints.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = ints.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetInt32FromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listints.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listints.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetInt32ListFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < floats.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = floats.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetFloatFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listfloats.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listfloats.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetFloatListFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < bools.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = bools.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetBoolFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listbools.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listbools.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetBoolListFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < vectors.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = vectors.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetVector3DFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < listvectors.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = listvectors.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "ParseHelpers.GetVector3DListFromVD2Data(DataXMLDoc, \"" + currentresult.Key + "\");");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            skipnewline = true;
            for (i = 0; i < datastructures.Count; i++)
            {
                skipnewline = false;
                KeyValuePair<string, TagNameReportEntry> currentresult = datastructures.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "DataStructureParseHelpers.Get" + currentresult.Key + "DataStructureFromVD2Data(DataXMLDoc);");
            }
            if (!skipnewline)
            {
                reporttextlines.Add("");
            }
            for (i = 0; i < listdatastructures.Count; i++)
            {
                KeyValuePair<string, TagNameReportEntry> currentresult = listdatastructures.ElementAt(i);
                reporttextlines.Add("                _" + currentresult.Key + " = " + "DataStructureParseHelpers.Get" + currentresult.Key + "DataStructureListFromVD2Data(DataXMLDoc);");
            }
            reporttextlines.Add("            }");
            reporttextlines.Add("        }");
            reporttextlines.Add("    }");
            reporttextlines.Add("}");
            string[] SplitPath = inPath[0].Split('\\');
            string mysubfolderofdata = "";
            for (int pathfoldersidx = 0; pathfoldersidx < SplitPath.Length; pathfoldersidx++)
            {
                if (pathfoldersidx > 0)
                {
                    if (SplitPath[pathfoldersidx - 1] == "Void Destroyer 2")
                    {
                        if (SplitPath[pathfoldersidx] == "Data")
                        {
                            if ((pathfoldersidx + 1) < SplitPath.Length)
                            {
                                mysubfolderofdata = SplitPath[pathfoldersidx + 1];
                            }
                        }
                    }
                }
            }
            if (!Directory.Exists(mysubfolderofdata))
            {
                Directory.CreateDirectory(mysubfolderofdata);
            }
            File.WriteAllLines(mysubfolderofdata + "\\" + inClassName + ".cs", reporttextlines);
        }
    }
}
