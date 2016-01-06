using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

/******************************************************************
 * Copyright(c)  : 徐春晓
 * CreateDate    : 2008-10-21 22:55
 * Creater       : CraxyMouse
 * LastChangeDate: 
 * LastChanger   : CraxyMouse
 * Version Info  : 1.0.1
 * Author        : CraxyMouse
 * Mail          : 9658258@qq.com
 * MSN           : chunxiaodyl@hotmail.com
 * Blog          : http://blog.csdn.net/dunao
 * Description   : 如果您使用此源程序或是提供下载，不可修改资助信息。以示对我的劳动成果的尊重！谢谢您的合作！否则请您不要提供下载或使用
 *                 源代码中CODE 39[CODE93,CODE 128A,CODE 128B,CODE 128C,EAN-13,UPC-A尚未添加,需要请发邮件给我!]的条码为有尝使用,如果您使用了这些代码请您
 *                 根据资助信息里的资助信息,支付RMB:10元以上的使用费用!给您带来不便还望谅解!如有问题你也可以直接和我
 *                 交流,我将知无不言!
 * ******************************************************************
 *本程序为开源程序。所有代码可以任意复制和使用，请您在使用的时候请保留版权信息，以示对我支持！谢谢！！同时要感谢AnsenYu支持！！！
  如果有任何关于程序方面的问题和意见请联系我！QQ群:47717908 Mail:9658258@qq.com我将会在第一时间内解答您的问题！
 * 首先谢谢您的资助!您可以通过以下几种方式资助:
    1.支付宝直接转帐：
          帐号：xutongchun@163.com
          姓名：徐春晓
    2.银行帐号直接转帐：
          开户行：招商银行苏州园区支行
          帐  号：6225  8851  2367  5829
          开户名：徐春晓
          
          开户行：农业银行苏州干将路支行
          帐  号：62284 8040 03789 32919
          开户名：徐春晓
    3.淘宝物品购买:
          物品地址:
 *                  http://auction1.taobao.com/auction/item_detail-0db2-c9d9d9663b8053dcebecbe17d8a4bbda.jhtml
 *                  
 */

namespace CustomControls.Control
{
    public partial class Ruler : System.Windows.Forms.Control,IMessageFilter
    {
        public Ruler()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            base.BackColor = Color.White;
            base.ForeColor = Color.Black;
            referLinePen = new Pen(this.ForeColor);
            backPen = new Pen(this.BackColor);
            g = this.CreateGraphics();
            Initialize();
            if (Visible)
            {
                Application.AddMessageFilter(this);
            }
        }

        ~Ruler()
        {
            referLinePen.Dispose();
            backPen.Dispose();

            Application.RemoveMessageFilter(this);
        }

        /// <summary>
        /// 初始化参数
        /// </summary>
        internal void Initialize()
        {
            //计算出标尺所在的宽和高
            width_mm = CommonSettings.PixelConvertMillimeter(this.Width);
            height_mm = CommonSettings.PixelConvertMillimeter(this.Height);

            if (rulerOrientation == Orientation.Horizontal)
            {
                percent = this.Width / width_mm;
            }
            else
            {
                percent = this.Height / height_mm;
            }
        }

        internal enum Msg
        {
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSELEAVE = 0x02A3,
            WM_NCMOUSELEAVE = 0x02A2,
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Initialize();
            Invalidate();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == (int)Msg.WM_MOUSEMOVE)
            {
                int X = 0;
                int Y = 0;

                Point pointScreen = System.Windows.Forms.Control.MousePosition;

                Point pointClientOrigin = new Point(X, Y);
                pointClientOrigin = PointToScreen(pointClientOrigin);

                bool _bDrawLine = false;
                //是否在标尺标示的范围
                if (this.rulerOrientation == Orientation.Horizontal)
                {
                    _bDrawLine = (pointScreen.X >= pointClientOrigin.X) && (pointScreen.X <= pointClientOrigin.X + this.Width);
                }
                else
                {
                    _bDrawLine = (pointScreen.Y >= pointClientOrigin.Y) && (pointScreen.Y <= pointClientOrigin.Y + this.Height);
                }

                if (_bDrawLine)
                {
                    X = pointScreen.X - pointClientOrigin.X;
                    Y = pointScreen.Y - pointClientOrigin.Y;

                    using (g = this.CreateGraphics())
                    {
                        //判断是水平尺还是垂直尺
                        if (rulerOrientation == Orientation.Horizontal)
                        {
                            //如果存在上一次坐标则以背景色将其擦除
                            if (trackOld != null)
                            {
                                g.DrawLine(backPen, trackOld.X, this.Height, trackOld.X, this.Height - referLine + 1);
                            }
                            g.DrawLine(Pens.Blue, X, this.Height, X, this.Height - referLine);
                        }
                        else
                        {
                            if (trackOld != null)
                            {
                                g.DrawLine(backPen, this.Width, trackOld.Y, this.Width - referLine + 1, trackOld.Y);
                            }
                            g.DrawLine(Pens.Blue, this.Width, Y, this.Width - referLine + 1,Y);
                        }
                        trackOld = new Point(X, Y);
                    }

                } 
            }

            return false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (rulerOrientation == Orientation.Horizontal)
            {

                e.Graphics.DrawLine(referLinePen, 0, this.Height - referLine, this.Width, this.Height - referLine);

                DrawScale(e.Graphics, (int)width_mm+startValue);
            }
            else
            {

                e.Graphics.DrawLine(referLinePen,  this.Width - referLine,0, this.Width - referLine, this.Height);

                DrawScale(e.Graphics, (int)height_mm + startValue);
            }
        }

        #region Variable
        /// <summary>
        /// 标尺数字的字体
        /// </summary>
        private Font scaleLabel = new Font("Verdana", 7);
        /// <summary>
        /// 刻度尺的起始位置
        /// </summary>
        private int start = 20;
        /// <summary>
        /// 标尺是垂直还是水平标尺
        /// 默认为水平
        /// </summary>
        private Orientation rulerOrientation = Orientation.Vertical;
        /// <summary>
        /// 标尺的宽和高
        /// </summary>
        private float width_mm,height_mm;
        /// <summary>
        /// 第个毫米所占的像素数
        /// </summary>
        private float percent;
        /// <summary>
        /// 参考线的位
        /// </summary>
        private int referLine = 15;
        private Pen referLinePen,backPen;
        /// <summary>
        /// 记录鼠标当前标识线和上一次的标识线
        /// </summary>
        private Point trackOld;
        /// <summary>
        /// 画鼠标轨迹线的GDI对像
        /// </summary>
        private Graphics g;
        private int startValue = 0;
        #endregion

        #region Attributes
        /// <summary>
        /// 标尺方向
        /// </summary>
        [DisplayName("标尺方向")]
        public Orientation RulerOrientation
        {
            get
            {
                return rulerOrientation;
            }
            set
            {
                rulerOrientation = value;
                Initialize();
                this.Invalidate();
            }
        }
        /// <summary>
        /// 取得或设置刻度尺的起始位置
        /// 单位:Pixel
        /// </summary>
        [DisplayName("起始位置")]
        public int StartPosition
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
                Initialize();
                Invalidate();
            }
        }
        
        /// <summary>
        /// 取得或设计第一个刻度值是多少
        /// </summary>
        [DisplayName("起始刻度")]
        public int StartValue
        {
            get
            {
                return startValue;
            }
            set 
            {
                startValue = value;
                Invalidate(); 
            }
        }
        #endregion

        

        /// <summary>
        /// 画标尺刻度
        /// </summary>
        /// <param name="g"></param>
        private void DrawScale(Graphics g,int whidth)
        {
            
            PointF ps, pe;
            int scale;
            for (int i = 0; i < whidth; i++)
            {
                if (i < startValue)
                {
                    continue;
                }
                if (i % 10 == 0)
                {
                    string x = (i / 10).ToString();
                    SizeF fontSize = g.MeasureString(x, scaleLabel);
                    scale = 15;
                    PointF pf;
                    if (rulerOrientation == Orientation.Horizontal)
                    {
                        pf = new PointF(start + (i - startValue) * percent - fontSize.Width / 2, this.Height - scale - fontSize.Height - referLine);
                    }
                    else
                    {
                        pf = new PointF(this.Width - scale - fontSize.Width - referLine, start + (i - startValue) * percent - fontSize.Height / 2);
                    }
                    g.DrawString(x, scaleLabel, Brushes.Blue, pf);
                }
                else if (i % 5 == 0)
                {
                    scale = 10;
                }
                else
                {
                    scale = 5;
                }

                if (rulerOrientation == Orientation.Horizontal)
                {
                    ps = new PointF(start + (i - startValue) * percent, this.Height - referLine);
                    pe = new PointF(start + (i - startValue) * percent, this.Height - scale - referLine);
                }
                else
                {
                    ps = new PointF(this.Width - referLine, start + (i - startValue) * percent);
                    pe = new PointF(this.Width - scale - referLine, start + (i - startValue) * percent);
                }
                g.DrawLine(Pens.Blue, ps, pe);
            }         
        }
    }
}
