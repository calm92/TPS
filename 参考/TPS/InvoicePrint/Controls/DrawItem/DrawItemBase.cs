using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Data;
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
    public abstract class DrawItemBase:ICloneable
    {
        private bool selected = false;
        private int lineWidth = 1;
        private Color color = Color.Black;
        private Color fillColor = Color.Transparent;
        private SmoothingMode smoothingMode = SmoothingMode.Default;
        private DataTable datasource;
        private int rowscount = 5;
        private string valuecolumn = string.Empty;
        private int currentPage = 1;
        private int rowsHeight = 25;

        /// <summary>
        /// 获取数据源是否为空
        /// </summary>
        protected bool GetDataSourceIsNotNullOrEmpty
        {
            get
            {
                return CheckDataTabelIsNoteNullOrEmpty(DataSource);
            }
        }

        /// <summary>
        /// 获取或设置行高
        /// </summary>
        [Browsable(false)]
        public int RowHeight
        {
            get 
            {
                return rowsHeight;
            }
            set
            {
                rowsHeight = value;
            }
        }

        /// <summary>
        /// 当前是哪一页
        /// </summary>
        [Browsable(false)]
        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
            }
        }
        /// <summary>
        /// 从datasource中哪一列中取值
        /// </summary>
        [Description("从DataTable中哪个Columns中取值"),DisplayName("列名")]
        public virtual string ValueColumn
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
        /// 如果是列表,对像所在重复的次数
        /// </summary>
        [Browsable(false)]
        public int PageRowsCount
        {
            get
            {
                return rowscount;
            }
            set
            {
                rowscount = value;
            }
        }
        /// <summary>
        /// 设置对像的数据源
        /// 只支持DataTable数据源
        /// 待修改成为支持IList接口的数据源
        /// </summary>
        [Browsable(false)]
        public DataTable DataSource
        {
            get
            {
                return datasource;
            }
            set
            {
                datasource = value;
            }
        }
      
        /// <summary>
        /// 对像是否选择
        /// </summary>
        [Browsable(false)]
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                //如果选中,则不做操作
                    selected = value;
            }
        }

        /// <summary>
        /// 设置对像的外观线的宽度
        /// </summary>
        [Description("设置对像外观线的宽度"), DisplayName("线条宽度")]
        public virtual int LineWidth
        {
            get 
            {
                return lineWidth;
            }
            set
            {
                lineWidth = value;
            }
        }
        /// <summary>
        /// 设置对像颜色
        /// </summary>
        [Description("设置对像颜色"), DisplayName("颜色")]
        public Color LineColor
        {
            get 
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Description("设置对像的填充颜色"), DisplayName("填充颜色")]
        public Color FillColor
        {
            get 
            {
                return fillColor;
            }
            set
            {
                fillColor = value;
            }
        }

        /// <summary>
        /// 设置对像的呈现质量
        /// </summary>
        [Description("设置对像的呈现质量,如果是条码则不受影响!"),DisplayName("做图质量")]
        public SmoothingMode DrawSmoothingMode
        {
            get
            {
                return smoothingMode;
            }
            set
            {
                if (value != SmoothingMode.Invalid)
                {
                    smoothingMode = value;
                }
            }
        }

        /// <summary>
        /// 检查DataTable是否为空
        /// </summary>
        /// <param name="dt">要检查的DataTable</param>
        /// <returns>False:为空 True:不为空</returns>
        protected bool CheckDataTabelIsNoteNullOrEmpty(DataTable dt)
        {
            bool IsNotNull = true;
            if (DataSource == null)
            {
                IsNotNull = false ;
            }
            else if (DataSource.Rows.Count == 0)
            {
                IsNotNull = false;
            }
            return IsNotNull;
        }

        /// <summary>
        /// 从资源文件中获取图标文件
        /// </summary>
        /// <param name="imageName">图标文件的名称,不加扩展名</param>
        /// <returns></returns>
        protected Image GetIconImage(string imageName)
        {
            using (Stream fs = Assembly.GetAssembly(typeof(DrawItemBase)).GetManifestResourceStream("CustomControls.Resources."+imageName))
            {
                Image image = Image.FromStream(fs);
                return image;
            }
        }
    

        /// <summary>
        /// 鼠标移动到什么地方
        /// </summary>
        /// <param name="point">鼠标移动到的坐标</param>
        /// <param name="handleIndex">鼠标的焦点在哪一个手柄上</param>
        public virtual void MoveHandleTo(Point point, int handleIndex)
        { 
        }

        /// <summary>
        /// 获得手柄的坐点
        /// </summary>
        /// <param name="handleNumber">哪一个手柄</param>
        /// <returns></returns>
        public virtual Point GetHandle(int handleNumber)
        {
            return new Point(0, 0);
        }

        /// <summary>
        /// 获得手柄矩形大小
        /// </summary>
        /// <param name="handleNumber">哪一个手柄</param>
        /// <returns></returns>
        public virtual Rectangle GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            return new Rectangle(point.X - 3, point.Y - 3, 7, 7);
        }

        /// <summary>
        /// 画出手柄
        /// </summary>
        /// <param name="g"></param>
        public virtual void DrawTracker(Graphics g)
        {
            if (!Selected)
                return;
                        
            for (int i = 1; i <= HandleCount; i++)
            {
                g.DrawRectangle(Pens.SkyBlue, GetHandleRectangle(i));
            }
        }

        /// <summary>
        /// 是否被点击
        /// 如返回大于1则是被点击并返回手柄数!
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual int HitTest(Point point)
        {
            return -1;
        }

        /// <summary>
        /// 点是否是对像中
        /// </summary>
        /// <param name="point">在返回true</param>
        /// <returns></returns>
        protected virtual bool PointInObject(Point point)
        {
            return false;
        }

        /// <summary>
        /// 是否在传来的矩型中
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public virtual bool IntersectsWith(Rectangle rectangle)
        {
            return false;
        }

        /// <summary> 
        /// 将对像移动到哪个点上
        /// </summary>
        /// <param name="deltaX">X坐标点</param>
        /// <param name="deltaY">Y坐标点</param>
        public virtual void Move(int deltaX, int deltaY)
        {
        }

        /// <summary>
        /// 调用此功能结束放大或缩小
        /// </summary>
        public virtual void Normalize()
        {
        }

        /// <summary>
        /// 获进手柄光标
        /// </summary>
        /// <param name="handleNumber">哪一个手柄</param>
        /// <returns></returns>
        public virtual Cursor GetHandleCursor(int handleNumber)
        {
            return Cursors.Default;
        }

        /// <summary>
        /// 设置选中后对像有几个调节手柄
        /// 例：线２个，矩型８个等
        /// </summary>
        [Browsable(false)]
        public abstract int HandleCount
        {
            get;
        }

        /// <summary>
        /// 在对像列表中显示的名称
        /// </summary>
        [Browsable(false)]
        public virtual string Name
        {
            get{return "NULL";}
        }
        /// <summary>
        /// 在对像列表中显示的图标
        /// </summary>
        [Browsable(false)]
        public virtual Image IconImage
        {
            get { return null; }
        }

        public virtual void Draw(Graphics g)
        {
 
        }

        #region ICloneable Members

        public virtual object Clone()
        {
            return base.MemberwiseClone();
        }
        #endregion
    }
}
