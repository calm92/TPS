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
    public partial class Meter_Result : TpsControl.BaseMeterControl
    {
        public static ListView resultListView;
        public static int resultID = 0;
        public Meter_Result()
        {
            InitializeComponent();
        }

           public Meter_Result(int graphID, int tabID)
            : base(graphID, tabID)
        {
            InitializeComponent();
        }




        

        protected override void setFuncName()
        {
            funcName = "ShowResult";
        }

        protected override void InitVarInfo()
        {
            VarInfo varInfo1 = new VarInfo(true, "测试名称", "string");
            VarInfo varInfo2 = new VarInfo(true, "下限值", "double");
            VarInfo varInfo3 = new VarInfo(true, "测量值", "double");
            VarInfo varInfo4 = new VarInfo(true, "上限值", "double");
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            varInfoList.Add(varInfo3);
            varInfoList.Add(varInfo4);
            return;
        }

        private void showResult(string textName, double down, double result, double up) {
            ListViewItem item = new ListViewItem();
            item.Text = resultID.ToString();
            resultID++;
            item.SubItems.Add(textName);
            item.SubItems.Add(down.ToString());
            item.SubItems.Add(result.ToString());
            item.SubItems.Add(up.ToString());
           
            if (result <= up && result >= down)
                item.SubItems.Add("Pass");
            else {
                item.SubItems.Add("Fail");
                item.ForeColor = Color.Red;
            }
            resultListView.Items.Add(item);
        }

        public override void function()
        {
            int count = this.varInfoList.Count;
            string textName;
            double down = 0.0;
            double result = 0.0;
            double up = 0.0;
            if (stringTable.Contains(varInfoList[0].sVar) == true)
                textName = (string)stringTable[varInfoList[0].sVar];
            else
                textName = varInfoList[0].sVar;
            if (doubleTable.Contains(varInfoList[1].sVar) == true)
                down = (double)doubleTable[varInfoList[1].sVar];
            else 
                double.TryParse(varInfoList[1].sVar, out down);

            if (doubleTable.Contains(varInfoList[2].sVar) == true)
                result = (double)doubleTable[varInfoList[2].sVar];
            else
                double.TryParse(varInfoList[2].sVar, out result);

            if (doubleTable.Contains(varInfoList[3].sVar) == true)
                up = (double)doubleTable[varInfoList[3].sVar];
            else
                double.TryParse(varInfoList[3].sVar, out up);
            showResult(textName,down,result,up);
        }

        private void Meter_Result_Load(object sender, EventArgs e)
        {
            this.squreName = "PR";
            this.labelName = "ShowResult";
        }
    }
}
