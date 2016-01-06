using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Drawing.Printing;
using  CustomControls.IO;
using  CustomControls.DrawItem;
using  CustomControls.ToolBox;

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
    public partial class DocumentSpace : UserControl
    {
        public DocumentSpace()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);  
            InitializeComponent(); 
            
            //绑定工具切换事件
            drawToolBox1.ToolChanged += new EventHandler(drawToolBox1_ToolChanged);
            //通过属性显示框,显示出所选对像的属性
            designer1.OnShowProperityInfo +=new ShowProperityInfo(designer1_OnShowProperityInfo);
            //工具变换事件
            designer1.OnActiveToolChange +=new ActiveToolChange(designer1_OnActiveToolChange);
            //添加或删除item事件
            designer1.OnItemChange += new ItemChange(designer1_OnItemChange);
          //添加工具栏按钮
            drawToolBox1.AddButton();

            numHeight.Value = (int)CommonSettings.PixelConvertMillimeter(designer1.Height);
            numWidth.Value = (int)CommonSettings.PixelConvertMillimeter(designer1.Width);

        }

        /// <summary>
        /// 获取design的宽和高
        /// </summary>
        private float design_width, design_height;
        /// <summary>
        /// 标尺数字的字体
        /// </summary>
        private Font scaleLabel = new Font("Verdana", 7);
        //private Point mouseLocationXs, mouseLocationXe, mouseLocationYs, mouseLocationYe;

        /// <summary>
        /// 通过此能数检测是打开还是新建的设计
        /// 在保存的时候是否可以直接保存
        /// </summary>
        private string openFileName = "";

        /// <summary>
        /// 画标尺刻度
        /// </summary>
        /// <param name="g"></param>
        private void DrawScale(Graphics g)
        {
            design_width = designer1.Width;
            design_height = designer1.Height;

            int width_mm = (int)CommonSettings.PixelConvertMillimeter(design_width);
            int heigth_mm = (int)CommonSettings.PixelConvertMillimeter(design_height);
            float percent = design_width / width_mm;
            PointF ps, pe;
            int scale;
            for (int i = 0; i < width_mm; i++)
            {
                if (i % 10 == 0)
                {
                    string x = (i / 10).ToString();
                    SizeF fontSize = g.MeasureString(x, scaleLabel);
                    scale = 15;
                    PointF pf = new PointF(designer1.Location.X + i * percent - fontSize.Width / 2, designer1.Location.Y - scale - fontSize.Height);
                    g.DrawString(x, scaleLabel, Brushes.Blue, pf);
                    pf = new PointF(designer1.Location.X + i * percent - fontSize.Width / 2, designer1.Location.Y + scale + designer1.Height);
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

                ps = new PointF(designer1.Location.X + i * percent, designer1.Location.Y);
                pe = new PointF(designer1.Location.X + i * percent, designer1.Location.Y - scale);
                g.DrawLine(Pens.Blue, ps, pe);
                ps = new PointF(designer1.Location.X + i * percent, designer1.Location.Y + designer1.Height);
                pe = new PointF(designer1.Location.X + i * percent, designer1.Location.Y + designer1.Height + scale);
                g.DrawLine(Pens.Blue, ps, pe);
            }

            for (int j = 0; j < heigth_mm; j++)
            {
                if (j % 10 == 0)
                {
                    string x = (j / 10).ToString();
                    scale = 15;
                    SizeF fontSize = g.MeasureString(x, scaleLabel);
                    g.DrawString(x, scaleLabel, Brushes.Blue, designer1.Location.X - fontSize.Width - scale, designer1.Location.Y + j * percent - fontSize.Height / 2);
                    g.DrawString(x, scaleLabel, Brushes.Blue, designer1.Location.X + designer1.Width + scale, designer1.Location.Y + j * percent - fontSize.Height / 2);
                }
                else if (j % 5 == 0)
                {
                    scale = 10;
                }
                else
                {
                    scale = 5;
                }

                ps = new PointF(designer1.Location.X, designer1.Location.Y + j * percent);
                pe = new PointF(designer1.Location.X - scale, designer1.Location.Y + j * percent);
                g.DrawLine(Pens.Blue, ps, pe);
                ps = new PointF(designer1.Location.X, designer1.Location.Y + j * percent);
                pe = new PointF(designer1.Location.X + designer1.Width + scale, designer1.Location.Y + j * percent);
                g.DrawLine(Pens.Blue, ps, pe);

            }
            //if (mouseLocationXs != null)
            //{
            //    g.DrawLine(Pens.Blue, mouseLocationXs, mouseLocationXe);
            //}
        }

        /// <summary>
        /// 当工具更换后,通知ToolBox更换工具
        /// </summary>
        /// <param name="tool"></param>
        protected void designer1_OnActiveToolChange(ToolBase tool)
        {
            drawToolBox1.SelectTool = tool;
        }

        /// <summary>
        /// 设计器是对像删除事件
        /// </summary>
        protected void designer1_OnItemChange()
        {
            itemList1.DrawItems = designer1.Items;

            designer1_OnShowProperityInfo(designer1.Items.GetSelectItem(0));
        }

        /// <summary>
        /// 将对像的属性显示出来
        /// </summary>
        /// <param name="sender"></param>
        protected void designer1_OnShowProperityInfo(DrawItemBase sender)
        {
            propertyGrid1.SelectedObject = sender;
        }

        /// <summary>
        /// 设置设计器当前的工具是?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawToolBox1_ToolChanged(object sender, EventArgs e)
        {
            designer1.ActiveTool = drawToolBox1.SelectTool;
        }

        /// <summary>
        /// 画出设计器的标尺
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{
        //    DrawScale(e.Graphics);
        //}

        /// <summary>
        /// 当在属性列表中更新数据后及时更新设计器内容,让更改的内容显示出来
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //如果所选的对像为DrawText修改值的时候要设置编辑输入框为不可见
            if (propertyGrid1.SelectedObject.GetType().Name == "DrawText")
            {
                designer1.textBox.Visible = false;
                designer1.textBox.Enabled = false;
            }
            designer1.Refresh();
        }

        #region 新建,打开,保存,删除,打印..........
        /// <summary>
        /// 新建设计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsNew_Click(object sender, EventArgs e)
        {
            //先检查设计器里对像有没有修改,有则提示保存
            if (designer1.ChangeFlage)
            {
                DialogResult dr = MessageBox.Show("是否保存设计?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    FileDialog fd = new SaveFileDialog();
                    fd.Filter = "CraxyMouse file (*.CraxyMouse)|*.CraxyMouse";
                    fd.InitialDirectory = Application.StartupPath;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        openFileName = fd.FileName;
                        InOutPut.SaveFile(designer1, fd.FileName);
                    }
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }

                //将状态设为没有修改过的
                designer1.ChangeFlage = false;
            }
            //清空对像
            designer1.Items.Clear();
            designer1.Refresh();

        }

        /// <summary>
        /// 打开设计器中的对像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsOpen_Click(object sender, EventArgs e)
        {
            if (designer1.ChangeFlage)
            {
                DialogResult dr = MessageBox.Show("是否保存更改?", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //如果有没有保存文件
                    //则先保存文件
                    if (string.IsNullOrEmpty(openFileName))
                    {
                        //检查当前的文件是否是保存过的
                        //如没有保存则重新保存
                        FileDialog fd = new SaveFileDialog();
                        fd.Filter = "CraxyMouse file (*.CraxyMouse)|*.CraxyMouse";
                        fd.InitialDirectory = Application.StartupPath;
                        if (fd.ShowDialog() == DialogResult.OK)
                        {
                            openFileName = fd.FileName;
                            designer1.ChangeFlage = false;
                            InOutPut.SaveFile(designer1, fd.FileName);
                            designer1.Items.Clear();
                            designer1.Refresh();
                        }
                    }
                    else
                    {
                        //保存过的直接保存
                        InOutPut.SaveFile(designer1, openFileName);
                    }
                }
                else if (dr == DialogResult.Cancel)
                {
                    //如果用户取消了则什么也不做
                    return;
                }
                designer1.ChangeFlage = false;



            } 
            FileDialog fod = new OpenFileDialog();
            fod.Filter = "CraxyMouse file (*.CraxyMouse)|*.CraxyMouse";
            fod.InitialDirectory = Application.StartupPath;
            if (fod.ShowDialog() == DialogResult.OK)
            {
                openFileName = fod.FileName;
                bool open = InOutPut.OpenFile(designer1, openFileName);
                //打开文件是否成功
                //如果打开成功是重新绘标尺
                if (open)
                {
                    panel1.Refresh();
                    designer1_OnItemChange();
                    numHeight.Value = (int)CommonSettings.PixelConvertMillimeter(designer1.Height);
                    numWidth.Value = (int)CommonSettings.PixelConvertMillimeter(designer1.Width);
                    if (designer1.RowHeight > 0)
                    {
                        numRowHeight.Value = (int)CommonSettings.PixelConvertMillimeter(designer1.RowHeight);
                    }
                    if (designer1.PageRows > 0)
                    {
                        numRows.Value = designer1.PageRows;
                    }
                }
            }
        }

        /// <summary>
        /// 保存设计器中的对像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(openFileName))
            {
                FileDialog fd = new SaveFileDialog();
                fd.Filter = "CraxyMouse file (*.CraxyMouse)|*.CraxyMouse";
                fd.InitialDirectory = Application.StartupPath;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    openFileName = fd.FileName;
                    designer1.RowHeight = (int)CommonSettings.MillimeterConvertPixel((float)numRowHeight.Value);
                    designer1.PageRows = (int)numRows.Value;
                    InOutPut.SaveFile(designer1, fd.FileName);
                    MessageBox.Show("保存文件成功!\n\r保存路径为:" + fd.FileName, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //designer1.Items.Clear();
                    designer1.Refresh();
                }
            }
            else
            {
                InOutPut.SaveFile(designer1, openFileName);
            }
            designer1.ChangeFlage = false;
        }

        /// <summary>
        /// 删除设计器中选中的对像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            designer1.DeleteSelectedItem();
        }

        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsTop_Click(object sender, EventArgs e)
        {
            designer1.Items.SendFront();
            designer1.Refresh();
            designer1_OnItemChange();
        }

        /// <summary>
        /// 置底
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBottom_Click(object sender, EventArgs e)
        {
            designer1.Items.SendBlow();
            designer1.Refresh();
            designer1_OnItemChange();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsExit_Click(object sender, EventArgs e)
        {
            if (designer1.ChangeFlage && (MessageBox.Show("退出程序要保存设计吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                tsSave_Click(sender, e);
            }
            if (MessageBox.Show("你确定要退出吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        /// <summary>
        /// 如果用户在对像列表中选择了对像,则更新到设计器中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            designer1.Items.UnSelectAll();
            designer1.Items[itemList1.SelectedIndex].Selected = true;
            propertyGrid1.SelectedObject = designer1.Items[itemList1.SelectedIndex];
            designer1.Refresh();
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsView_Click(object sender, EventArgs e)
        {
            designer1.PrintView();
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsInfo_Click(object sender, EventArgs e)
        {
            frmAbout fa = new frmAbout();
            fa.ShowDialog();
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Pay");
            dt.Columns.Add("Receive");
            dt.Columns.Add("TaxNum");
            dt.Columns.Add("Item");
            dt.Columns.Add("Amount");
            dt.Columns.Add("Desc");
            DataRow dr = dt.NewRow();
            dr[0] = "徐春晓";
            dr[1] = "徐春晓";
            dr[2] = "9658258";
            dr[3] = "电脑-001";
            dr[4] = "10000";
            dr[5] = "已发货";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓1";
            dr[1] = "徐春晓1";
            dr[2] = "96582581";
            dr[3] = "电脑-002";
            dr[4] = "10000";
            dr[5] = "已发货1";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓2";
            dr[1] = "徐春晓2";
            dr[2] = "9658258";
            dr[3] = "电脑-002";
            dr[4] = "100002";
            dr[5] = "已发货2";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓3";
            dr[1] = "徐春晓3";
            dr[2] = "96582583";
            dr[3] = "电脑-003";
            dr[4] = "100003";
            dr[5] = "已发货3";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "徐春晓4";
            dr[1] = "徐春晓4";
            dr[2] = "96582585";
            dr[3] = "电脑-0014";
            dr[4] = "100003";
            dr[5] = "已发货4";
            dt.Rows.Add(dr);
            designer1.DataSource = dt;
            designer1.PrintPage(1);
        }
        #endregion

        /// <summary>
        /// 改变设计的宽度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            //改变设计器的尺寸并重绘标尺
            designer1.Width = CommonSettings.MillimeterConvertPixel((float)numWidth.Value);
            panel1.Refresh();
        }

        private void numHeight_ValueChanged(object sender, EventArgs e)
        {
            //改变设计器的尺寸并重绘标尺
            designer1.Height = CommonSettings.MillimeterConvertPixel((float)numHeight.Value);
            panel1.Refresh();
        }

        /// <summary>
        /// 设计每页有多少行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numRows_ValueChanged(object sender, EventArgs e)
        {
            designer1.PageRows = (int)numRows.Value;
        }
        /// <summary>
        /// 设置行高
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numRowHeight_ValueChanged(object sender, EventArgs e)
        {
            designer1.RowHeight = CommonSettings.MillimeterConvertPixel((float)numRowHeight.Value);
        }

        /// <summary>
        /// 打印设置 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsSet_Click(object sender, EventArgs e)
        {
            frmSetting fs = new frmSetting(designer1.PrinterConfig);
            fs.ShowDialog();
        }

        /// <summary>
        /// 对像列表按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemList1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                designer1.DeleteSelectedItem();
                designer1.Refresh();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BarCode.frmNotice fn = new CustomControls.BarCode.frmNotice();
            fn.ShowDialog();
        }

        /// <summary>
        /// 滚动条拖动时更新机标尺
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel3_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)//水平尺
            {
                ruler1.StartValue = (int)CommonSettings.PixelConvertMillimeter(GetScrollValue(e.NewValue, e.OldValue));
            }
            else//垂直尺
            {
                ruler2.StartValue = (int)CommonSettings.PixelConvertMillimeter(GetScrollValue(e.NewValue, e.OldValue));
            }
        }

        /// <summary>
        /// 获取拖动的最小值做为标尺的起动值
        /// </summary>
        /// <param name="newvalue"></param>
        /// <param name="oldvalue"></param>
        /// <returns></returns>
        private int GetScrollValue(int newvalue,int oldvalue)
        {
            if (newvalue > oldvalue)
            {
                return oldvalue;
            }

            return newvalue;
        }

        /// <summary>
        /// 显示标尺
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsGrid_Click(object sender, EventArgs e)
        {
            designer1.ShowGrid = !designer1.ShowGrid;

            if (designer1.ShowGrid)
            {
                tsGrid.CheckState = CheckState.Indeterminate;
            }
            else
            {
                tsGrid.CheckState = CheckState.Unchecked;
            }
        }
    }
}