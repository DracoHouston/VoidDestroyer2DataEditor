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
            bool hasdebrisID = false;
            bool debrisIDexists = false;
            string debrisID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "debrisID", out debrisIDexists);

            int debrisMomentum = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "debrisMomentum");
            int debrisAngular = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "debrisAngular");

            debrisDataStructure result = new debrisDataStructure(debrisID, debrisMomentum, debrisAngular);
            result.VD2PropertyInfos.Add("debrisID", new VD2PropertyInfo());
            result.SetPropertyExists("debrisID", debrisIDexists);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'debris' data structures. 
        //Used for properties that are in a collection. See GetdebrisDataStructureFromXMLNodeNamedChild for a single 'debris' data structure.
        public static List<debrisDataStructure> GetdebrisDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<debrisDataStructure> result = new List<debrisDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetdebrisDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'debris' data structure. 
        //Used for properties that are not in a collection. See GetdebrisDataStructureListFromXMLNodeNamedChildren for collections of 'debris' data structures.
        public static debrisDataStructure GetdebrisDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            debrisDataStructure result = new debrisDataStructure();
            List <debrisDataStructure> results = GetdebrisDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'debris' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'debris' data structure
        public static List<debrisDataStructure> GetdebrisDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("debris");
            List <debrisDataStructure> result = new List<debrisDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                debrisDataStructure currentdata = DataStructureParseHelpers.GetdebrisDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'debris' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdebrisDataStructureListFromVD2Data for a collection of 'debris' data structures
        public static debrisDataStructure GetdebrisDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <debrisDataStructure> results = GetdebrisDataStructureListFromVD2Data(inXML);
            debrisDataStructure result = new debrisDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'debrisInfo' data structure as a debrisInfoDataStructure.
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            List<debrisDataStructure> debris = DataStructureParseHelpers.GetdebrisDataStructureListFromXMLNodeNamedChildren(inXMLNode, "debris");

            debrisInfoDataStructure result = new debrisInfoDataStructure(debris);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'debrisInfo' data structures. 
        //Used for properties that are in a collection. See GetdebrisInfoDataStructureFromXMLNodeNamedChild for a single 'debrisInfo' data structure.
        public static List<debrisInfoDataStructure> GetdebrisInfoDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<debrisInfoDataStructure> result = new List<debrisInfoDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetdebrisInfoDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'debrisInfo' data structure. 
        //Used for properties that are not in a collection. See GetdebrisInfoDataStructureListFromXMLNodeNamedChildren for collections of 'debrisInfo' data structures.
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            debrisInfoDataStructure result = new debrisInfoDataStructure();
            List <debrisInfoDataStructure> results = GetdebrisInfoDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'debrisInfo' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'debrisInfo' data structure
        public static List<debrisInfoDataStructure> GetdebrisInfoDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("debrisInfo");
            List <debrisInfoDataStructure> result = new List<debrisInfoDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                debrisInfoDataStructure currentdata = DataStructureParseHelpers.GetdebrisInfoDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'debrisInfo' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdebrisInfoDataStructureListFromVD2Data for a collection of 'debrisInfo' data structures
        public static debrisInfoDataStructure GetdebrisInfoDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <debrisInfoDataStructure> results = GetdebrisInfoDataStructureListFromVD2Data(inXML);
            debrisInfoDataStructure result = new debrisInfoDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'afterburner' data structure as a afterburnerDataStructure.
        public static afterburnerDataStructure GetafterburnerDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string soundID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "soundID");
            string tailSoundID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "tailSoundID");

            float multiplier = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "multiplier");
            float capacity = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "capacity");
            float recharge = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "recharge");

            afterburnerDataStructure result = new afterburnerDataStructure(soundID, tailSoundID, multiplier, capacity, recharge);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'afterburner' data structures. 
        //Used for properties that are in a collection. See GetafterburnerDataStructureFromXMLNodeNamedChild for a single 'afterburner' data structure.
        public static List<afterburnerDataStructure> GetafterburnerDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<afterburnerDataStructure> result = new List<afterburnerDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetafterburnerDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'afterburner' data structure. 
        //Used for properties that are not in a collection. See GetafterburnerDataStructureListFromXMLNodeNamedChildren for collections of 'afterburner' data structures.
        public static afterburnerDataStructure GetafterburnerDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            afterburnerDataStructure result = new afterburnerDataStructure();
            List <afterburnerDataStructure> results = GetafterburnerDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'afterburner' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'afterburner' data structure
        public static List<afterburnerDataStructure> GetafterburnerDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("afterburner");
            List <afterburnerDataStructure> result = new List<afterburnerDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                afterburnerDataStructure currentdata = DataStructureParseHelpers.GetafterburnerDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'afterburner' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetafterburnerDataStructureListFromVD2Data for a collection of 'afterburner' data structures
        public static afterburnerDataStructure GetafterburnerDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <afterburnerDataStructure> results = GetafterburnerDataStructureListFromVD2Data(inXML);
            afterburnerDataStructure result = new afterburnerDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'targetPriorityList' data structure as a targetPriorityListDataStructure.
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            List<string> targetClass = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "targetClass");

            targetPriorityListDataStructure result = new targetPriorityListDataStructure(targetClass);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'targetPriorityList' data structures. 
        //Used for properties that are in a collection. See GettargetPriorityListDataStructureFromXMLNodeNamedChild for a single 'targetPriorityList' data structure.
        public static List<targetPriorityListDataStructure> GettargetPriorityListDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<targetPriorityListDataStructure> result = new List<targetPriorityListDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GettargetPriorityListDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'targetPriorityList' data structure. 
        //Used for properties that are not in a collection. See GettargetPriorityListDataStructureListFromXMLNodeNamedChildren for collections of 'targetPriorityList' data structures.
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            targetPriorityListDataStructure result = new targetPriorityListDataStructure();
            List <targetPriorityListDataStructure> results = GettargetPriorityListDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'targetPriorityList' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'targetPriorityList' data structure
        public static List<targetPriorityListDataStructure> GettargetPriorityListDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("targetPriorityList");
            List <targetPriorityListDataStructure> result = new List<targetPriorityListDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                targetPriorityListDataStructure currentdata = DataStructureParseHelpers.GettargetPriorityListDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'targetPriorityList' data structure from a definition XML
        //Used for data structures that are not in a collection. See GettargetPriorityListDataStructureListFromVD2Data for a collection of 'targetPriorityList' data structures
        public static targetPriorityListDataStructure GettargetPriorityListDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <targetPriorityListDataStructure> results = GettargetPriorityListDataStructureListFromVD2Data(inXML);
            targetPriorityListDataStructure result = new targetPriorityListDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'upgrades' data structure as a upgradesDataStructure.
        public static upgradesDataStructure GetupgradesDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            List<string> upgradeID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "upgradeID");

            int primaryUpgradeCapacity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "primaryUpgradeCapacity");
            int activeUpgradeCapacity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "activeUpgradeCapacity");

            upgradesDataStructure result = new upgradesDataStructure(upgradeID, primaryUpgradeCapacity, activeUpgradeCapacity);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'upgrades' data structures. 
        //Used for properties that are in a collection. See GetupgradesDataStructureFromXMLNodeNamedChild for a single 'upgrades' data structure.
        public static List<upgradesDataStructure> GetupgradesDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<upgradesDataStructure> result = new List<upgradesDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetupgradesDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'upgrades' data structure. 
        //Used for properties that are not in a collection. See GetupgradesDataStructureListFromXMLNodeNamedChildren for collections of 'upgrades' data structures.
        public static upgradesDataStructure GetupgradesDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            upgradesDataStructure result = new upgradesDataStructure();
            List <upgradesDataStructure> results = GetupgradesDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'upgrades' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'upgrades' data structure
        public static List<upgradesDataStructure> GetupgradesDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("upgrades");
            List <upgradesDataStructure> result = new List<upgradesDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                upgradesDataStructure currentdata = DataStructureParseHelpers.GetupgradesDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'upgrades' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetupgradesDataStructureListFromVD2Data for a collection of 'upgrades' data structures
        public static upgradesDataStructure GetupgradesDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <upgradesDataStructure> results = GetupgradesDataStructureListFromVD2Data(inXML);
            upgradesDataStructure result = new upgradesDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'propulsion' data structure as a propulsionDataStructure.
        public static propulsionDataStructure GetpropulsionDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string propulsionEffectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "propulsionEffectID");
            string direction = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "direction");

            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch");
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw");

            bool bPlayerShipOnly = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bPlayerShipOnly");

            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position");

            propulsionDataStructure result = new propulsionDataStructure(propulsionEffectID, direction, pitch, yaw, bPlayerShipOnly, position);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'propulsion' data structures. 
        //Used for properties that are in a collection. See GetpropulsionDataStructureFromXMLNodeNamedChild for a single 'propulsion' data structure.
        public static List<propulsionDataStructure> GetpropulsionDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<propulsionDataStructure> result = new List<propulsionDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetpropulsionDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'propulsion' data structure. 
        //Used for properties that are not in a collection. See GetpropulsionDataStructureListFromXMLNodeNamedChildren for collections of 'propulsion' data structures.
        public static propulsionDataStructure GetpropulsionDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            propulsionDataStructure result = new propulsionDataStructure();
            List <propulsionDataStructure> results = GetpropulsionDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'propulsion' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'propulsion' data structure
        public static List<propulsionDataStructure> GetpropulsionDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("propulsion");
            List <propulsionDataStructure> result = new List<propulsionDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                propulsionDataStructure currentdata = DataStructureParseHelpers.GetpropulsionDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'propulsion' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetpropulsionDataStructureListFromVD2Data for a collection of 'propulsion' data structures
        public static propulsionDataStructure GetpropulsionDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <propulsionDataStructure> results = GetpropulsionDataStructureListFromVD2Data(inXML);
            propulsionDataStructure result = new propulsionDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'weapon' data structure as a weaponDataStructure.
        public static weaponDataStructure GetweaponDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string weaponType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponType");
            string hardpointID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "hardpointID");
            string weaponFire = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponFire");

            float barrelDelay = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "barrelDelay");
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw");
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch");

            List<Vector3D> weaponPosition = ParseHelpers.GetVector3DListFromXMLNodeNamedChildren(inXMLNode, "weaponPosition");

            weaponDataStructure result = new weaponDataStructure(weaponType, hardpointID, weaponFire, barrelDelay, yaw, pitch, weaponPosition);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'weapon' data structures. 
        //Used for properties that are in a collection. See GetweaponDataStructureFromXMLNodeNamedChild for a single 'weapon' data structure.
        public static List<weaponDataStructure> GetweaponDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<weaponDataStructure> result = new List<weaponDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetweaponDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'weapon' data structure. 
        //Used for properties that are not in a collection. See GetweaponDataStructureListFromXMLNodeNamedChildren for collections of 'weapon' data structures.
        public static weaponDataStructure GetweaponDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            weaponDataStructure result = new weaponDataStructure();
            List <weaponDataStructure> results = GetweaponDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'weapon' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'weapon' data structure
        public static List<weaponDataStructure> GetweaponDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("weapon");
            List <weaponDataStructure> result = new List<weaponDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                weaponDataStructure currentdata = DataStructureParseHelpers.GetweaponDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'weapon' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetweaponDataStructureListFromVD2Data for a collection of 'weapon' data structures
        public static weaponDataStructure GetweaponDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <weaponDataStructure> results = GetweaponDataStructureListFromVD2Data(inXML);
            weaponDataStructure result = new weaponDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'damage' data structure as a damageDataStructure.
        public static damageDataStructure GetdamageDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string damageEffectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "damageEffectID");

            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch");
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll");
            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw");
            float healthPoint = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "healthPoint");

            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position");

            damageDataStructure result = new damageDataStructure(damageEffectID, pitch, roll, yaw, healthPoint, position);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'damage' data structures. 
        //Used for properties that are in a collection. See GetdamageDataStructureFromXMLNodeNamedChild for a single 'damage' data structure.
        public static List<damageDataStructure> GetdamageDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<damageDataStructure> result = new List<damageDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetdamageDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'damage' data structure. 
        //Used for properties that are not in a collection. See GetdamageDataStructureListFromXMLNodeNamedChildren for collections of 'damage' data structures.
        public static damageDataStructure GetdamageDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            damageDataStructure result = new damageDataStructure();
            List <damageDataStructure> results = GetdamageDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'damage' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'damage' data structure
        public static List<damageDataStructure> GetdamageDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("damage");
            List <damageDataStructure> result = new List<damageDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                damageDataStructure currentdata = DataStructureParseHelpers.GetdamageDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'damage' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdamageDataStructureListFromVD2Data for a collection of 'damage' data structures
        public static damageDataStructure GetdamageDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <damageDataStructure> results = GetdamageDataStructureListFromVD2Data(inXML);
            damageDataStructure result = new damageDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'turret' data structure as a turretDataStructure.
        public static turretDataStructure GetturretDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string turretID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "turretID");
            string turretOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "turretOrientation");
            string weaponFire = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "weaponFire");

            List<string> turretRole = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "turretRole");

            int yawPermitted = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "yawPermitted");
            int weaponPositionID = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "weaponPositionID");

            float pitchLower = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitchLower");
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll");

            List<float> yaw = ParseHelpers.GetFloatListFromXMLNodeNamedChildren(inXMLNode, "yaw");

            bool bShowInCockpit = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bShowInCockpit");
            bool bHideInHangar = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bHideInHangar");

            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position");

            turretDataStructure result = new turretDataStructure(turretID, turretOrientation, weaponFire, turretRole, yawPermitted, weaponPositionID, pitchLower, roll, yaw, bShowInCockpit, bHideInHangar, position);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'turret' data structures. 
        //Used for properties that are in a collection. See GetturretDataStructureFromXMLNodeNamedChild for a single 'turret' data structure.
        public static List<turretDataStructure> GetturretDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<turretDataStructure> result = new List<turretDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetturretDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'turret' data structure. 
        //Used for properties that are not in a collection. See GetturretDataStructureListFromXMLNodeNamedChildren for collections of 'turret' data structures.
        public static turretDataStructure GetturretDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            turretDataStructure result = new turretDataStructure();
            List <turretDataStructure> results = GetturretDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'turret' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'turret' data structure
        public static List<turretDataStructure> GetturretDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("turret");
            List <turretDataStructure> result = new List<turretDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                turretDataStructure currentdata = DataStructureParseHelpers.GetturretDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'turret' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetturretDataStructureListFromVD2Data for a collection of 'turret' data structures
        public static turretDataStructure GetturretDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <turretDataStructure> results = GetturretDataStructureListFromVD2Data(inXML);
            turretDataStructure result = new turretDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'attachment' data structure as a attachmentDataStructure.
        public static attachmentDataStructure GetattachmentDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string attachmentOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "attachmentOrientation");

            List<string> attachmentID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "attachmentID");

            Vector3D attachmentPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "attachmentPosition");

            attachmentDataStructure result = new attachmentDataStructure(attachmentOrientation, attachmentID, attachmentPosition);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'attachment' data structures. 
        //Used for properties that are in a collection. See GetattachmentDataStructureFromXMLNodeNamedChild for a single 'attachment' data structure.
        public static List<attachmentDataStructure> GetattachmentDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<attachmentDataStructure> result = new List<attachmentDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetattachmentDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'attachment' data structure. 
        //Used for properties that are not in a collection. See GetattachmentDataStructureListFromXMLNodeNamedChildren for collections of 'attachment' data structures.
        public static attachmentDataStructure GetattachmentDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            attachmentDataStructure result = new attachmentDataStructure();
            List <attachmentDataStructure> results = GetattachmentDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'attachment' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'attachment' data structure
        public static List<attachmentDataStructure> GetattachmentDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("attachment");
            List <attachmentDataStructure> result = new List<attachmentDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                attachmentDataStructure currentdata = DataStructureParseHelpers.GetattachmentDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'attachment' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetattachmentDataStructureListFromVD2Data for a collection of 'attachment' data structures
        public static attachmentDataStructure GetattachmentDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <attachmentDataStructure> results = GetattachmentDataStructureListFromVD2Data(inXML);
            attachmentDataStructure result = new attachmentDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'movingElement' data structure as a movingElementDataStructure.
        public static movingElementDataStructure GetmovingElementDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName");

            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw");
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch");
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll");
            float speedMultiplier = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "speedMultiplier");

            bool bLinkedToWeapon = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bLinkedToWeapon");
            bool bCombat = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bCombat");

            Vector3D translateAmount = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "translateAmount");

            movingElementDataStructure result = new movingElementDataStructure(boneName, yaw, pitch, roll, speedMultiplier, bLinkedToWeapon, bCombat, translateAmount);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'movingElement' data structures. 
        //Used for properties that are in a collection. See GetmovingElementDataStructureFromXMLNodeNamedChild for a single 'movingElement' data structure.
        public static List<movingElementDataStructure> GetmovingElementDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<movingElementDataStructure> result = new List<movingElementDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetmovingElementDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'movingElement' data structure. 
        //Used for properties that are not in a collection. See GetmovingElementDataStructureListFromXMLNodeNamedChildren for collections of 'movingElement' data structures.
        public static movingElementDataStructure GetmovingElementDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            movingElementDataStructure result = new movingElementDataStructure();
            List <movingElementDataStructure> results = GetmovingElementDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'movingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'movingElement' data structure
        public static List<movingElementDataStructure> GetmovingElementDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("movingElement");
            List <movingElementDataStructure> result = new List<movingElementDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                movingElementDataStructure currentdata = DataStructureParseHelpers.GetmovingElementDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'movingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmovingElementDataStructureListFromVD2Data for a collection of 'movingElement' data structures
        public static movingElementDataStructure GetmovingElementDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <movingElementDataStructure> results = GetmovingElementDataStructureListFromVD2Data(inXML);
            movingElementDataStructure result = new movingElementDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'dock' data structure as a dockDataStructure.
        public static dockDataStructure GetdockDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string dockType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "dockType");
            string ejectOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "ejectOrientation");
            string orientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "orientation");
            string attachedID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "attachedID");
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName");
            string dockOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "dockOrientation");
            string resourceOnly = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "resourceOnly");

            List<string> objectID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "objectID");

            int ejectVelocity = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "ejectVelocity");
            int dockRollOffset = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "dockRollOffset");
            int dockYawOffset = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "dockYawOffset");

            bool bCanAcceptRawResource = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bCanAcceptRawResource");
            bool bInvisible = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bInvisible");

            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position");

            dockDataStructure result = new dockDataStructure(dockType, ejectOrientation, orientation, attachedID, boneName, dockOrientation, resourceOnly, objectID, ejectVelocity, dockRollOffset, dockYawOffset, bCanAcceptRawResource, bInvisible, position);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'dock' data structures. 
        //Used for properties that are in a collection. See GetdockDataStructureFromXMLNodeNamedChild for a single 'dock' data structure.
        public static List<dockDataStructure> GetdockDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<dockDataStructure> result = new List<dockDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetdockDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'dock' data structure. 
        //Used for properties that are not in a collection. See GetdockDataStructureListFromXMLNodeNamedChildren for collections of 'dock' data structures.
        public static dockDataStructure GetdockDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            dockDataStructure result = new dockDataStructure();
            List <dockDataStructure> results = GetdockDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'dock' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'dock' data structure
        public static List<dockDataStructure> GetdockDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("dock");
            List <dockDataStructure> result = new List<dockDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                dockDataStructure currentdata = DataStructureParseHelpers.GetdockDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'dock' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdockDataStructureListFromVD2Data for a collection of 'dock' data structures
        public static dockDataStructure GetdockDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <dockDataStructure> results = GetdockDataStructureListFromVD2Data(inXML);
            dockDataStructure result = new dockDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'shield' data structure as a shieldDataStructure.
        public static shieldDataStructure GetshieldDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string shieldID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "shieldID");
            string shieldOrientation = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "shieldOrientation");

            int pitch = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "pitch");
            int roll = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "roll");

            Vector3D shieldPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "shieldPosition");

            shieldDataStructure result = new shieldDataStructure(shieldID, shieldOrientation, pitch, roll, shieldPosition);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'shield' data structures. 
        //Used for properties that are in a collection. See GetshieldDataStructureFromXMLNodeNamedChild for a single 'shield' data structure.
        public static List<shieldDataStructure> GetshieldDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<shieldDataStructure> result = new List<shieldDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetshieldDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'shield' data structure. 
        //Used for properties that are not in a collection. See GetshieldDataStructureListFromXMLNodeNamedChildren for collections of 'shield' data structures.
        public static shieldDataStructure GetshieldDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            shieldDataStructure result = new shieldDataStructure();
            List <shieldDataStructure> results = GetshieldDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'shield' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'shield' data structure
        public static List<shieldDataStructure> GetshieldDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("shield");
            List <shieldDataStructure> result = new List<shieldDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                shieldDataStructure currentdata = DataStructureParseHelpers.GetshieldDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'shield' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetshieldDataStructureListFromVD2Data for a collection of 'shield' data structures
        public static shieldDataStructure GetshieldDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <shieldDataStructure> results = GetshieldDataStructureListFromVD2Data(inXML);
            shieldDataStructure result = new shieldDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'rotatingElement' data structure as a rotatingElementDataStructure.
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName");

            int rollSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollSpeed");

            bool bLinkedToWeapon = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bLinkedToWeapon");

            rotatingElementDataStructure result = new rotatingElementDataStructure(boneName, rollSpeed, bLinkedToWeapon);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'rotatingElement' data structures. 
        //Used for properties that are in a collection. See GetrotatingElementDataStructureFromXMLNodeNamedChild for a single 'rotatingElement' data structure.
        public static List<rotatingElementDataStructure> GetrotatingElementDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<rotatingElementDataStructure> result = new List<rotatingElementDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetrotatingElementDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'rotatingElement' data structure. 
        //Used for properties that are not in a collection. See GetrotatingElementDataStructureListFromXMLNodeNamedChildren for collections of 'rotatingElement' data structures.
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            rotatingElementDataStructure result = new rotatingElementDataStructure();
            List <rotatingElementDataStructure> results = GetrotatingElementDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'rotatingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'rotatingElement' data structure
        public static List<rotatingElementDataStructure> GetrotatingElementDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("rotatingElement");
            List <rotatingElementDataStructure> result = new List<rotatingElementDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                rotatingElementDataStructure currentdata = DataStructureParseHelpers.GetrotatingElementDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'rotatingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrotatingElementDataStructureListFromVD2Data for a collection of 'rotatingElement' data structures
        public static rotatingElementDataStructure GetrotatingElementDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <rotatingElementDataStructure> results = GetrotatingElementDataStructureListFromVD2Data(inXML);
            rotatingElementDataStructure result = new rotatingElementDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'recoil' data structure as a recoilDataStructure.
        public static recoilDataStructure GetrecoilDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string recoilBone = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "recoilBone");
            string muzzleBoneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "muzzleBoneName");
            string recoilParentType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "recoilParentType");

            List<string> muzzleBone = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "muzzleBone");

            float recoilZ = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "recoilZ");
            float recoilTime = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "recoilTime");

            recoilDataStructure result = new recoilDataStructure(recoilBone, muzzleBoneName, recoilParentType, muzzleBone, recoilZ, recoilTime);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'recoil' data structures. 
        //Used for properties that are in a collection. See GetrecoilDataStructureFromXMLNodeNamedChild for a single 'recoil' data structure.
        public static List<recoilDataStructure> GetrecoilDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<recoilDataStructure> result = new List<recoilDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetrecoilDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'recoil' data structure. 
        //Used for properties that are not in a collection. See GetrecoilDataStructureListFromXMLNodeNamedChildren for collections of 'recoil' data structures.
        public static recoilDataStructure GetrecoilDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            recoilDataStructure result = new recoilDataStructure();
            List <recoilDataStructure> results = GetrecoilDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'recoil' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'recoil' data structure
        public static List<recoilDataStructure> GetrecoilDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("recoil");
            List <recoilDataStructure> result = new List<recoilDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                recoilDataStructure currentdata = DataStructureParseHelpers.GetrecoilDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'recoil' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrecoilDataStructureListFromVD2Data for a collection of 'recoil' data structures
        public static recoilDataStructure GetrecoilDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <recoilDataStructure> results = GetrecoilDataStructureListFromVD2Data(inXML);
            recoilDataStructure result = new recoilDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'rotateBones' data structure as a rotateBonesDataStructure.
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string rotateBone = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "rotateBone");

            rotateBonesDataStructure result = new rotateBonesDataStructure(rotateBone);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'rotateBones' data structures. 
        //Used for properties that are in a collection. See GetrotateBonesDataStructureFromXMLNodeNamedChild for a single 'rotateBones' data structure.
        public static List<rotateBonesDataStructure> GetrotateBonesDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<rotateBonesDataStructure> result = new List<rotateBonesDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetrotateBonesDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'rotateBones' data structure. 
        //Used for properties that are not in a collection. See GetrotateBonesDataStructureListFromXMLNodeNamedChildren for collections of 'rotateBones' data structures.
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            rotateBonesDataStructure result = new rotateBonesDataStructure();
            List <rotateBonesDataStructure> results = GetrotateBonesDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'rotateBones' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'rotateBones' data structure
        public static List<rotateBonesDataStructure> GetrotateBonesDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("rotateBones");
            List <rotateBonesDataStructure> result = new List<rotateBonesDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                rotateBonesDataStructure currentdata = DataStructureParseHelpers.GetrotateBonesDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'rotateBones' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrotateBonesDataStructureListFromVD2Data for a collection of 'rotateBones' data structures
        public static rotateBonesDataStructure GetrotateBonesDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <rotateBonesDataStructure> results = GetrotateBonesDataStructureListFromVD2Data(inXML);
            rotateBonesDataStructure result = new rotateBonesDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'canister' data structure as a canisterDataStructure.
        public static canisterDataStructure GetcanisterDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string projectileID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "projectileID");

            int canisterCount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "canisterCount");
            int yawRange = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "yawRange");
            int pitchRange = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "pitchRange");
            int rollRange = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollRange");
            int speedAddBase = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "speedAddBase");
            int speedAddRandom = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "speedAddRandom");

            bool blowBackCanisterCount = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "blowBackCanisterCount");
            bool bCanisterAimAssist = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bCanisterAimAssist");
            bool bAddToRangeCalculations = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bAddToRangeCalculations");

            canisterDataStructure result = new canisterDataStructure(projectileID, canisterCount, yawRange, pitchRange, rollRange, speedAddBase, speedAddRandom, blowBackCanisterCount, bCanisterAimAssist, bAddToRangeCalculations);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'canister' data structures. 
        //Used for properties that are in a collection. See GetcanisterDataStructureFromXMLNodeNamedChild for a single 'canister' data structure.
        public static List<canisterDataStructure> GetcanisterDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<canisterDataStructure> result = new List<canisterDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetcanisterDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'canister' data structure. 
        //Used for properties that are not in a collection. See GetcanisterDataStructureListFromXMLNodeNamedChildren for collections of 'canister' data structures.
        public static canisterDataStructure GetcanisterDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            canisterDataStructure result = new canisterDataStructure();
            List <canisterDataStructure> results = GetcanisterDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'canister' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'canister' data structure
        public static List<canisterDataStructure> GetcanisterDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("canister");
            List <canisterDataStructure> result = new List<canisterDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                canisterDataStructure currentdata = DataStructureParseHelpers.GetcanisterDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'canister' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetcanisterDataStructureListFromVD2Data for a collection of 'canister' data structures
        public static canisterDataStructure GetcanisterDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <canisterDataStructure> results = GetcanisterDataStructureListFromVD2Data(inXML);
            canisterDataStructure result = new canisterDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'launchTube' data structure as a launchTubeDataStructure.
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string direction = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "direction");

            Vector3D launchDeckBeg = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "launchDeckBeg");
            Vector3D launchDeckEnd = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "launchDeckEnd");
            Vector3D dockPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockPosition");
            Vector3D dockSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockSize");

            launchTubeDataStructure result = new launchTubeDataStructure(direction, launchDeckBeg, launchDeckEnd, dockPosition, dockSize);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'launchTube' data structures. 
        //Used for properties that are in a collection. See GetlaunchTubeDataStructureFromXMLNodeNamedChild for a single 'launchTube' data structure.
        public static List<launchTubeDataStructure> GetlaunchTubeDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<launchTubeDataStructure> result = new List<launchTubeDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetlaunchTubeDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'launchTube' data structure. 
        //Used for properties that are not in a collection. See GetlaunchTubeDataStructureListFromXMLNodeNamedChildren for collections of 'launchTube' data structures.
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            launchTubeDataStructure result = new launchTubeDataStructure();
            List <launchTubeDataStructure> results = GetlaunchTubeDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'launchTube' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'launchTube' data structure
        public static List<launchTubeDataStructure> GetlaunchTubeDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("launchTube");
            List <launchTubeDataStructure> result = new List<launchTubeDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                launchTubeDataStructure currentdata = DataStructureParseHelpers.GetlaunchTubeDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'launchTube' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetlaunchTubeDataStructureListFromVD2Data for a collection of 'launchTube' data structures
        public static launchTubeDataStructure GetlaunchTubeDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <launchTubeDataStructure> results = GetlaunchTubeDataStructureListFromVD2Data(inXML);
            launchTubeDataStructure result = new launchTubeDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'mirv' data structure as a mirvDataStructure.
        public static mirvDataStructure GetmirvDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string mirvObjectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mirvObjectID");

            int mirvCount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "mirvCount");

            bool bNoExplodeOnMirv = ParseHelpers.GetBoolFromXMLNodeNamedChild(inXMLNode, "bNoExplodeOnMirv");

            mirvDataStructure result = new mirvDataStructure(mirvObjectID, mirvCount, bNoExplodeOnMirv);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'mirv' data structures. 
        //Used for properties that are in a collection. See GetmirvDataStructureFromXMLNodeNamedChild for a single 'mirv' data structure.
        public static List<mirvDataStructure> GetmirvDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<mirvDataStructure> result = new List<mirvDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetmirvDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'mirv' data structure. 
        //Used for properties that are not in a collection. See GetmirvDataStructureListFromXMLNodeNamedChildren for collections of 'mirv' data structures.
        public static mirvDataStructure GetmirvDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            mirvDataStructure result = new mirvDataStructure();
            List <mirvDataStructure> results = GetmirvDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'mirv' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'mirv' data structure
        public static List<mirvDataStructure> GetmirvDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("mirv");
            List <mirvDataStructure> result = new List<mirvDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                mirvDataStructure currentdata = DataStructureParseHelpers.GetmirvDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'mirv' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmirvDataStructureListFromVD2Data for a collection of 'mirv' data structures
        public static mirvDataStructure GetmirvDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <mirvDataStructure> results = GetmirvDataStructureListFromVD2Data(inXML);
            mirvDataStructure result = new mirvDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'weaponDirection' data structure as a weaponDirectionDataStructure.
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string mainDirection = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mainDirection");

            float yaw = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "yaw");
            float pitch = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "pitch");
            float roll = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "roll");

            weaponDirectionDataStructure result = new weaponDirectionDataStructure(mainDirection, yaw, pitch, roll);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'weaponDirection' data structures. 
        //Used for properties that are in a collection. See GetweaponDirectionDataStructureFromXMLNodeNamedChild for a single 'weaponDirection' data structure.
        public static List<weaponDirectionDataStructure> GetweaponDirectionDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<weaponDirectionDataStructure> result = new List<weaponDirectionDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetweaponDirectionDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'weaponDirection' data structure. 
        //Used for properties that are not in a collection. See GetweaponDirectionDataStructureListFromXMLNodeNamedChildren for collections of 'weaponDirection' data structures.
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            weaponDirectionDataStructure result = new weaponDirectionDataStructure();
            List <weaponDirectionDataStructure> results = GetweaponDirectionDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'weaponDirection' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'weaponDirection' data structure
        public static List<weaponDirectionDataStructure> GetweaponDirectionDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("weaponDirection");
            List <weaponDirectionDataStructure> result = new List<weaponDirectionDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                weaponDirectionDataStructure currentdata = DataStructureParseHelpers.GetweaponDirectionDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'weaponDirection' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetweaponDirectionDataStructureListFromVD2Data for a collection of 'weaponDirection' data structures
        public static weaponDirectionDataStructure GetweaponDirectionDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <weaponDirectionDataStructure> results = GetweaponDirectionDataStructureListFromVD2Data(inXML);
            weaponDirectionDataStructure result = new weaponDirectionDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'turretBarrel' data structure as a turretBarrelDataStructure.
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string boneName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "boneName");

            Vector3D weaponPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "weaponPosition");

            turretBarrelDataStructure result = new turretBarrelDataStructure(boneName, weaponPosition);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'turretBarrel' data structures. 
        //Used for properties that are in a collection. See GetturretBarrelDataStructureFromXMLNodeNamedChild for a single 'turretBarrel' data structure.
        public static List<turretBarrelDataStructure> GetturretBarrelDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<turretBarrelDataStructure> result = new List<turretBarrelDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetturretBarrelDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'turretBarrel' data structure. 
        //Used for properties that are not in a collection. See GetturretBarrelDataStructureListFromXMLNodeNamedChildren for collections of 'turretBarrel' data structures.
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            turretBarrelDataStructure result = new turretBarrelDataStructure();
            List <turretBarrelDataStructure> results = GetturretBarrelDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'turretBarrel' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'turretBarrel' data structure
        public static List<turretBarrelDataStructure> GetturretBarrelDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("turretBarrel");
            List <turretBarrelDataStructure> result = new List<turretBarrelDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                turretBarrelDataStructure currentdata = DataStructureParseHelpers.GetturretBarrelDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'turretBarrel' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetturretBarrelDataStructureListFromVD2Data for a collection of 'turretBarrel' data structures
        public static turretBarrelDataStructure GetturretBarrelDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <turretBarrelDataStructure> results = GetturretBarrelDataStructureListFromVD2Data(inXML);
            turretBarrelDataStructure result = new turretBarrelDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'deathSpawn' data structure as a deathSpawnDataStructure.
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            List<string> asteroidID = ParseHelpers.GetStringListFromXMLNodeNamedChildren(inXMLNode, "asteroidID");

            deathSpawnDataStructure result = new deathSpawnDataStructure(asteroidID);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'deathSpawn' data structures. 
        //Used for properties that are in a collection. See GetdeathSpawnDataStructureFromXMLNodeNamedChild for a single 'deathSpawn' data structure.
        public static List<deathSpawnDataStructure> GetdeathSpawnDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<deathSpawnDataStructure> result = new List<deathSpawnDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetdeathSpawnDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'deathSpawn' data structure. 
        //Used for properties that are not in a collection. See GetdeathSpawnDataStructureListFromXMLNodeNamedChildren for collections of 'deathSpawn' data structures.
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            deathSpawnDataStructure result = new deathSpawnDataStructure();
            List <deathSpawnDataStructure> results = GetdeathSpawnDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'deathSpawn' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'deathSpawn' data structure
        public static List<deathSpawnDataStructure> GetdeathSpawnDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("deathSpawn");
            List <deathSpawnDataStructure> result = new List<deathSpawnDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                deathSpawnDataStructure currentdata = DataStructureParseHelpers.GetdeathSpawnDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'deathSpawn' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdeathSpawnDataStructureListFromVD2Data for a collection of 'deathSpawn' data structures
        public static deathSpawnDataStructure GetdeathSpawnDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <deathSpawnDataStructure> results = GetdeathSpawnDataStructureListFromVD2Data(inXML);
            deathSpawnDataStructure result = new deathSpawnDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'baby' data structure as a babyDataStructure.
        public static babyDataStructure GetbabyDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string asteroidID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "asteroidID");

            float lifeTimer = ParseHelpers.GetFloatFromXMLNodeNamedChild(inXMLNode, "lifeTimer");

            Vector3D linearVelocity = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "linearVelocity");

            babyDataStructure result = new babyDataStructure(asteroidID, lifeTimer, linearVelocity);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'baby' data structures. 
        //Used for properties that are in a collection. See GetbabyDataStructureFromXMLNodeNamedChild for a single 'baby' data structure.
        public static List<babyDataStructure> GetbabyDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<babyDataStructure> result = new List<babyDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetbabyDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'baby' data structure. 
        //Used for properties that are not in a collection. See GetbabyDataStructureListFromXMLNodeNamedChildren for collections of 'baby' data structures.
        public static babyDataStructure GetbabyDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            babyDataStructure result = new babyDataStructure();
            List <babyDataStructure> results = GetbabyDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'baby' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'baby' data structure
        public static List<babyDataStructure> GetbabyDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("baby");
            List <babyDataStructure> result = new List<babyDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                babyDataStructure currentdata = DataStructureParseHelpers.GetbabyDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'baby' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetbabyDataStructureListFromVD2Data for a collection of 'baby' data structures
        public static babyDataStructure GetbabyDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <babyDataStructure> results = GetbabyDataStructureListFromVD2Data(inXML);
            babyDataStructure result = new babyDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'largeDock' data structure as a largeDockDataStructure.
        public static largeDockDataStructure GetlargeDockDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            int rollRotation = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollRotation");

            Vector3D dockPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockPosition");
            Vector3D dockSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "dockSize");

            largeDockDataStructure result = new largeDockDataStructure(rollRotation, dockPosition, dockSize);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'largeDock' data structures. 
        //Used for properties that are in a collection. See GetlargeDockDataStructureFromXMLNodeNamedChild for a single 'largeDock' data structure.
        public static List<largeDockDataStructure> GetlargeDockDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<largeDockDataStructure> result = new List<largeDockDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetlargeDockDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'largeDock' data structure. 
        //Used for properties that are not in a collection. See GetlargeDockDataStructureListFromXMLNodeNamedChildren for collections of 'largeDock' data structures.
        public static largeDockDataStructure GetlargeDockDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            largeDockDataStructure result = new largeDockDataStructure();
            List <largeDockDataStructure> results = GetlargeDockDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'largeDock' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'largeDock' data structure
        public static List<largeDockDataStructure> GetlargeDockDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("largeDock");
            List <largeDockDataStructure> result = new List<largeDockDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                largeDockDataStructure currentdata = DataStructureParseHelpers.GetlargeDockDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'largeDock' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetlargeDockDataStructureListFromVD2Data for a collection of 'largeDock' data structures
        public static largeDockDataStructure GetlargeDockDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <largeDockDataStructure> results = GetlargeDockDataStructureListFromVD2Data(inXML);
            largeDockDataStructure result = new largeDockDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'physicalRotatingElement' data structure as a physicalRotatingElementDataStructure.
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string meshName = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "meshName");
            string collisionShape = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "collisionShape");

            int rollSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "rollSpeed");
            int yawSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "yawSpeed");
            int pitchSpeed = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "pitchSpeed");

            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure(meshName, collisionShape, rollSpeed, yawSpeed, pitchSpeed);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'physicalRotatingElement' data structures. 
        //Used for properties that are in a collection. See GetphysicalRotatingElementDataStructureFromXMLNodeNamedChild for a single 'physicalRotatingElement' data structure.
        public static List<physicalRotatingElementDataStructure> GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<physicalRotatingElementDataStructure> result = new List<physicalRotatingElementDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetphysicalRotatingElementDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'physicalRotatingElement' data structure. 
        //Used for properties that are not in a collection. See GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren for collections of 'physicalRotatingElement' data structures.
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure();
            List <physicalRotatingElementDataStructure> results = GetphysicalRotatingElementDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'physicalRotatingElement' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'physicalRotatingElement' data structure
        public static List<physicalRotatingElementDataStructure> GetphysicalRotatingElementDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("physicalRotatingElement");
            List <physicalRotatingElementDataStructure> result = new List<physicalRotatingElementDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                physicalRotatingElementDataStructure currentdata = DataStructureParseHelpers.GetphysicalRotatingElementDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'physicalRotatingElement' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetphysicalRotatingElementDataStructureListFromVD2Data for a collection of 'physicalRotatingElement' data structures
        public static physicalRotatingElementDataStructure GetphysicalRotatingElementDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <physicalRotatingElementDataStructure> results = GetphysicalRotatingElementDataStructureListFromVD2Data(inXML);
            physicalRotatingElementDataStructure result = new physicalRotatingElementDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'alwaysOnEffect' data structure as a alwaysOnEffectDataStructure.
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string effectID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "effectID");

            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position");

            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure(effectID, position);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'alwaysOnEffect' data structures. 
        //Used for properties that are in a collection. See GetalwaysOnEffectDataStructureFromXMLNodeNamedChild for a single 'alwaysOnEffect' data structure.
        public static List<alwaysOnEffectDataStructure> GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<alwaysOnEffectDataStructure> result = new List<alwaysOnEffectDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetalwaysOnEffectDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'alwaysOnEffect' data structure. 
        //Used for properties that are not in a collection. See GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren for collections of 'alwaysOnEffect' data structures.
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure();
            List <alwaysOnEffectDataStructure> results = GetalwaysOnEffectDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'alwaysOnEffect' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'alwaysOnEffect' data structure
        public static List<alwaysOnEffectDataStructure> GetalwaysOnEffectDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("alwaysOnEffect");
            List <alwaysOnEffectDataStructure> result = new List<alwaysOnEffectDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                alwaysOnEffectDataStructure currentdata = DataStructureParseHelpers.GetalwaysOnEffectDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'alwaysOnEffect' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetalwaysOnEffectDataStructureListFromVD2Data for a collection of 'alwaysOnEffect' data structures
        public static alwaysOnEffectDataStructure GetalwaysOnEffectDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <alwaysOnEffectDataStructure> results = GetalwaysOnEffectDataStructureListFromVD2Data(inXML);
            alwaysOnEffectDataStructure result = new alwaysOnEffectDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'cargoBay' data structure as a cargoBayDataStructure.
        public static cargoBayDataStructure GetcargoBayDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string cargoBayType = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "cargoBayType");

            int maxAmount = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "maxAmount");

            cargoBayDataStructure result = new cargoBayDataStructure(cargoBayType, maxAmount);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'cargoBay' data structures. 
        //Used for properties that are in a collection. See GetcargoBayDataStructureFromXMLNodeNamedChild for a single 'cargoBay' data structure.
        public static List<cargoBayDataStructure> GetcargoBayDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<cargoBayDataStructure> result = new List<cargoBayDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetcargoBayDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'cargoBay' data structure. 
        //Used for properties that are not in a collection. See GetcargoBayDataStructureListFromXMLNodeNamedChildren for collections of 'cargoBay' data structures.
        public static cargoBayDataStructure GetcargoBayDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            cargoBayDataStructure result = new cargoBayDataStructure();
            List <cargoBayDataStructure> results = GetcargoBayDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'cargoBay' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'cargoBay' data structure
        public static List<cargoBayDataStructure> GetcargoBayDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("cargoBay");
            List <cargoBayDataStructure> result = new List<cargoBayDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                cargoBayDataStructure currentdata = DataStructureParseHelpers.GetcargoBayDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'cargoBay' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetcargoBayDataStructureListFromVD2Data for a collection of 'cargoBay' data structures
        public static cargoBayDataStructure GetcargoBayDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <cargoBayDataStructure> results = GetcargoBayDataStructureListFromVD2Data(inXML);
            cargoBayDataStructure result = new cargoBayDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'gateCollision' data structure as a gateCollisionDataStructure.
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            Vector3D gateCollisionSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "gateCollisionSize");

            gateCollisionDataStructure result = new gateCollisionDataStructure(gateCollisionSize);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'gateCollision' data structures. 
        //Used for properties that are in a collection. See GetgateCollisionDataStructureFromXMLNodeNamedChild for a single 'gateCollision' data structure.
        public static List<gateCollisionDataStructure> GetgateCollisionDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<gateCollisionDataStructure> result = new List<gateCollisionDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetgateCollisionDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'gateCollision' data structure. 
        //Used for properties that are not in a collection. See GetgateCollisionDataStructureListFromXMLNodeNamedChildren for collections of 'gateCollision' data structures.
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            gateCollisionDataStructure result = new gateCollisionDataStructure();
            List <gateCollisionDataStructure> results = GetgateCollisionDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'gateCollision' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'gateCollision' data structure
        public static List<gateCollisionDataStructure> GetgateCollisionDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("gateCollision");
            List <gateCollisionDataStructure> result = new List<gateCollisionDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                gateCollisionDataStructure currentdata = DataStructureParseHelpers.GetgateCollisionDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'gateCollision' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetgateCollisionDataStructureListFromVD2Data for a collection of 'gateCollision' data structures
        public static gateCollisionDataStructure GetgateCollisionDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <gateCollisionDataStructure> results = GetgateCollisionDataStructureListFromVD2Data(inXML);
            gateCollisionDataStructure result = new gateCollisionDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'refuelArea' data structure as a refuelAreaDataStructure.
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string refuelParticleSystem = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "refuelParticleSystem");

            Vector3D refuelPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "refuelPosition");
            Vector3D refuelSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "refuelSize");

            refuelAreaDataStructure result = new refuelAreaDataStructure(refuelParticleSystem, refuelPosition, refuelSize);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'refuelArea' data structures. 
        //Used for properties that are in a collection. See GetrefuelAreaDataStructureFromXMLNodeNamedChild for a single 'refuelArea' data structure.
        public static List<refuelAreaDataStructure> GetrefuelAreaDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<refuelAreaDataStructure> result = new List<refuelAreaDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetrefuelAreaDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'refuelArea' data structure. 
        //Used for properties that are not in a collection. See GetrefuelAreaDataStructureListFromXMLNodeNamedChildren for collections of 'refuelArea' data structures.
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            refuelAreaDataStructure result = new refuelAreaDataStructure();
            List <refuelAreaDataStructure> results = GetrefuelAreaDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'refuelArea' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'refuelArea' data structure
        public static List<refuelAreaDataStructure> GetrefuelAreaDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("refuelArea");
            List <refuelAreaDataStructure> result = new List<refuelAreaDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                refuelAreaDataStructure currentdata = DataStructureParseHelpers.GetrefuelAreaDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'refuelArea' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrefuelAreaDataStructureListFromVD2Data for a collection of 'refuelArea' data structures
        public static refuelAreaDataStructure GetrefuelAreaDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <refuelAreaDataStructure> results = GetrefuelAreaDataStructureListFromVD2Data(inXML);
            refuelAreaDataStructure result = new refuelAreaDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'repairArea' data structure as a repairAreaDataStructure.
        public static repairAreaDataStructure GetrepairAreaDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string repairParticleSystem = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "repairParticleSystem");
            string repairSoundID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "repairSoundID");
            string maxRepairClass = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "maxRepairClass");

            Vector3D repairPosition = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "repairPosition");
            Vector3D repairSize = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "repairSize");

            repairAreaDataStructure result = new repairAreaDataStructure(repairParticleSystem, repairSoundID, maxRepairClass, repairPosition, repairSize);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'repairArea' data structures. 
        //Used for properties that are in a collection. See GetrepairAreaDataStructureFromXMLNodeNamedChild for a single 'repairArea' data structure.
        public static List<repairAreaDataStructure> GetrepairAreaDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<repairAreaDataStructure> result = new List<repairAreaDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetrepairAreaDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'repairArea' data structure. 
        //Used for properties that are not in a collection. See GetrepairAreaDataStructureListFromXMLNodeNamedChildren for collections of 'repairArea' data structures.
        public static repairAreaDataStructure GetrepairAreaDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            repairAreaDataStructure result = new repairAreaDataStructure();
            List <repairAreaDataStructure> results = GetrepairAreaDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'repairArea' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'repairArea' data structure
        public static List<repairAreaDataStructure> GetrepairAreaDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("repairArea");
            List <repairAreaDataStructure> result = new List<repairAreaDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                repairAreaDataStructure currentdata = DataStructureParseHelpers.GetrepairAreaDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'repairArea' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetrepairAreaDataStructureListFromVD2Data for a collection of 'repairArea' data structures
        public static repairAreaDataStructure GetrepairAreaDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <repairAreaDataStructure> results = GetrepairAreaDataStructureListFromVD2Data(inXML);
            repairAreaDataStructure result = new repairAreaDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'mine' data structure as a mineDataStructure.
        public static mineDataStructure GetmineDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            string mineID = ParseHelpers.GetStringFromXMLNodeNamedChild(inXMLNode, "mineID");

            Vector3D position = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "position");
            Vector3D linearVelocity = ParseHelpers.GetVector3DFromXMLNodeNamedChild(inXMLNode, "linearVelocity");

            mineDataStructure result = new mineDataStructure(mineID, position, linearVelocity);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'mine' data structures. 
        //Used for properties that are in a collection. See GetmineDataStructureFromXMLNodeNamedChild for a single 'mine' data structure.
        public static List<mineDataStructure> GetmineDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<mineDataStructure> result = new List<mineDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetmineDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'mine' data structure. 
        //Used for properties that are not in a collection. See GetmineDataStructureListFromXMLNodeNamedChildren for collections of 'mine' data structures.
        public static mineDataStructure GetmineDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            mineDataStructure result = new mineDataStructure();
            List <mineDataStructure> results = GetmineDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'mine' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'mine' data structure
        public static List<mineDataStructure> GetmineDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("mine");
            List <mineDataStructure> result = new List<mineDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                mineDataStructure currentdata = DataStructureParseHelpers.GetmineDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'mine' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetmineDataStructureListFromVD2Data for a collection of 'mine' data structures
        public static mineDataStructure GetmineDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <mineDataStructure> results = GetmineDataStructureListFromVD2Data(inXML);
            mineDataStructure result = new mineDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
        //Gets the value of child nodes to get a 'damageCollisionField' data structure as a damageCollisionFieldDataStructure.
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromXMLNode(XmlNode inXMLNode)
        {
            int damage = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "damage");
            int scale = ParseHelpers.GetInt32FromXMLNodeNamedChild(inXMLNode, "scale");

            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure(damage, scale);

            return result;
        }

        //Get data structures with this name from the child nodes of this xml node, as a list of 'damageCollisionField' data structures. 
        //Used for properties that are in a collection. See GetdamageCollisionFieldDataStructureFromXMLNodeNamedChild for a single 'damageCollisionField' data structure.
        public static List<damageCollisionFieldDataStructure> GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren(XmlNode inXMLNode, string inChildNodeName)
        {
            List<damageCollisionFieldDataStructure> result = new List<damageCollisionFieldDataStructure>();
            int childindex = 0;
            for (childindex = 0; childindex < inXMLNode.ChildNodes.Count; childindex++)
            {
                XmlNode CurrentChildNode = inXMLNode.ChildNodes[childindex];
                if (CurrentChildNode.Name == inChildNodeName)
                {
                    result.Add(GetdamageCollisionFieldDataStructureFromXMLNode(CurrentChildNode));
                }
            }

            return result;
        }

        //Get the first data structure with this name from the child nodes of this xml node, as a 'damageCollisionField' data structure. 
        //Used for properties that are not in a collection. See GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren for collections of 'damageCollisionField' data structures.
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromXMLNodeNamedChild(XmlNode inXMLNode, string inChildNodeName)
        {
            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure();
            List <damageCollisionFieldDataStructure> results = GetdamageCollisionFieldDataStructureListFromXMLNodeNamedChildren(inXMLNode, inChildNodeName);
            if (results.Count > 0)
            {
                result = results[0];
            }

            return result;
        }

        //Gets a list of 'damageCollisionField' data structures from a definition XML
        //Used for data structures that are in a collection. See GetDataStructureFromVD2Data for a single 'damageCollisionField' data structure
        public static List<damageCollisionFieldDataStructure> GetdamageCollisionFieldDataStructureListFromVD2Data(XmlDocument inXML)
        {
            XmlNodeList xmlnodes = inXML.GetElementsByTagName("damageCollisionField");
            List <damageCollisionFieldDataStructure> result = new List<damageCollisionFieldDataStructure>();
            int nodeindex = 0;
            for (nodeindex = 0; nodeindex < xmlnodes.Count; nodeindex++)
            {
                XmlNode currentnode = xmlnodes[nodeindex];
                damageCollisionFieldDataStructure currentdata = DataStructureParseHelpers.GetdamageCollisionFieldDataStructureFromXMLNode(currentnode);
                result.Add(currentdata);
            }
            return result;
        }

        //Gets the first 'damageCollisionField' data structure from a definition XML
        //Used for data structures that are not in a collection. See GetdamageCollisionFieldDataStructureListFromVD2Data for a collection of 'damageCollisionField' data structures
        public static damageCollisionFieldDataStructure GetdamageCollisionFieldDataStructureFromVD2Data(XmlDocument inXML)
        {
            List <damageCollisionFieldDataStructure> results = GetdamageCollisionFieldDataStructureListFromVD2Data(inXML);
            damageCollisionFieldDataStructure result = new damageCollisionFieldDataStructure();

            if (results.Count > 0)
            {
                result = results[0];
            }
            return result;
        }
    }
}
