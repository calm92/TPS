using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using  CustomControls.DrawItem;
using System.Windows.Forms;
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
namespace CustomControls.ToolBox
{
    [ToolAttribute("选择", "Resources.cursor.png", Order =0)]
    public class ToolSelector:ToolBase
    {
        private enum SelectionMode
        {
            None,
            NetSelection,//选择一个区域
            Move,//移动对像
            Size//改变对像尺寸
        }



        private SelectionMode selectmode = SelectionMode.None;
        /// <summary>
        ///  改变大小的对像
        /// </summary>
        private DrawItemBase resizeObject;
        /// <summary>
        /// 使用的是哪个手柄
        /// </summary>
        private int resizeHandle;
        /// <summary>
        /// 移动开始坐标和最后坐标
        /// </summary>
        private Point lastPoint = new Point(0, 0), startPoint = new Point(0, 0);

        public ToolSelector()
        {
        }


        public override void OnMouseDown(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            selectmode = SelectionMode.None;
            Point point = new Point(e.X, e.Y);
            int selectCount = designer.Items.SelectionCount;
            //如果光标在后柄上,则模式为改变对像的大小
            for (int i = 0; i < selectCount; i++)
            {
                //找到要修改的对像
                DrawItemBase item = designer.Items.GetSelectItem(i);
                if (item == null)
                    continue;
                int handleNumber = item.HitTest(point);
                if (handleNumber > 0)
                {
                    selectmode = SelectionMode.Size;

                    resizeHandle = handleNumber;
                    resizeObject = item;

                    designer.Items.UnSelectAll();
                   
                    resizeObject.Selected = true;
                    break;
                }
            }

            //如果没有选中对像手柄,则检查是否在对像上
            if (selectmode == SelectionMode.None)
            {
                int itemCount = designer.Items.Count;
                DrawItemBase item = null;
                for (int i = 0; i < itemCount; i++)
                {
                    if (designer.Items[i].HitTest(point) == 0)
                    {
                        item = designer.Items[i];
                        selectmode = SelectionMode.Move;
                        designer.Items.UnSelectAll();
                        item.Selected = true;
                        designer.SelectedItem(item);
                        designer.Cursor = Cursors.SizeAll;
                        break;
                    }
                }
            }

            // 如果没有选中对像,则是进行区域选择
            if (selectmode == SelectionMode.None)
            {

                selectmode = SelectionMode.NetSelection;
                designer.Items.UnSelectAll();
                designer.IsDrawSelectRectangle = true;
            }

            lastPoint.X = startPoint.X = e.X;
            lastPoint.Y = startPoint.Y = e.Y;

            designer.Capture = true;

            designer.SelectRectangle = GetNormalizedRectangle(startPoint.X, startPoint.Y, lastPoint.X, lastPoint.Y);
            designer.Refresh();

        }

        /// <summary>
        /// Test Method
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                int tmp = x2;
                x2 = x1;
                x1 = tmp;
            }

            if (y2 < y1)
            {
                int tmp = y2;
                y2 = y1;
                y1 = tmp;
            }

            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        public override void OnMouseMove(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);
            //如果是移动鼠标,改变鼠标的指针
            if (e.Button == MouseButtons.None)
            {
                Cursor cursor = Cursors.Default;
                for (int i = 0; i < designer.Items.Count; i++)
                {
                    int n = designer.Items[i].HitTest(point);
                    if (n > 0)
                    {
                        cursor = designer.Items[i].GetHandleCursor(n);
                        break;
                    }
                }

                designer.Cursor = cursor;

            }

            if (e.Button == MouseButtons.Left)
            {
                int dx = e.X - lastPoint.X;
                int dy = e.Y - lastPoint.Y;
                lastPoint.X = e.X;
                lastPoint.Y = e.Y;
                //改变对像的尺寸
                if (selectmode == SelectionMode.Size)
                {
                    resizeObject.MoveHandleTo(point, resizeHandle);
                    designer.ChangeFlage = true;
                    designer.Refresh();
                    designer.SelectedItem(resizeObject);
                }
                //移动选中的对像
                if (selectmode == SelectionMode.Move)
                {
                    int n = designer.Items.SelectionCount;
                    for (int i = 0; i < n; i++)
                    {
                        designer.Items.GetSelectItem(i).Move(dx, dy);
                    }

                    designer.Cursor = Cursors.SizeAll;
                    designer.ChangeFlage = true;
                    designer.Refresh();
                }
                // 区域选择
                if (selectmode == SelectionMode.NetSelection)
                {
                    designer.SelectRectangle = GetNormalizedRectangle(startPoint.X, startPoint.Y, lastPoint.X, lastPoint.Y);
                    designer.Refresh();
                }
            }
        }

        public override void OnMouseUp(Designer designer, System.Windows.Forms.MouseEventArgs e)
        {
            //如果是区域选择,选中在此区域的对像
            if (selectmode == SelectionMode.NetSelection)
            {
                designer.Items.SelectInRectangle(designer.SelectRectangle);
                selectmode = SelectionMode.None;
                designer.IsDrawSelectRectangle = false;
            }
            //如果是改变大小则结束改变
            if (resizeObject != null)
            {
                resizeObject.Normalize();

                //如果改变对像的尺寸大小
                if (designer.SelectDrawText != null && (resizeObject.GetType().Name == designer.SelectDrawText.GetType().Name))
                {
                    Rectangle rectangle = DrawRectangle.GetNormalizedRectangle((resizeObject as DrawText).Rectangle);
                    designer.textBox.Location = new Point(rectangle.X + 8, rectangle.Y + 7);
                    designer.textBox.Size = new Size(rectangle.Width - 10, rectangle.Height - 10);
                   // designer.textBox.Focus();
                    //设置当前选中的文本编辑器
                    //在多个编辑切换时，可以知道当前编辑的是哪一个
                }

                resizeObject = null;
            }
            designer.Capture = false;
            designer.Refresh();
        }

        public override void OnDoubleClick(Designer designer, MouseEventArgs e)
        {
            base.OnDoubleClick(designer, e);
        }
        

    }
}
