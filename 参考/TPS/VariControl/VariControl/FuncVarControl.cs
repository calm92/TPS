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
    public partial class FuncVarControl : VarControl
    {
        public FuncVarControl()
        {
            InitializeComponent();
        }

        public FuncVarControl(string type, string inout, string varname) { 
            InitializeComponent();
            FuncVarControlInit(type, inout, varname);
        }
        private void FuncVarControlInit(string type, string inout, string varname) {
            string[] varInfo = new string[3];
            varInfo[0] = type;
            varInfo[1] = inout;
            varInfo[2] = varname;
            SetVarInfo(varInfo);
        }

        public override string[] ExportVarInfo()
        {
            getVarInfo();
            string[] varInfo = new string[1];
            varInfo[0] = value;
            return varInfo;
        }
    }
}
