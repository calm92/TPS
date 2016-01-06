using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
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
    public class DrawItemList:List<DrawItemBase>
    {
        public DrawItemList()
        { 
        }


        //将对像插入列表
        public new void Add(DrawItemBase itemBase)
        {
            base.Insert(0, itemBase);
        }

        public void Draw(Graphics g)
        {
            for (int i = this.Count-1; i >-1; i--)
            {
                //判定是否绑定了数据源
                if (!string.IsNullOrEmpty(this[i].ValueColumn) && CheckDataTabelIsNoteNullOrEmpty(dataTable))
                {
                    //设定数据源打印时的属性
                    this[i].DataSource = dataTable;
                    this[i].CurrentPage = currentPage;
                    this[i].RowHeight = rowsHeight;
                    this[i].PageRowsCount = pageRowsCount;
                    this[i].Selected = false;
                }

                this[i].Draw(g);
                //如果对像是选中状态,则画出手柄
                if (this[i].Selected)
                {
                    this[i].DrawTracker(g);
                }
            }
        }

        //数据源
        private DataTable dataTable;
        //当前是哪一页
        private int currentPage = 1;
        //每页有多少行
        private int pageRowsCount = 3;
        //每行行高
        private int rowsHeight = 15;

        /// <summary>
        /// 在数据源打印时的行高.默认15
        /// </summary>
        public int RowsHeight
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
        /// 设定每页中有多少条记录
        /// </summary>
        public int PageRowsCount
        {
            get
            {
                return pageRowsCount;
            }
            set
            {
                pageRowsCount = value;
            }
        }

        /// <summary>
        /// 当前要显示的是哪一页
        /// </summary>
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

        public DataTable DataSource
        {
            get
            {
                return dataTable;
            }
            set
            {
                dataTable = value;
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
                IsNotNull = false;
            }
            else if (DataSource.Rows.Count == 0)
            {
                IsNotNull = false;
            }
            return IsNotNull;
        }


        /// <summary>
        /// 获取对像列中选定的对像
        /// </summary>
        /// <param name="index">选中的是第几个</param>
        /// <returns></returns>
        public DrawItemBase GetSelectItem(int index)
        {
            int i = -1;
            foreach (DrawItemBase o in this)
            {
                if (o.Selected)
                {
                   i++;
                    if (i == index)
                        return o;
                }
            }

            return null;
        }

        /// <summary>
        /// 选择所有对像
        /// </summary>
        public void SelectAll()
        {
            foreach (DrawItemBase item in this)
            {
                item.Selected = true;
            }
        }

        /// <summary>
        /// 将所选中第一个对像放到最后
        /// </summary>
        /// <param name="selectindex"></param>
        public void SendBlow()
        {
            if (this.Count > 1)
            {
                DrawItemBase dib = GetSelectItem(0);
                this.Remove(dib);
                this.Insert(this.Count, dib);
            } 
        }
        /// <summary>
        /// 将选中的第一个对像放到最前面
        /// </summary>
        /// <param name="selectindex"></param>
        public void SendFront()
        {
            if (this.Count > 1)
            {
                DrawItemBase dib = GetSelectItem(0);
                this.Remove(dib);
                this.Insert(0, dib);
            }
 
        }

        /// <summary>
        /// 取消选择所有对像
        /// </summary>
        public void UnSelectAll()
        {
            foreach (DrawItemBase item in this)
            {
                item.Selected = false;
            }
        }

        /// <summary>
        /// 选择矩形中的对像
        /// </summary>
        /// <param name="rect"></param>
        public void SelectInRectangle(Rectangle rect)
        {
            foreach (DrawItemBase item in this)
            {
                if (item.IntersectsWith(rect))
                {
                    item.Selected = true ;
                }
            }
        }
        /// <summary>
        /// 获取有多少个选中的对像
        /// </summary>
        public int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (DrawItemBase o in this)
                {
                    if (o.Selected)
                        n++;
                }

                return n;
            }
        }

        /// <summary>
        /// 获取选中对像列表中第一个对像在列表中的索引号
        /// </summary>
        public int GetSelectedIndex
        {
            get
            {
                int n = -1;
                foreach (DrawItemBase o in this)
                {
                    n++;
                    if (o.Selected)
                    {
                        break;
                    }
                }

                return n;
            }
        }
       
    }
}
