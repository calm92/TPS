namespace TpsControl
{
    partial class BaseMeterControl
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
            this.squre = new System.Windows.Forms.Label();
            this.deleteMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除组件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // squre
            // 
            this.squre.BackColor = System.Drawing.SystemColors.Control;
            this.squre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.squre.ContextMenuStrip = this.deleteMenuStrip;
            this.squre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.squre.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.squre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.squre.Image = global::TpsControl.Properties.Resources.buttonBackImage;
            this.squre.Location = new System.Drawing.Point(13, 9);
            this.squre.Name = "squre";
            this.squre.Size = new System.Drawing.Size(51, 40);
            this.squre.TabIndex = 4;
            this.squre.Text = "label2";
            this.squre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.squre.Click += new System.EventHandler(this.squre_Click);
            this.squre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.squre_MouseDown);
            this.squre.MouseLeave += new System.EventHandler(this.squre_MouseLeave);
            this.squre.MouseHover += new System.EventHandler(this.squre_MouseHover);
            this.squre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.squre_MouseMove);
            this.squre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.squre_MouseUp);
            // 
            // deleteMenuStrip
            // 
            this.deleteMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除组件ToolStripMenuItem});
            this.deleteMenuStrip.Name = "deleteMenuStrip";
            this.deleteMenuStrip.Size = new System.Drawing.Size(125, 26);
            // 
            // 删除组件ToolStripMenuItem
            // 
            this.删除组件ToolStripMenuItem.Name = "删除组件ToolStripMenuItem";
            this.删除组件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除组件ToolStripMenuItem.Text = "删除组件";
            this.删除组件ToolStripMenuItem.Click += new System.EventHandler(this.删除组件ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(19, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // BaseMeterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.squre);
            this.Controls.Add(this.label1);
            this.Name = "BaseMeterControl";
            this.Size = new System.Drawing.Size(98, 86);
            this.deleteMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label squre;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip deleteMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 删除组件ToolStripMenuItem;
    }
}
