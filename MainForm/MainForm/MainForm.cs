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
         * 所有setControl设置
        ********************************/
        private void SetControlInit()
        {
           
            
            //Flow parent
            ScopeFlow.Parent = HidePage;
            DMMFlow.Parent = HidePage;
           

            //baseSetControl Init
            FuncControl.BaseSetControl.tabPage = HidePage;
            FuncControl.BaseSetControl.tabControl = ControlTab;
            //DMMSET Init
            SetDMM = new FuncControl.BaseSetControl(DMMFlow, "DMM");
            SetDMM.Parent = InstruementFlow;
            SetDMM.LabelText = "SetDMM";
            SetDMM.ButtonText = "DMM";
            
            //ScopeSet Init
            SetScope = new FuncControl.BaseSetControl(ScopeFlow, "Scope");
            SetScope.Parent = InstruementFlow;
            SetScope.LabelText = "SetScope";
            SetScope.ButtonText = "SCOPE";

            //
        }

        #region 变量
        //debug
        private List<BaseMeterControl> FuncControlList = new List<BaseMeterControl>();
      
        //private BaseMeterControl startControl;
        private Point startLocation  = new Point(80,80);
        private FuncControl.BaseSetControl SetDMM;
        private FuncControl.BaseSetControl SetScope;
        private int formCount = 0;  

        #endregion

        #region 添加form
            private void addForm(TabPage form){
                 BaseMeterControl.AddForm();
                 FlowFuncControl.AddForm(form);

                // add start control
                 BaseMeterControl startControl = new BaseMeterControl(formCount, 0);
                 //BaseMeterControl.meterControl[formCount].Add(startControl);
                 startControl.controlParent = formControl.TabPages[formCount];
                 //formControl.SelectedTab.Controls.Add();
                 startControl.controlLocation = startLocation;
                 startControl.labelName = "START";
                 startControl.squreName = "START";
                 formCount++;
            }

        #endregion
        #region MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            AdjustControlTabpage();
            SetControlInit();
            ControlTabInit();
            addForm(MainPage);

            //控件static参数设置
            BaseMeterControl.varPanelParent = varPanel;
            FlowFuncControl.FormControl = formControl;
           
            
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

    

        

        #region varPanel
        private void varPanel_SizeChanged(object sender, EventArgs e)
        {
            int formCount = FlowFuncControl.Form.Count;

            for (int formIndex = 0; formIndex < formCount; ++formIndex)
            {
                int controlCount = BaseMeterControl.meterControl[formIndex].Count;
                for (int i = 0; i < controlCount; ++i) {
                    BaseMeterControl.meterControl[formIndex][i].AdjustSize();
                }
            }
        }

        #endregion

      








        #region fileList右键

        #endregion















    }

    
}
