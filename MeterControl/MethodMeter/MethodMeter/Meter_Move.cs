using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TpsControl;
using moveLib;

namespace MethodMeter
{
    public partial class Meter_Move : TpsControl.BaseMeterControl
    {
        public Meter_Move()
        {
            InitializeComponent();
        }

        public Meter_Move(int graphID, int tabID) : base(graphID, tabID) {
            InitializeComponent();
        }

        protected override void setFuncName()
        {
            funcName = "Move";
        }

        protected override void InitVarInfo()
        {
            VarInfo varInfo1 = new VarInfo(true, "X", "double");
            VarInfo varInfo2 = new VarInfo(true, "Y", "double");
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            return;
        }

        private void move(double x, double y)
        {
            MoveProbe.movePoint(x, y);
        }

        public override void function()
        {
            int count = this.varInfoList.Count;
            double x = 0.0;
            double y = 0.0;
            if (doubleTable.Contains(varInfoList[0].sVar) == true)
                x = (double)doubleTable[varInfoList[0].sVar];
            else
                double.TryParse(varInfoList[0].sVar, out x);

            if (doubleTable.Contains(varInfoList[1].sVar) == true)
                y = (double)doubleTable[varInfoList[1].sVar];
            else
                double.TryParse(varInfoList[1].sVar, out y);
            move(x,y);
        }

        private void Meter_Move_Load(object sender, EventArgs e)
        {
            this.squreName = "MOVE";
            this.labelName = "Move";
        }

    }
}






