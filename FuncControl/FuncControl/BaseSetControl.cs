using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuncControl
{
    public partial class BaseSetControl: UserControl
    {
        public BaseSetControl()
        {
            InitializeComponent();
        }
        #region 属性
        public string LabelText{
            set { label1.Text = value; AdjustLabelLocation(); }
            get { return label1.Text; }
        }
        public string ButtonText {
            set { label2.Text = value; }
            get { return label2.Text; }
        }
        #endregion
      
        private void AdjustLabelLocation() {
            int buttonX = label2.Location.X;
            int buttonX_Mid = buttonX + label2.Width / 2;
            label1.Location = new Point(buttonX_Mid - label1.Width / 2, label1.Location.Y);
            return;
        }

      

        #region doubleClick
        /******************************
        //自定义事件
        ******************************/
        public delegate void UserDoubleClick(object sender, EventArgs e);

        public event UserDoubleClick UserControlDoubleClicked;

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            UserControlDoubleClicked(sender,e);
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            label2_DoubleClick(sender, e);
        }

        #endregion


        private void BaseControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;

        }

        private void BaseControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            BaseControl_MouseEnter(sender, e);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            BaseControl_MouseLeave(sender, e);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            BaseControl_MouseEnter(sender, e);
        }

    }
}
