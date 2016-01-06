using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarControl
{
    public partial class VarControl: UserControl
    {
        private string varType;
        private string varInOut; 
        private string varName;
        protected string value;
        public VarControl()
        {
            InitializeComponent();
            AdjustSize();
        }

        #region 对外接口
        public virtual string[] ExportVarInfo() {
            getVarInfo();

            string[] varInfo = new string[4];
            varInfo[0] = varType;
            varInfo[1] = varInOut;
            varInfo[2] = varName;
            varInfo[3] = value;
            return varInfo;
        }

        #endregion

        #region 类内方法
        private void AdjustSize() {
            int width = this.Width - TypeBox.Location.X - 15;
            TypeBox.Width = width;
            NameBox.Width = width;
            ValueBox.Width = width;
            InOutBox.Width = width;
            return;
        }

 
 

        protected void getVarInfo()
        {
            value = ValueBox.Text;
            varType = TypeBox.Text;
            varInOut = InOutBox.Text;
            varName = NameBox.Text;
        }
        #endregion

        protected void SetVarInfo(string[] varInfo) {
            TypeBox.Text = varInfo[0];
            TypeBox.Enabled = false;

            InOutBox.Text = varInfo[1];
            InOutBox.Enabled = false;

            NameBox.Text = varInfo[2];
            NameBox.ReadOnly = true;
        }

    }
}
