namespace MainForm
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.splitLeft = new System.Windows.Forms.SplitContainer();
            this.splitLeftUp = new System.Windows.Forms.SplitContainer();
            this.ControlTab = new System.Windows.Forms.TabControl();
            this.InstrumentPage = new System.Windows.Forms.TabPage();
            this.InstruementFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.MethodPage = new System.Windows.Forms.TabPage();
            this.MethodFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.flow_Add1 = new MethodFlowControl.Flow_Add();
            this.HidePage = new System.Windows.Forms.TabPage();
            this.DMMFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.ScopeFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.formControl = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.drawLineButton = new System.Windows.Forms.Button();
            this.splitRightUp = new System.Windows.Forms.SplitContainer();
            this.varPanel = new System.Windows.Forms.Panel();
            this.userVarPanel = new System.Windows.Forms.Panel();
            this.userVarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.插入变量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawLineTip = new System.Windows.Forms.ToolTip(this.components);
            this.buildButton = new System.Windows.Forms.Button();
            this.buildTip = new System.Windows.Forms.ToolTip(this.components);
            this.errorListView = new System.Windows.Forms.ListView();
            this.序号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.错误描述 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.错误位置详情 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).BeginInit();
            this.splitLeft.Panel1.SuspendLayout();
            this.splitLeft.Panel2.SuspendLayout();
            this.splitLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftUp)).BeginInit();
            this.splitLeftUp.Panel1.SuspendLayout();
            this.splitLeftUp.Panel2.SuspendLayout();
            this.splitLeftUp.SuspendLayout();
            this.ControlTab.SuspendLayout();
            this.InstrumentPage.SuspendLayout();
            this.MethodPage.SuspendLayout();
            this.MethodFlow.SuspendLayout();
            this.HidePage.SuspendLayout();
            this.DMMFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.Panel2.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.formControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRightUp)).BeginInit();
            this.splitRightUp.Panel1.SuspendLayout();
            this.splitRightUp.Panel2.SuspendLayout();
            this.splitRightUp.SuspendLayout();
            this.userVarMenu.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.buildButton);
            this.MenuPanel.Controls.Add(this.menu);
            this.MenuPanel.Controls.Add(this.drawLineButton);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(721, 52);
            this.MenuPanel.TabIndex = 0;
            // 
            // splitLeft
            // 
            this.splitLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeft.Location = new System.Drawing.Point(0, 52);
            this.splitLeft.Name = "splitLeft";
            // 
            // splitLeft.Panel1
            // 
            this.splitLeft.Panel1.Controls.Add(this.splitLeftUp);
            // 
            // splitLeft.Panel2
            // 
            this.splitLeft.Panel2.Controls.Add(this.splitRight);
            this.splitLeft.Size = new System.Drawing.Size(721, 427);
            this.splitLeft.SplitterDistance = 118;
            this.splitLeft.TabIndex = 1;
            this.splitLeft.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitLeft_SplitterMoved);
            // 
            // splitLeftUp
            // 
            this.splitLeftUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitLeftUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeftUp.Location = new System.Drawing.Point(0, 0);
            this.splitLeftUp.Name = "splitLeftUp";
            this.splitLeftUp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitLeftUp.Panel1
            // 
            this.splitLeftUp.Panel1.Controls.Add(this.ControlTab);
            // 
            // splitLeftUp.Panel2
            // 
            this.splitLeftUp.Panel2.Controls.Add(this.listBox1);
            this.splitLeftUp.Size = new System.Drawing.Size(118, 427);
            this.splitLeftUp.SplitterDistance = 221;
            this.splitLeftUp.TabIndex = 0;
            // 
            // ControlTab
            // 
            this.ControlTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.ControlTab.Controls.Add(this.InstrumentPage);
            this.ControlTab.Controls.Add(this.MethodPage);
            this.ControlTab.Controls.Add(this.HidePage);
            this.ControlTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlTab.Location = new System.Drawing.Point(0, 0);
            this.ControlTab.Multiline = true;
            this.ControlTab.Name = "ControlTab";
            this.ControlTab.SelectedIndex = 0;
            this.ControlTab.Size = new System.Drawing.Size(116, 219);
            this.ControlTab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.ControlTab.TabIndex = 0;
            this.ControlTab.Selected += new System.Windows.Forms.TabControlEventHandler(this.ControlTab_Selected);
            // 
            // InstrumentPage
            // 
            this.InstrumentPage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InstrumentPage.Controls.Add(this.InstruementFlow);
            this.InstrumentPage.Location = new System.Drawing.Point(4, 73);
            this.InstrumentPage.Name = "InstrumentPage";
            this.InstrumentPage.Padding = new System.Windows.Forms.Padding(3);
            this.InstrumentPage.Size = new System.Drawing.Size(108, 142);
            this.InstrumentPage.TabIndex = 0;
            this.InstrumentPage.Text = "仪器仪表";
            // 
            // InstruementFlow
            // 
            this.InstruementFlow.AutoScroll = true;
            this.InstruementFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstruementFlow.Location = new System.Drawing.Point(3, 3);
            this.InstruementFlow.Name = "InstruementFlow";
            this.InstruementFlow.Size = new System.Drawing.Size(102, 136);
            this.InstruementFlow.TabIndex = 0;
            // 
            // MethodPage
            // 
            this.MethodPage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MethodPage.Controls.Add(this.MethodFlow);
            this.MethodPage.Location = new System.Drawing.Point(4, 73);
            this.MethodPage.Name = "MethodPage";
            this.MethodPage.Padding = new System.Windows.Forms.Padding(3);
            this.MethodPage.Size = new System.Drawing.Size(108, 142);
            this.MethodPage.TabIndex = 1;
            this.MethodPage.Text = "Method";
            // 
            // MethodFlow
            // 
            this.MethodFlow.AutoScroll = true;
            this.MethodFlow.Controls.Add(this.flow_Add1);
            this.MethodFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MethodFlow.Location = new System.Drawing.Point(3, 3);
            this.MethodFlow.Name = "MethodFlow";
            this.MethodFlow.Size = new System.Drawing.Size(102, 136);
            this.MethodFlow.TabIndex = 0;
            // 
            // flow_Add1
            // 
            this.flow_Add1.BackColor = System.Drawing.Color.Transparent;
            this.flow_Add1.ButtonText = "Meth";
            this.flow_Add1.ControlParent = this.MethodFlow;
            this.flow_Add1.LabelText = "ADD";
            this.flow_Add1.Location = new System.Drawing.Point(3, 3);
            this.flow_Add1.Name = "flow_Add1";
            this.flow_Add1.Size = new System.Drawing.Size(69, 75);
            this.flow_Add1.TabIndex = 1;
            // 
            // HidePage
            // 
            this.HidePage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HidePage.Controls.Add(this.DMMFlow);
            this.HidePage.Location = new System.Drawing.Point(4, 73);
            this.HidePage.Name = "HidePage";
            this.HidePage.Padding = new System.Windows.Forms.Padding(3);
            this.HidePage.Size = new System.Drawing.Size(108, 142);
            this.HidePage.TabIndex = 2;
            this.HidePage.Text = "hidepage";
            // 
            // DMMFlow
            // 
            this.DMMFlow.Controls.Add(this.ScopeFlow);
            this.DMMFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DMMFlow.Location = new System.Drawing.Point(3, 3);
            this.DMMFlow.Name = "DMMFlow";
            this.DMMFlow.Size = new System.Drawing.Size(102, 136);
            this.DMMFlow.TabIndex = 0;
            // 
            // ScopeFlow
            // 
            this.ScopeFlow.AutoScroll = true;
            this.ScopeFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScopeFlow.Location = new System.Drawing.Point(3, 3);
            this.ScopeFlow.Name = "ScopeFlow";
            this.ScopeFlow.Size = new System.Drawing.Size(102, 0);
            this.ScopeFlow.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "Main"});
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(116, 200);
            this.listBox1.TabIndex = 0;
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitRight.Panel2
            // 
            this.splitRight.Panel2.Controls.Add(this.splitRightUp);
            this.splitRight.Size = new System.Drawing.Size(597, 425);
            this.splitRight.SplitterDistance = 494;
            this.splitRight.TabIndex = 0;
            // 
            // formControl
            // 
            this.formControl.Controls.Add(this.MainPage);
            this.formControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formControl.Location = new System.Drawing.Point(0, 0);
            this.formControl.Name = "formControl";
            this.formControl.SelectedIndex = 0;
            this.formControl.Size = new System.Drawing.Size(494, 289);
            this.formControl.TabIndex = 0;
            // 
            // MainPage
            // 
            this.MainPage.AutoScroll = true;
            this.MainPage.Location = new System.Drawing.Point(4, 22);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(486, 263);
            this.MainPage.TabIndex = 1;
            this.MainPage.Text = "Main";
            this.MainPage.UseVisualStyleBackColor = true;
            this.MainPage.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPage_Paint_1);
            // 
            // drawLineButton
            // 
            this.drawLineButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawLineButton.BackgroundImage")));
            this.drawLineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawLineButton.Location = new System.Drawing.Point(0, 29);
            this.drawLineButton.Name = "drawLineButton";
            this.drawLineButton.Size = new System.Drawing.Size(24, 23);
            this.drawLineButton.TabIndex = 0;
            this.drawLineButton.UseVisualStyleBackColor = true;
            this.drawLineButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitRightUp
            // 
            this.splitRightUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitRightUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRightUp.Location = new System.Drawing.Point(0, 0);
            this.splitRightUp.Name = "splitRightUp";
            this.splitRightUp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRightUp.Panel1
            // 
            this.splitRightUp.Panel1.Controls.Add(this.varPanel);
            // 
            // splitRightUp.Panel2
            // 
            this.splitRightUp.Panel2.Controls.Add(this.userVarPanel);
            this.splitRightUp.Size = new System.Drawing.Size(99, 425);
            this.splitRightUp.SplitterDistance = 137;
            this.splitRightUp.TabIndex = 0;
            // 
            // varPanel
            // 
            this.varPanel.AutoScroll = true;
            this.varPanel.BackColor = System.Drawing.Color.White;
            this.varPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.varPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.varPanel.Location = new System.Drawing.Point(0, 0);
            this.varPanel.Name = "varPanel";
            this.varPanel.Size = new System.Drawing.Size(97, 135);
            this.varPanel.TabIndex = 0;
            this.varPanel.SizeChanged += new System.EventHandler(this.varPanel_SizeChanged);
            // 
            // userVarPanel
            // 
            this.userVarPanel.AutoScroll = true;
            this.userVarPanel.BackColor = System.Drawing.Color.White;
            this.userVarPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userVarPanel.ContextMenuStrip = this.userVarMenu;
            this.userVarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userVarPanel.Location = new System.Drawing.Point(0, 0);
            this.userVarPanel.Name = "userVarPanel";
            this.userVarPanel.Size = new System.Drawing.Size(97, 282);
            this.userVarPanel.TabIndex = 1;
            this.userVarPanel.SizeChanged += new System.EventHandler(this.userVarPanel_SizeChanged);
            // 
            // userVarMenu
            // 
            this.userVarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.插入变量ToolStripMenuItem});
            this.userVarMenu.Name = "contextMenuStrip1";
            this.userVarMenu.Size = new System.Drawing.Size(125, 26);
            // 
            // 插入变量ToolStripMenuItem
            // 
            this.插入变量ToolStripMenuItem.Name = "插入变量ToolStripMenuItem";
            this.插入变量ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.插入变量ToolStripMenuItem.Text = "插入变量";
            this.插入变量ToolStripMenuItem.Click += new System.EventHandler(this.插入变量ToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(721, 25);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // buildButton
            // 
            this.buildButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buildButton.BackgroundImage")));
            this.buildButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buildButton.Location = new System.Drawing.Point(23, 29);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(27, 23);
            this.buildButton.TabIndex = 2;
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // errorListView
            // 
            this.errorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.序号,
            this.错误描述,
            this.错误位置详情});
            this.errorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorListView.GridLines = true;
            this.errorListView.Location = new System.Drawing.Point(0, 0);
            this.errorListView.Name = "errorListView";
            this.errorListView.Size = new System.Drawing.Size(494, 132);
            this.errorListView.TabIndex = 0;
            this.errorListView.UseCompatibleStateImageBehavior = false;
            this.errorListView.View = System.Windows.Forms.View.Details;
            // 
            // 序号
            // 
            this.序号.Text = "序号";
            this.序号.Width = 40;
            // 
            // 错误描述
            // 
            this.错误描述.Text = "错误描述";
            this.错误描述.Width = 308;
            // 
            // 错误位置详情
            // 
            this.错误位置详情.Text = "错误位置详情/变量名";
            this.错误位置详情.Width = 139;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.formControl);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.errorListView);
            this.splitContainer1.Size = new System.Drawing.Size(494, 425);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 479);
            this.Controls.Add(this.splitLeft);
            this.Controls.Add(this.MenuPanel);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.splitLeft.Panel1.ResumeLayout(false);
            this.splitLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeft)).EndInit();
            this.splitLeft.ResumeLayout(false);
            this.splitLeftUp.Panel1.ResumeLayout(false);
            this.splitLeftUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLeftUp)).EndInit();
            this.splitLeftUp.ResumeLayout(false);
            this.ControlTab.ResumeLayout(false);
            this.InstrumentPage.ResumeLayout(false);
            this.MethodPage.ResumeLayout(false);
            this.MethodFlow.ResumeLayout(false);
            this.HidePage.ResumeLayout(false);
            this.DMMFlow.ResumeLayout(false);
            this.splitRight.Panel1.ResumeLayout(false);
            this.splitRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.formControl.ResumeLayout(false);
            this.splitRightUp.Panel1.ResumeLayout(false);
            this.splitRightUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRightUp)).EndInit();
            this.splitRightUp.ResumeLayout(false);
            this.userVarMenu.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.SplitContainer splitLeft;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.SplitContainer splitLeftUp;
        private System.Windows.Forms.TabControl ControlTab;
        private System.Windows.Forms.TabPage MethodPage;
        private System.Windows.Forms.FlowLayoutPanel MethodFlow;
        private System.Windows.Forms.TabPage InstrumentPage;
        private System.Windows.Forms.FlowLayoutPanel InstruementFlow;
        private System.Windows.Forms.TabPage HidePage;
        private System.Windows.Forms.FlowLayoutPanel DMMFlow;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabControl formControl;
        private System.Windows.Forms.TabPage MainPage;
        private System.Windows.Forms.FlowLayoutPanel ScopeFlow;
        private System.Windows.Forms.SplitContainer splitRightUp;
        private System.Windows.Forms.Panel varPanel;
        private MethodFlowControl.Flow_Add flow_Add1;
        private System.Windows.Forms.Panel userVarPanel;
        private System.Windows.Forms.ContextMenuStrip userVarMenu;
        private System.Windows.Forms.ToolStripMenuItem 插入变量ToolStripMenuItem;
        private System.Windows.Forms.Button drawLineButton;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolTip DrawLineTip;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.ToolTip buildTip;
        private System.Windows.Forms.ListView errorListView;
        private System.Windows.Forms.ColumnHeader 序号;
        private System.Windows.Forms.ColumnHeader 错误描述;
        private System.Windows.Forms.ColumnHeader 错误位置详情;
        private System.Windows.Forms.SplitContainer splitContainer1;



    }
}

