using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace VoidDestroyer2DataEditor
{
    class VD2UITypeEditor : UITypeEditor
    {
        public override void PaintValue(System.Drawing.Design.PaintValueEventArgs e)
        {
           // base.PaintValue(e);
            VD2Data datainstance = (VD2Data)e.Context.Instance;
            Color indicatorcolor = new Color();
            if (datainstance != null)
            {
                if (datainstance.PropertyExists(e.Context.PropertyDescriptor.Name))
                {
                    if (datainstance.PropertyEdited(e.Context.PropertyDescriptor.Name))
                    {
                        indicatorcolor = Color.Yellow;
                    }
                    else
                    {
                        indicatorcolor = Color.Green;
                    }                    
                }
                else
                {
                    if (datainstance.PropertyExistsInBaseData(e.Context.PropertyDescriptor.Name))
                    {
                        indicatorcolor = Color.Orange;
                    }
                    else
                    {
                        indicatorcolor = Color.Red;
                    }
                }
            }
            e.Graphics.FillRectangle(new SolidBrush(indicatorcolor), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            //e.Graphics.DrawString(e.Value.ToString(), new Font("Arial", 8), new SolidBrush(Color.White), new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
        }

        public override bool GetPaintValueSupported(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
