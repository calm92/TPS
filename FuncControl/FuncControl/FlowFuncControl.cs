using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TpsControl
{
    public partial class FlowFuncControl : FuncControl.BaseSetControl
    {
        //Form 为控件主界面。为了以后可以扩展自定义函数功能，把其作为list类型
        //新添加一个自定义函数(自定义form)，需要在form里面ADD添加的页面。
        //formcontrol是form的容器，            
        //FormControl.SelectedTab为当前From
        //添加的metercontrol应该添加到当前form

        static public List<TabPage> Form = new List<TabPage>();
        static public TabControl FormControl;

        //controlCount 联合tabnum来实现增加控件。
        private static int tabNum = -1;
        private BaseMeterControl meterControl;
        public FlowFuncControl()
        {
            InitializeComponent();
        }


        #region 属性

        public dynamic ControlParent { 
            set{
                this.Parent = value; 
                }
            get {
                return this.Parent;
            }
        }

        #endregion

        
        static public void AddForm(TabPage newForm)
        {
            Form.Add(newForm);
        }

        protected virtual void buildMeterControl(out BaseMeterControl meterControl) {
            //新建对应的meterControl，并且把新建控件加入meterControl中。
            meterControl = new BaseMeterControl();
            return ;
        }

        private void FlowFuncControl_MouseMove(object sender, MouseEventArgs e)
        {
             if(e.Location.X < (this.Parent.Location.X + this.Parent.Width) )
                this.Cursor =Cursors.No;
             else
             {
                 this.Cursor = Cursors.Arrow;

                 if (tabNum < 0)
                 {
               
                     buildMeterControl( out meterControl);
                     tabNum = 0;

                     meterControl.Parent = FormControl.SelectedTab;
                     FormControl.SelectedTab.Controls.Add(meterControl);
                 }
                 Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
                 mousePoint = FormControl.SelectedTab.Parent.PointToClient(mousePoint);
                 int x = mousePoint.X - meterControl.Width / 2;
                 int y = mousePoint.Y - meterControl.Height / 2;
                 meterControl.Location = new Point(x, y);

                 return;

             }

        }

        private void FlowFuncControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Location.X < (this.Parent.Location.X + this.Parent.Width))
                this.Cursor = Cursors.Default;
            else
            {
                //Out range
                Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
                mousePoint = FormControl.SelectedTab.PointToClient(mousePoint);

                meterControl.Location = new Point
                    (mousePoint.X - meterControl.Width / 2,
                        mousePoint.Y - meterControl.Height / 2);

                meterControl.Visible = true;
                meterControl.controlLocation
                    = new Point(meterControl.Location.X, meterControl.Location.Y);
            }


             this.MouseMove -= new MouseEventHandler(FlowFuncControl_MouseMove);
             tabNum = -1;
             if (meterControl == null)
                 return;
             else
             {
                 meterControl.controlParent = FormControl.SelectedTab;
                 meterControl.Visible = false;
                 meterControl.ShowVar();
             }
            // BaseMeterControl.meterControl[FormControl.SelectedIndex].Add(meterControl);
        }

        private void FlowFuncControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.MouseMove += new MouseEventHandler(FlowFuncControl_MouseMove);
        }


        #region label1 事件
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            this.label1.MouseMove += new MouseEventHandler(label1_MouseMove);

        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            FlowFuncControl_MouseMove(sender, e);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            FlowFuncControl_MouseUp(sender, e);
            this.label1.MouseMove -= new MouseEventHandler(label1_MouseMove);
        }
        #endregion

        #region label2 event
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            this.label2.MouseMove += new MouseEventHandler(label2_MouseMove);
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            FlowFuncControl_MouseMove(sender, e);
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            FlowFuncControl_MouseUp(sender, e);
            this.label2.MouseMove -= new MouseEventHandler(label2_MouseMove);

        }
        #endregion

        private void FlowFuncControl_Load(object sender, EventArgs e)
        {
            this.MouseMove -= new MouseEventHandler(FlowFuncControl_MouseMove);
            this.label2.MouseMove -= new MouseEventHandler(label2_MouseMove);
            this.label1.MouseMove -= new MouseEventHandler(label1_MouseMove);
            disableDoubleClick();
        }

    }

    
}
