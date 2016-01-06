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
    public partial class FuncVarControl : UserControl
    {


        public FuncVarControl()
        {
            InitializeComponent();
            
        }
        public FuncVarControl(bool isInput = true, string sName = "name", string sType = "type")
        {
            InitializeComponent();
            if (isInput)
                labelIO.Text = "InputVariable";
            else
                labelIO.Text = "OutputVariable";
            varName.Text = sName;
            varType.Text = sType;
        }

        public void AdjustWidth()
        {
            int parentWidth = this.Parent.Width;
            this.Width = parentWidth;
            textBox1.Width = varName.Width = this.Width / 2;
            textBox2.Width = varType.Width = this.Width / 2;
            textBox3.Width = varValue.Width = this.Width / 2;
            varName.Width = this.Width - textBox1.Width;
            varType.Width = this.Width - textBox2.Width;
            varValue.Width = this.Width - textBox3.Width;

            varName.Location = new Point(this.Width/2, varName.Location.Y);
            varType.Location = new Point(this.Width / 2, varType.Location.Y);
            varValue.Location = new Point(this.Width / 2, varValue.Location.Y);
            return;
        }

        private void varName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void varType_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
