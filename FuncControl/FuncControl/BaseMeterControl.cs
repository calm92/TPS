using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
//using MainForm;

namespace TpsControl
{
    public partial class BaseMeterControl : UserControl
    {
        #region 变量
        private List<string> funcVars = new List<string>();
        public List<VarInfo> varInfoList= new List<VarInfo>();
        //获得函数参数：
        //funcVarPanel.GetVar();
        protected VarPanel funcVarPanel;

        //二维，第一维表示图，第二位表示位
        //记录每个图中的metercontrol
        static public List<List<BaseMeterControl>> meterControl = new List<List<BaseMeterControl>>();
       
        //变量Panel父容器，是mainfom里面的varPanel
        static public Panel varPanelParent;

       //static public MainForm.MainForm mainForm;
        static public TabPage mainPage;
        //变量树
        static public Hashtable intTable = new Hashtable();
        static public Hashtable doubleTable = new Hashtable();
        static public Hashtable stringTable = new Hashtable();

        static public Color FormBackColor = Color.White;
       
        //在连线阶段使用，表示连线中，线的两端图号id(暂时只考虑一维情况)，注意和下面的nextID区别
        static public int preTabID_static;
        static public int nextTabID_static;
        
        public int GraphID; //图号
        public int TabID;   //位号
      
        //表示下一个连接的图号，若为-1，则表示是流程图最后一个流程
        public int nextID_local = -1;
        public int preID_local = -1;
        //记录是否画框的状态
        private bool isEnablePrintSqure = false;

        //辅助记录点击时的坐标位置
        static Point sPtoMainPage = new Point(-1,-1);
        static Point ePtoMainPage = new Point(-1,-1);

        //使用委托，调用mainform中的画线方法
        public delegate void delePL(Point sP,Point eP); //画线委托
        public delegate void deleRPL(int tabID, Point sP, Point eP);    //重新画线委托

        public delePL printLine;
        public deleRPL RePrintLine;
        #endregion

        public BaseMeterControl()
        {
            InitializeComponent();
        }

        
        public BaseMeterControl(int graphID,int tabID )
        {
            InitializeComponent();
            this.GraphID = graphID;
            this.TabID = tabID;

            InitVarPanel();
            meterControl[GraphID].Add(this);
         
        }

        #region 对外方法
        static public void AddForm()
        {
            List<BaseMeterControl> empty = new List<BaseMeterControl>();
            meterControl.Add(empty);
        }
        public void EnablePrintSqure()
        {
            squre.MouseHover += new EventHandler(squre_MouseHover);
            squre.MouseLeave += new EventHandler(squre_MouseLeave);
            isEnablePrintSqure = true;
            
           // squre.MouseMove -= new MouseEventHandler(squre_MouseMove);
           // squre.MouseDown -= new MouseEventHandler(squre_MouseDown);
        }

        public void DisablePrintSqure()
        {
            squre.MouseHover -= new EventHandler(squre_MouseHover);
            squre.MouseLeave -= new EventHandler(squre_MouseLeave);
            isEnablePrintSqure = false;
            //squre.MouseMove += new MouseEventHandler(squre_MouseMove);
            //squre.MouseDown += new MouseEventHandler(squre_MouseDown);
        }

        public void AdjustSize()
        {
            this.funcVarPanel.AdjustSize();
        }

        //显示右上角varPanel的参数列表
        public void ShowVar()
        {
            varPanelParent.Controls.Clear();

            varPanelParent.Controls.Add(funcVarPanel);
        }

        //获得函数参数
       
        #endregion

        #region 参数

        #region 控件相关可设置参数
        const int spancing = 12; //label squre 上下间距
        private const int redSqureLength = 20;  //红框边长
        private const int redSqureThickness = 2;   //红框粗细
        #endregion
        
        

        #region 不可设置参数
        #region 新控件参数
        private TextBox inputBox;
        #endregion

        #region 拖动效果参数
         Point m_lastMPoint = new Point();
         Point m_lastSqurePoint = new Point();
         Point m_lastLablePoint = new Point();

        #endregion

         #region 画红框参数
         private bool isLeftSqure = false; //有没有画squre
         private bool isRightSqure = false;
         private bool isUpSqure = false;
         private bool isDownSqure = false;
         //button 中心点
         private Point buttonLeft = new Point();
         private Point buttonRight = new Point();
         private Point buttonUp = new Point();
         private Point buttonDown = new Point();
         //squre location
         private Point squreLeft = new Point();
         private Point squreRight = new Point();
         private Point squreUp = new Point();
         private Point squreDown = new Point();

        #endregion


        #endregion

        #region 类内参数
         protected string funcName = "default";
        #endregion
        #endregion

         #region 属性
         public string squreName {
            set {   squre.Text = value;
                    labelAutosize();
            }
            get { return squre.Text; }
        }

        public string labelName {
            set { label1.Text = value; }
            get { return label1.Text; }
        }

        public dynamic controlParent {
            set
            {
                this.label1.Parent = value;
                this.squre.Parent = value;
            }
            get {
                return this.squre.Parent;
            }
        }

        public List<string> functionVars {
            get {
                
                funcVars = funcVarPanel.GetVar();
                return funcVars;
            }
        }
        
        public Point controlLocation{
            set{
                squre.Location = value;
                labelAutosize();
            }
            get{
                return squre.Location;
            }
        }
        
        
        #endregion

        #region label function
        
        //label1 autosize

        private void labelAutosize() {
            int mid = squre.Location.X + squre.Width/2;
            int newLabelX = mid - label1.Width/2;
            int newlabelY = squre.Location.Y + squre.Height + spancing;
            label1.Location = new Point (newLabelX, newlabelY);
            return;
        }
        

        //双击修改label名字
        private void label1_DoubleClick(object sender, EventArgs e)
        {
            label1.Visible = false;
            inputBox = new TextBox();
            inputBox.Parent = label1.Parent;
            inputBox.Location = label1.Location;
            inputBox.Text = label1.Text;
            //TextBox1.Parent = funcName;
            //inputBox.BackColor = System.Drawing.SystemColors.Control;
            inputBox.BackColor = FormBackColor;
            inputBox.Visible = true;
            inputBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            inputBox.Parent.Controls.Add(inputBox);
            // Controls.Add(TextBox1);
            inputBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label1.Visible = true;
                label1.Text = inputBox.Text;
                inputBox.Dispose();
                labelAutosize();
                return;
            }
        }
        #endregion

        #region 拖动效果实现
        private void squre_MouseDown(object sender, MouseEventArgs e)
        {
            m_lastMPoint = Control.MousePosition;
            m_lastSqurePoint = (sender as Label).Location;
            m_lastLablePoint = label1.Location;
            if(isEnablePrintSqure == false)
                sPtoMainPage = mainPage.PointToClient(MousePosition);
        }

        private void squre_MouseMove(object sender, MouseEventArgs e)
        {
            if (isEnablePrintSqure == true)
                return;
            if (e.Button == MouseButtons.Left)
            {
                mainPage.VerticalScroll.Value = mainPage.VerticalScroll.Minimum;
                mainPage.HorizontalScroll.Value = mainPage.HorizontalScroll.Minimum;

                //移动组件
                label1.Location = new Point
                    (m_lastLablePoint.X + Control.MousePosition.X - m_lastMPoint.X, 
                    m_lastLablePoint.Y + Control.MousePosition.Y - m_lastMPoint.Y);
                squre.Location = new Point
                    (m_lastSqurePoint.X + Control.MousePosition.X - m_lastMPoint.X,
                    m_lastSqurePoint.Y + Control.MousePosition.Y - m_lastMPoint.Y);

                
                //移动连接线,通过组件相对于mainPage的位置来计算
                sPtoMainPage = ePtoMainPage;
                //计算移动后，组件相对于mainPage的位置
                Point mouseToControl = this.squre.PointToClient(MousePosition); //鼠标相对于meter的坐标
                Point mouseToMainpage = mainPage.PointToClient(MousePosition);
                ePtoMainPage = new Point(mouseToMainpage.X - mouseToControl.X,
                                mouseToMainpage.Y -mouseToControl.Y);
                //mainForm.pubRePrintLine(this.TabID, sPtoMainPage, ePtoMainPage);
                if(RePrintLine != null)
                    RePrintLine(this.TabID,sPtoMainPage,ePtoMainPage);
           
            }
              
        }

        #endregion
        


        #region 点击事件

        protected void squre_Click(object sender, EventArgs e)
        {   //若没有使能画框
            //显示点击效果，出现参数列表
            if (isEnablePrintSqure == false)
            {
                DateTime clickTime = DateTime.Now;
                squre.BorderStyle = BorderStyle.Fixed3D;
                TimeSpan span = DateTime.Now - clickTime;
                while (span.Milliseconds <= 100)
                {
                    span = DateTime.Now - clickTime;
                }
                squre.BorderStyle = BorderStyle.FixedSingle;

                ShowVar();

                return;
            }

            //若使能画框，则记录点击时的ID和position
            if (isEnablePrintSqure == true)
            {

                Point pToMainpage = mainPage.PointToClient(MousePosition);
              
                //第一次点击
                if (sPtoMainPage.X < 0 && sPtoMainPage.Y < 0)
                {
                    sPtoMainPage = adjustPosition(pToMainpage);
                    preTabID_static = this.TabID;
                }
                //第二次点击
                else
                {
                    ePtoMainPage = adjustPosition(pToMainpage);
                    nextTabID_static = this.TabID;
                    //mainForm.pubPrintLine(sPtoMainPage,ePtoMainPage);
                    printLine(sPtoMainPage,ePtoMainPage);
                    sPtoMainPage = new Point(-1,-1);
                    ePtoMainPage = new Point(-1,-1);
                    meterControl[0][preTabID_static].nextID_local = nextTabID_static;
                    meterControl[0][nextTabID_static].preID_local = preTabID_static;                    
                }
                return;
            }
        }
        //输入是鼠标相对于mainPage的坐标
        //调整鼠标点的位置到4条边中的其中一条的中点，返回相对于mainPage的坐标位置
        private Point adjustPosition(Point p) {

            Point mouseToControl = this.squre.PointToClient(MousePosition); //鼠标相对于meter的坐标
            
            Point left = new Point(0, squre.Height / 2);
            Point down = new Point(  squre.Width / 2,  squre.Height);
            Point right = new Point( squre.Width, squre.Height/2);
            Point up = new Point(squre.Width/2, 0);

            Point closePoint;
            if (isInclude(left, mouseToControl))
                closePoint = left;
            else if (isInclude(down, mouseToControl))
                closePoint = down;
            else if (isInclude(right, mouseToControl))
                closePoint = right;
            else
                closePoint = up;
            Point adjustP = new Point(p.X+ closePoint.X - mouseToControl.X,
                                p.Y + closePoint.Y-mouseToControl.Y);
            return adjustP;

         }
        #endregion

        #region 画红框
        /*****************************************
        //更新框体位置的中心点
         *******************************************/
        private void updataLocation()
        {
            int x = squre.Location.X;
            int y = squre.Location.Y;
            //updata the points data of button 
            buttonLeft.X = x;
            buttonLeft.Y = y + squre.Height / 2;

            buttonRight.X = x + squre.Width;
            buttonRight.Y = y + squre.Height / 2;

            buttonUp.X = x + squre.Width / 2;
            buttonUp.Y = y;

            buttonDown.X = x + squre.Width / 2;
            buttonDown.Y = y + squre.Height;

            //updata the points of the squre;
            int diffLength = redSqureLength / 2;
            squreLeft.X = buttonLeft.X - diffLength;
            squreLeft.Y = buttonLeft.Y - diffLength;

            squreRight.X = buttonRight.X - diffLength;
            squreRight.Y = buttonRight.Y - diffLength;

            squreDown.X = buttonDown.X - diffLength;
            squreDown.Y = buttonDown.Y - diffLength;

            squreUp.X = buttonUp.X - diffLength;
            squreUp.Y = buttonUp.Y - diffLength;

            return;
        }

        /******************************************************
         * 两点之间距离是否小于r
         * *****************************************************/
        private bool isInclude(Point location1, Point location2, double r = redSqureLength/2*1.5)
        {
            double diffX = location1.X - location2.X;
            double diffY = location2.Y - location1.Y;
            double diff = diffX * diffX + diffY * diffY;
            if (diff <= (r * r))
                return true;
            else return false;
        }

        /*********************************************************
         * 画redSqure
         * *******************************************************/
        private void printSqure(Point location, bool isDelete = false)
        {
            Pen p = new Pen(Color.Red, redSqureThickness);
            if (isDelete == true)
            {
                //p.Color = squre.Parent.BackColor;
                p.Color = FormBackColor;
            }
            System.Drawing.Graphics g = squre.Parent.CreateGraphics();
            g.DrawRectangle(p, location.X, location.Y, redSqureLength, redSqureLength);
            p.Dispose();
            g.Dispose();

            //判断是否点击左键，若点击，则记录preID
            //if(MouseButtons == System.Windows.Forms.MouseButtons.Left)
           
        }

        /***********************************************************
         * 删除redsqure
         * ********************************************************/
        private void deleteRedSqure() {
            if (isLeftSqure)
            {
                printSqure(squreLeft, true);
                isLeftSqure = false;
                return;
            }

            if (isRightSqure)
            {
                printSqure(squreRight, true);
                isRightSqure = false;
                return;
            }

            if (isUpSqure)
            {
                printSqure(squreUp, true);
                isUpSqure = false;
                return;
            }

            if (isDownSqure)
            {
                printSqure(squreDown, true);
                isDownSqure = false;
                return;

            }
        }

        /****************************************************
         * 进入squre时，画红框
         * ***************************************************/
        private void squre_MouseHover(object sender, EventArgs e)
        {
           
            updataLocation();

            Point mPoint = squre.Parent.PointToClient(MousePosition);
            int mX = mPoint.X;
            int mY = mPoint.Y;

            if (isInclude(mPoint, buttonLeft))
            {
                printSqure(squreLeft);
                isLeftSqure = true;
                return;
            }

            if (isInclude(mPoint, buttonRight))
            {
                printSqure(squreRight);
                isRightSqure = true;
                return;
            }

            if (isInclude(mPoint, buttonUp))
            {
                printSqure(squreUp);
                isUpSqure = true;
                return;
            }

            if (isInclude(mPoint, buttonDown))
            {
                printSqure(squreDown);
                isDownSqure = true;
                return;
            }

            deleteRedSqure();
          
        }

        /********************************************************
        //离开时删除redsqure
         * ******************************************************/
        private void squre_MouseLeave(object sender, EventArgs e)
        {
            deleteRedSqure();
        }

        #endregion

        #region varPanel
        private void InitVarPanel() {
            
            DisablePrintSqure();//关闭红框闪烁事件
            //EnablePrintSqure();
            if (TabID == 0)
                varInfoList = null;
            else InitVarInfo();

            setFuncName();

            funcVarPanel = new VarPanel(varInfoList, funcName,TabID);
            funcVarPanel.Dock = DockStyle.Fill;
            funcVarPanel.Parent = varPanelParent;
        }

        protected virtual void setFuncName() {
            funcName = "START";
            return;
        }
        protected virtual void InitVarInfo() {
            return;
        }

        #endregion

        private void squre_MouseUp(object sender, MouseEventArgs e)
        {
            if (isEnablePrintSqure == false)
            {
                mainPage.VerticalScroll.Value = mainPage.VerticalScroll.Minimum;
                mainPage.HorizontalScroll.Value = mainPage.HorizontalScroll.Minimum;
                sPtoMainPage = ePtoMainPage;
                //计算移动后，组件相对于mainPage的位置
                Point mouseToControl = this.squre.PointToClient(MousePosition); //鼠标相对于meter的坐标
                Point mouseToMainpage = mainPage.PointToClient(MousePosition);
                ePtoMainPage = new Point(mouseToMainpage.X - mouseToControl.X,
                                mouseToMainpage.Y - mouseToControl.Y);
               //mainForm.pubRePrintLine(this.TabID, sPtoMainPage, ePtoMainPage);
                if(RePrintLine != null)
                    RePrintLine(this.TabID, sPtoMainPage, ePtoMainPage);
                sPtoMainPage = new Point(-1, -1);
                ePtoMainPage = new Point(-1, -1);
            }

        }

        //虚函数，用来承载不同组件的执行函数
        public virtual void function() {
            return;
        }

      

    }
}
