using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TpsControl;

namespace MainForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           
        }

        /**********************
         * 所有控件parent设置
        ********************************/
        private void ControlParentInit()
        {
            //Set parent
            SetDMM.Parent = InstruementFlow;
            SetScope.Parent = InstruementFlow;
            MethodFuncControl.Parent = MethodFlow;
            //Flow parent
            ScopeFlow.Parent = HidePage;
            DMMFlow.Parent = HidePage;
            
        }

        #region 变量
        //debug
        private List<BaseMeterControl> FuncControlList = new List<BaseMeterControl>();
        private int listCount = 0;
        private int GraphNum = 0;
        private BaseMeterControl startControl;
        private Point startLocation  = new Point(80,80);
        #endregion


        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            //MainForm
            this.WindowState = FormWindowState.Maximized;
            AdjustControlTabpage();
            ControlParentInit();
            ControlTabInit();

            //start control            
            startControl = new BaseMeterControl(GraphNum, varPanel);
            FuncControlList.Add(startControl);
            GraphNum++;
            listCount++;
            startControl.controlParent = MainPage;
            startControl.controlLocation = startLocation;
            startControl.labelName = "START";
            startControl.squreName = "START";
        }
        #endregion


        #region ControlTab

        /************************************
        调整tabpage的width       
        *************************************/
        private void AdjustControlTabpage()
        {
            int height = ControlTab.ItemSize.Height;
            ControlTab.SizeMode = TabSizeMode.Fixed;
            ControlTab.ItemSize = new Size(ControlTab.Size.Width, height);
        }


        /************************************
        隐藏page，作为hidepage
        *************************************/
        private void ControlTabInit()
        {
            ControlTab.TabPages.Remove(HidePage);
        }

        /***************************************
        选中tabpage时，隐藏hidepage
        ***************************************/
        private void ControlTab_Selected(object sender, TabControlEventArgs e)
        {
            ControlTab.TabPages.Remove(HidePage);
        }

        #endregion

     
        #region splitLeft
        private void splitLeft_SplitterMoved(object sender, SplitterEventArgs e)
        {
            AdjustControlTabpage();

        }
        #endregion

        #region InstrumentPanel  //Set控件Parent设置和仪器仪表页面Set控件双击事件
        private void SetDMM_UserControlDoubleClicked_1(object sender, EventArgs e)
        {
            ControlTab.SelectedTab = HidePage;
            ControlTab.TabPages.Add(HidePage);
            HidePage.Text = "DMM";
            DMMFlow.BringToFront();
        }
        private void SetScope_UserControlDoubleClicked(object sender, EventArgs e)
        {
            ControlTab.SelectedTab = HidePage;
            ControlTab.TabPages.Add(HidePage);
            HidePage.Text = "Scope";
            ScopeFlow.BringToFront();
        }
        #endregion

        #region methodFlow
        
        private void flowFuncControl1_FlowControlMouseMove_Out(object sender, EventArgs e)
        {
            if (listCount == GraphNum)
            {
                BaseMeterControl meterControl = new BaseMeterControl(GraphNum,varPanel);
                FuncControlList.Add(meterControl);
               
                
                listCount++;
                //meterControl.controlParent = MainPage;
                meterControl.Parent = MainPage;
                MainPage.Controls.Add(meterControl);
            }
           
            Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
            mousePoint = FuncControlList[GraphNum].Parent.PointToClient(mousePoint);
            int x = mousePoint.X - FuncControlList[GraphNum].Width / 2;
            int y = mousePoint.Y - FuncControlList[GraphNum].Height / 2;
            FuncControlList[GraphNum].Location = new Point(x, y);
        
            return;

        }


        private void flowFuncControl1_FlowControlMouseUp_Out_1(object sender, EventArgs e)
        {
            Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
            mousePoint = FuncControlList[GraphNum].Parent.PointToClient(mousePoint);

            FuncControlList[GraphNum].Location = new Point
                    (mousePoint.X - FuncControlList[GraphNum].Width / 2,
                        mousePoint.Y - FuncControlList[GraphNum].Height / 2);
            GraphNum++;

            //debug code
            FuncControlList[GraphNum - 1].Visible = false;
            FuncControlList[GraphNum - 1].controlParent = MainPage;
            FuncControlList[GraphNum - 1].controlLocation
                = new Point(FuncControlList[GraphNum - 1].Location.X, FuncControlList[GraphNum - 1].Location.Y);
                                                            
        }

        #endregion

        #region varPanel
        private void varPanel_SizeChanged(object sender, EventArgs e)
        {
            int count = FuncControlList.Count;
            for (int i = 0; i < count; ++i)
                FuncControlList[i].AdjustSize();
        }

        #endregion








        #region fileList右键

        #endregion















    }

    
}
