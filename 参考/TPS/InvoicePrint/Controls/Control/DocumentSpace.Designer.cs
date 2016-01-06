using System;
namespace CustomControls.Control
{
    partial class DocumentSpace
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsTop = new System.Windows.Forms.ToolStripButton();
            this.tsBottom = new System.Windows.Forms.ToolStripButton();
            this.tsGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPrint = new System.Windows.Forms.ToolStripButton();
            this.tsView = new System.Windows.Forms.ToolStripButton();
            this.tsSet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsInfo = new System.Windows.Forms.ToolStripButton();
            this.tsExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numRowHeight = new System.Windows.Forms.NumericUpDown();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lb111 = new System.Windows.Forms.Label();
            this.itemList1 = new CustomControls.Control.ItemList();
            this.drawToolBox1 = new CustomControls.Control.DrawToolBox();
            this.designer1 = new CustomControls.Designer();
            this.ruler2 = new CustomControls.Control.Ruler();
            this.ruler1 = new CustomControls.Control.Ruler();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.ruler2);
            this.panel1.Controls.Add(this.ruler1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(33, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 626);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.AutoScrollMargin = new System.Drawing.Size(5, 5);
            this.panel3.Controls.Add(this.designer1);
            this.panel3.Location = new System.Drawing.Point(51, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(737, 578);
            this.panel3.TabIndex = 6;
            this.panel3.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel3_Scroll);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(51, 38);
            this.panel2.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsOpen,
            this.tsSave,
            this.toolStripSeparator1,
            this.tsDelete,
            this.tsTop,
            this.tsBottom,
            this.tsGrid,
            this.toolStripSeparator3,
            this.tsPrint,
            this.tsView,
            this.tsSet,
            this.toolStripSeparator2,
            this.tsInfo,
            this.tsExit});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(445, 30);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsNew
            // 
            this.tsNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNew.Image = global::CustomControls.Properties.Resources._new;
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(23, 27);
            this.tsNew.Text = "新建";
            this.tsNew.ToolTipText = "新建";
            this.tsNew.Click += new System.EventHandler(this.tsNew_Click);
            // 
            // tsOpen
            // 
            this.tsOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsOpen.Image = global::CustomControls.Properties.Resources.open16;
            this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(23, 27);
            this.tsOpen.Text = "打开设计";
            this.tsOpen.ToolTipText = "打开设计";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = global::CustomControls.Properties.Resources.Save;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(23, 27);
            this.tsSave.Text = "保存设计";
            this.tsSave.ToolTipText = "保存设计";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // tsDelete
            // 
            this.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsDelete.Image = global::CustomControls.Properties.Resources.delete;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(23, 27);
            this.tsDelete.Text = "删除选中的对像";
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsTop
            // 
            this.tsTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsTop.Image = global::CustomControls.Properties.Resources.layer_to_front;
            this.tsTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(23, 27);
            this.tsTop.Text = "置顶";
            this.tsTop.Click += new System.EventHandler(this.tsTop_Click);
            // 
            // tsBottom
            // 
            this.tsBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBottom.Image = global::CustomControls.Properties.Resources.layer_to_back;
            this.tsBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.Size = new System.Drawing.Size(23, 27);
            this.tsBottom.Text = "置底";
            this.tsBottom.Click += new System.EventHandler(this.tsBottom_Click);
            // 
            // tsGrid
            // 
            this.tsGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsGrid.Image = global::CustomControls.Properties.Resources.showgrid;
            this.tsGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGrid.Name = "tsGrid";
            this.tsGrid.Size = new System.Drawing.Size(23, 27);
            this.tsGrid.Text = "显示网格";
            this.tsGrid.Click += new System.EventHandler(this.tsGrid_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 30);
            // 
            // tsPrint
            // 
            this.tsPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrint.Image = global::CustomControls.Properties.Resources.print;
            this.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrint.Name = "tsPrint";
            this.tsPrint.Size = new System.Drawing.Size(23, 27);
            this.tsPrint.Text = "打印";
            this.tsPrint.ToolTipText = "打印";
            this.tsPrint.Click += new System.EventHandler(this.tsPrint_Click);
            // 
            // tsView
            // 
            this.tsView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsView.Image = global::CustomControls.Properties.Resources.view;
            this.tsView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsView.Name = "tsView";
            this.tsView.Size = new System.Drawing.Size(23, 27);
            this.tsView.Text = "打印预览";
            this.tsView.ToolTipText = "打印预览";
            this.tsView.Click += new System.EventHandler(this.tsView_Click);
            // 
            // tsSet
            // 
            this.tsSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSet.Image = global::CustomControls.Properties.Resources.Setting;
            this.tsSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSet.Name = "tsSet";
            this.tsSet.Size = new System.Drawing.Size(23, 27);
            this.tsSet.Text = "设置";
            this.tsSet.ToolTipText = "设置";
            this.tsSet.Click += new System.EventHandler(this.tsSet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // tsInfo
            // 
            this.tsInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsInfo.Image = global::CustomControls.Properties.Resources.info;
            this.tsInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsInfo.Name = "tsInfo";
            this.tsInfo.Size = new System.Drawing.Size(23, 27);
            this.tsInfo.Text = "关于";
            this.tsInfo.ToolTipText = "关于";
            this.tsInfo.Click += new System.EventHandler(this.tsInfo_Click);
            // 
            // tsExit
            // 
            this.tsExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExit.Image = global::CustomControls.Properties.Resources.exit;
            this.tsExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExit.Name = "tsExit";
            this.tsExit.Size = new System.Drawing.Size(23, 27);
            this.tsExit.Text = "退出";
            this.tsExit.ToolTipText = "退出";
            this.tsExit.Click += new System.EventHandler(this.tsExit_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 30);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(828, 27);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(217, 256);
            this.propertyGrid1.TabIndex = 5;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(841, 548);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Page Width:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(838, 576);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Page Height:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(839, 603);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rows Count:";
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numWidth.Location = new System.Drawing.Point(911, 543);
            this.numWidth.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(77, 22);
            this.numWidth.TabIndex = 9;
            this.numWidth.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
            // 
            // numHeight
            // 
            this.numHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numHeight.Location = new System.Drawing.Point(911, 571);
            this.numHeight.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(77, 22);
            this.numHeight.TabIndex = 9;
            this.numHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // numRows
            // 
            this.numRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numRows.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRows.Location = new System.Drawing.Point(911, 599);
            this.numRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(77, 22);
            this.numRows.TabIndex = 9;
            this.numRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.ValueChanged += new System.EventHandler(this.numRows_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(988, 548);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(988, 576);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "mm";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(988, 603);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "row";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(987, 630);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "mm";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(833, 630);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Rows Height:";
            // 
            // numRowHeight
            // 
            this.numRowHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numRowHeight.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRowHeight.Location = new System.Drawing.Point(910, 626);
            this.numRowHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numRowHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRowHeight.Name = "numRowHeight";
            this.numRowHeight.Size = new System.Drawing.Size(77, 22);
            this.numRowHeight.TabIndex = 9;
            this.numRowHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRowHeight.ValueChanged += new System.EventHandler(this.numRowHeight_ValueChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(533, 6);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(132, 14);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "我要资助CraxyMouse";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lb111
            // 
            this.lb111.AutoSize = true;
            this.lb111.Location = new System.Drawing.Point(722, 7);
            this.lb111.Name = "lb111";
            this.lb111.Size = new System.Drawing.Size(35, 13);
            this.lb111.TabIndex = 11;
            this.lb111.Text = "label9";
            // 
            // itemList1
            // 
            this.itemList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.itemList1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.itemList1.ItemHeight = 20;
            this.itemList1.Location = new System.Drawing.Point(828, 286);
            this.itemList1.Name = "itemList1";
            this.itemList1.Size = new System.Drawing.Size(217, 244);
            this.itemList1.TabIndex = 7;
            this.itemList1.SelectedIndexChanged += new System.EventHandler(this.itemList1_SelectedIndexChanged);
            this.itemList1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.itemList1_KeyDown);
            // 
            // drawToolBox1
            // 
            this.drawToolBox1.AutoSize = false;
            this.drawToolBox1.Dock = System.Windows.Forms.DockStyle.None;
            this.drawToolBox1.GripMargin = new System.Windows.Forms.Padding(20, 2, 2, 2);
            this.drawToolBox1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawToolBox1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.drawToolBox1.Location = new System.Drawing.Point(0, 29);
            this.drawToolBox1.Margin = new System.Windows.Forms.Padding(3);
            this.drawToolBox1.Name = "drawToolBox1";
            this.drawToolBox1.Padding = new System.Windows.Forms.Padding(0);
            this.drawToolBox1.Size = new System.Drawing.Size(30, 207);
            this.drawToolBox1.TabIndex = 3;
            this.drawToolBox1.Text = "drawToolBox1";
            // 
            // designer1
            // 
            this.designer1.BackColor = System.Drawing.Color.White;
            this.designer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.designer1.CanSelectItem = true;
            this.designer1.IsDrawMousePosition = false;
            this.designer1.IsDrawSelectRectangle = true;
            this.designer1.Location = new System.Drawing.Point(5, 4);
            this.designer1.Margin = new System.Windows.Forms.Padding(3, 3, 30, 30);
            this.designer1.Name = "designer1";
            this.designer1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.designer1.RowHeight = 15;
            this.designer1.ShowGrid = false;
            this.designer1.Size = new System.Drawing.Size(371, 273);
            this.designer1.TabIndex = 7;
            // 
            // ruler2
            // 
            this.ruler2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ruler2.BackColor = System.Drawing.Color.White;
            this.ruler2.ForeColor = System.Drawing.Color.Black;
            this.ruler2.Location = new System.Drawing.Point(0, 32);
            this.ruler2.Name = "ruler2";
            this.ruler2.RulerOrientation = CustomControls.Orientation.Vertical;
            this.ruler2.Size = new System.Drawing.Size(50, 597);
            this.ruler2.StartPosition = 21;
            this.ruler2.StartValue = 0;
            this.ruler2.TabIndex = 4;
            this.ruler2.Text = "ruler2";
            // 
            // ruler1
            // 
            this.ruler1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ruler1.BackColor = System.Drawing.Color.White;
            this.ruler1.ForeColor = System.Drawing.Color.Black;
            this.ruler1.Location = new System.Drawing.Point(35, 0);
            this.ruler1.Name = "ruler1";
            this.ruler1.RulerOrientation = CustomControls.Orientation.Horizontal;
            this.ruler1.Size = new System.Drawing.Size(773, 46);
            this.ruler1.StartPosition = 22;
            this.ruler1.StartValue = 0;
            this.ruler1.TabIndex = 3;
            this.ruler1.Text = "ruler1";
            // 
            // DocumentSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb111);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.numRowHeight);
            this.Controls.Add(this.numRows);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemList1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.drawToolBox1);
            this.Controls.Add(this.panel1);
            this.Name = "DocumentSpace";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Size = new System.Drawing.Size(1051, 659);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRowHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DrawToolBox drawToolBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private ItemList itemList1;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsPrint;
        private System.Windows.Forms.ToolStripButton tsSet;
        private System.Windows.Forms.ToolStripButton tsInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsView;
        private System.Windows.Forms.ToolStripButton tsExit;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripButton tsTop;
        private System.Windows.Forms.ToolStripButton tsBottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numRowHeight;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Ruler ruler2;
        private Ruler ruler1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb111;
        private System.Windows.Forms.Panel panel3;
        private Designer designer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;


    }
}
