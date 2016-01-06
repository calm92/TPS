using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using  CustomControls.ToolBox;
using System.Reflection;
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
namespace CustomControls.Control
{
    public class DrawToolBox:ToolStrip
    {
        /// <summary>
        /// 在使用时一要先绑定事件
        /// 在执行AddButton.
        /// 因为在AddButton时,程序会先查看SelectTool是否有值
        /// 如为null则先创建ToolSelector为默认的工具
        /// </summary>
        public DrawToolBox()
        {
            //AddButton();
        }

        private ToolBase selectTool;
        public event EventHandler ToolChanged;

        
        /// <summary>
        /// 当前选中的工具
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ToolBase SelectTool
        {
            get
            {
                return selectTool;
            }
            set
            {
                if (value != null)
                {
                    selectTool = value;
                    foreach (ToolStripButton tsb in this.Items)
                    {
                        tsb.CheckState = CheckState.Unchecked;
                        if (((Type)tsb.Tag).Name == value.GetType().Name)
                        {
                            tsb.CheckState = CheckState.Indeterminate;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将工具添加到toolbox中
        /// </summary>
        public void AddButton()
        {
            this.Items.Clear();
            //获得ToolBase组件
            Assembly assembly = Assembly.GetAssembly(typeof(ToolBase));
            Type[] types = assembly.GetTypes();
            //按钮排序,根据ToolAttribute中order进行排序
            SortedList<int ,ToolStripButton> toolbtns = new SortedList<int,ToolStripButton>();
            //遍历组件,找出toolbox类
            //并添加天toolbox中
            foreach(Type t in types)
            {
                object[] attributes = t.GetCustomAttributes(typeof(ToolAttribute), true);
                if (attributes.Length > 0)
                {
                    ToolAttribute toolAttribute = attributes[0] as ToolAttribute;
                    ToolStripButton tsb = new ToolStripButton();
                    tsb.ToolTipText = toolAttribute.Description;//悬浮提示
                    if (toolAttribute.TooBoxImage != null)
                    {
                        tsb.Image = toolAttribute.TooBoxImage;//图标
                    }
                    tsb.CheckOnClick = true;
                    tsb.Tag = t;
                    tsb.Click +=new EventHandler(tsb_Click);
                    toolbtns.Add(toolAttribute.Order,tsb); 
                }
            }

            //添加toolbutton到toolbox容器中
            foreach(ToolStripButton tbtn in toolbtns.Values)
            {
                this.Items.Add(tbtn);
            }

            if (SelectTool == null && this.Items != null && this.Items.Count>0)
            {
                selectTool = (ToolBase)Activator.CreateInstance((Type)((ToolStripButton)this.Items[0]).Tag);
                ((ToolStripButton)this.Items[0]).CheckState = CheckState.Indeterminate;
                if (ToolChanged != null)
                {
                    ToolChanged(this, null);
                }
            }
        }

        void tsb_Click(object sender, EventArgs e)
        {
            foreach (ToolStripButton tsb in this.Items)
            {
                //检查用户点的是不是本身,如果是则不进行任何操作
                if (tsb != sender)
                {
                    tsb.Checked = false;
                    selectTool = (ToolBase)Activator.CreateInstance((Type)((ToolStripButton)sender).Tag);
                    if (ToolChanged != null)
                    {
                        ToolChanged(this, e);
                    }
                }
                else
                {
                    tsb.CheckState = CheckState.Indeterminate;
                }

            }
        }
    }
}
