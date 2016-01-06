using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpsControl
{
    public partial class FuncHead : UserControl
    {
        public FuncHead()
        {
            InitializeComponent();
          
            return;
        }

        public FuncHead(int graphID = 0, string funcName = "default")
        {
            InitializeComponent();
            label1.Text += graphID.ToString();
            FuncNameBox.Text = funcName;
            return;
        }

        public void AdjustWidth() {
            int parentWidth = this.Parent.Width;
            this.Width = parentWidth;
            textBox1.Width =  this.Width / 2;
            FuncNameBox.Width = this.Width - textBox1.Width;
            FuncNameBox.Location = new Point(this.Width/2, FuncNameBox.Location.Y);
            return;
        }
    }
}
