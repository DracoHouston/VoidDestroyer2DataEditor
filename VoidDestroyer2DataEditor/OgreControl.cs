using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using org.ogre;

namespace VoidDestroyer2DataEditor
{

    public partial class OgreControl : UserControl
    {
        bool DraggingCamera;
        Point OldMouseLocation;
        public Camera OgreCamera;
        public SceneManager OgreScene;
        public RenderWindow OgreWindow;
        public CameraMan OgreCameraMan;
        public float distance;
        public float zoomdistance;
        public float yaw;
        public float pitch;
        public string meshname;
        public OgreControl()
        {
            DraggingCamera = false;
            InitializeComponent();
            Disposed += new EventHandler(OgreControl_Disposed);
            MouseWheel += OgreControl_MouseWheel;
        }

        

        private void OgreControl_Disposed(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                OgreCameraMan.Dispose();
                OgreCamera.Dispose();
                OgreScene.Dispose();
                OgreWindow.Dispose();
            }
        }

        protected void OgreControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (OgreRenderer.Renderer.IsReady)
                {
                    NameValuePairList misc = new NameValuePairList();
                    misc["externalWindowHandle"] = Handle.ToString();
                    OgreWindow = OgreRenderer.Renderer.OgreRoot.createRenderWindow(Name + Handle.ToString(), 800, 600, false, misc);

                    TextureManager.getSingleton().setDefaultNumMipmaps(5);
                    //ResourceGroupManager.getSingleton().
                    //ResourceGroupManager.getSingleton().setLoadingListener(new FileCollisionResolver());
                    ResourceGroupManager.getSingleton().initialiseAllResourceGroups();
                    //ResourceGroupManager.getSingleton().loadResourceGroup("General");
                    OgreScene = OgreRenderer.Renderer.OgreRoot.createSceneManager();
                    //ResourceGroupManager.getSingleton().
                    //var shadergen = ShaderGenerator.getSingleton();
                    //shadergen.addSceneManager(OgreScene);/// must be done before we do anything with the scene

                    OgreScene.setAmbientLight(new ColourValue(.6f, .6f, .6f));

                    var light = OgreScene.createLight("MainLight");
                    var lightnode = OgreScene.getRootSceneNode().createChildSceneNode();
                    lightnode.setPosition(0f, 10f, 15f);
                    lightnode.attachObject(light);
                    OgreCamera = OgreScene.createCamera("myCam");
                    OgreCamera.setAutoAspectRatio(true);
                    OgreCamera.setNearClipDistance(5);
                    var camnode = OgreScene.getRootSceneNode().createChildSceneNode();
                    camnode.attachObject(OgreCamera);

                    OgreCameraMan = new CameraMan(camnode);
                    OgreCameraMan.setStyle(CameraStyle.CS_ORBIT);
                    distance = 200f;
                    yaw = 0f;
                    pitch = 0.3f;
                    OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
                    var vp = OgreWindow.addViewport(OgreCamera);
                    //var vp = getRenderWindow().addViewport(cam);
                    vp.setBackgroundColour(new ColourValue(.3f, .3f, .3f));
                    SpawnEntities();
                    OgreRenderer.Renderer.OgreRoot.renderOneFrame();
                }
            }
        }

        protected virtual void SpawnEntities()
        {
            if (meshname != null)
            {
                if (meshname != "")
                {

                    var ent = OgreScene.createEntity(GetTrueFileName(meshname));
                    distance = ent.getBoundingRadius() * 1.25f;
                    zoomdistance = distance * 0.1f;
                    OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
                    //ent.setMaterial()
                    var node = OgreScene.getRootSceneNode().createChildSceneNode();
                    node.attachObject(ent);
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

       /* private void OgreControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                OgreRenderer.Renderer.OgreRoot.renderOneFrame();
            }
            else if (e.KeyCode == Keys.W)
            {
                distance -= 20;
                distance = System.Math.Max(0, distance);
                OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
            }
            else if (e.KeyCode == Keys.S)
            {
                distance += 20;
                OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
            }
            else if (e.KeyCode == Keys.A)
            {
                yaw += 0.1f;
                OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
            }
            else if (e.KeyCode == Keys.D)
            {
                yaw -= 0.1f;
                OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
            }
        }*/

        private void OgreControl_Resize(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                if (OgreWindow != null)
                {
                    OgreWindow.windowMovedOrResized();
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
                OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
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
            
            OgreCameraMan.setYawPitchDist(new Radian(yaw), new Radian(pitch), distance);
        }
    }

    public class testclass : MaterialManager_Listener //fine
    {

    }

    public class FileCollisionResolver : ResourceLoadingListener //'ResourceLoadingListener' does not contain a constructor that takes 0 arguments
    {
        public override bool resourceCollision(Resource resource, ResourceManager resourceManager)
        {
            return false;
        }

        public override DataStreamPtr resourceLoading(string name, string group, Resource resource)
        {
            return new DataStreamPtr();
        }

        public override void resourceStreamOpened(string name, string group, Resource resource, DataStreamPtr dataStream)
        {

        }
    }
}
