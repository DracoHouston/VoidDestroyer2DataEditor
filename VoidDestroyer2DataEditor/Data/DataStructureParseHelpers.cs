using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace VoidDestroyer2DataEditor
{
    static class DataStructureParseHelpers
    {
        //Gets the value of child nodes to get a 'debris' data structure as a debrisDataStructure.
        public static debrisDataStructure GetdebrisDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool debrisIDexists;
            string debrisID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "debrisID", out debrisIDexists);

            bool debrisMomentumexists;
            int debrisMomentum = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "debrisMomentum", out debrisMomentumexists);
            bool debrisAngularexists;
            int debrisAngular = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "debrisAngular", out debrisAngularexists);

            debrisDataStructure result = new debrisDataStructure(debrisID, debrisMomentum, debrisAngular);

            result.SetPropertyExistsInBaseData("debrisID", debrisIDexists);
            result.SetPropertyExists("debrisID", debrisIDexists);

            result.SetPropertyExistsInBaseData("debrisMomentum", debrisMomentumexists);
            result.SetPropertyExists("debrisMomentum", debrisMomentumexists);
            result.SetPropertyExistsInBaseData("debrisAngular", debrisAngularexists);
            result.SetPropertyExists("debrisAngular", debrisAngularexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'debris' data structures. 
        //Used for properties that are in a collection. See GetdebrisDataStructureFromXMLNodeNamedChild for a single 'debris' data structure.
        public static List<debrisDataStructure> GetdebrisDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetdebrisDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'debris' data structure. 
        //Used for properties that are not in a collection. See GetdebrisDataStructureListFromXMLNodeNamedChildren for collections of 'debris' data structures.
        public static debrisDataStructure GetdebrisDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            debrisDataStructure result = new debrisDataStructure();
            bool exists = false;
            List <debrisDataStructure> results = GetdebrisDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'debris' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'debris' data structure
        public static List<debrisDataStructure> GetdebrisDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("debris");
            List <debrisDataStructure> result = new List<debrisDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                debrisDataStructure currentdata = DataStructureParseHelpers.GetdebrisDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'debris' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdebrisDataStructureListFromVD2Data for a collection of 'debris' data structures
        public static debrisDataStructure GetdebrisDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <debrisDataStructure> results = GetdebrisDataStructureListFromVD2Data(inXML, out exists);
            debrisDataStructure result = new debrisDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'debrisInfo' data structure as a debrisInfoDataStructure.
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool debrisexists;
            List<debrisDataStructure> debris = DataStructureParseHelpers.GetdebrisDataStructureListFromXMLNodeNamedChildren(inXMLNode, "debris", out debrisexists);

            debrisInfoDataStructure result = new debrisInfoDataStructure(debris);

            result.SetPropertyExistsInBaseData("debris", debrisexists);
            result.SetPropertyExists("debris", debrisexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'debrisInfo' data structures. 
        //Used for properties that are in a collection. See GetdebrisInfoDataStructureFromXMLNodeNamedChild for a single 'debrisInfo' data structure.
        public static List<debrisInfoDataStructure> GetdebrisInfoDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetdebrisInfoDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'debrisInfo' data structure. 
        //Used for properties that are not in a collection. See GetdebrisInfoDataStructureListFromXMLNodeNamedChildren for collections of 'debrisInfo' data structures.
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            debrisInfoDataStructure result = new debrisInfoDataStructure();
            bool exists = false;
            List <debrisInfoDataStructure> results = GetdebrisInfoDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'debrisInfo' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'debrisInfo' data structure
        public static List<debrisInfoDataStructure> GetdebrisInfoDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("debrisInfo");
            List <debrisInfoDataStructure> result = new List<debrisInfoDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                debrisInfoDataStructure currentdata = DataStructureParseHelpers.GetdebrisInfoDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'debrisInfo' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdebrisInfoDataStructureListFromVD2Data for a collection of 'debrisInfo' data structures
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <debrisInfoDataStructure> results = GetdebrisInfoDataStructureListFromVD2Data(inXML, out exists);
            debrisInfoDataStructure result = new debrisInfoDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'afterburner' data structure as a afterburnerDataStructure.
        public static afterburnerDataStructure GetafterburnerDataStructureFromXMLNode(XmlNode inXMLNode)
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

            afterburnerDataStructure result = new afterburnerDataStructure(soundID, tailSoundID, multiplier, capacity, recharge);

            result.SetPropertyExistsInBaseData("soundID", soundIDexists);
            result.SetPropertyExists("soundID", soundIDexists);
            result.SetPropertyExistsInBaseData("tailSoundID", tailSoundIDexists);
            result.SetPropertyExists("tailSoundID", tailSoundIDexists);

            result.SetPropertyExistsInBaseData("multiplier", multiplierexists);
            result.SetPropertyExists("multiplier", multiplierexists);
            result.SetPropertyExistsInBaseData("capacity", capacityexists);
            result.SetPropertyExists("capacity", capacityexists);
            result.SetPropertyExistsInBaseData("recharge", rechargeexists);
            result.SetPropertyExists("recharge", rechargeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'afterburner' data structures. 
        //Used for properties that are in a collection. See GetafterburnerDataStructureFromXMLNodeNamedChild for a single 'afterburner' data structure.
        public static List<afterburnerDataStructure> GetafterburnerDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetafterburnerDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'afterburner' data structure. 
        //Used for properties that are not in a collection. See GetafterburnerDataStructureListFromXMLNodeNamedChildren for collections of 'afterburner' data structures.
        public static afterburnerDataStructure GetafterburnerDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            afterburnerDataStructure result = new afterburnerDataStructure();
            bool exists = false;
            List <afterburnerDataStructure> results = GetafterburnerDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'afterburner' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'afterburner' data structure
        public static List<afterburnerDataStructure> GetafterburnerDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("afterburner");
            List <afterburnerDataStructure> result = new List<afterburnerDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                afterburnerDataStructure currentdata = DataStructureParseHelpers.GetafterburnerDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'afterburner' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetafterburnerDataStructureListFromVD2Data for a collection of 'afterburner' data structures
        public static afterburnerDataStructure GetafterburnerDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <afterburnerDataStructure> results = GetafterburnerDataStructureListFromVD2Data(inXML, out exists);
            afterburnerDataStructure result = new afterburnerDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'targetPriorityList' data structure as a targetPriorityListDataStructure.
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool targetClassexists;
            List<string> targetClass = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "targetClass", out targetClassexists);

            targetPriorityListDataStructure result = new targetPriorityListDataStructure(targetClass);

            result.SetPropertyExistsInBaseData("targetClass", targetClassexists);
            result.SetPropertyExists("targetClass", targetClassexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'targetPriorityList' data structures. 
        //Used for properties that are in a collection. See GettargetPriorityListDataStructureFromXMLNodeNamedChild for a single 'targetPriorityList' data structure.
        public static List<targetPriorityListDataStructure> GettargetPriorityListDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GettargetPriorityListDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'targetPriorityList' data structure. 
        //Used for properties that are not in a collection. See GettargetPriorityListDataStructureListFromXMLNodeNamedChildren for collections of 'targetPriorityList' data structures.
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            targetPriorityListDataStructure result = new targetPriorityListDataStructure();
            bool exists = false;
            List <targetPriorityListDataStructure> results = GettargetPriorityListDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'targetPriorityList' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'targetPriorityList' data structure
        public static List<targetPriorityListDataStructure> GettargetPriorityListDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("targetPriorityList");
            List <targetPriorityListDataStructure> result = new List<targetPriorityListDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                targetPriorityListDataStructure currentdata = DataStructureParseHelpers.GettargetPriorityListDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'targetPriorityList' data structure from a definition XML
        //Used for data structures that are not in a collection. See GettargetPriorityListDataStructureListFromVD2Data for a collection of 'targetPriorityList' data structures
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <targetPriorityListDataStructure> results = GettargetPriorityListDataStructureListFromVD2Data(inXML, out exists);
            targetPriorityListDataStructure result = new targetPriorityListDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'upgrades' data structure as a upgradesDataStructure.
        public static upgradesDataStructure GetupgradesDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool upgradeIDexists;
            List<string> upgradeID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "upgradeID", out upgradeIDexists);

            bool primaryUpgradeCapacityexists;
            int primaryUpgradeCapacity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "primaryUpgradeCapacity", out primaryUpgradeCapacityexists);
            bool activeUpgradeCapacityexists;
            int activeUpgradeCapacity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "activeUpgradeCapacity", out activeUpgradeCapacityexists);

            upgradesDataStructure result = new upgradesDataStructure(upgradeID, primaryUpgradeCapacity, activeUpgradeCapacity);

            result.SetPropertyExistsInBaseData("upgradeID", upgradeIDexists);
            result.SetPropertyExists("upgradeID", upgradeIDexists);

            result.SetPropertyExistsInBaseData("primaryUpgradeCapacity", primaryUpgradeCapacityexists);
            result.SetPropertyExists("primaryUpgradeCapacity", primaryUpgradeCapacityexists);
            result.SetPropertyExistsInBaseData("activeUpgradeCapacity", activeUpgradeCapacityexists);
            result.SetPropertyExists("activeUpgradeCapacity", activeUpgradeCapacityexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'upgrades' data structures. 
        //Used for properties that are in a collection. See GetupgradesDataStructureFromXMLNodeNamedChild for a single 'upgrades' data structure.
        public static List<upgradesDataStructure> GetupgradesDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetupgradesDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'upgrades' data structure. 
        //Used for properties that are not in a collection. See GetupgradesDataStructureListFromXMLNodeNamedChildren for collections of 'upgrades' data structures.
        public static upgradesDataStructure GetupgradesDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            upgradesDataStructure result = new upgradesDataStructure();
            bool exists = false;
            List <upgradesDataStructure> results = GetupgradesDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'upgrades' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'upgrades' data structure
        public static List<upgradesDataStructure> GetupgradesDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("upgrades");
            List <upgradesDataStructure> result = new List<upgradesDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                upgradesDataStructure currentdata = DataStructureParseHelpers.GetupgradesDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'upgrades' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetupgradesDataStructureListFromVD2Data for a collection of 'upgrades' data structures
        public static upgradesDataStructure GetupgradesDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <upgradesDataStructure> results = GetupgradesDataStructureListFromVD2Data(inXML, out exists);
            upgradesDataStructure result = new upgradesDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'propulsion' data structure as a propulsionDataStructure.
        public static propulsionDataStructure GetpropulsionDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool propulsionEffectIDexists;
            string propulsionEffectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "propulsionEffectID", out propulsionEffectIDexists);
            bool directionexists;
            string direction = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "direction", out directionexists);

            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);

            bool bPlayerShipOnlyexists;
            bool bPlayerShipOnly = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bPlayerShipOnly", out bPlayerShipOnlyexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            propulsionDataStructure result = new propulsionDataStructure(propulsionEffectID, direction, pitch, yaw, bPlayerShipOnly, position);

            result.SetPropertyExistsInBaseData("propulsionEffectID", propulsionEffectIDexists);
            result.SetPropertyExists("propulsionEffectID", propulsionEffectIDexists);
            result.SetPropertyExistsInBaseData("direction", directionexists);
            result.SetPropertyExists("direction", directionexists);

            result.SetPropertyExistsInBaseData("pitch", pitchexists);
            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExistsInBaseData("yaw", yawexists);
            result.SetPropertyExists("yaw", yawexists);

            result.SetPropertyExistsInBaseData("bPlayerShipOnly", bPlayerShipOnlyexists);
            result.SetPropertyExists("bPlayerShipOnly", bPlayerShipOnlyexists);

            result.SetPropertyExistsInBaseData("position", positionexists);
            result.SetPropertyExists("position", positionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'propulsion' data structures. 
        //Used for properties that are in a collection. See GetpropulsionDataStructureFromXMLNodeNamedChild for a single 'propulsion' data structure.
        public static List<propulsionDataStructure> GetpropulsionDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetpropulsionDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'propulsion' data structure. 
        //Used for properties that are not in a collection. See GetpropulsionDataStructureListFromXMLNodeNamedChildren for collections of 'propulsion' data structures.
        public static propulsionDataStructure GetpropulsionDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            propulsionDataStructure result = new propulsionDataStructure();
            bool exists = false;
            List <propulsionDataStructure> results = GetpropulsionDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'propulsion' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'propulsion' data structure
        public static List<propulsionDataStructure> GetpropulsionDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("propulsion");
            List <propulsionDataStructure> result = new List<propulsionDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                propulsionDataStructure currentdata = DataStructureParseHelpers.GetpropulsionDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'propulsion' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetpropulsionDataStructureListFromVD2Data for a collection of 'propulsion' data structures
        public static propulsionDataStructure GetpropulsionDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <propulsionDataStructure> results = GetpropulsionDataStructureListFromVD2Data(inXML, out exists);
            propulsionDataStructure result = new propulsionDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'weapon' data structure as a weaponDataStructure.
        public static weaponDataStructure GetweaponDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool weaponTypeexists;
            string weaponType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponType", out weaponTypeexists);
            bool hardpointIDexists;
            string hardpointID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "hardpointID", out hardpointIDexists);
            bool weaponFireexists;
            string weaponFire = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponFire", out weaponFireexists);

            bool barrelDelayexists;
            float barrelDelay = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "barrelDelay", out barrelDelayexists);
            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);

            bool weaponPositionexists;
            List<Vector3D> weaponPosition = ParseHelpers.GetVector3DListFromXMLNodeNamedChildren(inXMLNode, "weaponPosition", out weaponPositionexists);

            weaponDataStructure result = new weaponDataStructure(weaponType, hardpointID, weaponFire, barrelDelay, yaw, pitch, weaponPosition);

            result.SetPropertyExistsInBaseData("weaponType", weaponTypeexists);
            result.SetPropertyExists("weaponType", weaponTypeexists);
            result.SetPropertyExistsInBaseData("hardpointID", hardpointIDexists);
            result.SetPropertyExists("hardpointID", hardpointIDexists);
            result.SetPropertyExistsInBaseData("weaponFire", weaponFireexists);
            result.SetPropertyExists("weaponFire", weaponFireexists);

            result.SetPropertyExistsInBaseData("barrelDelay", barrelDelayexists);
            result.SetPropertyExists("barrelDelay", barrelDelayexists);
            result.SetPropertyExistsInBaseData("yaw", yawexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExistsInBaseData("pitch", pitchexists);
            result.SetPropertyExists("pitch", pitchexists);

            result.SetPropertyExistsInBaseData("weaponPosition", weaponPositionexists);
            result.SetPropertyExists("weaponPosition", weaponPositionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'weapon' data structures. 
        //Used for properties that are in a collection. See GetweaponDataStructureFromXMLNodeNamedChild for a single 'weapon' data structure.
        public static List<weaponDataStructure> GetweaponDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetweaponDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'weapon' data structure. 
        //Used for properties that are not in a collection. See GetweaponDataStructureListFromXMLNodeNamedChildren for collections of 'weapon' data structures.
        public static weaponDataStructure GetweaponDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            weaponDataStructure result = new weaponDataStructure();
            bool exists = false;
            List <weaponDataStructure> results = GetweaponDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'weapon' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'weapon' data structure
        public static List<weaponDataStructure> GetweaponDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("weapon");
            List <weaponDataStructure> result = new List<weaponDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                weaponDataStructure currentdata = DataStructureParseHelpers.GetweaponDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'weapon' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetweaponDataStructureListFromVD2Data for a collection of 'weapon' data structures
        public static weaponDataStructure GetweaponDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <weaponDataStructure> results = GetweaponDataStructureListFromVD2Data(inXML, out exists);
            weaponDataStructure result = new weaponDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'damage' data structure as a damageDataStructure.
        public static damageDataStructure GetdamageDataStructureFromXMLNode(XmlNode inXMLNode)
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

            damageDataStructure result = new damageDataStructure(damageEffectID, pitch, roll, yaw, healthPoint, position);

            result.SetPropertyExistsInBaseData("damageEffectID", damageEffectIDexists);
            result.SetPropertyExists("damageEffectID", damageEffectIDexists);

            result.SetPropertyExistsInBaseData("pitch", pitchexists);
            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExistsInBaseData("roll", rollexists);
            result.SetPropertyExists("roll", rollexists);
            result.SetPropertyExistsInBaseData("yaw", yawexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExistsInBaseData("healthPoint", healthPointexists);
            result.SetPropertyExists("healthPoint", healthPointexists);

            result.SetPropertyExistsInBaseData("position", positionexists);
            result.SetPropertyExists("position", positionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'damage' data structures. 
        //Used for properties that are in a collection. See GetdamageDataStructureFromXMLNodeNamedChild for a single 'damage' data structure.
        public static List<damageDataStructure> GetdamageDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetdamageDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'damage' data structure. 
        //Used for properties that are not in a collection. See GetdamageDataStructureListFromXMLNodeNamedChildren for collections of 'damage' data structures.
        public static damageDataStructure GetdamageDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            damageDataStructure result = new damageDataStructure();
            bool exists = false;
            List <damageDataStructure> results = GetdamageDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'damage' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'damage' data structure
        public static List<damageDataStructure> GetdamageDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("damage");
            List <damageDataStructure> result = new List<damageDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                damageDataStructure currentdata = DataStructureParseHelpers.GetdamageDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'damage' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdamageDataStructureListFromVD2Data for a collection of 'damage' data structures
        public static damageDataStructure GetdamageDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <damageDataStructure> results = GetdamageDataStructureListFromVD2Data(inXML, out exists);
            damageDataStructure result = new damageDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'turret' data structure as a turretDataStructure.
        public static turretDataStructure GetturretDataStructureFromXMLNode(XmlNode inXMLNode)
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

            bool bShowInCockpitexists;
            bool bShowInCockpit = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bShowInCockpit", out bShowInCockpitexists);
            bool bHideInHangarexists;
            bool bHideInHangar = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bHideInHangar", out bHideInHangarexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            turretDataStructure result = new turretDataStructure(turretID, turretOrientation, weaponFire, turretRole, yawPermitted, weaponPositionID, pitchLower, roll, yaw, bShowInCockpit, bHideInHangar, position);

            result.SetPropertyExistsInBaseData("turretID", turretIDexists);
            result.SetPropertyExists("turretID", turretIDexists);
            result.SetPropertyExistsInBaseData("turretOrientation", turretOrientationexists);
            result.SetPropertyExists("turretOrientation", turretOrientationexists);
            result.SetPropertyExistsInBaseData("weaponFire", weaponFireexists);
            result.SetPropertyExists("weaponFire", weaponFireexists);

            result.SetPropertyExistsInBaseData("turretRole", turretRoleexists);
            result.SetPropertyExists("turretRole", turretRoleexists);

            result.SetPropertyExistsInBaseData("yawPermitted", yawPermittedexists);
            result.SetPropertyExists("yawPermitted", yawPermittedexists);
            result.SetPropertyExistsInBaseData("weaponPositionID", weaponPositionIDexists);
            result.SetPropertyExists("weaponPositionID", weaponPositionIDexists);

            result.SetPropertyExistsInBaseData("pitchLower", pitchLowerexists);
            result.SetPropertyExists("pitchLower", pitchLowerexists);
            result.SetPropertyExistsInBaseData("roll", rollexists);
            result.SetPropertyExists("roll", rollexists);
            result.SetPropertyExistsInBaseData("yaw", yawexists);
            result.SetPropertyExists("yaw", yawexists);

            result.SetPropertyExistsInBaseData("bShowInCockpit", bShowInCockpitexists);
            result.SetPropertyExists("bShowInCockpit", bShowInCockpitexists);
            result.SetPropertyExistsInBaseData("bHideInHangar", bHideInHangarexists);
            result.SetPropertyExists("bHideInHangar", bHideInHangarexists);

            result.SetPropertyExistsInBaseData("position", positionexists);
            result.SetPropertyExists("position", positionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'turret' data structures. 
        //Used for properties that are in a collection. See GetturretDataStructureFromXMLNodeNamedChild for a single 'turret' data structure.
        public static List<turretDataStructure> GetturretDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetturretDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'turret' data structure. 
        //Used for properties that are not in a collection. See GetturretDataStructureListFromXMLNodeNamedChildren for collections of 'turret' data structures.
        public static turretDataStructure GetturretDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            turretDataStructure result = new turretDataStructure();
            bool exists = false;
            List <turretDataStructure> results = GetturretDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'turret' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'turret' data structure
        public static List<turretDataStructure> GetturretDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("turret");
            List <turretDataStructure> result = new List<turretDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                turretDataStructure currentdata = DataStructureParseHelpers.GetturretDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'turret' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetturretDataStructureListFromVD2Data for a collection of 'turret' data structures
        public static turretDataStructure GetturretDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <turretDataStructure> results = GetturretDataStructureListFromVD2Data(inXML, out exists);
            turretDataStructure result = new turretDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'attachment' data structure as a attachmentDataStructure.
        public static attachmentDataStructure GetattachmentDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool attachmentOrientationexists;
            string attachmentOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "attachmentOrientation", out attachmentOrientationexists);

            bool attachmentIDexists;
            List<string> attachmentID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "attachmentID", out attachmentIDexists);

            bool attachmentPositionexists;
            Vector3D attachmentPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "attachmentPosition", out attachmentPositionexists);

            attachmentDataStructure result = new attachmentDataStructure(attachmentOrientation, attachmentID, attachmentPosition);

            result.SetPropertyExistsInBaseData("attachmentOrientation", attachmentOrientationexists);
            result.SetPropertyExists("attachmentOrientation", attachmentOrientationexists);

            result.SetPropertyExistsInBaseData("attachmentID", attachmentIDexists);
            result.SetPropertyExists("attachmentID", attachmentIDexists);

            result.SetPropertyExistsInBaseData("attachmentPosition", attachmentPositionexists);
            result.SetPropertyExists("attachmentPosition", attachmentPositionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'attachment' data structures. 
        //Used for properties that are in a collection. See GetattachmentDataStructureFromXMLNodeNamedChild for a single 'attachment' data structure.
        public static List<attachmentDataStructure> GetattachmentDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetattachmentDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'attachment' data structure. 
        //Used for properties that are not in a collection. See GetattachmentDataStructureListFromXMLNodeNamedChildren for collections of 'attachment' data structures.
        public static attachmentDataStructure GetattachmentDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            attachmentDataStructure result = new attachmentDataStructure();
            bool exists = false;
            List <attachmentDataStructure> results = GetattachmentDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'attachment' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'attachment' data structure
        public static List<attachmentDataStructure> GetattachmentDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("attachment");
            List <attachmentDataStructure> result = new List<attachmentDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                attachmentDataStructure currentdata = DataStructureParseHelpers.GetattachmentDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'attachment' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetattachmentDataStructureListFromVD2Data for a collection of 'attachment' data structures
        public static attachmentDataStructure GetattachmentDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <attachmentDataStructure> results = GetattachmentDataStructureListFromVD2Data(inXML, out exists);
            attachmentDataStructure result = new attachmentDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'movingElement' data structure as a movingElementDataStructure.
        public static movingElementDataStructure GetmovingElementDataStructureFromXMLNode(XmlNode inXMLNode)
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

            movingElementDataStructure result = new movingElementDataStructure(boneName, yaw, pitch, roll, speedMultiplier, bLinkedToWeapon, bCombat, translateAmount);

            result.SetPropertyExistsInBaseData("boneName", boneNameexists);
            result.SetPropertyExists("boneName", boneNameexists);

            result.SetPropertyExistsInBaseData("yaw", yawexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExistsInBaseData("pitch", pitchexists);
            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExistsInBaseData("roll", rollexists);
            result.SetPropertyExists("roll", rollexists);
            result.SetPropertyExistsInBaseData("speedMultiplier", speedMultiplierexists);
            result.SetPropertyExists("speedMultiplier", speedMultiplierexists);

            result.SetPropertyExistsInBaseData("bLinkedToWeapon", bLinkedToWeaponexists);
            result.SetPropertyExists("bLinkedToWeapon", bLinkedToWeaponexists);
            result.SetPropertyExistsInBaseData("bCombat", bCombatexists);
            result.SetPropertyExists("bCombat", bCombatexists);

            result.SetPropertyExistsInBaseData("translateAmount", translateAmountexists);
            result.SetPropertyExists("translateAmount", translateAmountexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'movingElement' data structures. 
        //Used for properties that are in a collection. See GetmovingElementDataStructureFromXMLNodeNamedChild for a single 'movingElement' data structure.
        public static List<movingElementDataStructure> GetmovingElementDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetmovingElementDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'movingElement' data structure. 
        //Used for properties that are not in a collection. See GetmovingElementDataStructureListFromXMLNodeNamedChildren for collections of 'movingElement' data structures.
        public static movingElementDataStructure GetmovingElementDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            movingElementDataStructure result = new movingElementDataStructure();
            bool exists = false;
            List <movingElementDataStructure> results = GetmovingElementDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'movingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'movingElement' data structure
        public static List<movingElementDataStructure> GetmovingElementDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("movingElement");
            List <movingElementDataStructure> result = new List<movingElementDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                movingElementDataStructure currentdata = DataStructureParseHelpers.GetmovingElementDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'movingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmovingElementDataStructureListFromVD2Data for a collection of 'movingElement' data structures
        public static movingElementDataStructure GetmovingElementDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <movingElementDataStructure> results = GetmovingElementDataStructureListFromVD2Data(inXML, out exists);
            movingElementDataStructure result = new movingElementDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'dock' data structure as a dockDataStructure.
        public static dockDataStructure GetdockDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool dockTypeexists;
            string dockType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "dockType", out dockTypeexists);
            bool ejectOrientationexists;
            string ejectOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "ejectOrientation", out ejectOrientationexists);
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

            bool objectIDexists;
            List<string> objectID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "objectID", out objectIDexists);

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

            dockDataStructure result = new dockDataStructure(dockType, ejectOrientation, orientation, attachedID, boneName, dockOrientation, resourceOnly, objectID, ejectVelocity, dockRollOffset, dockYawOffset, bCanAcceptRawResource, bInvisible, position);

            result.SetPropertyExistsInBaseData("dockType", dockTypeexists);
            result.SetPropertyExists("dockType", dockTypeexists);
            result.SetPropertyExistsInBaseData("ejectOrientation", ejectOrientationexists);
            result.SetPropertyExists("ejectOrientation", ejectOrientationexists);
            result.SetPropertyExistsInBaseData("orientation", orientationexists);
            result.SetPropertyExists("orientation", orientationexists);
            result.SetPropertyExistsInBaseData("attachedID", attachedIDexists);
            result.SetPropertyExists("attachedID", attachedIDexists);
            result.SetPropertyExistsInBaseData("boneName", boneNameexists);
            result.SetPropertyExists("boneName", boneNameexists);
            result.SetPropertyExistsInBaseData("dockOrientation", dockOrientationexists);
            result.SetPropertyExists("dockOrientation", dockOrientationexists);
            result.SetPropertyExistsInBaseData("resourceOnly", resourceOnlyexists);
            result.SetPropertyExists("resourceOnly", resourceOnlyexists);

            result.SetPropertyExistsInBaseData("objectID", objectIDexists);
            result.SetPropertyExists("objectID", objectIDexists);

            result.SetPropertyExistsInBaseData("ejectVelocity", ejectVelocityexists);
            result.SetPropertyExists("ejectVelocity", ejectVelocityexists);
            result.SetPropertyExistsInBaseData("dockRollOffset", dockRollOffsetexists);
            result.SetPropertyExists("dockRollOffset", dockRollOffsetexists);
            result.SetPropertyExistsInBaseData("dockYawOffset", dockYawOffsetexists);
            result.SetPropertyExists("dockYawOffset", dockYawOffsetexists);

            result.SetPropertyExistsInBaseData("bCanAcceptRawResource", bCanAcceptRawResourceexists);
            result.SetPropertyExists("bCanAcceptRawResource", bCanAcceptRawResourceexists);
            result.SetPropertyExistsInBaseData("bInvisible", bInvisibleexists);
            result.SetPropertyExists("bInvisible", bInvisibleexists);

            result.SetPropertyExistsInBaseData("position", positionexists);
            result.SetPropertyExists("position", positionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'dock' data structures. 
        //Used for properties that are in a collection. See GetdockDataStructureFromXMLNodeNamedChild for a single 'dock' data structure.
        public static List<dockDataStructure> GetdockDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetdockDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'dock' data structure. 
        //Used for properties that are not in a collection. See GetdockDataStructureListFromXMLNodeNamedChildren for collections of 'dock' data structures.
        public static dockDataStructure GetdockDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            dockDataStructure result = new dockDataStructure();
            bool exists = false;
            List <dockDataStructure> results = GetdockDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'dock' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'dock' data structure
        public static List<dockDataStructure> GetdockDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("dock");
            List <dockDataStructure> result = new List<dockDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                dockDataStructure currentdata = DataStructureParseHelpers.GetdockDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'dock' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdockDataStructureListFromVD2Data for a collection of 'dock' data structures
        public static dockDataStructure GetdockDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <dockDataStructure> results = GetdockDataStructureListFromVD2Data(inXML, out exists);
            dockDataStructure result = new dockDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'shield' data structure as a shieldDataStructure.
        public static shieldDataStructure GetshieldDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool shieldIDexists;
            string shieldID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "shieldID", out shieldIDexists);
            bool shieldOrientationexists;
            string shieldOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "shieldOrientation", out shieldOrientationexists);

            bool pitchexists;
            int pitch = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool rollexists;
            int roll = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);

            bool shieldPositionexists;
            Vector3D shieldPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "shieldPosition", out shieldPositionexists);

            shieldDataStructure result = new shieldDataStructure(shieldID, shieldOrientation, pitch, roll, shieldPosition);

            result.SetPropertyExistsInBaseData("shieldID", shieldIDexists);
            result.SetPropertyExists("shieldID", shieldIDexists);
            result.SetPropertyExistsInBaseData("shieldOrientation", shieldOrientationexists);
            result.SetPropertyExists("shieldOrientation", shieldOrientationexists);

            result.SetPropertyExistsInBaseData("pitch", pitchexists);
            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExistsInBaseData("roll", rollexists);
            result.SetPropertyExists("roll", rollexists);

            result.SetPropertyExistsInBaseData("shieldPosition", shieldPositionexists);
            result.SetPropertyExists("shieldPosition", shieldPositionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'shield' data structures. 
        //Used for properties that are in a collection. See GetshieldDataStructureFromXMLNodeNamedChild for a single 'shield' data structure.
        public static List<shieldDataStructure> GetshieldDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetshieldDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'shield' data structure. 
        //Used for properties that are not in a collection. See GetshieldDataStructureListFromXMLNodeNamedChildren for collections of 'shield' data structures.
        public static shieldDataStructure GetshieldDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            shieldDataStructure result = new shieldDataStructure();
            bool exists = false;
            List <shieldDataStructure> results = GetshieldDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'shield' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'shield' data structure
        public static List<shieldDataStructure> GetshieldDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("shield");
            List <shieldDataStructure> result = new List<shieldDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                shieldDataStructure currentdata = DataStructureParseHelpers.GetshieldDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'shield' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetshieldDataStructureListFromVD2Data for a collection of 'shield' data structures
        public static shieldDataStructure GetshieldDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <shieldDataStructure> results = GetshieldDataStructureListFromVD2Data(inXML, out exists);
            shieldDataStructure result = new shieldDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'rotatingElement' data structure as a rotatingElementDataStructure.
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool boneNameexists;
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName", out boneNameexists);

            bool rollSpeedexists;
            int rollSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollSpeed", out rollSpeedexists);

            bool bLinkedToWeaponexists;
            bool bLinkedToWeapon = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bLinkedToWeapon", out bLinkedToWeaponexists);

            rotatingElementDataStructure result = new rotatingElementDataStructure(boneName, rollSpeed, bLinkedToWeapon);

            result.SetPropertyExistsInBaseData("boneName", boneNameexists);
            result.SetPropertyExists("boneName", boneNameexists);

            result.SetPropertyExistsInBaseData("rollSpeed", rollSpeedexists);
            result.SetPropertyExists("rollSpeed", rollSpeedexists);

            result.SetPropertyExistsInBaseData("bLinkedToWeapon", bLinkedToWeaponexists);
            result.SetPropertyExists("bLinkedToWeapon", bLinkedToWeaponexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'rotatingElement' data structures. 
        //Used for properties that are in a collection. See GetrotatingElementDataStructureFromXMLNodeNamedChild for a single 'rotatingElement' data structure.
        public static List<rotatingElementDataStructure> GetrotatingElementDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetrotatingElementDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'rotatingElement' data structure. 
        //Used for properties that are not in a collection. See GetrotatingElementDataStructureListFromXMLNodeNamedChildren for collections of 'rotatingElement' data structures.
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            rotatingElementDataStructure result = new rotatingElementDataStructure();
            bool exists = false;
            List <rotatingElementDataStructure> results = GetrotatingElementDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'rotatingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'rotatingElement' data structure
        public static List<rotatingElementDataStructure> GetrotatingElementDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("rotatingElement");
            List <rotatingElementDataStructure> result = new List<rotatingElementDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                rotatingElementDataStructure currentdata = DataStructureParseHelpers.GetrotatingElementDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'rotatingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrotatingElementDataStructureListFromVD2Data for a collection of 'rotatingElement' data structures
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <rotatingElementDataStructure> results = GetrotatingElementDataStructureListFromVD2Data(inXML, out exists);
            rotatingElementDataStructure result = new rotatingElementDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'recoil' data structure as a recoilDataStructure.
        public static recoilDataStructure GetrecoilDataStructureFromXMLNode(XmlNode inXMLNode)
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

            recoilDataStructure result = new recoilDataStructure(recoilBone, muzzleBoneName, recoilParentType, muzzleBone, recoilZ, recoilTime);

            result.SetPropertyExistsInBaseData("recoilBone", recoilBoneexists);
            result.SetPropertyExists("recoilBone", recoilBoneexists);
            result.SetPropertyExistsInBaseData("muzzleBoneName", muzzleBoneNameexists);
            result.SetPropertyExists("muzzleBoneName", muzzleBoneNameexists);
            result.SetPropertyExistsInBaseData("recoilParentType", recoilParentTypeexists);
            result.SetPropertyExists("recoilParentType", recoilParentTypeexists);

            result.SetPropertyExistsInBaseData("muzzleBone", muzzleBoneexists);
            result.SetPropertyExists("muzzleBone", muzzleBoneexists);

            result.SetPropertyExistsInBaseData("recoilZ", recoilZexists);
            result.SetPropertyExists("recoilZ", recoilZexists);
            result.SetPropertyExistsInBaseData("recoilTime", recoilTimeexists);
            result.SetPropertyExists("recoilTime", recoilTimeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'recoil' data structures. 
        //Used for properties that are in a collection. See GetrecoilDataStructureFromXMLNodeNamedChild for a single 'recoil' data structure.
        public static List<recoilDataStructure> GetrecoilDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetrecoilDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'recoil' data structure. 
        //Used for properties that are not in a collection. See GetrecoilDataStructureListFromXMLNodeNamedChildren for collections of 'recoil' data structures.
        public static recoilDataStructure GetrecoilDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            recoilDataStructure result = new recoilDataStructure();
            bool exists = false;
            List <recoilDataStructure> results = GetrecoilDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'recoil' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'recoil' data structure
        public static List<recoilDataStructure> GetrecoilDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("recoil");
            List <recoilDataStructure> result = new List<recoilDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                recoilDataStructure currentdata = DataStructureParseHelpers.GetrecoilDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'recoil' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrecoilDataStructureListFromVD2Data for a collection of 'recoil' data structures
        public static recoilDataStructure GetrecoilDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <recoilDataStructure> results = GetrecoilDataStructureListFromVD2Data(inXML, out exists);
            recoilDataStructure result = new recoilDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'rotateBones' data structure as a rotateBonesDataStructure.
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool rotateBoneexists;
            string rotateBone = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "rotateBone", out rotateBoneexists);

            rotateBonesDataStructure result = new rotateBonesDataStructure(rotateBone);

            result.SetPropertyExistsInBaseData("rotateBone", rotateBoneexists);
            result.SetPropertyExists("rotateBone", rotateBoneexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'rotateBones' data structures. 
        //Used for properties that are in a collection. See GetrotateBonesDataStructureFromXMLNodeNamedChild for a single 'rotateBones' data structure.
        public static List<rotateBonesDataStructure> GetrotateBonesDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetrotateBonesDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'rotateBones' data structure. 
        //Used for properties that are not in a collection. See GetrotateBonesDataStructureListFromXMLNodeNamedChildren for collections of 'rotateBones' data structures.
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            rotateBonesDataStructure result = new rotateBonesDataStructure();
            bool exists = false;
            List <rotateBonesDataStructure> results = GetrotateBonesDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'rotateBones' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'rotateBones' data structure
        public static List<rotateBonesDataStructure> GetrotateBonesDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("rotateBones");
            List <rotateBonesDataStructure> result = new List<rotateBonesDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                rotateBonesDataStructure currentdata = DataStructureParseHelpers.GetrotateBonesDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'rotateBones' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrotateBonesDataStructureListFromVD2Data for a collection of 'rotateBones' data structures
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <rotateBonesDataStructure> results = GetrotateBonesDataStructureListFromVD2Data(inXML, out exists);
            rotateBonesDataStructure result = new rotateBonesDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'canister' data structure as a canisterDataStructure.
        public static canisterDataStructure GetcanisterDataStructureFromXMLNode(XmlNode inXMLNode)
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

            canisterDataStructure result = new canisterDataStructure(projectileID, canisterCount, blowBackCanisterCount, yawRange, pitchRange, rollRange, speedAddBase, speedAddRandom, bCanisterAimAssist, bAddToRangeCalculations);

            result.SetPropertyExistsInBaseData("projectileID", projectileIDexists);
            result.SetPropertyExists("projectileID", projectileIDexists);

            result.SetPropertyExistsInBaseData("canisterCount", canisterCountexists);
            result.SetPropertyExists("canisterCount", canisterCountexists);
            result.SetPropertyExistsInBaseData("blowBackCanisterCount", blowBackCanisterCountexists);
            result.SetPropertyExists("blowBackCanisterCount", blowBackCanisterCountexists);
            result.SetPropertyExistsInBaseData("yawRange", yawRangeexists);
            result.SetPropertyExists("yawRange", yawRangeexists);
            result.SetPropertyExistsInBaseData("pitchRange", pitchRangeexists);
            result.SetPropertyExists("pitchRange", pitchRangeexists);
            result.SetPropertyExistsInBaseData("rollRange", rollRangeexists);
            result.SetPropertyExists("rollRange", rollRangeexists);
            result.SetPropertyExistsInBaseData("speedAddBase", speedAddBaseexists);
            result.SetPropertyExists("speedAddBase", speedAddBaseexists);
            result.SetPropertyExistsInBaseData("speedAddRandom", speedAddRandomexists);
            result.SetPropertyExists("speedAddRandom", speedAddRandomexists);

            result.SetPropertyExistsInBaseData("bCanisterAimAssist", bCanisterAimAssistexists);
            result.SetPropertyExists("bCanisterAimAssist", bCanisterAimAssistexists);
            result.SetPropertyExistsInBaseData("bAddToRangeCalculations", bAddToRangeCalculationsexists);
            result.SetPropertyExists("bAddToRangeCalculations", bAddToRangeCalculationsexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'canister' data structures. 
        //Used for properties that are in a collection. See GetcanisterDataStructureFromXMLNodeNamedChild for a single 'canister' data structure.
        public static List<canisterDataStructure> GetcanisterDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetcanisterDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'canister' data structure. 
        //Used for properties that are not in a collection. See GetcanisterDataStructureListFromXMLNodeNamedChildren for collections of 'canister' data structures.
        public static canisterDataStructure GetcanisterDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            canisterDataStructure result = new canisterDataStructure();
            bool exists = false;
            List <canisterDataStructure> results = GetcanisterDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'canister' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'canister' data structure
        public static List<canisterDataStructure> GetcanisterDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("canister");
            List <canisterDataStructure> result = new List<canisterDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                canisterDataStructure currentdata = DataStructureParseHelpers.GetcanisterDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'canister' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetcanisterDataStructureListFromVD2Data for a collection of 'canister' data structures
        public static canisterDataStructure GetcanisterDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <canisterDataStructure> results = GetcanisterDataStructureListFromVD2Data(inXML, out exists);
            canisterDataStructure result = new canisterDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'launchTube' data structure as a launchTubeDataStructure.
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromXMLNode(XmlNode inXMLNode)
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

            launchTubeDataStructure result = new launchTubeDataStructure(direction, launchDeckBeg, launchDeckEnd, dockPosition, dockSize);

            result.SetPropertyExistsInBaseData("direction", directionexists);
            result.SetPropertyExists("direction", directionexists);

            result.SetPropertyExistsInBaseData("launchDeckBeg", launchDeckBegexists);
            result.SetPropertyExists("launchDeckBeg", launchDeckBegexists);
            result.SetPropertyExistsInBaseData("launchDeckEnd", launchDeckEndexists);
            result.SetPropertyExists("launchDeckEnd", launchDeckEndexists);
            result.SetPropertyExistsInBaseData("dockPosition", dockPositionexists);
            result.SetPropertyExists("dockPosition", dockPositionexists);
            result.SetPropertyExistsInBaseData("dockSize", dockSizeexists);
            result.SetPropertyExists("dockSize", dockSizeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'launchTube' data structures. 
        //Used for properties that are in a collection. See GetlaunchTubeDataStructureFromXMLNodeNamedChild for a single 'launchTube' data structure.
        public static List<launchTubeDataStructure> GetlaunchTubeDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetlaunchTubeDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'launchTube' data structure. 
        //Used for properties that are not in a collection. See GetlaunchTubeDataStructureListFromXMLNodeNamedChildren for collections of 'launchTube' data structures.
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            launchTubeDataStructure result = new launchTubeDataStructure();
            bool exists = false;
            List <launchTubeDataStructure> results = GetlaunchTubeDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'launchTube' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'launchTube' data structure
        public static List<launchTubeDataStructure> GetlaunchTubeDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("launchTube");
            List <launchTubeDataStructure> result = new List<launchTubeDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                launchTubeDataStructure currentdata = DataStructureParseHelpers.GetlaunchTubeDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'launchTube' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetlaunchTubeDataStructureListFromVD2Data for a collection of 'launchTube' data structures
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <launchTubeDataStructure> results = GetlaunchTubeDataStructureListFromVD2Data(inXML, out exists);
            launchTubeDataStructure result = new launchTubeDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'mirv' data structure as a mirvDataStructure.
        public static mirvDataStructure GetmirvDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool mirvObjectIDexists;
            string mirvObjectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mirvObjectID", out mirvObjectIDexists);

            bool mirvCountexists;
            int mirvCount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "mirvCount", out mirvCountexists);

            bool bNoExplodeOnMirvexists;
            bool bNoExplodeOnMirv = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bNoExplodeOnMirv", out bNoExplodeOnMirvexists);

            mirvDataStructure result = new mirvDataStructure(mirvObjectID, mirvCount, bNoExplodeOnMirv);

            result.SetPropertyExistsInBaseData("mirvObjectID", mirvObjectIDexists);
            result.SetPropertyExists("mirvObjectID", mirvObjectIDexists);

            result.SetPropertyExistsInBaseData("mirvCount", mirvCountexists);
            result.SetPropertyExists("mirvCount", mirvCountexists);

            result.SetPropertyExistsInBaseData("bNoExplodeOnMirv", bNoExplodeOnMirvexists);
            result.SetPropertyExists("bNoExplodeOnMirv", bNoExplodeOnMirvexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'mirv' data structures. 
        //Used for properties that are in a collection. See GetmirvDataStructureFromXMLNodeNamedChild for a single 'mirv' data structure.
        public static List<mirvDataStructure> GetmirvDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetmirvDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'mirv' data structure. 
        //Used for properties that are not in a collection. See GetmirvDataStructureListFromXMLNodeNamedChildren for collections of 'mirv' data structures.
        public static mirvDataStructure GetmirvDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            mirvDataStructure result = new mirvDataStructure();
            bool exists = false;
            List <mirvDataStructure> results = GetmirvDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'mirv' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'mirv' data structure
        public static List<mirvDataStructure> GetmirvDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("mirv");
            List <mirvDataStructure> result = new List<mirvDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                mirvDataStructure currentdata = DataStructureParseHelpers.GetmirvDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'mirv' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmirvDataStructureListFromVD2Data for a collection of 'mirv' data structures
        public static mirvDataStructure GetmirvDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <mirvDataStructure> results = GetmirvDataStructureListFromVD2Data(inXML, out exists);
            mirvDataStructure result = new mirvDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'weaponDirection' data structure as a weaponDirectionDataStructure.
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool mainDirectionexists;
            string mainDirection = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mainDirection", out mainDirectionexists);

            bool yawexists;
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw", out yawexists);
            bool pitchexists;
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch", out pitchexists);
            bool rollexists;
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll", out rollexists);

            weaponDirectionDataStructure result = new weaponDirectionDataStructure(mainDirection, yaw, pitch, roll);

            result.SetPropertyExistsInBaseData("mainDirection", mainDirectionexists);
            result.SetPropertyExists("mainDirection", mainDirectionexists);

            result.SetPropertyExistsInBaseData("yaw", yawexists);
            result.SetPropertyExists("yaw", yawexists);
            result.SetPropertyExistsInBaseData("pitch", pitchexists);
            result.SetPropertyExists("pitch", pitchexists);
            result.SetPropertyExistsInBaseData("roll", rollexists);
            result.SetPropertyExists("roll", rollexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'weaponDirection' data structures. 
        //Used for properties that are in a collection. See GetweaponDirectionDataStructureFromXMLNodeNamedChild for a single 'weaponDirection' data structure.
        public static List<weaponDirectionDataStructure> GetweaponDirectionDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetweaponDirectionDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'weaponDirection' data structure. 
        //Used for properties that are not in a collection. See GetweaponDirectionDataStructureListFromXMLNodeNamedChildren for collections of 'weaponDirection' data structures.
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            weaponDirectionDataStructure result = new weaponDirectionDataStructure();
            bool exists = false;
            List <weaponDirectionDataStructure> results = GetweaponDirectionDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'weaponDirection' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'weaponDirection' data structure
        public static List<weaponDirectionDataStructure> GetweaponDirectionDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("weaponDirection");
            List <weaponDirectionDataStructure> result = new List<weaponDirectionDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                weaponDirectionDataStructure currentdata = DataStructureParseHelpers.GetweaponDirectionDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'weaponDirection' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetweaponDirectionDataStructureListFromVD2Data for a collection of 'weaponDirection' data structures
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <weaponDirectionDataStructure> results = GetweaponDirectionDataStructureListFromVD2Data(inXML, out exists);
            weaponDirectionDataStructure result = new weaponDirectionDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'turretBarrel' data structure as a turretBarrelDataStructure.
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool boneNameexists;
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName", out boneNameexists);

            bool weaponPositionexists;
            Vector3D weaponPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "weaponPosition", out weaponPositionexists);

            turretBarrelDataStructure result = new turretBarrelDataStructure(boneName, weaponPosition);

            result.SetPropertyExistsInBaseData("boneName", boneNameexists);
            result.SetPropertyExists("boneName", boneNameexists);

            result.SetPropertyExistsInBaseData("weaponPosition", weaponPositionexists);
            result.SetPropertyExists("weaponPosition", weaponPositionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'turretBarrel' data structures. 
        //Used for properties that are in a collection. See GetturretBarrelDataStructureFromXMLNodeNamedChild for a single 'turretBarrel' data structure.
        public static List<turretBarrelDataStructure> GetturretBarrelDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetturretBarrelDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'turretBarrel' data structure. 
        //Used for properties that are not in a collection. See GetturretBarrelDataStructureListFromXMLNodeNamedChildren for collections of 'turretBarrel' data structures.
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            turretBarrelDataStructure result = new turretBarrelDataStructure();
            bool exists = false;
            List <turretBarrelDataStructure> results = GetturretBarrelDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'turretBarrel' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'turretBarrel' data structure
        public static List<turretBarrelDataStructure> GetturretBarrelDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("turretBarrel");
            List <turretBarrelDataStructure> result = new List<turretBarrelDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                turretBarrelDataStructure currentdata = DataStructureParseHelpers.GetturretBarrelDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'turretBarrel' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetturretBarrelDataStructureListFromVD2Data for a collection of 'turretBarrel' data structures
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <turretBarrelDataStructure> results = GetturretBarrelDataStructureListFromVD2Data(inXML, out exists);
            turretBarrelDataStructure result = new turretBarrelDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'deathSpawn' data structure as a deathSpawnDataStructure.
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool asteroidIDexists;
            List<string> asteroidID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "asteroidID", out asteroidIDexists);

            deathSpawnDataStructure result = new deathSpawnDataStructure(asteroidID);

            result.SetPropertyExistsInBaseData("asteroidID", asteroidIDexists);
            result.SetPropertyExists("asteroidID", asteroidIDexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'deathSpawn' data structures. 
        //Used for properties that are in a collection. See GetdeathSpawnDataStructureFromXMLNodeNamedChild for a single 'deathSpawn' data structure.
        public static List<deathSpawnDataStructure> GetdeathSpawnDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetdeathSpawnDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'deathSpawn' data structure. 
        //Used for properties that are not in a collection. See GetdeathSpawnDataStructureListFromXMLNodeNamedChildren for collections of 'deathSpawn' data structures.
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            deathSpawnDataStructure result = new deathSpawnDataStructure();
            bool exists = false;
            List <deathSpawnDataStructure> results = GetdeathSpawnDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'deathSpawn' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'deathSpawn' data structure
        public static List<deathSpawnDataStructure> GetdeathSpawnDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("deathSpawn");
            List <deathSpawnDataStructure> result = new List<deathSpawnDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                deathSpawnDataStructure currentdata = DataStructureParseHelpers.GetdeathSpawnDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'deathSpawn' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdeathSpawnDataStructureListFromVD2Data for a collection of 'deathSpawn' data structures
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <deathSpawnDataStructure> results = GetdeathSpawnDataStructureListFromVD2Data(inXML, out exists);
            deathSpawnDataStructure result = new deathSpawnDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'baby' data structure as a babyDataStructure.
        public static babyDataStructure GetbabyDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool asteroidIDexists;
            string asteroidID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "asteroidID", out asteroidIDexists);

            bool lifeTimerexists;
            float lifeTimer = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "lifeTimer", out lifeTimerexists);

            bool linearVelocityexists;
            Vector3D linearVelocity = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "linearVelocity", out linearVelocityexists);

            babyDataStructure result = new babyDataStructure(asteroidID, lifeTimer, linearVelocity);

            result.SetPropertyExistsInBaseData("asteroidID", asteroidIDexists);
            result.SetPropertyExists("asteroidID", asteroidIDexists);

            result.SetPropertyExistsInBaseData("lifeTimer", lifeTimerexists);
            result.SetPropertyExists("lifeTimer", lifeTimerexists);

            result.SetPropertyExistsInBaseData("linearVelocity", linearVelocityexists);
            result.SetPropertyExists("linearVelocity", linearVelocityexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'baby' data structures. 
        //Used for properties that are in a collection. See GetbabyDataStructureFromXMLNodeNamedChild for a single 'baby' data structure.
        public static List<babyDataStructure> GetbabyDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetbabyDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'baby' data structure. 
        //Used for properties that are not in a collection. See GetbabyDataStructureListFromXMLNodeNamedChildren for collections of 'baby' data structures.
        public static babyDataStructure GetbabyDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            babyDataStructure result = new babyDataStructure();
            bool exists = false;
            List <babyDataStructure> results = GetbabyDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'baby' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'baby' data structure
        public static List<babyDataStructure> GetbabyDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("baby");
            List <babyDataStructure> result = new List<babyDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                babyDataStructure currentdata = DataStructureParseHelpers.GetbabyDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'baby' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetbabyDataStructureListFromVD2Data for a collection of 'baby' data structures
        public static babyDataStructure GetbabyDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <babyDataStructure> results = GetbabyDataStructureListFromVD2Data(inXML, out exists);
            babyDataStructure result = new babyDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'largeDock' data structure as a largeDockDataStructure.
        public static largeDockDataStructure GetlargeDockDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool rollRotationexists;
            int rollRotation = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollRotation", out rollRotationexists);

            bool dockPositionexists;
            Vector3D dockPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockPosition", out dockPositionexists);
            bool dockSizeexists;
            Vector3D dockSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockSize", out dockSizeexists);

            largeDockDataStructure result = new largeDockDataStructure(rollRotation, dockPosition, dockSize);

            result.SetPropertyExistsInBaseData("rollRotation", rollRotationexists);
            result.SetPropertyExists("rollRotation", rollRotationexists);

            result.SetPropertyExistsInBaseData("dockPosition", dockPositionexists);
            result.SetPropertyExists("dockPosition", dockPositionexists);
            result.SetPropertyExistsInBaseData("dockSize", dockSizeexists);
            result.SetPropertyExists("dockSize", dockSizeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'largeDock' data structures. 
        //Used for properties that are in a collection. See GetlargeDockDataStructureFromXMLNodeNamedChild for a single 'largeDock' data structure.
        public static List<largeDockDataStructure> GetlargeDockDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetlargeDockDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'largeDock' data structure. 
        //Used for properties that are not in a collection. See GetlargeDockDataStructureListFromXMLNodeNamedChildren for collections of 'largeDock' data structures.
        public static largeDockDataStructure GetlargeDockDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            largeDockDataStructure result = new largeDockDataStructure();
            bool exists = false;
            List <largeDockDataStructure> results = GetlargeDockDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'largeDock' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'largeDock' data structure
        public static List<largeDockDataStructure> GetlargeDockDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("largeDock");
            List <largeDockDataStructure> result = new List<largeDockDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                largeDockDataStructure currentdata = DataStructureParseHelpers.GetlargeDockDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'largeDock' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetlargeDockDataStructureListFromVD2Data for a collection of 'largeDock' data structures
        public static largeDockDataStructure GetlargeDockDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <largeDockDataStructure> results = GetlargeDockDataStructureListFromVD2Data(inXML, out exists);
            largeDockDataStructure result = new largeDockDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'physicalRotatingElement' data structure as a physicalRotatingElementDataStructure.
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromXMLNode(XmlNode inXMLNode)
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

            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure(meshName, collisionShape, rollSpeed, yawSpeed, pitchSpeed);

            result.SetPropertyExistsInBaseData("meshName", meshNameexists);
            result.SetPropertyExists("meshName", meshNameexists);
            result.SetPropertyExistsInBaseData("collisionShape", collisionShapeexists);
            result.SetPropertyExists("collisionShape", collisionShapeexists);

            result.SetPropertyExistsInBaseData("rollSpeed", rollSpeedexists);
            result.SetPropertyExists("rollSpeed", rollSpeedexists);
            result.SetPropertyExistsInBaseData("yawSpeed", yawSpeedexists);
            result.SetPropertyExists("yawSpeed", yawSpeedexists);
            result.SetPropertyExistsInBaseData("pitchSpeed", pitchSpeedexists);
            result.SetPropertyExists("pitchSpeed", pitchSpeedexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'physicalRotatingElement' data structures. 
        //Used for properties that are in a collection. See GetphysicalRotatingElementDataStructureFromXMLNodeNamedChild for a single 'physicalRotatingElement' data structure.
        public static List<physicalRotatingElementDataStructure> GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetphysicalRotatingElementDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'physicalRotatingElement' data structure. 
        //Used for properties that are not in a collection. See GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren for collections of 'physicalRotatingElement' data structures.
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure();
            bool exists = false;
            List <physicalRotatingElementDataStructure> results = GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'physicalRotatingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'physicalRotatingElement' data structure
        public static List<physicalRotatingElementDataStructure> GetphysicalRotatingElementDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("physicalRotatingElement");
            List <physicalRotatingElementDataStructure> result = new List<physicalRotatingElementDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                physicalRotatingElementDataStructure currentdata = DataStructureParseHelpers.GetphysicalRotatingElementDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'physicalRotatingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetphysicalRotatingElementDataStructureListFromVD2Data for a collection of 'physicalRotatingElement' data structures
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <physicalRotatingElementDataStructure> results = GetphysicalRotatingElementDataStructureListFromVD2Data(inXML, out exists);
            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'alwaysOnEffect' data structure as a alwaysOnEffectDataStructure.
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool effectIDexists;
            string effectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "effectID", out effectIDexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);

            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure(effectID, position);

            result.SetPropertyExistsInBaseData("effectID", effectIDexists);
            result.SetPropertyExists("effectID", effectIDexists);

            result.SetPropertyExistsInBaseData("position", positionexists);
            result.SetPropertyExists("position", positionexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'alwaysOnEffect' data structures. 
        //Used for properties that are in a collection. See GetalwaysOnEffectDataStructureFromXMLNodeNamedChild for a single 'alwaysOnEffect' data structure.
        public static List<alwaysOnEffectDataStructure> GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetalwaysOnEffectDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'alwaysOnEffect' data structure. 
        //Used for properties that are not in a collection. See GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren for collections of 'alwaysOnEffect' data structures.
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure();
            bool exists = false;
            List <alwaysOnEffectDataStructure> results = GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'alwaysOnEffect' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'alwaysOnEffect' data structure
        public static List<alwaysOnEffectDataStructure> GetalwaysOnEffectDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("alwaysOnEffect");
            List <alwaysOnEffectDataStructure> result = new List<alwaysOnEffectDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                alwaysOnEffectDataStructure currentdata = DataStructureParseHelpers.GetalwaysOnEffectDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'alwaysOnEffect' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetalwaysOnEffectDataStructureListFromVD2Data for a collection of 'alwaysOnEffect' data structures
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <alwaysOnEffectDataStructure> results = GetalwaysOnEffectDataStructureListFromVD2Data(inXML, out exists);
            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'cargoBay' data structure as a cargoBayDataStructure.
        public static cargoBayDataStructure GetcargoBayDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool cargoBayTypeexists;
            string cargoBayType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "cargoBayType", out cargoBayTypeexists);

            bool maxAmountexists;
            int maxAmount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "maxAmount", out maxAmountexists);

            cargoBayDataStructure result = new cargoBayDataStructure(cargoBayType, maxAmount);

            result.SetPropertyExistsInBaseData("cargoBayType", cargoBayTypeexists);
            result.SetPropertyExists("cargoBayType", cargoBayTypeexists);

            result.SetPropertyExistsInBaseData("maxAmount", maxAmountexists);
            result.SetPropertyExists("maxAmount", maxAmountexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'cargoBay' data structures. 
        //Used for properties that are in a collection. See GetcargoBayDataStructureFromXMLNodeNamedChild for a single 'cargoBay' data structure.
        public static List<cargoBayDataStructure> GetcargoBayDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetcargoBayDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'cargoBay' data structure. 
        //Used for properties that are not in a collection. See GetcargoBayDataStructureListFromXMLNodeNamedChildren for collections of 'cargoBay' data structures.
        public static cargoBayDataStructure GetcargoBayDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            cargoBayDataStructure result = new cargoBayDataStructure();
            bool exists = false;
            List <cargoBayDataStructure> results = GetcargoBayDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'cargoBay' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'cargoBay' data structure
        public static List<cargoBayDataStructure> GetcargoBayDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("cargoBay");
            List <cargoBayDataStructure> result = new List<cargoBayDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                cargoBayDataStructure currentdata = DataStructureParseHelpers.GetcargoBayDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'cargoBay' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetcargoBayDataStructureListFromVD2Data for a collection of 'cargoBay' data structures
        public static cargoBayDataStructure GetcargoBayDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <cargoBayDataStructure> results = GetcargoBayDataStructureListFromVD2Data(inXML, out exists);
            cargoBayDataStructure result = new cargoBayDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'gateCollision' data structure as a gateCollisionDataStructure.
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool gateCollisionSizeexists;
            Vector3D gateCollisionSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "gateCollisionSize", out gateCollisionSizeexists);

            gateCollisionDataStructure result = new gateCollisionDataStructure(gateCollisionSize);

            result.SetPropertyExistsInBaseData("gateCollisionSize", gateCollisionSizeexists);
            result.SetPropertyExists("gateCollisionSize", gateCollisionSizeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'gateCollision' data structures. 
        //Used for properties that are in a collection. See GetgateCollisionDataStructureFromXMLNodeNamedChild for a single 'gateCollision' data structure.
        public static List<gateCollisionDataStructure> GetgateCollisionDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetgateCollisionDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'gateCollision' data structure. 
        //Used for properties that are not in a collection. See GetgateCollisionDataStructureListFromXMLNodeNamedChildren for collections of 'gateCollision' data structures.
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            gateCollisionDataStructure result = new gateCollisionDataStructure();
            bool exists = false;
            List <gateCollisionDataStructure> results = GetgateCollisionDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'gateCollision' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'gateCollision' data structure
        public static List<gateCollisionDataStructure> GetgateCollisionDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("gateCollision");
            List <gateCollisionDataStructure> result = new List<gateCollisionDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                gateCollisionDataStructure currentdata = DataStructureParseHelpers.GetgateCollisionDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'gateCollision' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetgateCollisionDataStructureListFromVD2Data for a collection of 'gateCollision' data structures
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <gateCollisionDataStructure> results = GetgateCollisionDataStructureListFromVD2Data(inXML, out exists);
            gateCollisionDataStructure result = new gateCollisionDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'refuelArea' data structure as a refuelAreaDataStructure.
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool refuelParticleSystemexists;
            string refuelParticleSystem = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "refuelParticleSystem", out refuelParticleSystemexists);

            bool refuelPositionexists;
            Vector3D refuelPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "refuelPosition", out refuelPositionexists);
            bool refuelSizeexists;
            Vector3D refuelSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "refuelSize", out refuelSizeexists);

            refuelAreaDataStructure result = new refuelAreaDataStructure(refuelParticleSystem, refuelPosition, refuelSize);

            result.SetPropertyExistsInBaseData("refuelParticleSystem", refuelParticleSystemexists);
            result.SetPropertyExists("refuelParticleSystem", refuelParticleSystemexists);

            result.SetPropertyExistsInBaseData("refuelPosition", refuelPositionexists);
            result.SetPropertyExists("refuelPosition", refuelPositionexists);
            result.SetPropertyExistsInBaseData("refuelSize", refuelSizeexists);
            result.SetPropertyExists("refuelSize", refuelSizeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'refuelArea' data structures. 
        //Used for properties that are in a collection. See GetrefuelAreaDataStructureFromXMLNodeNamedChild for a single 'refuelArea' data structure.
        public static List<refuelAreaDataStructure> GetrefuelAreaDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetrefuelAreaDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'refuelArea' data structure. 
        //Used for properties that are not in a collection. See GetrefuelAreaDataStructureListFromXMLNodeNamedChildren for collections of 'refuelArea' data structures.
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            refuelAreaDataStructure result = new refuelAreaDataStructure();
            bool exists = false;
            List <refuelAreaDataStructure> results = GetrefuelAreaDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'refuelArea' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'refuelArea' data structure
        public static List<refuelAreaDataStructure> GetrefuelAreaDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("refuelArea");
            List <refuelAreaDataStructure> result = new List<refuelAreaDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                refuelAreaDataStructure currentdata = DataStructureParseHelpers.GetrefuelAreaDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'refuelArea' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrefuelAreaDataStructureListFromVD2Data for a collection of 'refuelArea' data structures
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <refuelAreaDataStructure> results = GetrefuelAreaDataStructureListFromVD2Data(inXML, out exists);
            refuelAreaDataStructure result = new refuelAreaDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'repairArea' data structure as a repairAreaDataStructure.
        public static repairAreaDataStructure GetrepairAreaDataStructureFromXMLNode(XmlNode inXMLNode)
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

            repairAreaDataStructure result = new repairAreaDataStructure(repairParticleSystem, repairSoundID, maxRepairClass, repairPosition, repairSize);

            result.SetPropertyExistsInBaseData("repairParticleSystem", repairParticleSystemexists);
            result.SetPropertyExists("repairParticleSystem", repairParticleSystemexists);
            result.SetPropertyExistsInBaseData("repairSoundID", repairSoundIDexists);
            result.SetPropertyExists("repairSoundID", repairSoundIDexists);
            result.SetPropertyExistsInBaseData("maxRepairClass", maxRepairClassexists);
            result.SetPropertyExists("maxRepairClass", maxRepairClassexists);

            result.SetPropertyExistsInBaseData("repairPosition", repairPositionexists);
            result.SetPropertyExists("repairPosition", repairPositionexists);
            result.SetPropertyExistsInBaseData("repairSize", repairSizeexists);
            result.SetPropertyExists("repairSize", repairSizeexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'repairArea' data structures. 
        //Used for properties that are in a collection. See GetrepairAreaDataStructureFromXMLNodeNamedChild for a single 'repairArea' data structure.
        public static List<repairAreaDataStructure> GetrepairAreaDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetrepairAreaDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'repairArea' data structure. 
        //Used for properties that are not in a collection. See GetrepairAreaDataStructureListFromXMLNodeNamedChildren for collections of 'repairArea' data structures.
        public static repairAreaDataStructure GetrepairAreaDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            repairAreaDataStructure result = new repairAreaDataStructure();
            bool exists = false;
            List <repairAreaDataStructure> results = GetrepairAreaDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'repairArea' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'repairArea' data structure
        public static List<repairAreaDataStructure> GetrepairAreaDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("repairArea");
            List <repairAreaDataStructure> result = new List<repairAreaDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                repairAreaDataStructure currentdata = DataStructureParseHelpers.GetrepairAreaDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'repairArea' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrepairAreaDataStructureListFromVD2Data for a collection of 'repairArea' data structures
        public static repairAreaDataStructure GetrepairAreaDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <repairAreaDataStructure> results = GetrepairAreaDataStructureListFromVD2Data(inXML, out exists);
            repairAreaDataStructure result = new repairAreaDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'mine' data structure as a mineDataStructure.
        public static mineDataStructure GetmineDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool mineIDexists;
            string mineID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mineID", out mineIDexists);

            bool positionexists;
            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position", out positionexists);
            bool linearVelocityexists;
            Vector3D linearVelocity = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "linearVelocity", out linearVelocityexists);

            mineDataStructure result = new mineDataStructure(mineID, position, linearVelocity);

            result.SetPropertyExistsInBaseData("mineID", mineIDexists);
            result.SetPropertyExists("mineID", mineIDexists);

            result.SetPropertyExistsInBaseData("position", positionexists);
            result.SetPropertyExists("position", positionexists);
            result.SetPropertyExistsInBaseData("linearVelocity", linearVelocityexists);
            result.SetPropertyExists("linearVelocity", linearVelocityexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'mine' data structures. 
        //Used for properties that are in a collection. See GetmineDataStructureFromXMLNodeNamedChild for a single 'mine' data structure.
        public static List<mineDataStructure> GetmineDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetmineDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'mine' data structure. 
        //Used for properties that are not in a collection. See GetmineDataStructureListFromXMLNodeNamedChildren for collections of 'mine' data structures.
        public static mineDataStructure GetmineDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            mineDataStructure result = new mineDataStructure();
            bool exists = false;
            List <mineDataStructure> results = GetmineDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'mine' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'mine' data structure
        public static List<mineDataStructure> GetmineDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("mine");
            List <mineDataStructure> result = new List<mineDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                mineDataStructure currentdata = DataStructureParseHelpers.GetmineDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'mine' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmineDataStructureListFromVD2Data for a collection of 'mine' data structures
        public static mineDataStructure GetmineDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <mineDataStructure> results = GetmineDataStructureListFromVD2Data(inXML, out exists);
            mineDataStructure result = new mineDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
        //Gets the value of child nodes to get a 'damageCollisionField' data structure as a damageCollisionFieldDataStructure.
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            bool damageexists;
            int damage = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "damage", out damageexists);
            bool scaleexists;
            int scale = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "scale", out scaleexists);

            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure(damage, scale);

            result.SetPropertyExistsInBaseData("damage", damageexists);
            result.SetPropertyExists("damage", damageexists);
            result.SetPropertyExistsInBaseData("scale", scaleexists);
            result.SetPropertyExists("scale", scaleexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'damageCollisionField' data structures. 
        //Used for properties that are in a collection. See GetdamageCollisionFieldDataStructureFromXMLNodeNamedChild for a single 'damageCollisionField' data structure.
        public static List<damageCollisionFieldDataStructure> GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
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
                    result.Add(GetdamageCollisionFieldDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            outExists = exists;
            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'damageCollisionField' data structure. 
        //Used for properties that are not in a collection. See GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren for collections of 'damageCollisionField' data structures.
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName, out bool outExists)
        {
            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure();
            bool exists = false;
            List <damageCollisionFieldDataStructure> results = GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName, out exists);
            if (results.Count > 0)
            {
                result = results[0];
            }

            outExists = exists;
            return result;
        }

        //Gets a list of 'damageCollisionField' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'damageCollisionField' data structure
        public static List<damageCollisionFieldDataStructure> GetdamageCollisionFieldDataStructureListFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("damageCollisionField");
            List <damageCollisionFieldDataStructure> result = new List<damageCollisionFieldDataStructure>();
            bool exists = false;
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                damageCollisionFieldDataStructure currentdata = DataStructureParseHelpers.GetdamageCollisionFieldDataStructureFromXMLNode(currentnode);
                exists = true;
                result.Add(currentdata);
            }
            outExists = exists;
            return result;
        }

        //Gets the first 'damageCollisionField' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdamageCollisionFieldDataStructureListFromVD2Data for a collection of 'damageCollisionField' data structures
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromVD2Data(XmlDocument inXML, out bool outExists)
        {
            bool exists = false;
            List <damageCollisionFieldDataStructure> results = GetdamageCollisionFieldDataStructureListFromVD2Data(inXML, out exists);
            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            outExists = exists;
            return result;
        }
    }
}
