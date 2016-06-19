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
    public partial class DMMFetchDig_Meter : TpsControl.BaseMeterControl
    {
        public DMMFetchDig_Meter()
        {
            InitializeComponent();
        }

        public DMMFetchDig_Meter(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }

         private void DMMFetchDig_Load(object sender, EventArgs e)
        {
            this.squreName = "DMM";
            this.labelName = "fetchDig";
        }

        protected override void setFuncName()
        {
            funcName = "DMMFetchDig";
        }

        protected override void InitVarInfo()
        {
            VarInfo varInfo0 = new VarInfo(true, "DMM句柄", "int");
            VarInfo varInfo1 = new VarInfo(true, "最小值", "double");
            VarInfo varInfo2 = new VarInfo(true, "最大值", "double");
            VarInfo varInfo3 = new VarInfo(false, "测量结果", "double");
             varInfoList.Add(varInfo0);
             varInfoList.Add(varInfo1);
             varInfoList.Add(varInfo2);
             varInfoList.Add(varInfo3);

            return;
        }

        private void  fetchDig(int handle,double min, double max,ref double result)
        {
            
            Ag3446x dmm =(Ag3446x) instTable[handle];
            FetchDigForm form = new FetchDigForm(min, max, dmm);
            form.ShowDialog();

            result = form.fetchVal();
            return;
        }

        public override void function()
        {

            int handle;
            double min, max;
            double result;
            //检测变量树里面是否存在变量，若存在，则去除变量树中的对应的变量
            //否则，直接赋值
            if(intTable.Count> 0 && intTable.Contains(varInfoList[0].sVar) == true)
                handle = (int)intTable[varInfoList[0].sVar];
            else
                int.TryParse(varInfoList[0].sVar, out handle);

            if (doubleTable.Count>0 && doubleTable.Contains(varInfoList[1].sVar) == true)
                min = (double)doubleTable[varInfoList[1].sVar];
            else
                double.TryParse(varInfoList[1].sVar, out min);

            if (doubleTable.Count > 0 && doubleTable.Contains(varInfoList[2].sVar) == true)
                max = (double)doubleTable[varInfoList[2].sVar];
            else
                double.TryParse(varInfoList[2].sVar, out max);

            if (doubleTable.Count > 0 && doubleTable.Contains(varInfoList[3].sVar) == true)
                result = (double)doubleTable[varInfoList[3].sVar];
            else
                double.TryParse(varInfoList[3].sVar, out result);

         

            fetchDig(handle, min, max, ref result);
            if (doubleTable.Count > 0 && doubleTable.Contains(varInfoList[3].sVar) == true)
                doubleTable[varInfoList[3].sVar] = result;
            return;
        }
    }
}
