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
            this.startButton = new System.Windows.Forms.Button();
            this.buildButton = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLineButton = new System.Windows.Forms.Button();
            this.splitLeft = new System.Windows.Forms.SplitContainer();
            this.splitLeftUp = new System.Windows.Forms.SplitContainer();
            this.ControlTab = new System.Windows.Forms.TabControl();
            this.InstrumentPage = new System.Windows.Forms.TabPage();
            this.InstruementFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.MethodPage = new System.Windows.Forms.TabPage();
            this.MethodFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.flow_Result1 = new MethodFlowControl.Flow_Result();
            this.flow_Add1 = new MethodFlowControl.Flow_Add();
            this.flow_MessBox1 = new MethodFlowControl.Flow_MessBox();
            this.flow_Move1 = new MethodFlowControl.Flow_Move();
            this.HidePage = new System.Windows.Forms.TabPage();
            this.DMMFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.ScopeFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.formControl = new System.Windows.Forms.TabControl();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.resultListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.closeDwonWin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关闭窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.输出为excleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorListView = new System.Windows.Forms.ListView();
            this.序号 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.错误描述 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.错误位置详情 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitRightUp = new System.Windows.Forms.SplitContainer();
            this.varPanel = new System.Windows.Forms.Panel();
            this.userVarPanel = new System.Windows.Forms.Panel();
            this.userVarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.插入变量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DrawLineTip = new System.Windows.Forms.ToolTip(this.components);
            this.buildTip = new System.Windows.Forms.ToolTip(this.components);
            this.flow_MotorClose1 = new MethodFlowControl.Flow_MotorClose();
            this.MenuPanel.SuspendLayout();
            this.menu.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.formControl.SuspendLayout();
            this.closeDwonWin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRightUp)).BeginInit();
            this.splitRightUp.Panel1.SuspendLayout();
            this.splitRightUp.Panel2.SuspendLayout();
            this.splitRightUp.SuspendLayout();
            this.userVarMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.Controls.Add(this.startButton);
            this.MenuPanel.Controls.Add(this.buildButton);
            this.MenuPanel.Controls.Add(this.menu);
            this.MenuPanel.Controls.Add(this.drawLineButton);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(721, 52);
            this.MenuPanel.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startButton.BackgroundImage")));
            this.startButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startButton.Location = new System.Drawing.Point(49, 29);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(27, 23);
            this.startButton.TabIndex = 3;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
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
            // splitLeft
            // 
            this.splitLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.splitLeft.SplitterDistance = 156;
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
            this.splitLeftUp.Size = new System.Drawing.Size(156, 427);
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
            this.ControlTab.Size = new System.Drawing.Size(154, 219);
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
            this.InstrumentPage.Size = new System.Drawing.Size(146, 142);
            this.InstrumentPage.TabIndex = 0;
            this.InstrumentPage.Text = "仪器仪表";
            // 
            // InstruementFlow
            // 
            this.InstruementFlow.AutoScroll = true;
            this.InstruementFlow.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.InstruementFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstruementFlow.Location = new System.Drawing.Point(3, 3);
            this.InstruementFlow.Name = "InstruementFlow";
            this.InstruementFlow.Size = new System.Drawing.Size(140, 136);
            this.InstruementFlow.TabIndex = 0;
            // 
            // MethodPage
            // 
            this.MethodPage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MethodPage.Controls.Add(this.MethodFlow);
            this.MethodPage.Location = new System.Drawing.Point(4, 73);
            this.MethodPage.Name = "MethodPage";
            this.MethodPage.Padding = new System.Windows.Forms.Padding(3);
            this.MethodPage.Size = new System.Drawing.Size(146, 142);
            this.MethodPage.TabIndex = 1;
            this.MethodPage.Text = "Method";
            // 
            // MethodFlow
            // 
            this.MethodFlow.AutoScroll = true;
            this.MethodFlow.Controls.Add(this.flow_Result1);
            this.MethodFlow.Controls.Add(this.flow_Add1);
            this.MethodFlow.Controls.Add(this.flow_MessBox1);
            this.MethodFlow.Controls.Add(this.flow_Move1);
            this.MethodFlow.Controls.Add(this.flow_MotorClose1);
            this.MethodFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MethodFlow.Location = new System.Drawing.Point(3, 3);
            this.MethodFlow.Name = "MethodFlow";
            this.MethodFlow.Size = new System.Drawing.Size(140, 136);
            this.MethodFlow.TabIndex = 0;
            // 
            // flow_Result1
            // 
            this.flow_Result1.BackColor = System.Drawing.Color.Transparent;
            this.flow_Result1.ButtonText = "PR";
            this.flow_Result1.ControlParent = this.MethodFlow;
            this.flow_Result1.LabelText = "ShowResult";
            this.flow_Result1.Location = new System.Drawing.Point(3, 3);
            this.flow_Result1.Name = "flow_Result1";
            this.flow_Result1.Size = new System.Drawing.Size(69, 75);
            this.flow_Result1.TabIndex = 2;
            // 
            // flow_Add1
            // 
            this.flow_Add1.BackColor = System.Drawing.Color.Transparent;
            this.flow_Add1.ButtonText = "Meth";
            this.flow_Add1.ControlParent = this.MethodFlow;
            this.flow_Add1.LabelText = "ADD";
            this.flow_Add1.Location = new System.Drawing.Point(3, 84);
            this.flow_Add1.Name = "flow_Add1";
            this.flow_Add1.Size = new System.Drawing.Size(69, 75);
            this.flow_Add1.TabIndex = 1;
            // 
            // flow_MessBox1
            // 
            this.flow_MessBox1.BackColor = System.Drawing.Color.Transparent;
            this.flow_MessBox1.ButtonText = "Mes";
            this.flow_MessBox1.ControlParent = this.MethodFlow;
            this.flow_MessBox1.LabelText = "MessageBox";
            this.flow_MessBox1.Location = new System.Drawing.Point(3, 165);
            this.flow_MessBox1.Name = "flow_MessBox1";
            this.flow_MessBox1.Size = new System.Drawing.Size(69, 75);
            this.flow_MessBox1.TabIndex = 3;
            // 
            // flow_Move1
            // 
            this.flow_Move1.BackColor = System.Drawing.Color.Transparent;
            this.flow_Move1.ButtonText = "Move";
            this.flow_Move1.ControlParent = this.MethodFlow;
            this.flow_Move1.LabelText = "Move";
            this.flow_Move1.Location = new System.Drawing.Point(3, 246);
            this.flow_Move1.Name = "flow_Move1";
            this.flow_Move1.Size = new System.Drawing.Size(69, 75);
            this.flow_Move1.TabIndex = 4;
            // 
            // HidePage
            // 
            this.HidePage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.HidePage.Controls.Add(this.DMMFlow);
            this.HidePage.Location = new System.Drawing.Point(4, 73);
            this.HidePage.Name = "HidePage";
            this.HidePage.Padding = new System.Windows.Forms.Padding(3);
            this.HidePage.Size = new System.Drawing.Size(146, 142);
            this.HidePage.TabIndex = 2;
            this.HidePage.Text = "hidepage";
            // 
            // DMMFlow
            // 
            this.DMMFlow.Controls.Add(this.ScopeFlow);
            this.DMMFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DMMFlow.Location = new System.Drawing.Point(3, 3);
            this.DMMFlow.Name = "DMMFlow";
            this.DMMFlow.Size = new System.Drawing.Size(140, 136);
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
            this.listBox1.Size = new System.Drawing.Size(154, 200);
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
            this.splitRight.Size = new System.Drawing.Size(559, 425);
            this.splitRight.SplitterDistance = 442;
            this.splitRight.TabIndex = 0;
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
            this.splitContainer1.Panel2.Controls.Add(this.resultListView);
            this.splitContainer1.Panel2.Controls.Add(this.errorListView);
            this.splitContainer1.Size = new System.Drawing.Size(442, 425);
            this.splitContainer1.SplitterDistance = 289;
            this.splitContainer1.TabIndex = 1;
            // 
            // formControl
            // 
            this.formControl.Controls.Add(this.MainPage);
            this.formControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formControl.Location = new System.Drawing.Point(0, 0);
            this.formControl.Name = "formControl";
            this.formControl.SelectedIndex = 0;
            this.formControl.Size = new System.Drawing.Size(442, 289);
            this.formControl.TabIndex = 0;
            // 
            // MainPage
            // 
            this.MainPage.AutoScroll = true;
            this.MainPage.Location = new System.Drawing.Point(4, 22);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainPage.Size = new System.Drawing.Size(434, 263);
            this.MainPage.TabIndex = 1;
            this.MainPage.Text = "Main";
            this.MainPage.UseVisualStyleBackColor = true;
            this.MainPage.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPage_Paint_1);
            // 
            // resultListView
            // 
            this.resultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.resultListView.ContextMenuStrip = this.closeDwonWin;
            this.resultListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultListView.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.resultListView.FullRowSelect = true;
            this.resultListView.GridLines = true;
            this.resultListView.Location = new System.Drawing.Point(0, 0);
            this.resultListView.Name = "resultListView";
            this.resultListView.Size = new System.Drawing.Size(442, 132);
            this.resultListView.TabIndex = 1;
            this.resultListView.UseCompatibleStateImageBehavior = false;
            this.resultListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "序号";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "测试项名称";
            this.columnHeader6.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "下限值";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "测量值";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "上限值";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "测试项结果";
            this.columnHeader5.Width = 87;
            // 
            // closeDwonWin
            // 
            this.closeDwonWin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭窗口ToolStripMenuItem,
            this.输出为excleToolStripMenuItem});
            this.closeDwonWin.Name = "closeDwonWin";
            this.closeDwonWin.Size = new System.Drawing.Size(142, 48);
            // 
            // 关闭窗口ToolStripMenuItem
            // 
            this.关闭窗口ToolStripMenuItem.Name = "关闭窗口ToolStripMenuItem";
            this.关闭窗口ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.关闭窗口ToolStripMenuItem.Text = "关闭窗口";
            this.关闭窗口ToolStripMenuItem.Click += new System.EventHandler(this.关闭窗口ToolStripMenuItem_Click);
            // 
            // 输出为excleToolStripMenuItem
            // 
            this.输出为excleToolStripMenuItem.Name = "输出为excleToolStripMenuItem";
            this.输出为excleToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.输出为excleToolStripMenuItem.Text = "输出为excle";
            this.输出为excleToolStripMenuItem.Click += new System.EventHandler(this.输出为excleToolStripMenuItem_Click);
            // 
            // errorListView
            // 
            this.errorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.序号,
            this.错误描述,
            this.错误位置详情});
            this.errorListView.ContextMenuStrip = this.closeDwonWin;
            this.errorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorListView.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.errorListView.FullRowSelect = true;
            this.errorListView.GridLines = true;
            this.errorListView.Location = new System.Drawing.Point(0, 0);
            this.errorListView.Name = "errorListView";
            this.errorListView.Size = new System.Drawing.Size(442, 132);
            this.errorListView.TabIndex = 0;
            this.errorListView.UseCompatibleStateImageBehavior = false;
            this.errorListView.View = System.Windows.Forms.View.Details;
            // 
            // 序号
            // 
            this.序号.Text = "序号";
            // 
            // 错误描述
            // 
            this.错误描述.Text = "错误描述";
            this.错误描述.Width = 500;
            // 
            // 错误位置详情
            // 
            this.错误位置详情.Text = "错误位置详情/变量名";
            this.错误位置详情.Width = 300;
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
            this.splitRightUp.Size = new System.Drawing.Size(113, 425);
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
            this.varPanel.Size = new System.Drawing.Size(111, 135);
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
            this.userVarPanel.Size = new System.Drawing.Size(111, 282);
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
            // flow_MotorClose1
            // 
            this.flow_MotorClose1.BackColor = System.Drawing.Color.Transparent;
            this.flow_MotorClose1.ButtonText = "Moter";
            this.flow_MotorClose1.ControlParent = this.MethodFlow;
            this.flow_MotorClose1.LabelText = "Close";
            this.flow_MotorClose1.Location = new System.Drawing.Point(3, 327);
            this.flow_MotorClose1.Name = "flow_MotorClose1";
            this.flow_MotorClose1.Size = new System.Drawing.Size(69, 75);
            this.flow_MotorClose1.TabIndex = 5;
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
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.formControl.ResumeLayout(false);
            this.closeDwonWin.ResumeLayout(false);
            this.splitRightUp.Panel1.ResumeLayout(false);
            this.splitRightUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRightUp)).EndInit();
            this.splitRightUp.ResumeLayout(false);
            this.userVarMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip closeDwonWin;
        private System.Windows.Forms.ToolStripMenuItem 关闭窗口ToolStripMenuItem;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button startButton;
        private MethodFlowControl.Flow_Result flow_Result1;
        private System.Windows.Forms.ToolStripMenuItem 输出为excleToolStripMenuItem;
        private MethodFlowControl.Flow_MessBox flow_MessBox1;
        private MethodFlowControl.Flow_Move flow_Move1;
        private MethodFlowControl.Flow_MotorClose flow_MotorClose1;



    }
}

