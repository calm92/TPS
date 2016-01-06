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
    public partial class BaseMeterControl : UserControl
    {
        private List<VarInfo> varInfoList= new List<VarInfo>();
        private VarPanel funcVarPanel;

        public BaseMeterControl()
        {
            InitializeComponent();
        }

        
        public BaseMeterControl(int ID, Panel varPanelParent)
        {
            InitializeComponent();
            GraphID = ID;
            this.varPanelParent = varPanelParent;
            if (GraphID == 0)
                InitVarPanel();
        }

        #region 对外方法
        public void EnablePrintSqure()
        {
            squre.MouseHover += new EventHandler(squre_MouseHover);
            squre.MouseLeave += new EventHandler(squre_MouseLeave);
            squre.MouseMove -= new MouseEventHandler(squre_MouseMove);
            squre.MouseDown -= new MouseEventHandler(squre_MouseDown);
        }

        public void DisablePrintSqure()
        {
            squre.MouseHover -= new EventHandler(squre_MouseHover);
            squre.MouseLeave -= new EventHandler(squre_MouseLeave);
            squre.MouseMove += new MouseEventHandler(squre_MouseMove);
            squre.MouseDown += new MouseEventHandler(squre_MouseDown);
        }

        public void AdjustSize()
        {
            this.funcVarPanel.AdjustSize();
        }
        #endregion

        #region 参数

        #region 控件相关可设置参数
        const int spancing = 8; //label squre 上下间距
        private const int redSqureLength = 20;  //红框边长
        private const int redSqureThickness = 2;   //红框粗细
        #endregion
        
        #region 对外参数
        public int GraphID;
        public Panel varPanelParent;
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
            inputBox.BackColor = System.Drawing.SystemColors.Control;
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
        }

        private void squre_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                label1.Location = new Point(m_lastLablePoint.X + Control.MousePosition.X - m_lastMPoint.X, m_lastLablePoint.Y + Control.MousePosition.Y - m_lastMPoint.Y);
                squre.Location = new Point(m_lastSqurePoint.X + Control.MousePosition.X - m_lastMPoint.X, m_lastSqurePoint.Y + Control.MousePosition.Y - m_lastMPoint.Y);
            }
        }

        #endregion
        


        #region 点击事件

        private void squre_Click(object sender, EventArgs e)
        {
            //显示点击效果
            DateTime clickTime = DateTime.Now;
            squre.BorderStyle = BorderStyle.Fixed3D;
            TimeSpan span = DateTime.Now - clickTime ;
            while (span.Milliseconds <= 100) {
                span = DateTime.Now - clickTime;
            }
            squre.BorderStyle = BorderStyle.FixedSingle;

            varPanelParent.Controls.Clear();

            varPanelParent.Controls.Add(funcVarPanel);

            //funcVarPanel.Visible = true;

            return;
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
                p.Color = squre.Parent.BackColor;
            }
            System.Drawing.Graphics g = squre.Parent.CreateGraphics();
            g.DrawRectangle(p, location.X, location.Y, redSqureLength, redSqureLength);
            p.Dispose();
            g.Dispose();
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
            
            DisablePrintSqure();
            if (GraphID == 0)
                varInfoList = null;
            else InitVarInfo();

            setFuncName();

            funcVarPanel = new VarPanel(varInfoList, funcName,GraphID);
            funcVarPanel.Dock = DockStyle.Fill;
            funcVarPanel.Parent = varPanelParent;
        }

        protected virtual void setFuncName() {
            funcName = "START";
            return;
        }
        protected virtual void InitVarInfo() {
            VarInfo varInfo1 = new VarInfo(true, "add1", "int");
            VarInfo varInfo2 = new VarInfo(true, "add2", "int");
            VarInfo varInfo3 = new VarInfo(false, "result", "int");
            varInfoList.Add(varInfo1);
            varInfoList.Add(varInfo2);
            varInfoList.Add(varInfo3);

            
            return;
        }

        #endregion
        private void BaseMeterControl_Load(object sender, EventArgs e)
        {
            
            InitVarPanel();
        }

       

        
    }
}
