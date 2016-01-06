﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.ComponentModel;
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
    public class DrawText : DrawRectangle, ISerializable
    {
        public DrawText():base()
        {
        }

        public override string Name
        {
            get { return "文本"; }
        }

        public override Image IconImage
        {
            get
            {
                return GetIconImage("text.png");
            }
        }

        public DrawText(int x, int y, int w, int h)
            : base(x, y, w, h)
        { }

        /// <summary>
        /// 文本的字体
        /// </summary>
        private Font textFont = new Font("Verdana", 9);
        /// <summary>
        /// 文本内容
        /// </summary>
        private string textValue = "";

        /// <summary>
        /// 呈现方式 
        /// </summary>
        private DrawType drawtype = DrawType.Label;

        /// <summary>
        /// 呈现方式 
        /// </summary>
        [Description("数据的呈现方式,数据源不为空的情况下有效")]
        public DrawType DrawTextType
        {
            get
            {
                return drawtype;
            }
            set
            {
                drawtype = value;
            }
        }

        /// <summary>
        /// 在文本编辑中不会用到些属性仅隐藏
        /// </summary>
        [Browsable(false)]
        public new int LineWidth
        {
            get
            {
                return 0;
            }
            set
            {
                int x = value;
            }
        }

        /// <summary>
        /// 获取或设置文本字体
        /// </summary>
        [Description("文本编辑器的字体")]
        public Font TextFont
        {
            get
            {
                return textFont;
            }
            set
            {
                textFont = value;
            }
        }

        /// <summary>
        /// 获取或设置文本内容
        /// </summary>
        [Description("文本编辑器的内容")]
        public string TextValue 
        {
            get
            {
                return textValue;
            }
            set
            {
                textValue = value;
            }
        }

        /// <summary>
        /// 获取或设计文本编辑器的小大
        /// </summary>
        [Description("文本编辑器的区域")]
        public Rectangle TextRectangle
        {
            get
            {
                return GetNormalizedRectangle(this.Rectangle);
            }
            set
            {
                this.Rectangle = GetNormalizedRectangle(value);
            }
        }

        public override void Draw(Graphics g)
        {
            //如果对像是选择状态则画出一个虚线框
            if (Selected)
            {
                using(Pen pen = new Pen(Color.SkyBlue,1f))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    pen.DashPattern = new float[]{3.0f,3.0f};
                    g.DrawRectangle(pen, TextRectangle);
                    g.DrawLine(pen, 0, TextRectangle.Y, TextRectangle.X , TextRectangle.Y );
                    g.DrawLine(pen, TextRectangle.X , 0, TextRectangle.X , TextRectangle.Y);
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

            //在特定区域画出文本内容
            using(SolidBrush sb = new SolidBrush(LineColor))
            {
                //判断是否从数据源中取值
                //如果数据源为空或是取值的栏位不为空则数据源中取值
                if (GetDataSourceIsNotNullOrEmpty && !string.IsNullOrEmpty(ValueColumn))
                {
                    //根据当前的页数,找出在数据源中的第一条记录
                    int i = (CurrentPage - 1) * PageRowsCount;
                    int temp = 0;

                    //根据数据呈现方式画出数据
                    if (drawtype == DrawType.Label)
                    {
                        string vale = "列名不存在!";
                        if (DataSource.Columns.Contains(ValueColumn))
                        {
                            vale = DataSource.Rows[i][ValueColumn].ToString();
                        }
                        g.DrawString(vale, textFont, Brushes.DarkRed, new Rectangle(TextRectangle.X + 7, TextRectangle.Y + 7 + temp * RowHeight, TextRectangle.Width, RowHeight));
                    }
                    else
                    { 
                        //依次画出数据源中的相应数据
                        //TO DO
                        for (; i < DataSource.Rows.Count; i++)
                        {
                            string vale = "列名不存在!";
                            if (DataSource.Columns.Contains(ValueColumn))
                            {
                                vale = DataSource.Rows[i][ValueColumn].ToString();
                            }
                            g.DrawString(vale, textFont, Brushes.DarkRed, new Rectangle(TextRectangle.X + 7, TextRectangle.Y + 7 + temp * RowHeight, TextRectangle.Width, RowHeight));
                            temp++;
                            //画出预先设置的数后退出
                            if (temp == PageRowsCount)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // 缩小字符串所在区域,防止与调节手柄重叠在一起
                    g.DrawString(textValue, textFont, sb, new Rectangle(TextRectangle.X + 7, TextRectangle.Y + 7, TextRectangle.Width - 14, TextRectangle.Height - 14));

                    if (string.IsNullOrEmpty(TextValue))
                    {
                        string stemp;
                        if (string.IsNullOrEmpty(ValueColumn))
                        {
                            stemp = "请输入文本内容!";
                        }
                        else
                        {
                            stemp = "列：" + ValueColumn;
                        }

                        g.DrawString(stemp, textFont, Brushes.DarkRed, new Rectangle(TextRectangle.X + 7, TextRectangle.Y + 7, TextRectangle.Width - 14, TextRectangle.Height - 14));

                        using (Pen pen = new Pen(Color.SkyBlue, 1f))
                        {
                            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                            pen.DashPattern = new float[] { 3.0f, 3.0f };
                            g.DrawRectangle(pen, TextRectangle);
                        }
                    }
                }
                
            }
        }

        new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("TextFont", this.TextFont);
            info.AddValue("TextValue", this.TextValue);
            info.AddValue("TextRectangle", TextRectangle);
            info.AddValue("TextColor", LineColor);
            info.AddValue("TextValueColumn", ValueColumn);
            info.AddValue("DrawTextType", DrawTextType);
        }

        public DrawText(SerializationInfo info, StreamingContext context):this()
        {
            TextFont = (Font)info.GetValue("TextFont", typeof(Font));
            TextValue = info.GetString("TextValue");
            TextRectangle = (Rectangle)info.GetValue("TextRectangle", typeof(Rectangle));
            LineColor = (Color)info.GetValue("TextColor", typeof(Color));
            ValueColumn = info.GetString("TextValueColumn");
            DrawTextType = (DrawType)info.GetValue("DrawTextType", typeof(DrawType));
        }

    }
}
