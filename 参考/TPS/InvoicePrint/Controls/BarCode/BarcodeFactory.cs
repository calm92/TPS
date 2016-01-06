using System;
using System.Collections.Generic;
using System.Text;
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
    public class BarcodeFactory
    {
        public BarcodeFactory()
        { }

        public IBarcode CreateBarcode(string Name)
        {
            IBarcode MyBarcode = null;
            try
            {
                Type BarcodeType = Type.GetType(Name, true);
                MyBarcode = (IBarcode)Activator.CreateInstance(BarcodeType);
            }
            catch (TypeLoadException)
            {
                System.Windows.Forms.MessageBox.Show("条码加载失败!" + Name, "WormSoft Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return MyBarcode;

        }

        public IBarcode CreateBarcode(string Name,params object[] args)
        {
            IBarcode MyBarcode = null;
            try
            {
                Type btype = Type.GetType(Name, true);
                MyBarcode = (IBarcode)Activator.CreateInstance(btype,args);
            }
            catch (TypeLoadException)
            {
                System.Windows.Forms.MessageBox.Show("条码加载失败!" + Name, "WormSoft Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return MyBarcode;

        }
    }
}
