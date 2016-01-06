using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Runtime.Serialization;
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
namespace CustomControls.DrawItem
{
    [Serializable()]
    public class DrawLine:DrawItemBase,ISerializable
    {
        public DrawLine()
        {
            pfs = new Point(0, 0);
            pfe = new Point(1, 1);
            
        }

        public DrawLine(Point fs, Point fe)
        {
            pfs = fs;
            pfe = fe;
        }

        public override string Name
        {
            get { return "直线"; }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("line.png");
            }
        }

        /// <summary>
        /// 起始坐标
        /// </summary>
        private Point pfs = new Point();
        /// <summary>
        /// 结束坐标
        /// </summary>
        private Point pfe = new Point();
        /// <summary>
        /// 做图所在区域的路径
        /// 在选择是使用
        /// </summary>
        private GraphicsPath areaPath = null;
        /// <summary>
        /// 做图所在的区域
        /// 在选择是使用
        /// </summary>
        private Region areaRegion = null;
        /// <summary>
        /// 绘制区域的画笔
        /// 在选择是使用
        /// </summary>
        private Pen areaPen = null;

        private bool drawWithDatasource = false;
        private string valuecolumn = string.Empty;

        /// <summary>
        /// 是否和数据源中的行进行重复的画出来
        /// 如果值为True请不要修改ValueColumn的值,当ValueColumn的值不为空时才会重复画出来
        /// </summary>
        [Description("是否和数据源中的行进行重复的画出来")]
        public bool DrawWithDataSource
        {
            get
            {
                return drawWithDatasource;
            }
            set
            {
                if (value)
                {
                    valuecolumn = "Temp";
                }
                else
                {
                    valuecolumn = "";
                }
                drawWithDatasource = value;
            }
        }

        /// <summary>
        /// 因为不用从数据源中取数据所以不用显示
        /// 但不能显示,在DrawItemList中有通过检查此属性是否为空,如果为空则不会添加数源
        /// </summary>
        [Browsable(false)]
        public override string ValueColumn
        {
            get
            {
                return valuecolumn;
            }
            set
            {
                valuecolumn = value;
            }
        }


        /// <summary>
        /// 直线的开始坐标
        /// </summary>
        [Description("直线的开始坐标")]
        public Point StartPoint
        {
            get
            {
                return pfs;
            }
            set
            {
                pfs = value;
            }
        }
        /// <summary>
        /// 直线的结束坐标
        /// </summary>
        [Description("直线的结束坐标")]
        public Point EndPoint
        {
            get
            {
                return pfe;
            }
            set
            {
                pfe = value;
            }
        }

        public override void Draw(Graphics g)
        {
            g.SmoothingMode = this.DrawSmoothingMode;

            if (GetDataSourceIsNotNullOrEmpty && DrawWithDataSource)
            {
                //根据当前的页数,找出在数据源中的第一条记录
                int i = (CurrentPage - 1) * PageRowsCount;
                int temp = 0;
                //依次画出数据源中的相应数据
                //TO DO
                for (; i < DataSource.Rows.Count; i++)
                {
                    //检查直线是不是垂直
                    //如果是垂直则设定线的高度为行高
                    Point temp1, temp2;
                    if (pfs.X == pfe.X)
                    {
                        temp1 = new Point(pfs.X, pfs.Y + temp * RowHeight);
                        temp2 = new Point(pfs.X, pfs.Y + temp * RowHeight + RowHeight);
                    }
                    else
                    {
                        temp1 = new Point(pfs.X, pfs.Y + temp * RowHeight);
                        temp2 = new Point(pfe.X, pfe.Y + temp * RowHeight);
                    }
                    DrawLineObject(g, temp1, temp2);
                    temp++;
                    //画出预先设置的数后退出
                    if (temp == PageRowsCount)
                    {
                        break;
                    }
                }
            }
            else
            {
                DrawLineObject(g, pfs, pfe);
            }
            
        }

        private void DrawLineObject(Graphics g,Point pointStart,Point pointEnd)
        {
            using (Pen linePen = new Pen(this.LineColor, LineWidth))
            {
                g.DrawLine(new Pen(new SolidBrush(this.LineColor), LineWidth), pointStart, pointEnd);
            }
        }

        //鼠标移动画线,移动的是哪个坐标
        public override void MoveHandleTo(Point point, int handleIndex)
        {
            if (handleIndex == 2)
            {
                pfe = point;
            }
            else
            {
                pfs = point;
            }
            ReleaseTempObject();
        }

        //获得对像有几个调节手柄
        public override int HandleCount
        {
            get { return 2; }
        }

        public override Point GetHandle(int handleNumber)
        {
            //如果是第一个坐标点则返回起始坐标
            if (handleNumber == 1)
            {
                return pfs;
            }
            return pfe;
        }

        public override int HitTest(Point point)
        {
           if(Selected)
           {
               for (int i = 1; i <= HandleCount; i++)
               {
                   if (GetHandleRectangle(i).Contains(point))
                   {
                       return i;
                   }
               }
           }
           if (PointInObject(point))
           {
               return 0;
           }
           return -1;
        }

        protected override bool PointInObject(Point point)
        {
            CreateObjects();
            return areaRegion.IsVisible(point);
        }

        public override bool IntersectsWith(Rectangle rectangle)
        {
            CreateObjects();
            return areaRegion.IsVisible(rectangle);
        }

        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                case 1:
                case 2:
                    return Cursors.SizeAll;
                default:
                    return Cursors.Default;
            }
        }

        public override void Move(int deltaX, int deltaY)
        {
            pfs.X += deltaX;
            pfs.Y += deltaY;

            pfe.X += deltaX;
            pfe.Y += deltaY;
            ReleaseTempObject();
        }

        private void CreateObjects()
        {
           
            if (areaPath != null)
            {
                return;
            }
            //在设置选择路径时将直线加粗,方便选择
            using (areaPen = new Pen(Color.Blue, this.LineWidth + 7))
            {
                areaPath = new GraphicsPath();
                areaPath.AddLine(pfs, pfe);

                areaPath.Widen(areaPen);

                areaRegion = new Region(areaPath);
            }
        }

        /// <summary>
        /// 释放做图区域
        /// </summary>
        private void ReleaseTempObject()
        {
            if (areaPath != null)
            {
                areaPath.Dispose();
                areaPath = null;
            }
            //if (areaPen != null)
            //{
            //    areaPen.Dispose();
            //    areaPen = null;
            //}
            if (areaRegion != null)
            {
                areaRegion.Dispose();
                areaRegion = null;
            }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("StartPoint", this.StartPoint);
            info.AddValue("EndPoint", this.EndPoint);
            info.AddValue("PenWidth", this.LineWidth);
            info.AddValue("LineColor", this.LineColor);
            info.AddValue("FillColor", this.FillColor);
            info.AddValue("DrawWithDataSource", DrawWithDataSource);

        }
        public DrawLine(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.StartPoint = (Point)info.GetValue("StartPoint", typeof(Point));
            this.EndPoint = (Point)info.GetValue("EndPoint", typeof(Point));
            this.LineWidth = info.GetInt32("PenWidth");
            this.LineColor = (Color)info.GetValue("LineColor", typeof(Color));
            this.FillColor = (Color)info.GetValue("FillColor", typeof(Color));
            this.DrawWithDataSource = info.GetBoolean("DrawWithDataSource");
        }

        #endregion

    }
}
