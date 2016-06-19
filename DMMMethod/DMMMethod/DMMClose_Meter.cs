using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TpsControl;
using Agilent.CommandExpert.ScpiNet.Ag3446x_2_08;
namespace DMMMethod
{
    public partial class DMMClose_Meter : TpsControl.BaseMeterControl
    {
        public DMMClose_Meter()
        {
            InitializeComponent();
        }

         public DMMClose_Meter(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }

         private void DMMClose_Load(object sender, EventArgs e)
        {
            this.squreName = "DMM";
            this.labelName = "close";
        }

        protected override void setFuncName()
        {
            funcName = "DMMClose";
        }

        protected override void InitVarInfo()
        {
            VarInfo varinfo0 = new VarInfo(true, "DMM句柄", "int");
            varInfoList.Add(varinfo0);

            return;
        }

        private void  close(int handle)
        {
            
            Ag3446x dmm =(Ag3446x) instTable[handle];
            dmm.Disconnect();
            return;
        }

        public override void function()
        {

            int handle;
            //检测变量树里面是否存在变量，若存在，则去除变量树中的对应的变量
            //否则，直接赋值
            if(intTable.Count> 0 && intTable.Contains(varInfoList[0].sVar) == true)
                handle = (int)intTable[varInfoList[0].sVar];
            else
                int.TryParse(varInfoList[0].sVar, out handle);

            close(handle);
            return;
        }
    }
}
