namespace TpsControl
{
    partial class FuncVarControl
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
            this.labelIO = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.varName = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.varType = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.varValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelIO
            // 
            this.labelIO.AutoSize = true;
            this.labelIO.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelIO.Location = new System.Drawing.Point(3, 0);
            this.labelIO.Name = "labelIO";
            this.labelIO.Size = new System.Drawing.Size(111, 15);
            this.labelIO.TabIndex = 1;
            this.labelIO.Text = "InputVariable";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(0, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(136, 25);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "变量名称:";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // varName
            // 
            this.varName.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.varName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varName.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varName.Location = new System.Drawing.Point(136, 15);
            this.varName.Name = "varName";
            this.varName.ReadOnly = true;
            this.varName.Size = new System.Drawing.Size(137, 25);
            this.varName.TabIndex = 0;
            this.varName.TextChanged += new System.EventHandler(this.varName_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(0, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(136, 25);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "变量类型:";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // varType
            // 
            this.varType.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.varType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varType.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varType.Location = new System.Drawing.Point(135, 34);
            this.varType.Name = "varType";
            this.varType.ReadOnly = true;
            this.varType.Size = new System.Drawing.Size(138, 25);
            this.varType.TabIndex = 0;
            this.varType.TextChanged += new System.EventHandler(this.varType_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(0, 54);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(136, 25);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "变量大小:";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // varValue
            // 
            this.varValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varValue.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.varValue.Location = new System.Drawing.Point(135, 54);
            this.varValue.Name = "varValue";
            this.varValue.Size = new System.Drawing.Size(138, 25);
            this.varValue.TabIndex = 7;
            // 
            // FuncVarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.varValue);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.varType);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.varName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelIO);
            this.Name = "FuncVarControl";
            this.Size = new System.Drawing.Size(272, 92);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIO;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox varName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox varType;
        private System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox varValue;
    }
}
