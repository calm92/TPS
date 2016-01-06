using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpsControl
{
    public class VarInfo
    {
        public bool isInput;
        public string sName;
        public string sType;
        public VarInfo(bool isinput, string name, string type) {
            isInput = isinput;
            sName = name;
            sType = type;
        }
    }
}
