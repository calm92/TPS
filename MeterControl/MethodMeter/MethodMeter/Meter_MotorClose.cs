using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using moveLib;
using TpsControl;

namespace MethodMeter
{
    public partial class Meter_MotorClose : TpsControl.BaseMeterControl
    {
        public Meter_MotorClose()
        {
            InitializeComponent();
        }

        public Meter_MotorClose(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }

        protected override void setFuncName()
        {
            funcName = "MotorClose";
        }

        protected override void InitVarInfo()
        {
           
            return;
        }

      

        public override void function()
        {
            MoveProbe.closeCard();
        }

        private void Meter_MotorClose_Load(object sender, EventArgs e)
        {
            this.squreName = "Moter";
            this.labelName = "close";
        }

   
    }
}
