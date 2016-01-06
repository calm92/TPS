using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    public class DrawImage:DrawRectangle,ISerializable
    {
        public DrawImage()
        {
        }

        public DrawImage(int x, int y, int w, int h)
            : base(x, y, w, h)
        { }

        private Image image;

        /// <summary>
        /// 所要显示的图片
        /// </summary>
        public Image ImageObject
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }


        public override string Name
        {
            get { return "图片"; }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("image.gif");
            }
        }

        /// <summary>
        /// 将图片画到佛定位置
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            if (Selected)
            {
                //如果是选中状态画出虚线框
                using (Pen pen = new Pen(Color.SkyBlue))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    pen.DashPattern = new float[] { 3.0f, 3.0f };

                    g.DrawRectangle(pen, this.Rectangle);
                    g.DrawLine(pen, 0, Rectangle.Y, Rectangle.X, Rectangle.Y);
                    g.DrawLine(pen, Rectangle.X, 0, Rectangle.X, Rectangle.Y);
                    Point xyNotice;
                    int fontHeight = new Font("Verdana", 7).Height;
                    if (Rectangle.Y < fontHeight)
                    {
                        xyNotice = new Point(Rectangle.X, Rectangle.Y + Rectangle.Height + 2);
                    }
                    else
                    {
                        xyNotice = new Point(Rectangle.X + 2, Rectangle.Y - fontHeight - 2);
                    }
                    g.DrawString(string.Format("[X:{0} Y:{1}][W:{2} H:{3}]", (int)CommonSettings.PixelConvertMillimeter(Rectangle.X), (int)CommonSettings.PixelConvertMillimeter(Rectangle.Y), (int)CommonSettings.PixelConvertMillimeter(Rectangle.Width), (int)CommonSettings.PixelConvertMillimeter(Rectangle.Height)), new Font("Verdana", 7), Brushes.Blue, xyNotice);
                    
                }
            }
            else
            {
                //如果没有选中,但是没有图片
                //则画出虚线框
                if (image == null)
                {
                    using (Pen pen = new Pen(Color.SkyBlue))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        pen.DashPattern = new float[] { 3.0f, 3.0f };

                        g.DrawRectangle(pen, this.Rectangle);
                    }
                }
            }
            if (image != null)
            {
                //有图片则画出图片
                g.DrawImage(image, this.Rectangle);
            }
            else
            {
                //没有图片在指定的区域画出提示信息
                GraphicsState state = g.Save();
                g.SetClip(this.Rectangle);//提示信息不能超出图片所在的区域
                g.DrawString("请选择图片!", new Font("Verdana", 9), Brushes.DarkRed, this.Rectangle.X + 8, this.Rectangle.Y + 8);
                g.Restore(state);//恢复做图区域
            }
        }

         new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Image", this.image);
            info.AddValue("ImageRectangle", this.Rectangle);

        }
        public DrawImage(SerializationInfo info, StreamingContext context)
            : this()
        {
            this.image = info.GetValue("Image", typeof(Image)) == null ? null : info.GetValue("Image", typeof(Image)) as Image ;
            this.Rectangle = (Rectangle)info.GetValue("ImageRectangle", typeof(Rectangle));
        }
    }
}
