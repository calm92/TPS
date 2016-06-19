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
    public partial class DMMSetup_Meter : TpsControl.BaseMeterControl
    {
        public DMMSetup_Meter()
        {
            InitializeComponent();
        }

        public DMMSetup_Meter(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }

        private void DMMSetup_Load(object sender, EventArgs e)
        {
            this.squreName = "DMM";
            this.labelName = "Setup";
        }

        protected override void setFuncName()
        {
            funcName = "DMMSetup";
        }

        protected override void InitVarInfo()
        {
            VarInfo varInfo1 = new VarInfo(true, "DMM句柄", "int");
            VarInfo varInfo2 = new VarInfo(true, "测试类型(0:Res,1:VDC)", "int");
            VarInfo varInfo3 = new VarInfo(true, "量程(0:Auto)", "int");
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            varInfoList.Add(varInfo3);
            return;
        }

        private void setup(int handle, int type, int range)
        {

            Ag3446x dmm = (Ag3446x)instTable[handle];
            if (type == 0)
            {
                if (range == 0)
                    dmm.SCPI.CONFigure.RESistance.Command("AUTO", null);
                else
                    dmm.SCPI.CONFigure.RESistance.Command(range, "MAXimum");
            }
            else if (type == 1)
            {
                if (range == 0)
                    dmm.SCPI.CONFigure.VOLTage.DC.Command("AUTO", null);
                else
                    dmm.SCPI.CONFigure.VOLTage.DC.Command(range, "MAXimum");
            }
            return;

        }

        public override void function()
        {

            int handle;
            int type;
            int range;
            //检测变量树里面是否存在变量，若存在，则去除变量树中的对应的变量
            //否则，直接赋值
            if (intTable.Contains(varInfoList[0].sVar) == true)
                handle = (int)intTable[varInfoList[0].sVar];
            else
                int.TryParse(varInfoList[0].sVar, out handle);

            if (intTable.Contains(varInfoList[1].sVar) == true)
                type = (int)intTable[varInfoList[1].sVar];
            else
                int.TryParse(varInfoList[1].sVar, out type);

            if (intTable.Contains(varInfoList[2].sVar) == true)
                range = (int)intTable[varInfoList[2].sVar];
            else
                int.TryParse(varInfoList[1].sVar, out range);

            setup(handle, type, range);
            return;
        }
    }
}
