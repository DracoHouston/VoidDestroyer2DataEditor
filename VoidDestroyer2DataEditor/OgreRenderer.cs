using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.ogre;

namespace VoidDestroyer2DataEditor
{
    public class OgreRenderer
    {
        private static OgreRenderer Instance = null;
        public static OgreRenderer Renderer
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new OgreRenderer();
                }
                return Instance;
            }
        }
        private OgreRenderer()
        {

        }

        public Root OgreRoot;

        public bool IsReady
        {
            get
            {
                if (OgreRoot != null)
                {
                    return true;
                }
                return false;
            }
        }

        public void InitOgre()
        {
            if (OgreRoot == null)
            {
                OgreRoot = new Root();

                ResourceGroupManager rgm = ResourceGroupManager.getSingleton();


                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/packs/SdkTrays.zip", "Zip", "Essential");
                
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/Media/materials/scripts", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/Media/materials/programs", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Media/materials/scripts", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Media/materials/programs", "FileSystem", "General");

                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/gui", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/materials/textures", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/materials/textures/backgrounds", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/materials/textures/effects", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/materials/textures/hud", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/materials/textures/hud/CBA", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/materials/textures/wireframes", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/materials/textures/shipclasses", "FileSystem", "General");

                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/gui", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/materials/textures", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/materials/textures/backgrounds", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/materials/textures/effects", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/materials/textures/hud", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/materials/textures/hud/CBA", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/materials/textures/wireframes", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/materials/textures/shipclasses", "FileSystem", "General");

                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/asteroids", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/bases", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/debris", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/missiles", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/other", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/ships", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/shields", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/stations", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/cockpits", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/interiors", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/overworld", "FileSystem", "General");

                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/asteroids", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/bases", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/debris", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/missiles", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/other", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/ships", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/shields", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/stations", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/cockpits", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/interiors", "FileSystem", "General");
                rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/overworld", "FileSystem", "General");

                RenderSystem rs = OgreRoot.getRenderSystemByName("Direct3D9 Rendering Subsystem");

                OgreRoot.setRenderSystem(rs);
                rs.setConfigOption("Full Screen", "No");
                rs.setConfigOption("Video Mode", "800 x 600 @ 32-bit colour");
                OgreRoot.initialise(false, "Main Ogre Window");
            }
        }

        public void ReleaseOgre()
        {
            OgreRoot.Dispose();
            OgreRoot = null;
        }
    }
}
