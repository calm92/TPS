using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TpsControl;
using DMMMethod;

namespace DMMFlowControl
{
    public partial class DMMClose_Flow : TpsControl.FlowFuncControl
    {
        public DMMClose_Flow()
        {
            InitializeComponent();
            nameInit();
        }
        private void nameInit()
        {
            this.LabelText = "Close";
            this.ButtonText = "DMM";
        }

        protected override void buildMeterControl(out BaseMeterControl meterControl)
        {
            //新建对应的meterControl，并且把新建控件加入meterControl中。
            int graphID = FlowFuncControl.FormControl.SelectedIndex;
            int tabID = BaseMeterControl.meterControl[FlowFuncControl.FormControl.SelectedIndex].Count;
            meterControl = new DMMClose_Meter(graphID, tabID);
            return;
        }
    }
}
