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
    public partial class DMMInit_Meter : TpsControl.BaseMeterControl
    {
        public DMMInit_Meter()
        {
            InitializeComponent();
        }

        public DMMInit_Meter(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }

        private void DMMInit_Meter_Load(object sender, EventArgs e)
        {
            this.squreName = "DMM";
            this.labelName = "Init";
        }

        protected override void setFuncName()
        {
            funcName = "DMMInit";
        }

        protected override void InitVarInfo()
        {
            VarInfo varInfo1 = new VarInfo(true, "DMM逻辑地址", "string");
            VarInfo varInfo2 = new VarInfo(true, "是否Reset:0/1", "int");
            VarInfo varInfo3 = new VarInfo(false, "DMM句柄", "int");
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            varInfoList.Add(varInfo3);
            return;
        }

        private void init(string add, int isReset, ref int handle)
        {

            Ag3446x dmm = new Ag3446x(add);
            if (isReset != 0)
                dmm.SCPI.RST.Command();
            //保证handle唯一
            handle = instTable.Count;
            instTable.Add(handle, dmm);
            return;

        }

        public override void function()
        {

            string address;
            int isReset;
            int handle;
            //检测变量树里面是否存在变量，若存在，则去除变量树中的对应的变量
            //否则，直接赋值
            if (stringTable.Count > 0 && stringTable.Count > 0 && stringTable.Contains(varInfoList[0].sVar) == true)
                address = (string)stringTable[varInfoList[0].sVar];
            else
                address = varInfoList[0].sVar;

            if (intTable.Count > 0 && intTable.Count > 0 && intTable.Contains(varInfoList[1].sVar) == true)
                isReset = (int)intTable[varInfoList[1].sVar];
            else
                int.TryParse(varInfoList[1].sVar, out isReset);

            if (intTable.Count > 0 && intTable.Count > 0 && intTable.Contains(varInfoList[2].sVar) == true)
                handle = (int)intTable[varInfoList[2].sVar];
            else
                int.TryParse(varInfoList[1].sVar, out handle);

            init(address, isReset, ref handle);
            //输出值传回变量树中
            if (intTable.Count > 0 && intTable.Count > 0 && intTable.Contains(varInfoList[2].sVar) == true)
                intTable[varInfoList[2].sVar] = handle;
        }
    }
}
