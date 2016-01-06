using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace InvoicePrint
{
    public partial class UserControl2 : TableLayoutPanel
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.SkyBlue)), new Rectangle(0, 0, this.Width / 6, this.Height / 6));
        }
    }
}
