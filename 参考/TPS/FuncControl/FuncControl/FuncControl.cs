using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuncControl
{
    public partial class FuncControl: UserControl
    {
        public FuncControl()
        {
            InitializeComponent();

        }

        //******************可设置参数***********************//
        private const int squreLength = 20;
        private int squreThickness = 2;
        private int count = 0;
        //******************可设置参数***********************//
        public int Count;

        #region FuncVarControl

        #region funcvarcontrol相关参数

        private Form VarForm;
        private string[] varTypes;
        #endregion
        

        #endregion


        #region 属性
        //设置funcName的Text
        public string FuncName {
            get { return funcName.Text; }
            set { funcName.Text = value; }
        }
        
        //设置button的Text
        public string CaseName {
            set { button1.Text = value; }
            get { return button1.Text; }
        }
        
        //设置parent
        public dynamic ButtonParent {
            set {
                funcName.Parent = value;
                button1.Parent = value;
            }
            get {
                return funcName.Parent;
            }
        }

        public dynamic VarFormParent {
            get {
                return VarForm.Parent;
            }
            set {
                VarForm.Parent = value;
            }
        }
        #endregion

        #region 红框

        #region 画红框相关参数
        private TextBox TextBox1;   //用来改变lable的Text
        private Point m_lastMPoint;
        private Point m_lastLablePoint;
        private Point m_lastButtonPoint;
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

        #region 对外接口
        //********************对外接口*************************//
        public void EnablePrintSqure()
        {
            button1.MouseHover += new EventHandler(button1_MouseHover);
            button1.MouseLeave += new EventHandler(button1_MouseLeave);
            //当画矩形时，取消拖动功能
            button1.MouseDown -= new MouseEventHandler(button1_MouseDown);
            button1.MouseMove -= new MouseEventHandler(button1_MouseMove);
        }

        public void CancelPrintSqure()
        {
            button1.MouseHover -= new EventHandler(button1_MouseHover);
            button1.MouseLeave -= new EventHandler(button1_MouseLeave);
            //
            button1.MouseDown += new MouseEventHandler(button1_MouseDown);
            button1.MouseMove += new MouseEventHandler(button1_MouseMove);
        }
#endregion

        #region 画框事件和方法
        private bool isInclude(Point location1, Point location2, double r = squreLength/2*1.5)
        {
            double diffX = location1.X - location2.X;
            double diffY = location2.Y - location1.Y;
            double diff = diffX * diffX + diffY * diffY;
            if (diff <= (r * r))
                return true;
            else return false;
        }
        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle UserControlBtnClicked;

     

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (UserControlBtnClicked != null)
                UserControlBtnClicked(sender, new EventArgs());//把按钮自身作为参数传递
        }

        private void funcName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            funcName.Visible = false;
            TextBox1 = new TextBox();
            TextBox1.Parent = funcName.Parent;
            TextBox1.Location = funcName.Location;
            TextBox1.Text = funcName.Text;
            //TextBox1.Parent = funcName;
            TextBox1.BackColor = System.Drawing.SystemColors.Control;
            TextBox1.Visible = true;
            TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            TextBox1.Parent.Controls.Add(TextBox1);
           // Controls.Add(TextBox1);
            TextBox1.KeyDown += new KeyEventHandler(TextBox_KeyDown);
        }

        private void funcName_Click(object sender, EventArgs e)
        {
           
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                funcName.Visible = true;
                funcName.Text = TextBox1.Text;
                TextBox1.Dispose();
                return;
            }
        }

        private void funcName_MouseDown(object sender, MouseEventArgs e)
        {
            m_lastMPoint = Control.MousePosition;
            m_lastLablePoint = (sender as Label).Location;
        }

        private void funcName_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                funcName.Location = new Point(m_lastLablePoint.X + Control.MousePosition.X - m_lastMPoint.X, m_lastLablePoint.Y + Control.MousePosition.Y - m_lastMPoint.Y);
               
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            m_lastMPoint = Control.MousePosition;
            m_lastButtonPoint = (sender as Button).Location;
            m_lastLablePoint = funcName.Location;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                funcName.Location = new Point(m_lastLablePoint.X + Control.MousePosition.X - m_lastMPoint.X, m_lastLablePoint.Y + Control.MousePosition.Y - m_lastMPoint.Y);
                button1.Location = new Point(m_lastButtonPoint.X + Control.MousePosition.X - m_lastMPoint.X, m_lastButtonPoint.Y + Control.MousePosition.Y - m_lastMPoint.Y);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.ButtonParent = this.Parent;
            this.Visible = false;
            //CancelPrintSqure();
        }

        private void updataLocation()
        {
            int x = button1.Location.X;
            int y = button1.Location.Y;
            //updata the points data of button 
            buttonLeft.X = x;
            buttonLeft.Y = y + button1.Height / 2;

            buttonRight.X = x + button1.Width;
            buttonRight.Y = y + button1.Height / 2;

            buttonUp.X = x + button1.Width / 2;
            buttonUp.Y = y;

            buttonDown.X = x + button1.Width / 2;
            buttonDown.Y = y + button1.Height;

            //updata the points of the squre;
            int diffLength = squreLength / 2;
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
        private void printSqure(Point location, bool isDelete = false) {
            Pen p = new Pen(Color.Red, squreThickness);
            if (isDelete == true)
            {
                p.Color = button1.Parent.BackColor;
            }
            System.Drawing.Graphics g = button1.Parent.CreateGraphics();
            g.DrawRectangle(p, location.X,location.Y, squreLength, squreLength);
            p.Dispose();
            g.Dispose();
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {

          
            updataLocation();
            Point mPoint = button1.Parent.PointToClient(MousePosition);
            int mX = mPoint.X;
            int mY = mPoint.Y;
            
            if (isInclude(mPoint, buttonLeft)) {
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

            if (isInclude(mPoint, buttonUp)) {
                printSqure(squreUp);
                isUpSqure = true;
                return;
            }

            if (isInclude(mPoint, buttonDown)) {
                printSqure(squreDown);
                isDownSqure = true;
                return;
            }

            if (isLeftSqure) {
                printSqure(squreLeft, true);
                isLeftSqure = false;
                return;
            }

            if (isRightSqure) {
                printSqure(squreRight, true);
                isRightSqure = false;
                return;
            }

            if (isUpSqure) {
                printSqure(squreUp, true);
                isUpSqure = false;
                return;
            }

            if (isDownSqure) {
                printSqure(squreDown, true);
                isDownSqure = false;
                return;

            }

           


        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
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


    }
        #endregion

        #endregion
    


}
