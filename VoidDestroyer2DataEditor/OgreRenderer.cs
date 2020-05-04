﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.ogre;

namespace VoidDestroyer2DataEditor
{
    public class OgreRenderer : ApplicationContextBase
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
            OgreControls = new List<OgreControl>();
        }

        public Root OgreRoot;

        public OverlaySystem OgreOverlaySystem;

        public List<OgreControl> OgreControls;

        public FileCollisionResolver LoadListener;
        public OgreFrameListener FrameListener;

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
                try
                {
                    createRoot();
                    OgreRoot = getRoot();
                }
                catch(Exception ex)
                {
                    VoidDestroyer2DataEditor.UI.ErrorMessageDialog errordialog = new VoidDestroyer2DataEditor.UI.ErrorMessageDialog();
                    errordialog.ErrorTitleText = "Ogre (1.12.1) failed to create Ogre Root!";
                    errordialog.ErrorMessageText = "Are you missing a dependency or runtime? Contact Draco at draco@dracohouston.net if you need help. \r\nIf you have built from source please ensure you are building for x64, x86/any cpu won't work.\r\n" + ex.Message + ex.StackTrace;
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        errordialog.ErrorMessageText += "\r\n" + ex.Message + ex.StackTrace;
                    }
                    errordialog.ShowDialog();
                    return;
                }
                //OgreOverlaySystem = getOverlaySystem();
                //OgreOverlaySystem.
                ResourceGroupManager rgm = ResourceGroupManager.getSingleton();

                try 
                { 
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
                    rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "Mod/media/models/turrets", "FileSystem", "General");
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
                    rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/turrets", "FileSystem", "General");
                    rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/cockpits", "FileSystem", "General");
                    rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/interiors", "FileSystem", "General");
                    rgm.addResourceLocation(EditorUserSettings.UserSettings.VD2Path + "media/models/overworld", "FileSystem", "General");
                }
                catch
                {
                    VoidDestroyer2DataEditor.UI.ErrorMessageDialog errordialog = new VoidDestroyer2DataEditor.UI.ErrorMessageDialog();
                    errordialog.ErrorTitleText = "Ogre (1.12.1) failed to add resource locations!";
                    errordialog.ErrorMessageText = "Are you missing a dependency or runtime? Contact Draco at draco@dracohouston.net if you need help.";
                    errordialog.ShowDialog();
                    return;
                }

                try
                {
                    RenderSystem rs = OgreRoot.getRenderSystemByName("Direct3D9 Rendering Subsystem");

                    OgreRoot.setRenderSystem(rs);
                    rs.setConfigOption("Full Screen", "No");
                    rs.setConfigOption("Video Mode", "800 x 600 @ 32-bit colour");
                    OgreRoot.initialise(false, "Main Ogre Window");
                }
                catch
                {
                    VoidDestroyer2DataEditor.UI.ErrorMessageDialog errordialog = new VoidDestroyer2DataEditor.UI.ErrorMessageDialog();
                    errordialog.ErrorTitleText = "Ogre (1.12.1) failed to initialize render system and main window!";
                    errordialog.ErrorMessageText = "Are you missing a dependency or runtime? Contact Draco at draco@dracohouston.net if you need help.";
                    errordialog.ShowDialog();
                    return;
                }
                LoadListener = new FileCollisionResolver();
                ResourceGroupManager.getSingleton().setLoadingListener(LoadListener);
                FrameListener = new OgreFrameListener();
                OgreRoot.addFrameListener(FrameListener);
            }
        }

        public void ReleaseOgre()
        {
            OgreRoot.Dispose();
            OgreRoot = null;
        }
    }

    public class OgreFrameListenerEventArgs : EventArgs
    {
        public float DeltaTime;
        public float TotalTime;
    }

    public class OgreFrameListener : FrameListener
    {
        public float DeltaTime;
        public float TotalTime;

        public event EventHandler<OgreFrameListenerEventArgs> OnFrameEnded;

        public OgreFrameListener()
        {
            DeltaTime = 0;
            TotalTime = 0;
        }

        public override bool frameStarted(FrameEvent evt)
        {
            return true;
        }

        public override bool frameEnded(FrameEvent evt)
        {
            DeltaTime = evt.timeSinceLastFrame;
            TotalTime += DeltaTime;
            OgreFrameListenerEventArgs e = new OgreFrameListenerEventArgs();
            e.DeltaTime = DeltaTime;
            e.TotalTime = TotalTime;
            OnFrameEnded?.Invoke(this, e);
            return true;
        }

        public override bool frameRenderingQueued(FrameEvent evt)
        {
            return true;
        }
    }
}
