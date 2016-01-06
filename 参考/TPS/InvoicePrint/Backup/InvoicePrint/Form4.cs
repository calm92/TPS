using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace InvoicePrint
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.ResizeRedraw, true);
        }

       List<Point> Points = new List<Point>();
        Point MovePoint;

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            if (Points.Count == 0)
            {
                Points.Add(e.Location);
                MovePoint = new Point(e.X, e.Y);
            }
            else if (Points.Count == 1)
                Points.Add(e.Location);
            else if (Points.Count == 2)
            {
                Points.RemoveAt(0);
                Points.RemoveAt(0);
            }
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {
            if (Points.Count == 1)
                MovePoint = new Point(e.X,e.Y);
            this.Refresh(); 
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (Points.Count == 1)
            {
                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), Points[0], MovePoint);
            }
            else if (Points.Count == 2)
            {
                e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Red)), Points[0], Points[1]);


                int x = Points[1].X - Points[0].X;
                int y = Points[1].Y - Points[0].Y;

                double z = Math.Sqrt(x * x + y * y);

                double zz = Math.Acos(y / x);//值有问题！

                GraphicsState state = g.Save();
                Matrix RotationTransform = new Matrix(1, 0, 0, 1, 1, 1); //rotation matrix
                RotationTransform.RotateAt((float)zz, Points[0]);
                g.Transform = RotationTransform;
                g.TranslateTransform(0, x/2);

                g.DrawString("Test", new Font("vanda", 10), Brushes.Blue, Points[0]);
                g.Restore(state);
            }
        }
    }
}
