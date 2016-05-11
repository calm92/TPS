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
    #region 注释
    /* 总体注释
     * BaseSetControl： 是一个仪器集合控件，作用为双击此控件，就会得到相应的视图。
     * 如DMMSet，双击此控件，在左上角的tabcontrol中会出现DMM的tab，在这个tab里面有
     * 关于DMM的各种仪器操作函数。
     * 
     */


    #endregion
    public partial class BaseSetControl: UserControl
    {
        public BaseSetControl()
        {
            InitializeComponent();
        }

        public  BaseSetControl(FlowLayoutPanel flow, string TabName)
        {
            InitializeComponent();
            setFlow = flow;
            tabName = TabName;
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

        #region 参数
        //tabPage=hidepage, tabControl是hidepage的父容器。
        static public TabPage tabPage;
        static public TabControl tabControl;

        private FlowLayoutPanel setFlow;
        private string tabName;
    #endregion

        private void AdjustLabelLocation() {
            int buttonX = label2.Location.X;
            int buttonX_Mid = buttonX + label2.Width / 2;
            label1.Location = new Point(buttonX_Mid - label1.Width / 2, label1.Location.Y);
            return;
        }

      

        #region doubleClick

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            BaseSetControl_DoubleClick(sender, e);
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

      
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            BaseControl_MouseEnter(sender, e);
        }

        private void BaseSetControl_DoubleClick(object sender, EventArgs e)
        {
            if (setFlow == null)
                return;
            tabControl.SelectedTab = tabPage;
            tabControl.TabPages.Add(tabPage);
            tabPage.Text = tabName;
            
            
            
                setFlow.BringToFront();
                this.BackColor = Color.Transparent;
            
        }

        protected void disableDoubleClick() {
            this.DoubleClick -= new EventHandler(BaseSetControl_DoubleClick);
        }

    }
}
