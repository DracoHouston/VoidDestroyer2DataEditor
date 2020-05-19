using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoidDestroyer2DataEditor
{
    public partial class PUOgreControl : OgreControl
    {
        public string PUSystemName;
        EditorActor PUActor;
        PUSystemComponent PUComponent;
        public PUOgreControl()
        {
            InitializeComponent();
        }

        protected override void OgreControlDisposed()
        {
            if (!DesignMode)
            {
                if (!SplashLoadingWindow)
                {
                    if (PUActor != null)
                    {
                        PUActor.Destroy();
                    }                    
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
                }
            }
        }

        protected override void SpawnEntities()
        {
            PUActor = World.CreateActor("PUActor");
            PUComponent = PUActor.CreatePUSystemComponent("PUSystem", PUSystemName, true);
            PUComponent.PlaySystem();
            distance = 50;
            zoomdistance = 5;
            VP.SetCameraYawPitchDistance(yaw, pitch, distance);
        }
    }
}
