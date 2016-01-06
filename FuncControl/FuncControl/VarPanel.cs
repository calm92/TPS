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
    public partial class VarPanel : UserControl
    {
        private List<FuncVarControl> inputVarControlList = new List<FuncVarControl>();
        private List<FuncVarControl> outputVarControlList = new List<FuncVarControl>();
        private FuncHead varHead =  null;
        private int lastHeight = 0;
        private const int detalHeight = 10; //每行参数之间的距离
        public VarPanel()
        {
            InitializeComponent();
        }

        /***********************************************
         * 构造函数，GraphID是相应的ID， varInfoList是相应的参数信息 
         * ****************************************/
        public  VarPanel (List<VarInfo> varInfoList, string funcName,int GraphID)
        {
            InitializeComponent();
           
            // add FuncHead
            varHead = new FuncHead(GraphID, funcName);
            //debug code
            this.Controls.Add(varHead);
            varHead.Location = new Point(0, 0);
            varHead.TabIndex = 1;
            varHead.AdjustWidth();
            varHead.BringToFront();
            varHead.AdjustWidth();

            lastHeight = varHead.Height + detalHeight;

            if (varInfoList == null)
                return;
            //add funcvarcontrol
            int varCount = varInfoList.Count;
            for (int i = 0; i < varCount; ++i) {
                VarInfo tempVarInfo = varInfoList[i];
                FuncVarControl varControl = new FuncVarControl
                               (tempVarInfo.isInput, tempVarInfo.sName,tempVarInfo.sType);
                
                if(tempVarInfo.isInput)
                    inputVarControlList.Add(varControl);
                else 
                    outputVarControlList.Add(varControl);

                this.Controls.Add(varControl);
                varControl.Location = new Point(0, lastHeight);
                varControl.BringToFront();
                lastHeight += varControl.Height + detalHeight;
            }

        }



        /*****************************************************
         * sizechanged adjustwidth
         * ****************************************************/
        private void Panel_SizeChanged(object sender, EventArgs e)
        {
            if (varHead == null)
                return;
            
            varHead.AdjustWidth();
            for (int i = 0; i < inputVarControlList.Count; i++)
                inputVarControlList[i].AdjustWidth();
            for (int i = 0; i < outputVarControlList.Count; i++)
                outputVarControlList[i].AdjustWidth();
            return;
        }

        public void AdjustSize()
        {
            varHead.AdjustWidth();
            for (int i = 0; i < inputVarControlList.Count; i++)
                inputVarControlList[i].AdjustWidth();
            for (int i = 0; i < outputVarControlList.Count; i++)
                outputVarControlList[i].AdjustWidth();
            return;
        }


        #region public 方法
        
        
        #endregion

    }

 
}
