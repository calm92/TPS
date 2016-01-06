namespace WindowsFormsApplication1
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.funcVarControl1 = new VarControl.FuncVarControl();
            this.funcVarControl2 = new VarControl.FuncVarControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.funcVarControl5 = new VarControl.FuncVarControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.funcVarControl6 = new VarControl.FuncVarControl();
            this.funcVarControl4 = new VarControl.FuncVarControl();
            this.funcVarControl3 = new VarControl.FuncVarControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.funcVarControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.funcVarControl2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 337);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // funcVarControl1
            // 
            this.funcVarControl1.Location = new System.Drawing.Point(3, 171);
            this.funcVarControl1.Name = "funcVarControl1";
            this.funcVarControl1.Size = new System.Drawing.Size(263, 133);
            this.funcVarControl1.TabIndex = 1;
            // 
            // funcVarControl2
            // 
            this.funcVarControl2.Location = new System.Drawing.Point(303, 171);
            this.funcVarControl2.Name = "funcVarControl2";
            this.funcVarControl2.Size = new System.Drawing.Size(263, 60);
            this.funcVarControl2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.funcVarControl5);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 150);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // funcVarControl5
            // 
            this.funcVarControl5.Location = new System.Drawing.Point(-3, 11);
            this.funcVarControl5.Name = "funcVarControl5";
            this.funcVarControl5.Size = new System.Drawing.Size(263, 133);
            this.funcVarControl5.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.funcVarControl6);
            this.panel1.Controls.Add(this.funcVarControl4);
            this.panel1.Controls.Add(this.funcVarControl3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(303, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 162);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // funcVarControl6
            // 
            this.funcVarControl6.Location = new System.Drawing.Point(-1, 73);
            this.funcVarControl6.Name = "funcVarControl6";
            this.funcVarControl6.Size = new System.Drawing.Size(263, 133);
            this.funcVarControl6.TabIndex = 2;
            // 
            // funcVarControl4
            // 
            this.funcVarControl4.Location = new System.Drawing.Point(3, 73);
            this.funcVarControl4.Name = "funcVarControl4";
            this.funcVarControl4.Size = new System.Drawing.Size(263, 142);
            this.funcVarControl4.TabIndex = 1;
            // 
            // funcVarControl3
            // 
            this.funcVarControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcVarControl3.Location = new System.Drawing.Point(-1, 3);
            this.funcVarControl3.Name = "funcVarControl3";
            this.funcVarControl3.Size = new System.Drawing.Size(246, 76);
            this.funcVarControl3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 337);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private VarControl.FuncVarControl funcVarControl1;
        private VarControl.FuncVarControl funcVarControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private VarControl.FuncVarControl funcVarControl4;
        private VarControl.FuncVarControl funcVarControl3;
        private VarControl.FuncVarControl funcVarControl5;
        private VarControl.FuncVarControl funcVarControl6;

    }
}

