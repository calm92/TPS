
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
            VarInfo varInfo1 = new VarInfo(true, "add1", "int");
            VarInfo varInfo2 = new VarInfo(true, "add2", "int");
            VarInfo varInfo3 = new VarInfo(false, "result", "int");
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            varInfoList.Add(varInfo3);
            return;
        }
    }
}
