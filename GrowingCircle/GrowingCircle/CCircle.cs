using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrowingCircle
{
    class CCircle
    {
        public float xc, yc;
        public int radius;
        public float stTheta;
        public float endTheta;
        public bool incir;

        public CCircle(float xc, float yc, int radius, float stTheta, float endTheta)
        {
            this.xc = xc;
            this.yc = yc;
            this.radius = radius;
            this.stTheta = stTheta * (float)Math.PI / 180;
            this.endTheta = endTheta * (float)Math.PI / 180;
        }
        public void drawcircle(Graphics g)
        {
            float x, y;

            for (float th = stTheta; th <= endTheta; th += 0.01f)
            {
                x = (float)(radius * Math.Cos(th) + xc);
                y = (float)(radius * Math.Sin(th) + yc);
                g.FillEllipse(Brushes.Red, x, y, 5, 5);
                //g.DrawLine(Pens.Red, xc, yc, x, y);
            }
        }
    }
}
