using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpsControl
{
    
    public partial class UserVar : UserControl
    {
        static public List<UserVar> userVarList = new List<UserVar>();
        static public Panel userVarPanel;
        public UserVar()
        {
            InitializeComponent();
        }

        public bool isSelect() {
            if (textBox1.BackColor == SystemColors.Control)
                return false;
            else
                return true;
        }
        public void AdjustWidth()
        {
            int height = textBox1.Height + textBox2.Height + textBox3.Height;
            if (height < varName.Height + varType.Height + varValue.Height)
                height = varName.Height + varType.Height + varValue.Height;
            this.Height = height + 5;
            int parentWidth = this.Parent.Width;
            if(userVarPanel.VerticalScroll.Visible)
                parentWidth -= SystemInformation.VerticalScrollBarWidth;
            this.Width = parentWidth;
            int delta = textBox1.Width - this.Width / 2;
            if (delta <= 5 && delta >= -5)
                return;
            textBox1.Width = this.Width / 2;
            textBox2.Width = this.Width / 2;
            textBox3.Width = this.Width / 2;
            varName.Width = this.Width - textBox1.Width-2;
            varType.Width = this.Width - textBox2.Width-2;
            varValue.Width = this.Width - textBox3.Width-2;
            textBox1.Location = new Point(0, 0);
            textBox2.Location = new Point(0, textBox1.Height);
            textBox3.Location = new Point(0, textBox1.Height + textBox2.Height);
            varName.Location = new Point(this.Width / 2, textBox1.Location.Y);
            varType.Location = new Point(this.Width / 2, textBox2.Location.Y);
            varValue.Location = new Point(this.Width / 2, textBox3.Location.Y);
            //this.Anchor = AnchorStyles.Left & AnchorStyles.Right;
            
            return;
        }

        public void changeBackColor()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            if (textBox1.BackColor != SystemColors.Control)
            {
                textBox1.BackColor = SystemColors.Control;
                textBox2.BackColor = SystemColors.Control;
                textBox3.BackColor = SystemColors.Control;

            }
            else
            {
                textBox1.BackColor = Color.DarkGray;
                textBox2.BackColor = Color.DarkGray;
                textBox3.BackColor = Color.DarkGray;
            }

            //解决光标问题
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (this.isSelect())
            {
                this.changeBackColor();
                return;
            }
            int count = userVarList.Count();
            for (int i = 0; i < count; i++)
            {
                if (userVarList[i].isSelect())
                    userVarList[i].changeBackColor();
            }
            this.changeBackColor();
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
              textBox1_Click(sender,  e);

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox1_Click(sender, e);
        }

        private void 插入变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userVarPanel.VerticalScroll.Value = userVarPanel.VerticalScroll.Minimum; 
            UserVar insertUserVar = new UserVar();
            insertUserVar.Parent = userVarPanel;
            //确定控件位置
            int count = userVarList.Count;
            int height = insertUserVar.Height;
            int location_y = height * count + 2;
            int location_x = 0;
            insertUserVar.Location = new Point(location_x, location_y);
            userVarList.Add(insertUserVar);
            insertUserVar.AdjustWidth();

        }

        private void 删除变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = userVarList.Count();
            int i;
            for (i = 0; i < count; i++) {
                if (!userVarList[i].isSelect())
                    continue;
                else
                {
                    i++;
                    break;
                }
            }

            //改变剩下的userVar的Y坐标
            UserVar deleteUserVar = userVarList[i-1];
            int height = userVarList[0].Size.Height;
            for (; i < count; i++)
            {   
                int y = userVarList[i].Location.Y - height + 2;
                userVarList[i].Location = new Point(0, y);
            }
            userVarList.Remove(deleteUserVar);
            deleteUserVar.Dispose();
        }

    }
}
