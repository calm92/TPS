using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using  CustomControls.DrawItem;
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
namespace CustomControls.BarCode
{
    [Serializable()]
    public class DrawBarcodes : DrawItemBase
    {
        private int startYscale = 0;
        public DrawBarcodes(int x, int y)
        {
            barcodeRectangle = new Rectangle(x, y, 116, 44);
            startYscale = y;
            Ibarcodes = barcodefactory.CreateBarcode("CustomControls.BarCode.Code39,CustomControls");
        }


        public override string Name
        {
            get { return Enum.GetName(typeof(BarcodeType), eBarcodeType); }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("barcodeNew.png");
            }
        }

        public override int HandleCount
        {
            get { return 0; }
        }

        /// <summary>
        /// 条码接口通过此接口实现不同类别的条码
        /// </summary>
        private IBarcode Ibarcodes;
        /// <summary>
        /// 要产生的条码类别
        /// Code 39,93,128A,B,C,EAN-13........
        /// </summary>
        protected BarcodeType eBarcodeType = BarcodeType.Code39;
        /// <summary>
        /// 条码的文字对齐方式
        /// </summary>
        protected BarcodeTextAlign eTextAlign = BarcodeTextAlign.Center;
        /// <summary>
        /// 条码的大小
        /// </summary>
        protected BarCodeWeight eBarcodeWeight = BarCodeWeight.Small;
        /// <summary>
        /// 条码的旋转角度
        /// 90,180,270
        /// </summary>
        protected BarcodeRotation eBaroceRotation = BarcodeRotation.Rotation0;
        /// <summary>
        /// 是否显示出条码的文本内容
        /// </summary>
        protected bool bShowValueText = true;
        /// <summary>
        /// 是否是条码的上面显示条码的内容
        /// </summary>
        protected bool bShowValueTextOnTop = false;
        /// <summary>
        /// 条码的值
        /// </summary>
        protected string sValueText = "Code39";
        /// <summary>
        /// 条码内容的字体
        /// </summary>
        protected Font fValueTextFont = new Font("Vendana", 8);
        /// <summary>
        /// 条码的高度
        /// </summary>
        protected int nBarcodeHeight = 32;
       /// <summary>
       /// 绘制条码的区域
       /// </summary>
        protected Rectangle barcodeRectangle;
        /// <summary>
        /// 条码工厂,产生不同类别的条码
        /// </summary>
        [NonSerialized]
        private BarcodeFactory barcodefactory = new BarcodeFactory();
        /// <summary>
        /// 是否需要重新计算条码的绘制构区域
        /// 在条码值改变时重新计算 
        /// </summary>

        #region Attributes
        [Category("Barcode Attribute"), DisplayName("旋转角度"), Description("设置条码的旋转角度")]
        public BarcodeRotation BarRotation
        {
            get { return eBaroceRotation; }
            set
            {
                eBaroceRotation = value;
            }
        }
        [Category("Barcode Attribute"), DisplayName("条码高度"), Description("设置条码的高度不算条码上的文字")]
        public int BarcodeHeight
        {
            get { return (int)CommonSettings.PixelConvertMillimeter(nBarcodeHeight); }
            set
            {
                nBarcodeHeight = CommonSettings.MillimeterConvertPixel(value);
            }
        }
        [Category("Barcode Attribute"), DisplayName("条码类别"), Description("设置条码类别(code39,code128,EAN-13,UPC-A)")]
        public BarcodeType BarcodeType
        {
            get { return eBarcodeType; }
            set
            {
                //建立新的条码接口
               // CreateBarcodeInterFace(BarcodeType.Code39);
                eBarcodeType = value;
                //if (eBarcodeType != BarcodeType.Code39)
                //{
                //    frmNotice fn = new frmNotice();
                //    fn.ShowDialog();
                //}
                switch (eBarcodeType)
                {
                    case BarcodeType.Code39:
                        CreateBarcodeInterFace(BarcodeType.Code39); 
                        ValueText = "Code39";
                        break;
                    case BarcodeType.Code93:
                        CreateBarcodeInterFace(BarcodeType.Code93);                        
                        ValueText = "Code93";
                        break;
                    case BarcodeType.Code128A:
                        Ibarcodes = barcodefactory.CreateBarcode("CustomControls.BarCode.Code128Base,CustomControls", eBarcodeType);
                        Ibarcodes.BarcodeRect = barcodeRectangle;
                        ValueText = "CODE128A";
                        break;
                    case BarcodeType.Code128B:
                        Ibarcodes = barcodefactory.CreateBarcode("CustomControls.BarCode.Code128Base,CustomControls", eBarcodeType);
                        Ibarcodes.BarcodeRect = barcodeRectangle;
                        ValueText = "Code128B";
                        break;
                    case BarcodeType.Code128C:
                    case BarcodeType.UCC_EAN128:
                        Ibarcodes = barcodefactory.CreateBarcode("CustomControls.BarCode.Code128Base,CustomControls", eBarcodeType);
                        Ibarcodes.BarcodeRect = barcodeRectangle;
                        ValueText = "01234567";
                        break;
                    case BarcodeType.EAN13:
                        CreateBarcodeInterFace(BarcodeType.EAN13); 
                        ValueText = "690|8888|88878";
                        break;
                    case BarcodeType.UPCA:
                        CreateBarcodeInterFace(BarcodeType.UPCA); 
                        ValueText = "9|88888|88888";
                        break;
                    case BarcodeType.Interleaved2of5:
                        CreateBarcodeInterFace(BarcodeType.Interleaved2of5);
                        ValueText = "123456";
                        break;
                    case BarcodeType.Standard2of5:
                        CreateBarcodeInterFace(BarcodeType.Standard2of5);
                        ValueText = "0123456";
                        break;
                    case BarcodeType.Code11:
                        CreateBarcodeInterFace(BarcodeType.Code11);
                        ValueText = "1234-1234";
                        break;
                    case BarcodeType.Codabar:
                        CreateBarcodeInterFace(BarcodeType.Codabar);
                        ValueText = "A123456A";
                        break;

                }
            }
        }
        [Category("Barcode Attribute"),DisplayName("对齐方式"), Description("设置条码上字符对齐式")]
        public BarcodeTextAlign ValueTextAlign
        {
            get { return eTextAlign; }
            set
            {
                eTextAlign = value;
            }
        }
        [Category("Barcode Attribute"),DisplayName("条码大小"), Description("设置条码的大小")]
        public BarCodeWeight BarcodeWeight
        {
            get { return eBarcodeWeight; }
            set
            {
                eBarcodeWeight = value;
            }
        }
        [Category("Barcode Attribute"), DisplayName("显示文本"), Description("设置条码上字符是否显示(true:显示 false:不显示")]
        public bool ShowText
        {
            get { return bShowValueText; }
            set
            {
                bShowValueText = value;

            }
        }
        [Category("Barcode Attribute"), DisplayName("上方显示文本"), Description("设置条码上字符是否显示在条码的上方(true:显示 false:不显示")]
        public bool ShowTextOnTop
        {
            get { return bShowValueTextOnTop; }
            set
            {
                bShowValueTextOnTop = value;
            }
        }
        [Category("Barcode Attribute"), DisplayName("条码文本"), Description("设置条码的值")]
        public string ValueText
        {
            get { return sValueText; }
            set
            {
                sValueText = value;
            }
        }
        [Category("Barcode Attribute"), DisplayName("文本字体"), Description("设置条码文本中的字体")]
        public Font ValueTextFont
        {
            get
            {
                return fValueTextFont;
            }
            set
            {
                fValueTextFont = value; ;
            }
        }
        #endregion

        internal void CreateBarcodeInterFace(BarcodeType be)
        {
            Ibarcodes = barcodefactory.CreateBarcode("CustomControls.BarCode." + Enum.GetName(typeof(BarcodeType), be) + ",CustomControls");
            Ibarcodes.BarcodeRect = barcodeRectangle;
        }

        /// <summary>
        /// 画出条码
        /// 在画条码时,质量用默认的即可,高质量的可能造成条码扫不出来
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighSpeed;
             try
            {
                if (Ibarcodes == null)
                {
                    return;
                }

                Ibarcodes.BarcodeHeight = nBarcodeHeight;
                Ibarcodes.barcodeRotation = BarRotation;
                Ibarcodes.barcodeTextAlign = ValueTextAlign;
                Ibarcodes.BarcodeWeight = BarcodeWeight;
                Ibarcodes.ShowText = ShowText;
                Ibarcodes.ShowTextOnTop = ShowTextOnTop;
                Ibarcodes.ValueTextFont = fValueTextFont;
                Ibarcodes.BarcodeRect = barcodeRectangle;
                if (GetDataSourceIsNotNullOrEmpty && DataSource.Columns.Contains(ValueColumn))
                {
                    //根据当前的页数,找出在数据源中的第一条记录
                    int i = (CurrentPage - 1) * PageRowsCount;
                    int temp = 0;
                    //依次画出数据源中的相应数据
                    //TO DO
                    for (; i < DataSource.Rows.Count; i++)
                    {
                        Ibarcodes.BarcodeValue = DataSource.Rows[i][ValueColumn].ToString();
                        Rectangle tempRect = Ibarcodes.GetBarcodeRectangle();
                        if (temp > 0)
                        {
                            tempRect = new Rectangle(tempRect.X, tempRect.Y + RowHeight, tempRect.Width, tempRect.Height);
                        }
                        Ibarcodes.BarcodeRect = tempRect;
                        Ibarcodes.CreateBarcode(g);
                        temp++;
                        //画出预先设置的数后退出
                        if (temp == PageRowsCount)
                        {
                            break;
                        }
                    }
                    //重置条码位置
                    Ibarcodes.BarcodeRect = barcodeRectangle;
                }
                else
                {
                    Ibarcodes.BarcodeValue = ValueText;
                    barcodeRectangle = Ibarcodes.GetBarcodeRectangle();
                    Ibarcodes.BarcodeRect = barcodeRectangle;
                    Ibarcodes.CreateBarcode(g);
                }

                if (Selected)
                {
                    using (Pen pen = new Pen(Color.SkyBlue))
                    {
                        pen.DashStyle = DashStyle.Custom;
                        pen.DashPattern = new float[] {3f,3f };
                        g.DrawRectangle(pen, barcodeRectangle.X - 2, barcodeRectangle.Y - 2, barcodeRectangle.Width + 4, barcodeRectangle.Height + 4);

                        g.DrawLine(pen, 0, barcodeRectangle.Y - 2, barcodeRectangle.X - 2, barcodeRectangle.Y - 2);
                        g.DrawLine(pen, barcodeRectangle.X - 2, 0, barcodeRectangle.X - 2, barcodeRectangle.Y - 2);

                        Point xyNotice;
                        int fontHeight = new Font("Verdana", 7).Height;
                        if (barcodeRectangle.Y < fontHeight)
                        {
                            xyNotice = new Point(barcodeRectangle.X, barcodeRectangle.Y + barcodeRectangle.Height + 2);
                        }
                        else
                        {
                            xyNotice = new Point(barcodeRectangle.X + 2, barcodeRectangle.Y - fontHeight - 2);
                        }
                        g.DrawString(string.Format("[X:{0} Y:{1}][W:{2} H:{3}]", (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.X), (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.Y), (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.Width), (int)CommonSettings.PixelConvertMillimeter(barcodeRectangle.Height)), new Font("Verdana", 7), Brushes.Blue, xyNotice);
                    
                    }
                }
             }
             catch (Exception ex)
             {
                 using (Pen pen = new Pen(Color.SkyBlue))
                 {
                     g.DrawString(ex.Message + "\n\rValue:[" + sValueText + "]", new Font("Tahoma", 8), Brushes.Red, barcodeRectangle);
                     pen.DashStyle = DashStyle.Custom;
                     pen.DashPattern = new float[] { 5, 2 };
                     g.DrawRectangle(pen, barcodeRectangle.X - 2, barcodeRectangle.Y - 2, barcodeRectangle.Width + 4, barcodeRectangle.Height + 4);
                 }
             }
        }



        /// <summary>
        /// 测试鼠标的当前位置有没有在对像上
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public override int HitTest(Point point)
        {           
            //在对像上但不是在手柄上
            if (PointInObject(point))
            {
                return 0;
            }
            //不在对像上
            return -1;
        }

        /// <summary>
        /// 检查点是否在矩形上
        /// </summary>
        /// <param name="point">要检查的点</param>
        /// <returns></returns>
        protected override bool PointInObject(Point point)
        {
            return barcodeRectangle.Contains(point);
        }

        /// <summary>
        /// 选择的矩形是否包含对像区域
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public override bool IntersectsWith(Rectangle selectRect)
        {
            return selectRect.Contains(barcodeRectangle);
        }

        /// <summary>
        /// 移动对像到坐标点上
        /// </summary>
        /// <param name="deltaX"></param>
        /// <param name="deltaY"></param>
        public override void Move(int deltaX, int deltaY)
        {
            barcodeRectangle.X += deltaX;
            barcodeRectangle.Y += deltaY;
        }


    }
}
