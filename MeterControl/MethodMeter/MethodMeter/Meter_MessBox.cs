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
    public partial class Meter_MessBox : TpsControl.BaseMeterControl
    {
        public Meter_MessBox()
        {
            InitializeComponent();
        }

          public Meter_MessBox(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }




        private void showMessage_Load(object sender, EventArgs e)
        {
            this.squreName = "Mes";
            this.labelName = "Mes";
        }

        protected override void setFuncName()
        {
            funcName = "ShowMessage";
        }

        protected override void InitVarInfo()
        {
            VarInfo varInfo1 = new VarInfo(true, "message", "string");
           
            varInfoList.Add(varInfo1);
           
            return;
        }

        private void showMess(string str) {
            MessageBox.Show(str);
            return;
        }

        public override void function()
        {
            string message;
            if (stringTable.Contains(varInfoList[0].sVar) == true)
                message = (string)stringTable[varInfoList[0].sVar];
            else
                message = varInfoList[0].sVar;
            showMess(message);
        }
    }
}
