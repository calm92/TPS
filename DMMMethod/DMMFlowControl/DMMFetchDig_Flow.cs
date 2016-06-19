using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TpsControl;
using Agilent.CommandExpert.ScpiNet.Ag3446x_2_08;
using DMMMethod;
namespace DMMFlowControl
{
    public partial class DMMFetchDig_Flow : TpsControl.FlowFuncControl
    {
        public DMMFetchDig_Flow()
        {
            InitializeComponent();
            nameInit();
        }

        private void nameInit()
        {
            this.LabelText = "FetchDig";
            this.ButtonText = "DMM";
        }

        protected override void buildMeterControl(out BaseMeterControl meterControl)
        {
            //新建对应的meterControl，并且把新建控件加入meterControl中。
            int graphID = FlowFuncControl.FormControl.SelectedIndex;
            int tabID = BaseMeterControl.meterControl[FlowFuncControl.FormControl.SelectedIndex].Count;
            meterControl = new DMMFetchDig_Meter(graphID, tabID);
            return;
        }
    }
}
