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

        #region 委托事件

        public delegate void MouseMove_Out(object sender, EventArgs e);
        public event MouseMove_Out FlowControlMouseMove_Out;

        public delegate void MouseUp_Out(object sender, EventArgs e);
        public event MouseUp_Out FlowControlMouseUp_Out;

        #endregion
 

        private void FlowFuncControl_MouseMove(object sender, MouseEventArgs e)
        {
             if(e.Location.X < (this.Parent.Location.X + this.Parent.Width) )
                this.Cursor =Cursors.No;
             else
             {
                 this.Cursor = Cursors.Default;
                 FlowControlMouseMove_Out(sender, e);
             }
        }

        private void FlowFuncControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Location.X < (this.Parent.Location.X + this.Parent.Width))
                this.Cursor = Cursors.Default;
            else
                FlowControlMouseUp_Out(sender, e);
            
            this.MouseMove -= new MouseEventHandler(FlowFuncControl_MouseMove);          


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
        }

    }

    
}
