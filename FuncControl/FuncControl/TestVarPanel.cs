using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpsControl
{
    public partial class TestVarPanel : UserControl
    {
        private VarPanel varPanel;
        private List<VarInfo> varInfoList;
        protected string funcName;
        public TestVarPanel()
        {
            InitializeComponent();
           InitVarInfo();
           InitVarPanel();
           //this.testPanel.Visible = false;
        }

        private void InitVarPanel()
        {
            varPanel = new VarPanel(varInfoList, funcName,10);
            varPanel.Dock = DockStyle.Fill;
            varPanel.Parent = testPanel;
        }

        protected virtual void InitVarInfo()
        {
            VarInfo varInfo1 = new VarInfo(true, "add1", "int");
            VarInfo varInfo2 = new VarInfo(true, "add2", "int");
            VarInfo varInfo3 = new VarInfo(false, "result", "int");
            varInfoList = new List<VarInfo>();
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            varInfoList.Add(varInfo3);
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }


    }
}
