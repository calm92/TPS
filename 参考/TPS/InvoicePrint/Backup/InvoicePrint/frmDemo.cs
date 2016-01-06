using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using  CustomControls.IO;

namespace InvoicePrint
{
    public partial class frmDemo : Form
    {
        public frmDemo()
        {
            InitializeComponent();
        }


        DataTable dt = new DataTable();
        private void Form4_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Pay");
            dt.Columns.Add("Receive");
            dt.Columns.Add("TaxNum");
            dt.Columns.Add("Item");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Desc");
            DataRow dr = dt.NewRow();
            dr[0] = "徐春晓";
            dr[1] = "徐春晓";
            dr[2] = "NUM001";
            dr[3] = "电脑-001";
            dr[4] = "10000";
            dr[5] = "已发货";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓1";
            dr[1] = "徐春晓1";
            dr[2] = "NUM1234";
            dr[3] = "电脑-002";
            dr[4] = "10000";
            dr[5] = "已发货1";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓2";
            dr[1] = "徐春晓2";
            dr[2] = "9658258";
            dr[3] = "电脑-002";
            dr[4] = "NUM5892";
            dr[5] = "已发货2";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓3";
            dr[1] = "徐春晓3";
            dr[2] = "NUM3214";
            dr[3] = "电脑-003";
            dr[4] = "100003";
            dr[5] = "已发货3";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓4";
            dr[1] = "徐春晓4";
            dr[2] = "NUM9857";
            dr[3] = "电脑-0014";
            dr[4] = "100003";
            dr[5] = "已发货4";
            dt.Rows.Add(dr);

              

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int i = 1; i < 200; i++)
            {
                textBox4.Text += (int.Parse(textBox1.Text) % i).ToString()+"  |\n\r";
                if ((int.Parse(textBox1.Text) % i).ToString() == "79")
                {
                    this.Text = i.ToString();
                }
            }
        }

        private void frmDemo_Paint(object sender, PaintEventArgs e)
        {
            string text2 = "Use";

            using (Font font2 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                Rectangle rect2 = new Rectangle(150, 10, 130, 140);

                // Create a TextFormatFlags with word wrapping, horizontal center and
                // vertical center specified.
                TextFormatFlags flags = TextFormatFlags.NoPadding |
                    TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

                // Draw the text and the surrounding rectangle.
                TextRenderer.DrawText(e.Graphics, text2, font2, rect2, Color.Blue, flags);
                e.Graphics.DrawRectangle(Pens.Black, rect2);
            }

        }
    }
}
