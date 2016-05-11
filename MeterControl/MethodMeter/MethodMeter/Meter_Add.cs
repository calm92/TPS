
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TpsControl;

namespace MethodMeter
{
    public partial class Meter_Add : TpsControl.BaseMeterControl
    {
        public Meter_Add()
        {
            InitializeComponent();
        }

        public Meter_Add(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }




        private void Add_Load(object sender, EventArgs e)
        {
            this.squreName = "ADD";
            this.labelName = "Add";
        }

        protected override void setFuncName()
        {
            funcName = "Add";
        }

        protected override void InitVarInfo()
        {
            VarInfo varInfo1 = new VarInfo(true, "add1", "double");
            VarInfo varInfo2 = new VarInfo(true, "add2", "double");
            VarInfo varInfo3 = new VarInfo(false, "result", "double");
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            varInfoList.Add(varInfo3);
            return;
        }

        private void add(double num1, double num2, ref double result) {
            result = num1 + num2;
        }

        public override void function()
        {
            int count = this.varInfoList.Count;
            double num1 = 0.0;
            double num2 = 0.0;
            double result = 0.0;
            if (doubleTable.Contains(varInfoList[0].sVar) == true)
                num1 = (double)doubleTable[varInfoList[0].sVar];
            else 
                double.TryParse(varInfoList[0].sVar, out num1);

            if (doubleTable.Contains(varInfoList[1].sVar) == true)
                num2 = (double)doubleTable[varInfoList[1].sVar];
            else
                double.TryParse(varInfoList[1].sVar, out num2);
            add(num1, num2, ref result);
            if (doubleTable.Contains(varInfoList[2].sVar) == true)
                doubleTable[varInfoList[2].sVar] = result;


        }
    }
}
