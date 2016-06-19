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
    public partial class DMMFetchVal_Meter : TpsControl.BaseMeterControl
    {
        public DMMFetchVal_Meter()
        {
            InitializeComponent();
        }

          public DMMFetchVal_Meter(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }

         private void DMMFetchVal_Load(object sender, EventArgs e)
        {
            this.squreName = "DMM";
            this.labelName = "fetchVal";
        }

        protected override void setFuncName()
        {
            funcName = "DMMFetchVal";
        }

        protected override void InitVarInfo()
        {
            VarInfo varinfo0 = new VarInfo(true, "DMM句柄", "int");
            VarInfo varInfo1 = new VarInfo(false, "测量结果", "double");
             varInfoList.Add(varinfo0);
            varInfoList.Add(varInfo1);

            return;
        }

        private void  fetchVal(int handle,ref double result)
        {
            
            Ag3446x dmm =(Ag3446x) instTable[handle];
            dmm.SCPI.INITiate.IMMediate.Command();
            double[] results;
            dmm.SCPI.FETCh.QueryAsciiReal(out results);
            result = results[0];
            return;
        }

        public override void function()
        {

            int handle;
            double result;
            //检测变量树里面是否存在变量，若存在，则去除变量树中的对应的变量
            //否则，直接赋值
            if(intTable.Count> 0 && intTable.Contains(varInfoList[0].sVar) == true)
                handle = (int)intTable[varInfoList[0].sVar];
            else
                int.TryParse(varInfoList[0].sVar, out handle);

            if (doubleTable.Count>0 && doubleTable.Contains(varInfoList[1].sVar) == true)
                result = (double)doubleTable[varInfoList[1].sVar];
            else
                double.TryParse(varInfoList[1].sVar, out result);

         

            fetchVal(handle, ref result);
            if (doubleTable.Count > 0 && doubleTable.Contains(varInfoList[1].sVar) == true)
                doubleTable[varInfoList[1].sVar] = result;
            return;
        }

    }
}


