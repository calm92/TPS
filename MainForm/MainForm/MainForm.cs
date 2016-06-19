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
using System.Collections;
using System.Drawing.Drawing2D;
using MethodMeter;
using MethodFlowControl;
using DMMFlowControl;
using DMMMethod;
using Excel = Microsoft.Office.Interop.Excel;
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

            //DMMInit
            DMMInit = new DMM_Init_Flow();
            DMMFetchVal = new DMMFetchVal_Flow();
            DMMSetup = new DMMSetup_Flow();
            DMMFetchDig = new DMMFetchDig_Flow();
            DMMClose = new DMMClose_Flow();

            DMMFlow.Controls.Add(DMMInit);
            DMMFlow.Controls.Add(DMMSetup);
            DMMFlow.Controls.Add(DMMFetchVal);
            DMMFlow.Controls.Add(DMMFetchDig);
            DMMFlow.Controls.Add(DMMClose);
            
        }

        #region 变量


        struct line
        {
           public Point startPoint;
           public Point endPoint;
           public int startTabID;
           public int endTabID;
            public line(Point sPoint, Point ePoint, int sID, int eID)
            {
                startPoint = sPoint;
                endPoint = ePoint;
                startTabID = sID;
                endTabID = eID;
            }
        };

        private List<BaseMeterControl> FuncControlList = new List<BaseMeterControl>();
      
        //private BaseMeterControl startControl;
        private Point startLocation  = new Point(80,80);
        private FuncControl.BaseSetControl SetDMM;
        private FuncControl.BaseSetControl SetScope;
        private DMM_Init_Flow DMMInit;
        private DMMFetchVal_Flow DMMFetchVal;
        private DMMSetup_Flow DMMSetup;
        private DMMFetchDig_Flow DMMFetchDig;
        private DMMClose_Flow DMMClose;
        private int formCount = 0;  
        
        
        //是否画线
        private bool isPrintLine = false;
        private Point startPoint = new Point(-1,-1);
        private Point endPoint = new Point(-1,-1);
        private Point lastEndPoint = new Point(-1,-1); //需要删除的线的坐标
        private List<line> lineList = new List<line>();

        //编译相关参数
        private int errorNo = 0;
        #endregion

        #region 添加form
            private void addForm(TabPage form){
                 BaseMeterControl.AddForm();
                 FlowFuncControl.AddForm(form);

                // add start control
                 BaseMeterControl startControl = new BaseMeterControl(formCount, 0);
                 startControl.controlParent = formControl.TabPages[formCount];
                 startControl.controlLocation = startLocation;
                 startControl.labelName = "START";
                 startControl.squreName = "START";
                 formCount++;
            }

        #endregion

        #region MainFormInit
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
            UserVar.userVarPanel = userVarPanel;
            BaseMeterControl.mainPage = MainPage;
            Meter_Result.resultListView = resultListView;
            
            //ToolTips
            DrawLineTip.SetToolTip(drawLineButton,"连接线");
            buildTip.SetToolTip(buildButton,"编译");

            //errorListView
            //隐藏errorList,折叠panel2
            splitContainer1.Panel2Collapsed = true;
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

        #region uservar
        

        private void userVarPanel_SizeChanged(object sender, EventArgs e)
        {
            userVarPanel.Width = varPanel.Size.Width;
            userVarPanel.HorizontalScroll.Value = userVarPanel.HorizontalScroll.Maximum;
            int count = UserVar.userVarList.Count;
            for (int i = 0; i < count; i++)
                UserVar.userVarList[i].AdjustWidth();

            if (count == 0)
                return;
            /*
            string str1 = userVarPanel.Size.Width.ToString();
            string str2 = "the userVar width =";
            string str3 = userVarList[0].Width.ToString();
            MessageBox.Show(str1 + str2 + str3);
            */
            return;
        }

        private void 插入变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserVar insertUserVar = new UserVar();
            insertUserVar.Parent = userVarPanel;
            //防止加入滚动条后，出现坐标错误
            userVarPanel.VerticalScroll.Value = userVarPanel.VerticalScroll.Minimum;

            //确定控件位置
            int count = UserVar.userVarList.Count;
            int height = insertUserVar.Height;
            int location_y = height * count + 2;
            int location_x = 0;
            insertUserVar.Location = new Point(location_x, location_y);
            insertUserVar.AdjustWidth();

            UserVar.userVarList.Add(insertUserVar);
        }


        #endregion








        #region 编译模块
        //清空var table
        private void clearVarTable() {
            BaseMeterControl.doubleTable = new Hashtable();
            BaseMeterControl.intTable = new Hashtable();
            BaseMeterControl.stringTable = new Hashtable();
            BaseMeterControl.instTable = new Hashtable();

            return;
        }

        private void insertVarTable(UserVar userVar,ref Hashtable varTable) {
            string varName = userVar.varName.Text;
            if (varName == "")
                return;
            string varValue = userVar.varValue.Text;
            if (userVar.varType.Text == "int") { 
                int value = 0;
                bool isTranslate = int.TryParse(varValue, out value);
                if (isTranslate || varValue == "")
                    varTable.Add(varName, value);
                else
                    //报错*********************************************************************
                    addErrorItem(errorNo++,"自定义变量类型不符", varName);
            }

            if (userVar.varType.Text == "double") { 
                double value = 0;
                bool isTranslate = double.TryParse(varValue, out value);
                if (isTranslate || varValue == "")
                    varTable.Add(varName, value);
                else
                    //报错*********************************************************************
                    addErrorItem(errorNo++, "自定义变量类型不符", varName); ;
            }

            if (userVar.varType.Text == "string")
            {
                if(varValue == "")
                    varTable.Add(varName, varValue);
                else if (varValue.EndsWith("\"") && varValue.StartsWith("\""))
                {
                    varValue = varValue.Substring(1, varValue.Length - 2);
                    varTable.Add(varName, varValue);
                }
                else
                    //报错************************************
                    addErrorItem(errorNo++, "自定义变量类型不符", varName); ;
                
            }
            return;

        }
        //更新变量树
        private void rebuildVarTable() {
            List<UserVar> userVarList = UserVar.userVarList;
            int count = userVarList.Count();
            //clear the var table
            clearVarTable();

            //重新建立var table
            for (int i = 0; i < count; i++) {
                UserVar userVar = userVarList[i];
                string type = userVar.varType.Text;
                if (type == "")
                    continue;
                if (type == "int")
                    insertVarTable(userVar, ref BaseMeterControl.intTable);
                else if (type == "double")
                    insertVarTable(userVar, ref BaseMeterControl.doubleTable);
                else
                    insertVarTable(userVar, ref BaseMeterControl.stringTable);
            }
            return;
        }

        //编译
        private void buildButton_Click(object sender, EventArgs e)
        {
            errorNo = 0;
            splitContainer1.Panel2Collapsed = false;
            errorListView.Items.Clear();
            resultListView.Items.Clear();
            errorListView.BringToFront();
            errorListView.Visible = true;
            resultListView.Visible = false;
            rebuildVarTable();  //载入用户变量
            checkVar();         //检查控件的参数

        }
        private void 关闭窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorListView.Items.Clear();
            resultListView.Items.Clear();
            errorListView.Visible = false;
            resultListView.Visible = false;
            splitContainer1.Panel2Collapsed = true;
        }

        #region  输出excel
        private void 输出为excleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView listview;
            
            if (resultListView.Visible == true)
                listview = resultListView;
            else
                listview = errorListView;

            Excel.Application excel = new Excel.Application();
            if (excel == null) {
                MessageBox.Show("无法建立excel");
                return;
            }

            int rowNum = listview.Items.Count;
            int columnNum = listview.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
           
            excel.DefaultFilePath = "";
            excel.DisplayAlerts = true;
            excel.SheetsInNewWorkbook = 1;
            Excel.Workbook xlbook = excel.Workbooks.Add(true);
            
            //将ListView的列名导入第一行
            foreach (ColumnHeader dc in listview.Columns) {
                columnIndex++;
                excel.Cells[rowIndex, columnIndex] = dc.Text;
            }

              //将ListView中的数据导入Excel中
             for (int i = 0; i < rowNum; i++){
            
                rowIndex++;
                columnIndex = 0;
                for (int j = 0; j < columnNum; j++)
                {
                    columnIndex++;
                    //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
                    excel.Cells[rowIndex, columnIndex] = Convert.ToString(listview.Items[i].SubItems[j].Text) + "\t";
                    
                }
            }
            //调整列宽
            excel.Columns.AutoFit();
            excel.Visible = true;
             
    }
     

        #endregion
        private void addErrorItem(int no, string errorInfo, string errorID) {
            ListViewItem item = new ListViewItem();
            item.Text = no.ToString();
            item.SubItems.Add(errorInfo);
            item.SubItems.Add(errorID);
            errorListView.Items.Add(item);
        }
        private void checkVarIter(ref VarInfo varInfo, int index){
            if (varInfo.isInput == true) {
                 //输入参数没有
                 if (varInfo.sVar == ""){
                    addErrorItem(errorNo++, "输入未给定",
                              "GraphID:" + index.ToString() + "  变量：" + varInfo.sName);
                     return;
                 }
            }
                 //参数错误
                  
                  if (varInfo.sType == "int") {
                      if (varInfo.sVar == "")
                            return;
                      if(BaseMeterControl.intTable.Contains(varInfo.sVar) == true)
                            return;
                      if (varInfo.isInput == false && varInfo.sVar != "")
                      {
                          addErrorItem(errorNo++, "输出参数错误",
                                "GraphID:" + index.ToString() + "  变量：" + varInfo.sName);
                          return;
                      }

                      int value = 0;
                      bool isTranslate = int.TryParse(varInfo.sVar, out value);
                      if (isTranslate)
                         return;
                      else
                        //报错
                          addErrorItem(errorNo++, "组件参数不符合",
                            "GraphID:" + index.ToString() + "  变量：" + varInfo.sName);
                 }
                 else if(varInfo.sType == "double"){
                    if(varInfo.sVar == "")
                        return;
                    if(BaseMeterControl.doubleTable.Contains(varInfo.sVar) == true)
                        return;
                    if (varInfo.isInput == false && varInfo.sVar != "")
                    {
                        addErrorItem(errorNo++, "输出参数错误",
                              "GraphID:" + index.ToString() + "  变量：" + varInfo.sName);
                        return;
                    }
                    double value = 0.0;
                    bool isTranslate = double.TryParse(varInfo.sVar, out value);
                     if(isTranslate)
                         return;
                     else
                          addErrorItem(errorNo++, "组件参数不符合",
                                "GraphID:"+ index.ToString() + "  变量：" + varInfo.sName  );
                 }
                 else if(varInfo.sType == "string"){
                    if(varInfo.sVar == "")
                        return;
                    else if (BaseMeterControl.stringTable.Contains(varInfo.sVar) == true)
                        return;
                    else if (varInfo.isInput == false && varInfo.sVar!= "")
                    {
                        addErrorItem(errorNo++, "输出参数错误",
                              "GraphID:" + index.ToString() + "  变量：" + varInfo.sName);
                    }
                    else if ( varInfo.sVar.EndsWith("\"") && varInfo.sVar.StartsWith("\""))
                {
                    varInfo.sVar = varInfo.sVar.Substring(1, varInfo.sVar.Length - 2);
                    
                }
                else
                    //报错************************************
                        addErrorItem(errorNo++, "组件参数不符合",
                               "GraphID:" + index.ToString() + "  变量：" + varInfo.sName);
                 }
             
        }
        private void checkVar() {
            List<BaseMeterControl> controlList = BaseMeterControl.meterControl[0];
            int index = 0;  //组件下标
            while (index >= 0) {
                BaseMeterControl control = controlList[index];
                List<string> varList = control.functionVars;//得到参数列表的用户输入
                if (varList == null) {
                    index = BaseMeterControl.meterControl[0][index].nextID_local;
                    continue;
                }
                int count = varList.Count();
                //参数到varInfo中
                for (int i = 0; i < count; i++)
                {
                    BaseMeterControl.meterControl[0][index].varInfoList[i].sVar = varList[i];
                }
                //检查参数是否符合
                for (int i = 0; i < count; i++) {
                    VarInfo varinfo =BaseMeterControl.meterControl[0][index].varInfoList[i];         
                    checkVarIter(ref varinfo, index);
                    //需要更新string 所以需要重新赋值
                    BaseMeterControl.meterControl[0][index].varInfoList[i] = varinfo;
                    }
                index = BaseMeterControl.meterControl[0][index].nextID_local;
                }

            }




        #endregion





        private void enableAllControl() {
            isPrintLine = true;
            int count = BaseMeterControl.meterControl[0].Count;
            for (int i = 0; i < count; i++)
                BaseMeterControl.meterControl[0][i].EnablePrintSqure();
        }

        private void disableAllControl() {
            isPrintLine = false;
            int count = BaseMeterControl.meterControl[0].Count;
            for (int i = 0; i < count; i++)
                BaseMeterControl.meterControl[0][i].DisablePrintSqure();
        }

        //画线按钮
        private void button1_Click(object sender, EventArgs e)
        {
            int count = BaseMeterControl.meterControl[0].Count;
            for (int i = 0; i < count; i++) {
                BaseMeterControl.meterControl[0][i].printLine = pubPrintLine;
                BaseMeterControl.meterControl[0][i].RePrintLine = pubRePrintLine;
                BaseMeterControl.meterControl[0][i].deleControl = deleTabID;
            }
                enableAllControl();
        }







        #region 画线

        //对外方法，在basemetercontrol中使用，在第二次点击组件时会调用此方法。
        //作用：在mainpage上画线
        //写的最恶心的一个地方，感觉把整个程序的层次搞乱了
        public void pubPrintLine(Point sPoint, Point ePoint) {
            //画线
            line templine = new line(sPoint, ePoint, 
                            BaseMeterControl.preTabID_static, BaseMeterControl.nextTabID_static);
            lineList.Add(templine);
            MainPage.Invalidate();
            disableAllControl();

           
        }

        public void pubRePrintLine(int tabID, Point prePosition, Point nowPositon) {
            if (prePosition.X < 0 && prePosition.Y < 0)
                return;
            int count = lineList.Count();
            bool isChange = false;
            for (int i = 0; i < count; i++) {
                if (lineList[i].startTabID != tabID && lineList[i].endTabID != tabID)
                    continue;
                else if (lineList[i].startTabID == tabID)
                {
                    line l = lineList[i];
                    l.startPoint = new Point
                        (lineList[i].startPoint.X + nowPositon.X - prePosition.X,
                        lineList[i].startPoint.Y + nowPositon.Y - prePosition.Y);
                    lineList[i] = l;
                    isChange = true;
                }
                else {
                    line l = lineList[i];
                    l.endPoint = new Point
                        (lineList[i].endPoint.X + nowPositon.X - prePosition.X,
                        lineList[i].endPoint.Y + nowPositon.Y - prePosition.Y);
                    lineList[i] = l;
                    
                    isChange = true;
                }
            }
            if(isChange == true)
                MainPage.Invalidate();
            
        }
        private void deleTabID(int tabID) {
            int count = lineList.Count;
            for (int i = count-1; i >=0; i--) {
                if (lineList[i].endTabID == tabID || lineList[i].startTabID == tabID)
                    lineList.RemoveAt(i);
            }
            MainPage.Invalidate();
        }
        private void printLine (Point sPoint, Point ePoint, bool isDele = false){
            Color lineColor = Color.Black;
            if (isDele == true)
                lineColor = MainPage.BackColor;

            //画线
            Pen p = new Pen(lineColor, 2);
            Graphics g = MainPage.CreateGraphics(); //this.CreateGraphics()
            //抗锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //设置箭头
            System.Drawing.Drawing2D.AdjustableArrowCap lineArrow =
                 new System.Drawing.Drawing2D.AdjustableArrowCap(4, 4, true);
            p.CustomEndCap = lineArrow;


           // p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;//恢复实线
           // p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;//定义线尾的样式为箭头
            g.DrawLine(p, sPoint, ePoint);
            p.Dispose();
            g.Dispose();
        }

        private void deleLine(Point sPoint, Point ePoint) {
            printLine(sPoint ,ePoint ,true);
        }
        
        
      
        private void MainPage_Paint_1(object sender, PaintEventArgs e)
        {   //载入时，不进行重绘
            //userVarPanel.VerticalScroll.Value = userVarPanel.VerticalScroll.Minimum;
            //MainPage.VerticalScroll.Value = MainPage.VerticalScroll.Minimum;
            int count = lineList.Count;
            for (int i = 0; i < count; i++)
                printLine(lineList[i].startPoint, lineList[i].endPoint);

        }



        #endregion

        #region 运行模块
        private void startButton_Click(object sender, EventArgs e)
        {
            Meter_Result.resultID = 0;
            splitContainer1.Panel2Collapsed = false;
            errorListView.Items.Clear();
            resultListView.Items.Clear();
            resultListView.BringToFront();
            resultListView.Visible = true;
            errorListView.Visible = false;

            //运行函数
            int index = BaseMeterControl.meterControl[0][0].nextID_local;
            while (index >= 0) {
                BaseMeterControl.meterControl[0][index].function();
                index = BaseMeterControl.meterControl[0][index].nextID_local;
            }
            MessageBox.Show("所有测试已完成，测试结果能够保存为excel");
            return;

        }


        #endregion

      

       




























    }

    
}

