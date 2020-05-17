using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using org.ogre;

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
            OgreControls = new List<OgreControl>();
        }

        //public Root OgreRoot;
        public EditorRendererSubsystem EditorRS;

        //public OverlaySystem OgreOverlaySystem;

        public List<OgreControl> OgreControls;

        //public FileCollisionResolver LoadListener;
        //public OgreFrameListener FrameListener;

        public bool IsReady
        {
            get
            {
                /*if (OgreRoot != null)
                {
                    return true;
                }*/
                return false;
            }
        }

        public bool InitEditorRendererSubsystem()
        {
            if (EditorRS == null)
            {
                try
                {
                    EditorRS = new EditorRendererSubsystem();
                    EditorRS.Init(EditorUserSettings.UserSettings.VD2Path);
                }
                catch (Exception ex)
                {
                    VoidDestroyer2DataEditor.UI.ErrorMessageDialog errordialog = new VoidDestroyer2DataEditor.UI.ErrorMessageDialog();
                    errordialog.ErrorTitleText = "Editor Renderer Subsystem failed to initialize!";
                    errordialog.ErrorMessageText = "Are you missing a dependency or runtime? Contact Draco at draco@dracohouston.net if you need help. \r\nIf you have built from source please ensure you are building for x64, x86/any cpu won't work.\r\n" + ex.Message + ex.StackTrace;
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        errordialog.ErrorMessageText += "\r\n" + ex.Message + ex.StackTrace;
                    }
                    errordialog.ShowDialog();
                    return false;
                }
            }
            return true;
        }        

        public void ReleaseEditorRenderer()
        {
            if (EditorRS != null)
            {
                EditorRS.Shutdown();
            }
        }
    }

    public class OgreFrameListenerEventArgs : EventArgs
    {
        public float DeltaTime;
        public float TotalTime;
    }

   /* public class OgreFrameListener : FrameListener
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
    }*/
}
