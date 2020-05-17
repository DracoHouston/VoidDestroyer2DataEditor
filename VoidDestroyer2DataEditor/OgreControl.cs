using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{

    public partial class OgreControl : UserControl
    {
        public bool SplashLoadingWindow;
        bool DraggingCamera;
        Point OldMouseLocation;
        protected EditorViewport VP;
        protected EditorWorld World;
        EditorActor MainActor;
        public float distance;
        public float zoomdistance;
        public float yaw;
        public float pitch;
        public string meshname;
        public OgreControl()
        {
            SplashLoadingWindow = false;
            DraggingCamera = false;
            InitializeComponent();
            Disposed += new EventHandler(OgreControl_Disposed);
            MouseWheel += OgreControl_MouseWheel;
        }        

        private void OgreControl_Disposed(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (!SplashLoadingWindow)
                {
                    if (VP != null)
                    {
                        VP.Destroy();
                        VP.Dispose();
                        VP = null;
                    }
                    if (World != null)
                    {
                        World.Destroy();
                        World.Dispose();
                        World = null;
                    }
                    if (MainActor != null)
                    {
                        MainActor.Destroy();
                    }
                }
            }
        }

        protected void OgreControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                VP = OgreRenderer.Renderer.EditorRS.CreateEditorViewport(Name, Handle.ToString());
                World = VP.CreateWorld(true);
                
                SpawnEntities();
            }
        }

        protected virtual void SpawnEntities()
        {
            if (meshname != null)
            {
                if (meshname != "")
                {
                    MainActor = World.CreateActor("Model");
                    if (MainActor != null)
                    {
                        MainActor.SetMesh(GetTrueFileName(meshname));
                        distance = MainActor.GetBoundingRadius() * 1.25f;
                        zoomdistance = distance * 0.1f;
                        VP.SetCameraDistance(distance);
                    }
                }
            }
        }

        public static string GetTrueFileName(string inAllegedName)
        {
            if (Directory.Exists(EditorUserSettings.UserSettings.VD2Path + "Mod\\media\\models"))
            {
                foreach (string path in Directory.EnumerateDirectories(EditorUserSettings.UserSettings.VD2Path + "Mod\\media\\models"))
                {
                    foreach (string file in Directory.EnumerateFiles(path))
                    {
                        if (inAllegedName.ToLower() == Path.GetFileName(file).ToLower())
                        {
                            return Path.GetFileName(file);
                        }
                    }
                }
            }
            if (Directory.Exists(EditorUserSettings.UserSettings.VD2Path + "media\\models"))
            {
                foreach (string path in Directory.EnumerateDirectories(EditorUserSettings.UserSettings.VD2Path + "media\\models"))
                {
                    foreach (string file in Directory.EnumerateFiles(path))
                    {
                        if (inAllegedName.ToLower() == Path.GetFileName(file).ToLower())
                        {
                            return Path.GetFileName(file);
                        }
                    }
                }
            }

            return "";//doesnt even exist.
        }      

        private void OgreControl_Resize(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (VP != null)
                {
                    VP.WindowMovedOrResized();
                }
            }
        }

        private void OgreControl_MouseDown(object sender, MouseEventArgs e)
        {
            DraggingCamera = true;
        }

        private void OgreControl_MouseLeave(object sender, EventArgs e)
        {
            DraggingCamera = false;
        }

        private void OgreControl_MouseUp(object sender, MouseEventArgs e)
        {
            DraggingCamera = false;
        }

        private void OgreControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (DraggingCamera)
            {
                Point mouselookdelta = new Point(e.Location.X - OldMouseLocation.X, e.Location.Y - OldMouseLocation.Y);
                yaw += mouselookdelta.X * 0.01f;
                pitch += mouselookdelta.Y * 0.01f;
                //distance += e.Delta;
                VP.SetCameraYawPitchDistance(yaw, pitch, distance);
            }
            OldMouseLocation = e.Location;
        }
        private void OgreControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                distance -= zoomdistance;
            }
            else
            {
                distance += zoomdistance;
            }

            VP.SetCameraYawPitchDistance(yaw, pitch, distance);
        }
    }
}
