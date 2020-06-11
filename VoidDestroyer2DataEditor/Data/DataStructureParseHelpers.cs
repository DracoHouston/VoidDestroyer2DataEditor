using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace VoidDestroyer2DataEditor
{
    static class DataStructureParseHelpers
    {
        //Gets the value of child nodes to get a 'debris' data structure as a debrisDataStructure.
        public static debrisDataStructure GetdebrisDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool debrisIDexists;
            string debrisID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "debrisID", out debrisIDexists);

            bool debrisMomentumexists;
            float debrisMomentum = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "debrisMomentum", out debrisMomentumexists);
            bool debrisAngularexists;
            float debrisAngular = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "debrisAngular", out debrisAngularexists);

            debrisDataStructure result = new debrisDataStructure(inParentDataFile, inXMLNode, debrisID, debrisMomentum, debrisAngular);

            result.SetPropertyExists("debrisID", debrisIDexists);

            result.SetPropertyExists("debrisMomentum", debrisMomentumexists);
            result.SetPropertyExists("debrisAngular", debrisAngularexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'debris' data structures. 
        //Used for properties that are in a collection. See GetdebrisDataStructureFromXMLNodeNamedChild for a single 'debris' data structure.
        public static List<debrisDataStructure> GetdebrisDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<debrisDataStructure> result = new List<debrisDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetdebrisDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'debris' data structure. 
        //Used for properties that are not in a collection. See GetdebrisDataStructureListFromXMLNodeNamedChildren for collections of 'debris' data structures.
        public static debrisDataStructure GetdebrisDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            debrisDataStructure result = new debrisDataStructure(inParentDataFile, null);
            bool exists = false;
            List <debrisDataStructure> results = GetdebrisDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'debris' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'debris' data structure
        public static List<debrisDataStructure> GetdebrisDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("debris");
            List <debrisDataStructure> result = new List<debrisDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                debrisDataStructure currentdata = DataStructureParseHelpers.GetdebrisDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'debris' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdebrisDataStructureListFromVD2Data for a collection of 'debris' data structures
        public static debrisDataStructure GetdebrisDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <debrisDataStructure> results = GetdebrisDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            debrisDataStructure result = new debrisDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'debrisInfo' data structure as a debrisInfoDataStructure.
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool debrisexists;
            List<debrisDataStructure> debris = DataStructureParseHelpers.GetdebrisDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, "debris", out debrisexists);

            debrisInfoDataStructure result = new debrisInfoDataStructure(inParentDataFile, inXMLNode, debris);

            result.SetPropertyExists("debris", debrisexists);
            result.debris.CollectionChanged += result.OndebrisChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'debrisInfo' data structures. 
        //Used for properties that are in a collection. See GetdebrisInfoDataStructureFromXMLNodeNamedChild for a single 'debrisInfo' data structure.
        public static List<debrisInfoDataStructure> GetdebrisInfoDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<debrisInfoDataStructure> result = new List<debrisInfoDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetdebrisInfoDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'debrisInfo' data structure. 
        //Used for properties that are not in a collection. See GetdebrisInfoDataStructureListFromXMLNodeNamedChildren for collections of 'debrisInfo' data structures.
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            debrisInfoDataStructure result = new debrisInfoDataStructure(inParentDataFile, null);
            bool exists = false;
            List <debrisInfoDataStructure> results = GetdebrisInfoDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'debrisInfo' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'debrisInfo' data structure
        public static List<debrisInfoDataStructure> GetdebrisInfoDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("debrisInfo");
            List <debrisInfoDataStructure> result = new List<debrisInfoDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                debrisInfoDataStructure currentdata = DataStructureParseHelpers.GetdebrisInfoDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'debrisInfo' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdebrisInfoDataStructureListFromVD2Data for a collection of 'debrisInfo' data structures
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <debrisInfoDataStructure> results = GetdebrisInfoDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            debrisInfoDataStructure result = new debrisInfoDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'afterburner' data structure as a afterburnerDataStructure.
        public static afterburnerDataStructure GetafterburnerDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool soundIDexists;
            string soundID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "soundID", out soundIDexists);
            bool tailSoundIDexists;
            string tailSoundID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "tailSoundID", out tailSoundIDexists);

            bool multiplierexists;
            float multiplier = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "multiplier", out multiplierexists);
            bool capacityexists;
            float capacity = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "capacity", out capacityexists);
            bool rechargeexists;
            float recharge = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "recharge", out rechargeexists);

            afterburnerDataStructure result = new afterburnerDataStructure(inParentDataFile, inXMLNode, soundID, tailSoundID, multiplier, capacity, recharge);

            result.SetPropertyExists("soundID", soundIDexists);
            result.SetPropertyExists("tailSoundID", tailSoundIDexists);

            result.SetPropertyExists("multiplier", multiplierexists);
            result.SetPropertyExists("capacity", capacityexists);
            result.SetPropertyExists("recharge", rechargeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'afterburner' data structures. 
        //Used for properties that are in a collection. See GetafterburnerDataStructureFromXMLNodeNamedChild for a single 'afterburner' data structure.
        public static List<afterburnerDataStructure> GetafterburnerDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<afterburnerDataStructure> result = new List<afterburnerDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetafterburnerDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'afterburner' data structure. 
        //Used for properties that are not in a collection. See GetafterburnerDataStructureListFromXMLNodeNamedChildren for collections of 'afterburner' data structures.
        public static afterburnerDataStructure GetafterburnerDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            afterburnerDataStructure result = new afterburnerDataStructure(inParentDataFile, null);
            bool exists = false;
            List <afterburnerDataStructure> results = GetafterburnerDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'afterburner' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'afterburner' data structure
        public static List<afterburnerDataStructure> GetafterburnerDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("afterburner");
            List <afterburnerDataStructure> result = new List<afterburnerDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                afterburnerDataStructure currentdata = DataStructureParseHelpers.GetafterburnerDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'afterburner' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetafterburnerDataStructureListFromVD2Data for a collection of 'afterburner' data structures
        public static afterburnerDataStructure GetafterburnerDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <afterburnerDataStructure> results = GetafterburnerDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            afterburnerDataStructure result = new afterburnerDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'targetPriorityList' data structure as a targetPriorityListDataStructure.
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool targetClassexists;
            List<string> targetClass = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "targetClass", out targetClassexists);

            targetPriorityListDataStructure result = new targetPriorityListDataStructure(inParentDataFile, inXMLNode, targetClass);

            result.SetPropertyExists("targetClass", targetClassexists);
            result.targetClass.CollectionChanged += result.OntargetClassChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'targetPriorityList' data structures. 
        //Used for properties that are in a collection. See GettargetPriorityListDataStructureFromXMLNodeNamedChild for a single 'targetPriorityList' data structure.
        public static List<targetPriorityListDataStructure> GettargetPriorityListDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<targetPriorityListDataStructure> result = new List<targetPriorityListDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GettargetPriorityListDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'targetPriorityList' data structure. 
        //Used for properties that are not in a collection. See GettargetPriorityListDataStructureListFromXMLNodeNamedChildren for collections of 'targetPriorityList' data structures.
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            targetPriorityListDataStructure result = new targetPriorityListDataStructure(inParentDataFile, null);
            bool exists = false;
            List <targetPriorityListDataStructure> results = GettargetPriorityListDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'targetPriorityList' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'targetPriorityList' data structure
        public static List<targetPriorityListDataStructure> GettargetPriorityListDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("targetPriorityList");
            List <targetPriorityListDataStructure> result = new List<targetPriorityListDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                targetPriorityListDataStructure currentdata = DataStructureParseHelpers.GettargetPriorityListDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'targetPriorityList' data structure from a definition XML
        //Used for data structures that are not in a collection. See GettargetPriorityListDataStructureListFromVD2Data for a collection of 'targetPriorityList' data structures
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <targetPriorityListDataStructure> results = GettargetPriorityListDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            targetPriorityListDataStructure result = new targetPriorityListDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'upgrades' data structure as a upgradesDataStructure.
        public static upgradesDataStructure GetupgradesDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool upgradeIDexists;
            List<string> upgradeID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "upgradeID", out upgradeIDexists);

            bool primaryUpgradeCapacityexists;
            int primaryUpgradeCapacity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "primaryUpgradeCapacity", out primaryUpgradeCapacityexists);
            bool activeUpgradeCapacityexists;
            int activeUpgradeCapacity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "activeUpgradeCapacity", out activeUpgradeCapacityexists);

            upgradesDataStructure result = new upgradesDataStructure(inParentDataFile, inXMLNode, upgradeID, primaryUpgradeCapacity, activeUpgradeCapacity);

            result.SetPropertyExists("upgradeID", upgradeIDexists);
            result.upgradeID.CollectionChanged += result.OnupgradeIDChanged;

            result.SetPropertyExists("primaryUpgradeCapacity", primaryUpgradeCapacityexists);
            result.SetPropertyExists("activeUpgradeCapacity", activeUpgradeCapacityexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'upgrades' data structures. 
        //Used for properties that are in a collection. See GetupgradesDataStructureFromXMLNodeNamedChild for a single 'upgrades' data structure.
        public static List<upgradesDataStructure> GetupgradesDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<upgradesDataStructure> result = new List<upgradesDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetupgradesDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'upgrades' data structure. 
        //Used for properties that are not in a collection. See GetupgradesDataStructureListFromXMLNodeNamedChildren for collections of 'upgrades' data structures.
        public static upgradesDataStructure GetupgradesDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            upgradesDataStructure result = new upgradesDataStructure(inParentDataFile, null);
            bool exists = false;
            List <upgradesDataStructure> results = GetupgradesDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'upgrades' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'upgrades' data structure
        public static List<upgradesDataStructure> GetupgradesDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("upgrades");
            List <upgradesDataStructure> result = new List<upgradesDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                upgradesDataStructure currentdata = DataStructureParseHelpers.GetupgradesDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'upgrades' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetupgradesDataStructureListFromVD2Data for a collection of 'upgrades' data structures
        public static upgradesDataStructure GetupgradesDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <upgradesDataStructure> results = GetupgradesDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            upgradesDataStructure result = new upgradesDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'propulsion' data structure as a propulsionDataStructure.
        public static propulsionDataStructure GetpropulsionDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool propulsionEffectIDexists;
            string propulsionEffectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "propulsionEffectID", out propulsionEffectIDexists);
            bool directionexists;
            string direction = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "direction", out directionexists);

            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool rollexists;
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);

            bool bPlayerShipOnlyexists;
            bool bPlayerShipOnly = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bPlayerShipOnly", out bPlayerShipOnlyexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            propulsionDataStructure result = new propulsionDataStructure(inParentDataFile, inXMLNode, propulsionEffectID, direction, pitch, yaw, roll, bPlayerShipOnly, position);

            result.SetPropertyExists("propulsionEffectID", propulsionEffectIDexists);
            result.SetPropertyExists("direction", directionexists);

            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExists("roll", rollexists);

            result.SetPropertyExists("bPlayerShipOnly", bPlayerShipOnlyexists);

            result.SetPropertyExists("position", positionexists);
            position.OnElementChanged += result.position_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'propulsion' data structures. 
        //Used for properties that are in a collection. See GetpropulsionDataStructureFromXMLNodeNamedChild for a single 'propulsion' data structure.
        public static List<propulsionDataStructure> GetpropulsionDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<propulsionDataStructure> result = new List<propulsionDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetpropulsionDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'propulsion' data structure. 
        //Used for properties that are not in a collection. See GetpropulsionDataStructureListFromXMLNodeNamedChildren for collections of 'propulsion' data structures.
        public static propulsionDataStructure GetpropulsionDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            propulsionDataStructure result = new propulsionDataStructure(inParentDataFile, null);
            bool exists = false;
            List <propulsionDataStructure> results = GetpropulsionDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'propulsion' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'propulsion' data structure
        public static List<propulsionDataStructure> GetpropulsionDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("propulsion");
            List <propulsionDataStructure> result = new List<propulsionDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                propulsionDataStructure currentdata = DataStructureParseHelpers.GetpropulsionDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'propulsion' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetpropulsionDataStructureListFromVD2Data for a collection of 'propulsion' data structures
        public static propulsionDataStructure GetpropulsionDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <propulsionDataStructure> results = GetpropulsionDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            propulsionDataStructure result = new propulsionDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'weapon' data structure as a weaponDataStructure.
        public static weaponDataStructure GetweaponDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool weaponTypeexists;
            string weaponType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponType", out weaponTypeexists);
            bool hardpointIDexists;
            string hardpointID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "hardpointID", out hardpointIDexists);
            bool weaponFireexists;
            string weaponFire = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponFire", out weaponFireexists);

            bool weaponPositionIDexists;
            int weaponPositionID = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "weaponPositionID", out weaponPositionIDexists);

            bool barrelDelayexists;
            float barrelDelay = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "barrelDelay", out barrelDelayexists);
            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            bool weaponPositionexists;
            List<Vector3D> weaponPosition = ParseHelpers.GetVector3DListFromXMLNodeNamedChildren(inXMLNode, "weaponPosition", out weaponPositionexists);

            weaponDataStructure result = new weaponDataStructure(inParentDataFile, inXMLNode, weaponType, hardpointID, weaponFire, weaponPositionID, barrelDelay, yaw, pitch, position, weaponPosition);

            result.SetPropertyExists("weaponType", weaponTypeexists);
            result.SetPropertyExists("hardpointID", hardpointIDexists);
            result.SetPropertyExists("weaponFire", weaponFireexists);

            result.SetPropertyExists("weaponPositionID", weaponPositionIDexists);

            result.SetPropertyExists("barrelDelay", barrelDelayexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExists("pitch", pitchexists);

            result.SetPropertyExists("position", positionexists);
            position.OnElementChanged += result.position_OnElementChanged;

            result.SetPropertyExists("weaponPosition", weaponPositionexists);
            result.weaponPosition.CollectionChanged += result.OnweaponPositionChanged;
            foreach (Vector3D element in result.weaponPosition)
            {
                element.OnElementChanged += result.weaponPosition_OnElementChanged;
            }

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'weapon' data structures. 
        //Used for properties that are in a collection. See GetweaponDataStructureFromXMLNodeNamedChild for a single 'weapon' data structure.
        public static List<weaponDataStructure> GetweaponDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<weaponDataStructure> result = new List<weaponDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetweaponDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'weapon' data structure. 
        //Used for properties that are not in a collection. See GetweaponDataStructureListFromXMLNodeNamedChildren for collections of 'weapon' data structures.
        public static weaponDataStructure GetweaponDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            weaponDataStructure result = new weaponDataStructure(inParentDataFile, null);
            bool exists = false;
            List <weaponDataStructure> results = GetweaponDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'weapon' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'weapon' data structure
        public static List<weaponDataStructure> GetweaponDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("weapon");
            List <weaponDataStructure> result = new List<weaponDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                weaponDataStructure currentdata = DataStructureParseHelpers.GetweaponDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'weapon' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetweaponDataStructureListFromVD2Data for a collection of 'weapon' data structures
        public static weaponDataStructure GetweaponDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <weaponDataStructure> results = GetweaponDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            weaponDataStructure result = new weaponDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'damage' data structure as a damageDataStructure.
        public static damageDataStructure GetdamageDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool damageEffectIDexists;
            string damageEffectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "damageEffectID", out damageEffectIDexists);

            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool rollexists;
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);
            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool healthPointexists;
            float healthPoint = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "healthPoint", out healthPointexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            damageDataStructure result = new damageDataStructure(inParentDataFile, inXMLNode, damageEffectID, pitch, roll, yaw, healthPoint, position);

            result.SetPropertyExists("damageEffectID", damageEffectIDexists);

            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExists("roll", rollexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExists("healthPoint", healthPointexists);

            result.SetPropertyExists("position", positionexists);
            position.OnElementChanged += result.position_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'damage' data structures. 
        //Used for properties that are in a collection. See GetdamageDataStructureFromXMLNodeNamedChild for a single 'damage' data structure.
        public static List<damageDataStructure> GetdamageDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<damageDataStructure> result = new List<damageDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetdamageDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'damage' data structure. 
        //Used for properties that are not in a collection. See GetdamageDataStructureListFromXMLNodeNamedChildren for collections of 'damage' data structures.
        public static damageDataStructure GetdamageDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            damageDataStructure result = new damageDataStructure(inParentDataFile, null);
            bool exists = false;
            List <damageDataStructure> results = GetdamageDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'damage' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'damage' data structure
        public static List<damageDataStructure> GetdamageDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("damage");
            List <damageDataStructure> result = new List<damageDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                damageDataStructure currentdata = DataStructureParseHelpers.GetdamageDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'damage' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdamageDataStructureListFromVD2Data for a collection of 'damage' data structures
        public static damageDataStructure GetdamageDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <damageDataStructure> results = GetdamageDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            damageDataStructure result = new damageDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'turret' data structure as a turretDataStructure.
        public static turretDataStructure GetturretDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool turretIDexists;
            string turretID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "turretID", out turretIDexists);
            bool turretOrientationexists;
            string turretOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "turretOrientation", out turretOrientationexists);
            bool weaponFireexists;
            string weaponFire = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponFire", out weaponFireexists);

            bool turretRoleexists;
            List<string> turretRole = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "turretRole", out turretRoleexists);

            bool yawPermittedexists;
            int yawPermitted = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "yawPermitted", out yawPermittedexists);
            bool weaponPositionIDexists;
            int weaponPositionID = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "weaponPositionID", out weaponPositionIDexists);

            bool pitchLowerexists;
            float pitchLower = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitchLower", out pitchLowerexists);
            bool rollexists;
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);
            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);

            bool bShowInCockpitexists;
            bool bShowInCockpit = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bShowInCockpit", out bShowInCockpitexists);
            bool bHideInHangarexists;
            bool bHideInHangar = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bHideInHangar", out bHideInHangarexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            turretDataStructure result = new turretDataStructure(inParentDataFile, inXMLNode, turretID, turretOrientation, weaponFire, turretRole, yawPermitted, weaponPositionID, pitchLower, roll, yaw, pitch, bShowInCockpit, bHideInHangar, position);

            result.SetPropertyExists("turretID", turretIDexists);
            result.SetPropertyExists("turretOrientation", turretOrientationexists);
            result.SetPropertyExists("weaponFire", weaponFireexists);

            result.SetPropertyExists("turretRole", turretRoleexists);
            result.turretRole.CollectionChanged += result.OnturretRoleChanged;

            result.SetPropertyExists("yawPermitted", yawPermittedexists);
            result.SetPropertyExists("weaponPositionID", weaponPositionIDexists);

            result.SetPropertyExists("pitchLower", pitchLowerexists);
            result.SetPropertyExists("roll", rollexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExists("pitch", pitchexists);

            result.SetPropertyExists("bShowInCockpit", bShowInCockpitexists);
            result.SetPropertyExists("bHideInHangar", bHideInHangarexists);

            result.SetPropertyExists("position", positionexists);
            position.OnElementChanged += result.position_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'turret' data structures. 
        //Used for properties that are in a collection. See GetturretDataStructureFromXMLNodeNamedChild for a single 'turret' data structure.
        public static List<turretDataStructure> GetturretDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<turretDataStructure> result = new List<turretDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetturretDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'turret' data structure. 
        //Used for properties that are not in a collection. See GetturretDataStructureListFromXMLNodeNamedChildren for collections of 'turret' data structures.
        public static turretDataStructure GetturretDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            turretDataStructure result = new turretDataStructure(inParentDataFile, null);
            bool exists = false;
            List <turretDataStructure> results = GetturretDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'turret' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'turret' data structure
        public static List<turretDataStructure> GetturretDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("turret");
            List <turretDataStructure> result = new List<turretDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                turretDataStructure currentdata = DataStructureParseHelpers.GetturretDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'turret' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetturretDataStructureListFromVD2Data for a collection of 'turret' data structures
        public static turretDataStructure GetturretDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <turretDataStructure> results = GetturretDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            turretDataStructure result = new turretDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'attachment' data structure as a attachmentDataStructure.
        public static attachmentDataStructure GetattachmentDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool attachmentIDexists;
            string attachmentID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "attachmentID", out attachmentIDexists);
            bool attachmentOrientationexists;
            string attachmentOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "attachmentOrientation", out attachmentOrientationexists);

            bool attachmentPositionexists;
            Vector3D attachmentPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "attachmentPosition", out attachmentPositionexists);

            attachmentDataStructure result = new attachmentDataStructure(inParentDataFile, inXMLNode, attachmentID, attachmentOrientation, attachmentPosition);

            result.SetPropertyExists("attachmentID", attachmentIDexists);
            result.SetPropertyExists("attachmentOrientation", attachmentOrientationexists);

            result.SetPropertyExists("attachmentPosition", attachmentPositionexists);
            attachmentPosition.OnElementChanged += result.attachmentPosition_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'attachment' data structures. 
        //Used for properties that are in a collection. See GetattachmentDataStructureFromXMLNodeNamedChild for a single 'attachment' data structure.
        public static List<attachmentDataStructure> GetattachmentDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<attachmentDataStructure> result = new List<attachmentDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetattachmentDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'attachment' data structure. 
        //Used for properties that are not in a collection. See GetattachmentDataStructureListFromXMLNodeNamedChildren for collections of 'attachment' data structures.
        public static attachmentDataStructure GetattachmentDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            attachmentDataStructure result = new attachmentDataStructure(inParentDataFile, null);
            bool exists = false;
            List <attachmentDataStructure> results = GetattachmentDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'attachment' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'attachment' data structure
        public static List<attachmentDataStructure> GetattachmentDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("attachment");
            List <attachmentDataStructure> result = new List<attachmentDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                attachmentDataStructure currentdata = DataStructureParseHelpers.GetattachmentDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'attachment' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetattachmentDataStructureListFromVD2Data for a collection of 'attachment' data structures
        public static attachmentDataStructure GetattachmentDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <attachmentDataStructure> results = GetattachmentDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            attachmentDataStructure result = new attachmentDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'movingElement' data structure as a movingElementDataStructure.
        public static movingElementDataStructure GetmovingElementDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool boneNameexists;
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName", out boneNameexists);

            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool rollexists;
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);
            bool speedMultiplierexists;
            float speedMultiplier = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "speedMultiplier", out speedMultiplierexists);

            bool bLinkedToWeaponexists;
            bool bLinkedToWeapon = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bLinkedToWeapon", out bLinkedToWeaponexists);
            bool bCombatexists;
            bool bCombat = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bCombat", out bCombatexists);

            bool translateAmountexists;
            Vector3D translateAmount = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "translateAmount", out translateAmountexists);

            movingElementDataStructure result = new movingElementDataStructure(inParentDataFile, inXMLNode, boneName, yaw, pitch, roll, speedMultiplier, bLinkedToWeapon, bCombat, translateAmount);

            result.SetPropertyExists("boneName", boneNameexists);

            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExists("roll", rollexists);
            result.SetPropertyExists("speedMultiplier", speedMultiplierexists);

            result.SetPropertyExists("bLinkedToWeapon", bLinkedToWeaponexists);
            result.SetPropertyExists("bCombat", bCombatexists);

            result.SetPropertyExists("translateAmount", translateAmountexists);
            translateAmount.OnElementChanged += result.translateAmount_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'movingElement' data structures. 
        //Used for properties that are in a collection. See GetmovingElementDataStructureFromXMLNodeNamedChild for a single 'movingElement' data structure.
        public static List<movingElementDataStructure> GetmovingElementDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<movingElementDataStructure> result = new List<movingElementDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetmovingElementDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'movingElement' data structure. 
        //Used for properties that are not in a collection. See GetmovingElementDataStructureListFromXMLNodeNamedChildren for collections of 'movingElement' data structures.
        public static movingElementDataStructure GetmovingElementDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            movingElementDataStructure result = new movingElementDataStructure(inParentDataFile, null);
            bool exists = false;
            List <movingElementDataStructure> results = GetmovingElementDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'movingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'movingElement' data structure
        public static List<movingElementDataStructure> GetmovingElementDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("movingElement");
            List <movingElementDataStructure> result = new List<movingElementDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                movingElementDataStructure currentdata = DataStructureParseHelpers.GetmovingElementDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'movingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmovingElementDataStructureListFromVD2Data for a collection of 'movingElement' data structures
        public static movingElementDataStructure GetmovingElementDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <movingElementDataStructure> results = GetmovingElementDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            movingElementDataStructure result = new movingElementDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'dock' data structure as a dockDataStructure.
        public static dockDataStructure GetdockDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool dockTypeexists;
            string dockType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "dockType", out dockTypeexists);
            bool ejectOrientationexists;
            string ejectOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "ejectOrientation", out ejectOrientationexists);
            bool objectIDexists;
            string objectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "objectID", out objectIDexists);
            bool orientationexists;
            string orientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "orientation", out orientationexists);
            bool attachedIDexists;
            string attachedID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "attachedID", out attachedIDexists);
            bool boneNameexists;
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName", out boneNameexists);
            bool dockOrientationexists;
            string dockOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "dockOrientation", out dockOrientationexists);
            bool resourceOnlyexists;
            string resourceOnly = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "resourceOnly", out resourceOnlyexists);

            bool ejectVelocityexists;
            int ejectVelocity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "ejectVelocity", out ejectVelocityexists);
            bool dockRollOffsetexists;
            int dockRollOffset = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "dockRollOffset", out dockRollOffsetexists);
            bool dockYawOffsetexists;
            int dockYawOffset = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "dockYawOffset", out dockYawOffsetexists);

            bool bCanAcceptRawResourceexists;
            bool bCanAcceptRawResource = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bCanAcceptRawResource", out bCanAcceptRawResourceexists);
            bool bInvisibleexists;
            bool bInvisible = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bInvisible", out bInvisibleexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            dockDataStructure result = new dockDataStructure(inParentDataFile, inXMLNode, dockType, ejectOrientation, objectID, orientation, attachedID, boneName, dockOrientation, resourceOnly, ejectVelocity, dockRollOffset, dockYawOffset, bCanAcceptRawResource, bInvisible, position);

            result.SetPropertyExists("dockType", dockTypeexists);
            result.SetPropertyExists("ejectOrientation", ejectOrientationexists);
            result.SetPropertyExists("objectID", objectIDexists);
            result.SetPropertyExists("orientation", orientationexists);
            result.SetPropertyExists("attachedID", attachedIDexists);
            result.SetPropertyExists("boneName", boneNameexists);
            result.SetPropertyExists("dockOrientation", dockOrientationexists);
            result.SetPropertyExists("resourceOnly", resourceOnlyexists);

            result.SetPropertyExists("ejectVelocity", ejectVelocityexists);
            result.SetPropertyExists("dockRollOffset", dockRollOffsetexists);
            result.SetPropertyExists("dockYawOffset", dockYawOffsetexists);

            result.SetPropertyExists("bCanAcceptRawResource", bCanAcceptRawResourceexists);
            result.SetPropertyExists("bInvisible", bInvisibleexists);

            result.SetPropertyExists("position", positionexists);
            position.OnElementChanged += result.position_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'dock' data structures. 
        //Used for properties that are in a collection. See GetdockDataStructureFromXMLNodeNamedChild for a single 'dock' data structure.
        public static List<dockDataStructure> GetdockDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<dockDataStructure> result = new List<dockDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetdockDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'dock' data structure. 
        //Used for properties that are not in a collection. See GetdockDataStructureListFromXMLNodeNamedChildren for collections of 'dock' data structures.
        public static dockDataStructure GetdockDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            dockDataStructure result = new dockDataStructure(inParentDataFile, null);
            bool exists = false;
            List <dockDataStructure> results = GetdockDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'dock' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'dock' data structure
        public static List<dockDataStructure> GetdockDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("dock");
            List <dockDataStructure> result = new List<dockDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                dockDataStructure currentdata = DataStructureParseHelpers.GetdockDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'dock' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdockDataStructureListFromVD2Data for a collection of 'dock' data structures
        public static dockDataStructure GetdockDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <dockDataStructure> results = GetdockDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            dockDataStructure result = new dockDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'shield' data structure as a shieldDataStructure.
        public static shieldDataStructure GetshieldDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool shieldIDexists;
            string shieldID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "shieldID", out shieldIDexists);
            bool shieldOrientationexists;
            string shieldOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "shieldOrientation", out shieldOrientationexists);

            bool pitchexists;
            int pitch = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool rollexists;
            int roll = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);

            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);

            bool shieldPositionexists;
            Vector3D shieldPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "shieldPosition", out shieldPositionexists);

            shieldDataStructure result = new shieldDataStructure(inParentDataFile, inXMLNode, shieldID, shieldOrientation, pitch, roll, yaw, shieldPosition);

            result.SetPropertyExists("shieldID", shieldIDexists);
            result.SetPropertyExists("shieldOrientation", shieldOrientationexists);

            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExists("roll", rollexists);

            result.SetPropertyExists("yaw", yawexists);

            result.SetPropertyExists("shieldPosition", shieldPositionexists);
            shieldPosition.OnElementChanged += result.shieldPosition_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'shield' data structures. 
        //Used for properties that are in a collection. See GetshieldDataStructureFromXMLNodeNamedChild for a single 'shield' data structure.
        public static List<shieldDataStructure> GetshieldDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<shieldDataStructure> result = new List<shieldDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetshieldDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'shield' data structure. 
        //Used for properties that are not in a collection. See GetshieldDataStructureListFromXMLNodeNamedChildren for collections of 'shield' data structures.
        public static shieldDataStructure GetshieldDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            shieldDataStructure result = new shieldDataStructure(inParentDataFile, null);
            bool exists = false;
            List <shieldDataStructure> results = GetshieldDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'shield' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'shield' data structure
        public static List<shieldDataStructure> GetshieldDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("shield");
            List <shieldDataStructure> result = new List<shieldDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                shieldDataStructure currentdata = DataStructureParseHelpers.GetshieldDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'shield' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetshieldDataStructureListFromVD2Data for a collection of 'shield' data structures
        public static shieldDataStructure GetshieldDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <shieldDataStructure> results = GetshieldDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            shieldDataStructure result = new shieldDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'rotatingElement' data structure as a rotatingElementDataStructure.
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool boneNameexists;
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName", out boneNameexists);

            bool rollSpeedexists;
            int rollSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollSpeed", out rollSpeedexists);

            bool bLinkedToWeaponexists;
            bool bLinkedToWeapon = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bLinkedToWeapon", out bLinkedToWeaponexists);

            rotatingElementDataStructure result = new rotatingElementDataStructure(inParentDataFile, inXMLNode, boneName, rollSpeed, bLinkedToWeapon);

            result.SetPropertyExists("boneName", boneNameexists);

            result.SetPropertyExists("rollSpeed", rollSpeedexists);

            result.SetPropertyExists("bLinkedToWeapon", bLinkedToWeaponexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'rotatingElement' data structures. 
        //Used for properties that are in a collection. See GetrotatingElementDataStructureFromXMLNodeNamedChild for a single 'rotatingElement' data structure.
        public static List<rotatingElementDataStructure> GetrotatingElementDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<rotatingElementDataStructure> result = new List<rotatingElementDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetrotatingElementDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'rotatingElement' data structure. 
        //Used for properties that are not in a collection. See GetrotatingElementDataStructureListFromXMLNodeNamedChildren for collections of 'rotatingElement' data structures.
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            rotatingElementDataStructure result = new rotatingElementDataStructure(inParentDataFile, null);
            bool exists = false;
            List <rotatingElementDataStructure> results = GetrotatingElementDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'rotatingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'rotatingElement' data structure
        public static List<rotatingElementDataStructure> GetrotatingElementDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("rotatingElement");
            List <rotatingElementDataStructure> result = new List<rotatingElementDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                rotatingElementDataStructure currentdata = DataStructureParseHelpers.GetrotatingElementDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'rotatingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrotatingElementDataStructureListFromVD2Data for a collection of 'rotatingElement' data structures
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <rotatingElementDataStructure> results = GetrotatingElementDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            rotatingElementDataStructure result = new rotatingElementDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'recoil' data structure as a recoilDataStructure.
        public static recoilDataStructure GetrecoilDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool recoilBoneexists;
            string recoilBone = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "recoilBone", out recoilBoneexists);
            bool muzzleBoneNameexists;
            string muzzleBoneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "muzzleBoneName", out muzzleBoneNameexists);
            bool recoilParentTypeexists;
            string recoilParentType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "recoilParentType", out recoilParentTypeexists);

            bool muzzleBoneexists;
            List<string> muzzleBone = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "muzzleBone", out muzzleBoneexists);

            bool recoilZexists;
            float recoilZ = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "recoilZ", out recoilZexists);
            bool recoilTimeexists;
            float recoilTime = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "recoilTime", out recoilTimeexists);

            recoilDataStructure result = new recoilDataStructure(inParentDataFile, inXMLNode, recoilBone, muzzleBoneName, recoilParentType, muzzleBone, recoilZ, recoilTime);

            result.SetPropertyExists("recoilBone", recoilBoneexists);
            result.SetPropertyExists("muzzleBoneName", muzzleBoneNameexists);
            result.SetPropertyExists("recoilParentType", recoilParentTypeexists);

            result.SetPropertyExists("muzzleBone", muzzleBoneexists);
            result.muzzleBone.CollectionChanged += result.OnmuzzleBoneChanged;

            result.SetPropertyExists("recoilZ", recoilZexists);
            result.SetPropertyExists("recoilTime", recoilTimeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'recoil' data structures. 
        //Used for properties that are in a collection. See GetrecoilDataStructureFromXMLNodeNamedChild for a single 'recoil' data structure.
        public static List<recoilDataStructure> GetrecoilDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<recoilDataStructure> result = new List<recoilDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetrecoilDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'recoil' data structure. 
        //Used for properties that are not in a collection. See GetrecoilDataStructureListFromXMLNodeNamedChildren for collections of 'recoil' data structures.
        public static recoilDataStructure GetrecoilDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            recoilDataStructure result = new recoilDataStructure(inParentDataFile, null);
            bool exists = false;
            List <recoilDataStructure> results = GetrecoilDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'recoil' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'recoil' data structure
        public static List<recoilDataStructure> GetrecoilDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("recoil");
            List <recoilDataStructure> result = new List<recoilDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                recoilDataStructure currentdata = DataStructureParseHelpers.GetrecoilDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'recoil' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrecoilDataStructureListFromVD2Data for a collection of 'recoil' data structures
        public static recoilDataStructure GetrecoilDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <recoilDataStructure> results = GetrecoilDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            recoilDataStructure result = new recoilDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'rotateBones' data structure as a rotateBonesDataStructure.
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool rotateBoneexists;
            List<string> rotateBone = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "rotateBone", out rotateBoneexists);

            rotateBonesDataStructure result = new rotateBonesDataStructure(inParentDataFile, inXMLNode, rotateBone);

            result.SetPropertyExists("rotateBone", rotateBoneexists);
            result.rotateBone.CollectionChanged += result.OnrotateBoneChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'rotateBones' data structures. 
        //Used for properties that are in a collection. See GetrotateBonesDataStructureFromXMLNodeNamedChild for a single 'rotateBones' data structure.
        public static List<rotateBonesDataStructure> GetrotateBonesDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<rotateBonesDataStructure> result = new List<rotateBonesDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetrotateBonesDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'rotateBones' data structure. 
        //Used for properties that are not in a collection. See GetrotateBonesDataStructureListFromXMLNodeNamedChildren for collections of 'rotateBones' data structures.
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            rotateBonesDataStructure result = new rotateBonesDataStructure(inParentDataFile, null);
            bool exists = false;
            List <rotateBonesDataStructure> results = GetrotateBonesDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'rotateBones' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'rotateBones' data structure
        public static List<rotateBonesDataStructure> GetrotateBonesDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("rotateBones");
            List <rotateBonesDataStructure> result = new List<rotateBonesDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                rotateBonesDataStructure currentdata = DataStructureParseHelpers.GetrotateBonesDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'rotateBones' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrotateBonesDataStructureListFromVD2Data for a collection of 'rotateBones' data structures
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <rotateBonesDataStructure> results = GetrotateBonesDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            rotateBonesDataStructure result = new rotateBonesDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'canister' data structure as a canisterDataStructure.
        public static canisterDataStructure GetcanisterDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool projectileIDexists;
            string projectileID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "projectileID", out projectileIDexists);

            bool canisterCountexists;
            int canisterCount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "canisterCount", out canisterCountexists);
            bool blowBackCanisterCountexists;
            int blowBackCanisterCount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "blowBackCanisterCount", out blowBackCanisterCountexists);
            bool yawRangeexists;
            int yawRange = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "yawRange", out yawRangeexists);
            bool pitchRangeexists;
            int pitchRange = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "pitchRange", out pitchRangeexists);
            bool rollRangeexists;
            int rollRange = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollRange", out rollRangeexists);
            bool speedAddBaseexists;
            int speedAddBase = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "speedAddBase", out speedAddBaseexists);
            bool speedAddRandomexists;
            int speedAddRandom = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "speedAddRandom", out speedAddRandomexists);

            bool bCanisterAimAssistexists;
            bool bCanisterAimAssist = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bCanisterAimAssist", out bCanisterAimAssistexists);
            bool bAddToRangeCalculationsexists;
            bool bAddToRangeCalculations = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bAddToRangeCalculations", out bAddToRangeCalculationsexists);

            canisterDataStructure result = new canisterDataStructure(inParentDataFile, inXMLNode, projectileID, canisterCount, blowBackCanisterCount, yawRange, pitchRange, rollRange, speedAddBase, speedAddRandom, bCanisterAimAssist, bAddToRangeCalculations);

            result.SetPropertyExists("projectileID", projectileIDexists);

            result.SetPropertyExists("canisterCount", canisterCountexists);
            result.SetPropertyExists("blowBackCanisterCount", blowBackCanisterCountexists);
            result.SetPropertyExists("yawRange", yawRangeexists);
            result.SetPropertyExists("pitchRange", pitchRangeexists);
            result.SetPropertyExists("rollRange", rollRangeexists);
            result.SetPropertyExists("speedAddBase", speedAddBaseexists);
            result.SetPropertyExists("speedAddRandom", speedAddRandomexists);

            result.SetPropertyExists("bCanisterAimAssist", bCanisterAimAssistexists);
            result.SetPropertyExists("bAddToRangeCalculations", bAddToRangeCalculationsexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'canister' data structures. 
        //Used for properties that are in a collection. See GetcanisterDataStructureFromXMLNodeNamedChild for a single 'canister' data structure.
        public static List<canisterDataStructure> GetcanisterDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<canisterDataStructure> result = new List<canisterDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetcanisterDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'canister' data structure. 
        //Used for properties that are not in a collection. See GetcanisterDataStructureListFromXMLNodeNamedChildren for collections of 'canister' data structures.
        public static canisterDataStructure GetcanisterDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            canisterDataStructure result = new canisterDataStructure(inParentDataFile, null);
            bool exists = false;
            List <canisterDataStructure> results = GetcanisterDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'canister' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'canister' data structure
        public static List<canisterDataStructure> GetcanisterDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("canister");
            List <canisterDataStructure> result = new List<canisterDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                canisterDataStructure currentdata = DataStructureParseHelpers.GetcanisterDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'canister' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetcanisterDataStructureListFromVD2Data for a collection of 'canister' data structures
        public static canisterDataStructure GetcanisterDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <canisterDataStructure> results = GetcanisterDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            canisterDataStructure result = new canisterDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'launchTube' data structure as a launchTubeDataStructure.
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool directionexists;
            string direction = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "direction", out directionexists);

            bool launchDeckBegexists;
            Vector3D launchDeckBeg = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "launchDeckBeg", out launchDeckBegexists);
            bool launchDeckEndexists;
            Vector3D launchDeckEnd = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "launchDeckEnd", out launchDeckEndexists);
            bool dockPositionexists;
            Vector3D dockPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockPosition", out dockPositionexists);
            bool dockSizeexists;
            Vector3D dockSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockSize", out dockSizeexists);

            launchTubeDataStructure result = new launchTubeDataStructure(inParentDataFile, inXMLNode, direction, launchDeckBeg, launchDeckEnd, dockPosition, dockSize);

            result.SetPropertyExists("direction", directionexists);

            result.SetPropertyExists("launchDeckBeg", launchDeckBegexists);
            launchDeckBeg.OnElementChanged += result.launchDeckBeg_OnElementChanged;
            result.SetPropertyExists("launchDeckEnd", launchDeckEndexists);
            launchDeckEnd.OnElementChanged += result.launchDeckEnd_OnElementChanged;
            result.SetPropertyExists("dockPosition", dockPositionexists);
            dockPosition.OnElementChanged += result.dockPosition_OnElementChanged;
            result.SetPropertyExists("dockSize", dockSizeexists);
            dockSize.OnElementChanged += result.dockSize_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'launchTube' data structures. 
        //Used for properties that are in a collection. See GetlaunchTubeDataStructureFromXMLNodeNamedChild for a single 'launchTube' data structure.
        public static List<launchTubeDataStructure> GetlaunchTubeDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<launchTubeDataStructure> result = new List<launchTubeDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetlaunchTubeDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'launchTube' data structure. 
        //Used for properties that are not in a collection. See GetlaunchTubeDataStructureListFromXMLNodeNamedChildren for collections of 'launchTube' data structures.
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            launchTubeDataStructure result = new launchTubeDataStructure(inParentDataFile, null);
            bool exists = false;
            List <launchTubeDataStructure> results = GetlaunchTubeDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'launchTube' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'launchTube' data structure
        public static List<launchTubeDataStructure> GetlaunchTubeDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("launchTube");
            List <launchTubeDataStructure> result = new List<launchTubeDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                launchTubeDataStructure currentdata = DataStructureParseHelpers.GetlaunchTubeDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'launchTube' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetlaunchTubeDataStructureListFromVD2Data for a collection of 'launchTube' data structures
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <launchTubeDataStructure> results = GetlaunchTubeDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            launchTubeDataStructure result = new launchTubeDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'mirv' data structure as a mirvDataStructure.
        public static mirvDataStructure GetmirvDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool mirvObjectIDexists;
            string mirvObjectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mirvObjectID", out mirvObjectIDexists);

            bool mirvCountexists;
            int mirvCount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "mirvCount", out mirvCountexists);

            bool bNoExplodeOnMirvexists;
            bool bNoExplodeOnMirv = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bNoExplodeOnMirv", out bNoExplodeOnMirvexists);

            mirvDataStructure result = new mirvDataStructure(inParentDataFile, inXMLNode, mirvObjectID, mirvCount, bNoExplodeOnMirv);

            result.SetPropertyExists("mirvObjectID", mirvObjectIDexists);

            result.SetPropertyExists("mirvCount", mirvCountexists);

            result.SetPropertyExists("bNoExplodeOnMirv", bNoExplodeOnMirvexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'mirv' data structures. 
        //Used for properties that are in a collection. See GetmirvDataStructureFromXMLNodeNamedChild for a single 'mirv' data structure.
        public static List<mirvDataStructure> GetmirvDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<mirvDataStructure> result = new List<mirvDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetmirvDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'mirv' data structure. 
        //Used for properties that are not in a collection. See GetmirvDataStructureListFromXMLNodeNamedChildren for collections of 'mirv' data structures.
        public static mirvDataStructure GetmirvDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            mirvDataStructure result = new mirvDataStructure(inParentDataFile, null);
            bool exists = false;
            List <mirvDataStructure> results = GetmirvDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'mirv' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'mirv' data structure
        public static List<mirvDataStructure> GetmirvDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("mirv");
            List <mirvDataStructure> result = new List<mirvDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                mirvDataStructure currentdata = DataStructureParseHelpers.GetmirvDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'mirv' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmirvDataStructureListFromVD2Data for a collection of 'mirv' data structures
        public static mirvDataStructure GetmirvDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <mirvDataStructure> results = GetmirvDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            mirvDataStructure result = new mirvDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'weaponDirection' data structure as a weaponDirectionDataStructure.
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool mainDirectionexists;
            string mainDirection = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mainDirection", out mainDirectionexists);

            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool rollexists;
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);

            weaponDirectionDataStructure result = new weaponDirectionDataStructure(inParentDataFile, inXMLNode, mainDirection, yaw, pitch, roll);

            result.SetPropertyExists("mainDirection", mainDirectionexists);

            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExists("roll", rollexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'weaponDirection' data structures. 
        //Used for properties that are in a collection. See GetweaponDirectionDataStructureFromXMLNodeNamedChild for a single 'weaponDirection' data structure.
        public static List<weaponDirectionDataStructure> GetweaponDirectionDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<weaponDirectionDataStructure> result = new List<weaponDirectionDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetweaponDirectionDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'weaponDirection' data structure. 
        //Used for properties that are not in a collection. See GetweaponDirectionDataStructureListFromXMLNodeNamedChildren for collections of 'weaponDirection' data structures.
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            weaponDirectionDataStructure result = new weaponDirectionDataStructure(inParentDataFile, null);
            bool exists = false;
            List <weaponDirectionDataStructure> results = GetweaponDirectionDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'weaponDirection' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'weaponDirection' data structure
        public static List<weaponDirectionDataStructure> GetweaponDirectionDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("weaponDirection");
            List <weaponDirectionDataStructure> result = new List<weaponDirectionDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                weaponDirectionDataStructure currentdata = DataStructureParseHelpers.GetweaponDirectionDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'weaponDirection' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetweaponDirectionDataStructureListFromVD2Data for a collection of 'weaponDirection' data structures
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <weaponDirectionDataStructure> results = GetweaponDirectionDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            weaponDirectionDataStructure result = new weaponDirectionDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'turretBarrel' data structure as a turretBarrelDataStructure.
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool boneNameexists;
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName", out boneNameexists);

            bool weaponPositionexists;
            Vector3D weaponPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "weaponPosition", out weaponPositionexists);

            turretBarrelDataStructure result = new turretBarrelDataStructure(inParentDataFile, inXMLNode, boneName, weaponPosition);

            result.SetPropertyExists("boneName", boneNameexists);

            result.SetPropertyExists("weaponPosition", weaponPositionexists);
            weaponPosition.OnElementChanged += result.weaponPosition_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'turretBarrel' data structures. 
        //Used for properties that are in a collection. See GetturretBarrelDataStructureFromXMLNodeNamedChild for a single 'turretBarrel' data structure.
        public static List<turretBarrelDataStructure> GetturretBarrelDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<turretBarrelDataStructure> result = new List<turretBarrelDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetturretBarrelDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'turretBarrel' data structure. 
        //Used for properties that are not in a collection. See GetturretBarrelDataStructureListFromXMLNodeNamedChildren for collections of 'turretBarrel' data structures.
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            turretBarrelDataStructure result = new turretBarrelDataStructure(inParentDataFile, null);
            bool exists = false;
            List <turretBarrelDataStructure> results = GetturretBarrelDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'turretBarrel' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'turretBarrel' data structure
        public static List<turretBarrelDataStructure> GetturretBarrelDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("turretBarrel");
            List <turretBarrelDataStructure> result = new List<turretBarrelDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                turretBarrelDataStructure currentdata = DataStructureParseHelpers.GetturretBarrelDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'turretBarrel' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetturretBarrelDataStructureListFromVD2Data for a collection of 'turretBarrel' data structures
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <turretBarrelDataStructure> results = GetturretBarrelDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            turretBarrelDataStructure result = new turretBarrelDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'deathSpawn' data structure as a deathSpawnDataStructure.
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool asteroidIDexists;
            List<string> asteroidID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "asteroidID", out asteroidIDexists);

            deathSpawnDataStructure result = new deathSpawnDataStructure(inParentDataFile, inXMLNode, asteroidID);

            result.SetPropertyExists("asteroidID", asteroidIDexists);
            result.asteroidID.CollectionChanged += result.OnasteroidIDChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'deathSpawn' data structures. 
        //Used for properties that are in a collection. See GetdeathSpawnDataStructureFromXMLNodeNamedChild for a single 'deathSpawn' data structure.
        public static List<deathSpawnDataStructure> GetdeathSpawnDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<deathSpawnDataStructure> result = new List<deathSpawnDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetdeathSpawnDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'deathSpawn' data structure. 
        //Used for properties that are not in a collection. See GetdeathSpawnDataStructureListFromXMLNodeNamedChildren for collections of 'deathSpawn' data structures.
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            deathSpawnDataStructure result = new deathSpawnDataStructure(inParentDataFile, null);
            bool exists = false;
            List <deathSpawnDataStructure> results = GetdeathSpawnDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'deathSpawn' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'deathSpawn' data structure
        public static List<deathSpawnDataStructure> GetdeathSpawnDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("deathSpawn");
            List <deathSpawnDataStructure> result = new List<deathSpawnDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                deathSpawnDataStructure currentdata = DataStructureParseHelpers.GetdeathSpawnDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'deathSpawn' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdeathSpawnDataStructureListFromVD2Data for a collection of 'deathSpawn' data structures
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <deathSpawnDataStructure> results = GetdeathSpawnDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            deathSpawnDataStructure result = new deathSpawnDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'baby' data structure as a babyDataStructure.
        public static babyDataStructure GetbabyDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool asteroidIDexists;
            string asteroidID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "asteroidID", out asteroidIDexists);

            bool lifeTimerexists;
            float lifeTimer = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "lifeTimer", out lifeTimerexists);

            bool linearVelocityexists;
            Vector3D linearVelocity = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "linearVelocity", out linearVelocityexists);

            babyDataStructure result = new babyDataStructure(inParentDataFile, inXMLNode, asteroidID, lifeTimer, linearVelocity);

            result.SetPropertyExists("asteroidID", asteroidIDexists);

            result.SetPropertyExists("lifeTimer", lifeTimerexists);

            result.SetPropertyExists("linearVelocity", linearVelocityexists);
            linearVelocity.OnElementChanged += result.linearVelocity_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'baby' data structures. 
        //Used for properties that are in a collection. See GetbabyDataStructureFromXMLNodeNamedChild for a single 'baby' data structure.
        public static List<babyDataStructure> GetbabyDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<babyDataStructure> result = new List<babyDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetbabyDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'baby' data structure. 
        //Used for properties that are not in a collection. See GetbabyDataStructureListFromXMLNodeNamedChildren for collections of 'baby' data structures.
        public static babyDataStructure GetbabyDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            babyDataStructure result = new babyDataStructure(inParentDataFile, null);
            bool exists = false;
            List <babyDataStructure> results = GetbabyDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'baby' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'baby' data structure
        public static List<babyDataStructure> GetbabyDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("baby");
            List <babyDataStructure> result = new List<babyDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                babyDataStructure currentdata = DataStructureParseHelpers.GetbabyDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'baby' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetbabyDataStructureListFromVD2Data for a collection of 'baby' data structures
        public static babyDataStructure GetbabyDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <babyDataStructure> results = GetbabyDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            babyDataStructure result = new babyDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'largeDock' data structure as a largeDockDataStructure.
        public static largeDockDataStructure GetlargeDockDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool rollRotationexists;
            int rollRotation = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollRotation", out rollRotationexists);

            bool dockPositionexists;
            Vector3D dockPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockPosition", out dockPositionexists);
            bool dockSizeexists;
            Vector3D dockSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockSize", out dockSizeexists);

            largeDockDataStructure result = new largeDockDataStructure(inParentDataFile, inXMLNode, rollRotation, dockPosition, dockSize);

            result.SetPropertyExists("rollRotation", rollRotationexists);

            result.SetPropertyExists("dockPosition", dockPositionexists);
            dockPosition.OnElementChanged += result.dockPosition_OnElementChanged;
            result.SetPropertyExists("dockSize", dockSizeexists);
            dockSize.OnElementChanged += result.dockSize_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'largeDock' data structures. 
        //Used for properties that are in a collection. See GetlargeDockDataStructureFromXMLNodeNamedChild for a single 'largeDock' data structure.
        public static List<largeDockDataStructure> GetlargeDockDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<largeDockDataStructure> result = new List<largeDockDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetlargeDockDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'largeDock' data structure. 
        //Used for properties that are not in a collection. See GetlargeDockDataStructureListFromXMLNodeNamedChildren for collections of 'largeDock' data structures.
        public static largeDockDataStructure GetlargeDockDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            largeDockDataStructure result = new largeDockDataStructure(inParentDataFile, null);
            bool exists = false;
            List <largeDockDataStructure> results = GetlargeDockDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'largeDock' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'largeDock' data structure
        public static List<largeDockDataStructure> GetlargeDockDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("largeDock");
            List <largeDockDataStructure> result = new List<largeDockDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                largeDockDataStructure currentdata = DataStructureParseHelpers.GetlargeDockDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'largeDock' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetlargeDockDataStructureListFromVD2Data for a collection of 'largeDock' data structures
        public static largeDockDataStructure GetlargeDockDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <largeDockDataStructure> results = GetlargeDockDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            largeDockDataStructure result = new largeDockDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'physicalRotatingElement' data structure as a physicalRotatingElementDataStructure.
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool meshNameexists;
            string meshName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "meshName", out meshNameexists);
            bool collisionShapeexists;
            string collisionShape = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "collisionShape", out collisionShapeexists);

            bool rollSpeedexists;
            int rollSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollSpeed", out rollSpeedexists);
            bool yawSpeedexists;
            int yawSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "yawSpeed", out yawSpeedexists);
            bool pitchSpeedexists;
            int pitchSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "pitchSpeed", out pitchSpeedexists);

            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure(inParentDataFile, inXMLNode, meshName, collisionShape, rollSpeed, yawSpeed, pitchSpeed);

            result.SetPropertyExists("meshName", meshNameexists);
            result.SetPropertyExists("collisionShape", collisionShapeexists);

            result.SetPropertyExists("rollSpeed", rollSpeedexists);
            result.SetPropertyExists("yawSpeed", yawSpeedexists);
            result.SetPropertyExists("pitchSpeed", pitchSpeedexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'physicalRotatingElement' data structures. 
        //Used for properties that are in a collection. See GetphysicalRotatingElementDataStructureFromXMLNodeNamedChild for a single 'physicalRotatingElement' data structure.
        public static List<physicalRotatingElementDataStructure> GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<physicalRotatingElementDataStructure> result = new List<physicalRotatingElementDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetphysicalRotatingElementDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'physicalRotatingElement' data structure. 
        //Used for properties that are not in a collection. See GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren for collections of 'physicalRotatingElement' data structures.
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure(inParentDataFile, null);
            bool exists = false;
            List <physicalRotatingElementDataStructure> results = GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'physicalRotatingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'physicalRotatingElement' data structure
        public static List<physicalRotatingElementDataStructure> GetphysicalRotatingElementDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("physicalRotatingElement");
            List <physicalRotatingElementDataStructure> result = new List<physicalRotatingElementDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                physicalRotatingElementDataStructure currentdata = DataStructureParseHelpers.GetphysicalRotatingElementDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'physicalRotatingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetphysicalRotatingElementDataStructureListFromVD2Data for a collection of 'physicalRotatingElement' data structures
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <physicalRotatingElementDataStructure> results = GetphysicalRotatingElementDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'alwaysOnEffect' data structure as a alwaysOnEffectDataStructure.
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool effectIDexists;
            string effectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "effectID", out effectIDexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure(inParentDataFile, inXMLNode, effectID, position);

            result.SetPropertyExists("effectID", effectIDexists);

            result.SetPropertyExists("position", positionexists);
            position.OnElementChanged += result.position_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'alwaysOnEffect' data structures. 
        //Used for properties that are in a collection. See GetalwaysOnEffectDataStructureFromXMLNodeNamedChild for a single 'alwaysOnEffect' data structure.
        public static List<alwaysOnEffectDataStructure> GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<alwaysOnEffectDataStructure> result = new List<alwaysOnEffectDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetalwaysOnEffectDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'alwaysOnEffect' data structure. 
        //Used for properties that are not in a collection. See GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren for collections of 'alwaysOnEffect' data structures.
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure(inParentDataFile, null);
            bool exists = false;
            List <alwaysOnEffectDataStructure> results = GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'alwaysOnEffect' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'alwaysOnEffect' data structure
        public static List<alwaysOnEffectDataStructure> GetalwaysOnEffectDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("alwaysOnEffect");
            List <alwaysOnEffectDataStructure> result = new List<alwaysOnEffectDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                alwaysOnEffectDataStructure currentdata = DataStructureParseHelpers.GetalwaysOnEffectDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'alwaysOnEffect' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetalwaysOnEffectDataStructureListFromVD2Data for a collection of 'alwaysOnEffect' data structures
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <alwaysOnEffectDataStructure> results = GetalwaysOnEffectDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'cargoBay' data structure as a cargoBayDataStructure.
        public static cargoBayDataStructure GetcargoBayDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool cargoBayTypeexists;
            string cargoBayType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "cargoBayType", out cargoBayTypeexists);

            bool maxAmountexists;
            int maxAmount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "maxAmount", out maxAmountexists);

            cargoBayDataStructure result = new cargoBayDataStructure(inParentDataFile, inXMLNode, cargoBayType, maxAmount);

            result.SetPropertyExists("cargoBayType", cargoBayTypeexists);

            result.SetPropertyExists("maxAmount", maxAmountexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'cargoBay' data structures. 
        //Used for properties that are in a collection. See GetcargoBayDataStructureFromXMLNodeNamedChild for a single 'cargoBay' data structure.
        public static List<cargoBayDataStructure> GetcargoBayDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<cargoBayDataStructure> result = new List<cargoBayDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetcargoBayDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'cargoBay' data structure. 
        //Used for properties that are not in a collection. See GetcargoBayDataStructureListFromXMLNodeNamedChildren for collections of 'cargoBay' data structures.
        public static cargoBayDataStructure GetcargoBayDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            cargoBayDataStructure result = new cargoBayDataStructure(inParentDataFile, null);
            bool exists = false;
            List <cargoBayDataStructure> results = GetcargoBayDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'cargoBay' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'cargoBay' data structure
        public static List<cargoBayDataStructure> GetcargoBayDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("cargoBay");
            List <cargoBayDataStructure> result = new List<cargoBayDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                cargoBayDataStructure currentdata = DataStructureParseHelpers.GetcargoBayDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'cargoBay' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetcargoBayDataStructureListFromVD2Data for a collection of 'cargoBay' data structures
        public static cargoBayDataStructure GetcargoBayDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <cargoBayDataStructure> results = GetcargoBayDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            cargoBayDataStructure result = new cargoBayDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'gateCollision' data structure as a gateCollisionDataStructure.
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool gateCollisionSizeexists;
            Vector3D gateCollisionSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "gateCollisionSize", out gateCollisionSizeexists);

            gateCollisionDataStructure result = new gateCollisionDataStructure(inParentDataFile, inXMLNode, gateCollisionSize);

            result.SetPropertyExists("gateCollisionSize", gateCollisionSizeexists);
            gateCollisionSize.OnElementChanged += result.gateCollisionSize_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'gateCollision' data structures. 
        //Used for properties that are in a collection. See GetgateCollisionDataStructureFromXMLNodeNamedChild for a single 'gateCollision' data structure.
        public static List<gateCollisionDataStructure> GetgateCollisionDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<gateCollisionDataStructure> result = new List<gateCollisionDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetgateCollisionDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'gateCollision' data structure. 
        //Used for properties that are not in a collection. See GetgateCollisionDataStructureListFromXMLNodeNamedChildren for collections of 'gateCollision' data structures.
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            gateCollisionDataStructure result = new gateCollisionDataStructure(inParentDataFile, null);
            bool exists = false;
            List <gateCollisionDataStructure> results = GetgateCollisionDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'gateCollision' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'gateCollision' data structure
        public static List<gateCollisionDataStructure> GetgateCollisionDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("gateCollision");
            List <gateCollisionDataStructure> result = new List<gateCollisionDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                gateCollisionDataStructure currentdata = DataStructureParseHelpers.GetgateCollisionDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'gateCollision' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetgateCollisionDataStructureListFromVD2Data for a collection of 'gateCollision' data structures
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <gateCollisionDataStructure> results = GetgateCollisionDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            gateCollisionDataStructure result = new gateCollisionDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'refuelArea' data structure as a refuelAreaDataStructure.
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool refuelParticleSystemexists;
            string refuelParticleSystem = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "refuelParticleSystem", out refuelParticleSystemexists);

            bool refuelPositionexists;
            Vector3D refuelPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "refuelPosition", out refuelPositionexists);
            bool refuelSizeexists;
            Vector3D refuelSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "refuelSize", out refuelSizeexists);

            refuelAreaDataStructure result = new refuelAreaDataStructure(inParentDataFile, inXMLNode, refuelParticleSystem, refuelPosition, refuelSize);

            result.SetPropertyExists("refuelParticleSystem", refuelParticleSystemexists);

            result.SetPropertyExists("refuelPosition", refuelPositionexists);
            refuelPosition.OnElementChanged += result.refuelPosition_OnElementChanged;
            result.SetPropertyExists("refuelSize", refuelSizeexists);
            refuelSize.OnElementChanged += result.refuelSize_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'refuelArea' data structures. 
        //Used for properties that are in a collection. See GetrefuelAreaDataStructureFromXMLNodeNamedChild for a single 'refuelArea' data structure.
        public static List<refuelAreaDataStructure> GetrefuelAreaDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<refuelAreaDataStructure> result = new List<refuelAreaDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetrefuelAreaDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'refuelArea' data structure. 
        //Used for properties that are not in a collection. See GetrefuelAreaDataStructureListFromXMLNodeNamedChildren for collections of 'refuelArea' data structures.
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            refuelAreaDataStructure result = new refuelAreaDataStructure(inParentDataFile, null);
            bool exists = false;
            List <refuelAreaDataStructure> results = GetrefuelAreaDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'refuelArea' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'refuelArea' data structure
        public static List<refuelAreaDataStructure> GetrefuelAreaDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("refuelArea");
            List <refuelAreaDataStructure> result = new List<refuelAreaDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                refuelAreaDataStructure currentdata = DataStructureParseHelpers.GetrefuelAreaDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'refuelArea' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrefuelAreaDataStructureListFromVD2Data for a collection of 'refuelArea' data structures
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <refuelAreaDataStructure> results = GetrefuelAreaDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            refuelAreaDataStructure result = new refuelAreaDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'repairArea' data structure as a repairAreaDataStructure.
        public static repairAreaDataStructure GetrepairAreaDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool repairParticleSystemexists;
            string repairParticleSystem = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "repairParticleSystem", out repairParticleSystemexists);
            bool repairSoundIDexists;
            string repairSoundID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "repairSoundID", out repairSoundIDexists);
            bool maxRepairClassexists;
            string maxRepairClass = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "maxRepairClass", out maxRepairClassexists);

            bool repairPositionexists;
            Vector3D repairPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "repairPosition", out repairPositionexists);
            bool repairSizeexists;
            Vector3D repairSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "repairSize", out repairSizeexists);

            repairAreaDataStructure result = new repairAreaDataStructure(inParentDataFile, inXMLNode, repairParticleSystem, repairSoundID, maxRepairClass, repairPosition, repairSize);

            result.SetPropertyExists("repairParticleSystem", repairParticleSystemexists);
            result.SetPropertyExists("repairSoundID", repairSoundIDexists);
            result.SetPropertyExists("maxRepairClass", maxRepairClassexists);

            result.SetPropertyExists("repairPosition", repairPositionexists);
            repairPosition.OnElementChanged += result.repairPosition_OnElementChanged;
            result.SetPropertyExists("repairSize", repairSizeexists);
            repairSize.OnElementChanged += result.repairSize_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'repairArea' data structures. 
        //Used for properties that are in a collection. See GetrepairAreaDataStructureFromXMLNodeNamedChild for a single 'repairArea' data structure.
        public static List<repairAreaDataStructure> GetrepairAreaDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<repairAreaDataStructure> result = new List<repairAreaDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetrepairAreaDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'repairArea' data structure. 
        //Used for properties that are not in a collection. See GetrepairAreaDataStructureListFromXMLNodeNamedChildren for collections of 'repairArea' data structures.
        public static repairAreaDataStructure GetrepairAreaDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            repairAreaDataStructure result = new repairAreaDataStructure(inParentDataFile, null);
            bool exists = false;
            List <repairAreaDataStructure> results = GetrepairAreaDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'repairArea' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'repairArea' data structure
        public static List<repairAreaDataStructure> GetrepairAreaDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("repairArea");
            List <repairAreaDataStructure> result = new List<repairAreaDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                repairAreaDataStructure currentdata = DataStructureParseHelpers.GetrepairAreaDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'repairArea' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrepairAreaDataStructureListFromVD2Data for a collection of 'repairArea' data structures
        public static repairAreaDataStructure GetrepairAreaDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <repairAreaDataStructure> results = GetrepairAreaDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            repairAreaDataStructure result = new repairAreaDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'mine' data structure as a mineDataStructure.
        public static mineDataStructure GetmineDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool mineIDexists;
            string mineID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mineID", out mineIDexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);
            bool linearVelocityexists;
            Vector3D linearVelocity = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "linearVelocity", out linearVelocityexists);

            mineDataStructure result = new mineDataStructure(inParentDataFile, inXMLNode, mineID, position, linearVelocity);

            result.SetPropertyExists("mineID", mineIDexists);

            result.SetPropertyExists("position", positionexists);
            position.OnElementChanged += result.position_OnElementChanged;
            result.SetPropertyExists("linearVelocity", linearVelocityexists);
            linearVelocity.OnElementChanged += result.linearVelocity_OnElementChanged;

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'mine' data structures. 
        //Used for properties that are in a collection. See GetmineDataStructureFromXMLNodeNamedChild for a single 'mine' data structure.
        public static List<mineDataStructure> GetmineDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<mineDataStructure> result = new List<mineDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetmineDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'mine' data structure. 
        //Used for properties that are not in a collection. See GetmineDataStructureListFromXMLNodeNamedChildren for collections of 'mine' data structures.
        public static mineDataStructure GetmineDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            mineDataStructure result = new mineDataStructure(inParentDataFile, null);
            bool exists = false;
            List <mineDataStructure> results = GetmineDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'mine' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'mine' data structure
        public static List<mineDataStructure> GetmineDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("mine");
            List <mineDataStructure> result = new List<mineDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                mineDataStructure currentdata = DataStructureParseHelpers.GetmineDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'mine' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmineDataStructureListFromVD2Data for a collection of 'mine' data structures
        public static mineDataStructure GetmineDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <mineDataStructure> results = GetmineDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            mineDataStructure result = new mineDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

        //Gets the value of child nodes to get a 'damageCollisionField' data structure as a damageCollisionFieldDataStructure.
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromXMLNode(VD2Data inParentDataFile, XmlNode inXMLNode)
        {
            bool damageexists;
            int damage = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "damage", out damageexists);
            bool scaleexists;
            int scale = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "scale", out scaleexists);

            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure(inParentDataFile, inXMLNode, damage, scale);

            result.SetPropertyExists("damage", damageexists);
            result.SetPropertyExists("scale", scaleexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'damageCollisionField' data structures. 
        //Used for properties that are in a collection. See GetdamageCollisionFieldDataStructureFromXMLNodeNamedChild for a single 'damageCollisionField' data structure.
        public static List<damageCollisionFieldDataStructure> GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            List<damageCollisionFieldDataStructure> result = new List<damageCollisionFieldDataStructure>();
            bool exists = false;
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    exists = true;
                    result.Add(GetdamageCollisionFieldDataStructureFromXMLNode(inParentDataFile, CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'damageCollisionField' data structure. 
        //Used for properties that are not in a collection. See GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren for collections of 'damageCollisionField' data structures.
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromXMLNodeNamedChild(VD2Data inParentDataFile, XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure(inParentDataFile, null);
            bool exists = false;
            List <damageCollisionFieldDataStructure> results = GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren(inParentDataFile, inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'damageCollisionField' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'damageCollisionField' data structure
        public static List<damageCollisionFieldDataStructure> GetdamageCollisionFieldDataStructureListFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("damageCollisionField");
            List <damageCollisionFieldDataStructure> result = new List<damageCollisionFieldDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                damageCollisionFieldDataStructure currentdata = DataStructureParseHelpers.GetdamageCollisionFieldDataStructureFromXMLNode(inParentDataFile, currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'damageCollisionField' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdamageCollisionFieldDataStructureListFromVD2Data for a collection of 'damageCollisionField' data structures
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromVD2Data(VD2Data inParentDataFile, XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <damageCollisionFieldDataStructure> results = GetdamageCollisionFieldDataStructureListFromVD2Data(inParentDataFile, inXML, out exists);
            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure(inParentDataFile, null);

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }

    }
}
