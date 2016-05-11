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
        public string sVar; //参数的值
        public VarInfo(bool isinput, string name, string type, string sVar="") {
            isInput = isinput;
            sName = name;
            sType = type;
        }
    }
}
