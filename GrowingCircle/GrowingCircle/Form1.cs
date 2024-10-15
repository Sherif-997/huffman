using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrowingCircle
{
    public partial class Form1 : Form
    {
        private Bitmap off;
        Timer timer = new Timer();
        Random rr = new Random();

        CCircle circle;
        bool flag = false;
        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(circle.radius < 150 && !flag)
            {
                circle.radius += 2;
                
                if(circle.radius >= 150)
                {
                    flag = true;
                }
            }
            else if (circle.radius >= 40 && flag)
            {
                circle.radius -= 2;

                if(circle.radius <= 40)
                {
                    flag = false;
                }
            }
            DrawDubb(CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(CreateGraphics());
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);

            circle = new CCircle(ClientSize.Width/2, ClientSize.Height/2, 60, 0, 360);
            
            timer.Start();
            DrawDubb(CreateGraphics());
        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

        private void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            circle.drawcircle(g);
        }
    }
}
