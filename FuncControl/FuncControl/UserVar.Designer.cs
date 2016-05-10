namespace TpsControl
{
    partial class UserVar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.varValue = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.varType = new System.Windows.Forms.ComboBox();
            this.varName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.插入变量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除变量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // varValue
            // 
            this.varValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varValue.Location = new System.Drawing.Point(180, 55);
            this.varValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.varValue.Name = "varValue";
            this.varValue.Size = new System.Drawing.Size(179, 26);
            this.varValue.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(0, 55);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(181, 26);
            this.textBox3.TabIndex = 0;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "变量大小:";
            this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(0, 29);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(181, 26);
            this.textBox2.TabIndex = 0;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "变量类型:";
            this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(0, 4);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(181, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "变量名称:";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // varType
            // 
            this.varType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.varType.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.varType.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varType.FormattingEnabled = true;
            this.varType.Items.AddRange(new object[] {
            "int",
            "double",
            "string"});
            this.varType.Location = new System.Drawing.Point(180, 31);
            this.varType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.varType.Name = "varType";
            this.varType.Size = new System.Drawing.Size(179, 24);
            this.varType.TabIndex = 15;
            // 
            // varName
            // 
            this.varName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varName.Location = new System.Drawing.Point(180, 4);
            this.varName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.varName.Name = "varName";
            this.varName.Size = new System.Drawing.Size(179, 26);
            this.varName.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入变量ToolStripMenuItem,
            this.删除变量ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 插入变量ToolStripMenuItem
            // 
            this.插入变量ToolStripMenuItem.Name = "插入变量ToolStripMenuItem";
            this.插入变量ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.插入变量ToolStripMenuItem.Text = "插入变量";
            this.插入变量ToolStripMenuItem.Click += new System.EventHandler(this.插入变量ToolStripMenuItem_Click);
            // 
            // 删除变量ToolStripMenuItem
            // 
            this.删除变量ToolStripMenuItem.Name = "删除变量ToolStripMenuItem";
            this.删除变量ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除变量ToolStripMenuItem.Text = "删除变量";
            this.删除变量ToolStripMenuItem.Click += new System.EventHandler(this.删除变量ToolStripMenuItem_Click);
            // 
            // UserVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.varName);
            this.Controls.Add(this.varType);
            this.Controls.Add(this.varValue);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserVar";
            this.Size = new System.Drawing.Size(360, 82);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox varValue;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ComboBox varType;
        public System.Windows.Forms.TextBox varName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 插入变量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除变量ToolStripMenuItem;
    }
}
