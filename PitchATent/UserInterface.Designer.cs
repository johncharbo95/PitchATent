﻿namespace PitchATent
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.tentGroupBox = new System.Windows.Forms.GroupBox();
            this.tentDGV = new System.Windows.Forms.DataGridView();
            this.tentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentCoverType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentHoldDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentWalls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentLegs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenTieDownIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenWallsIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddenLegsIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addSmallTentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLargeTentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addClearSpanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accGroupBox = new System.Windows.Forms.GroupBox();
            this.accDGV = new System.Windows.Forms.DataGridView();
            this.Accessory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_addSmallTent = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.newTruckLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_truck = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_trailer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_driver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.previewGroupBox = new System.Windows.Forms.GroupBox();
            this.previewDGV = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_addLargeTent = new System.Windows.Forms.Button();
            this.btn_addFrame = new System.Windows.Forms.Button();
            this.btn_addClearSpan = new System.Windows.Forms.Button();
            this.btn_AddAcc = new System.Windows.Forms.Button();
            this.btn_GeneratePDF = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_ClearTents = new System.Windows.Forms.Button();
            this.btn_ClearAcc = new System.Windows.Forms.Button();
            this.tentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tentDGV)).BeginInit();
            this.tentContextMenu.SuspendLayout();
            this.accGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.previewGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tentGroupBox
            // 
            this.tentGroupBox.Controls.Add(this.tentDGV);
            this.tentGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentGroupBox.Location = new System.Drawing.Point(12, 101);
            this.tentGroupBox.Name = "tentGroupBox";
            this.tentGroupBox.Size = new System.Drawing.Size(548, 291);
            this.tentGroupBox.TabIndex = 0;
            this.tentGroupBox.TabStop = false;
            this.tentGroupBox.Text = "Tents";
            // 
            // tentDGV
            // 
            this.tentDGV.AllowUserToAddRows = false;
            this.tentDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.tentDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.tentDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tentDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tentDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tentType,
            this.tentSize,
            this.tentQty,
            this.tentCoverType,
            this.tentHoldDown,
            this.tentWalls,
            this.tentLegs,
            this.hiddenTieDownIndex,
            this.hiddenWallsIndex,
            this.hiddenLegsIndex});
            this.tentDGV.ContextMenuStrip = this.tentContextMenu;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tentDGV.DefaultCellStyle = dataGridViewCellStyle9;
            this.tentDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tentDGV.GridColor = System.Drawing.SystemColors.Control;
            this.tentDGV.Location = new System.Drawing.Point(3, 25);
            this.tentDGV.Name = "tentDGV";
            this.tentDGV.RowHeadersVisible = false;
            this.tentDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tentDGV.Size = new System.Drawing.Size(542, 263);
            this.tentDGV.TabIndex = 0;
            this.tentDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tentDGV_DataError);
            this.tentDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tentDGV_KeyDown);
            this.tentDGV.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tentDGV_MouseDown);
            // 
            // tentType
            // 
            this.tentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tentType.HeaderText = "Tent";
            this.tentType.Name = "tentType";
            this.tentType.ReadOnly = true;
            this.tentType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentType.Width = 63;
            // 
            // tentSize
            // 
            this.tentSize.HeaderText = "Size";
            this.tentSize.Name = "tentSize";
            this.tentSize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tentSize.Width = 44;
            // 
            // tentQty
            // 
            this.tentQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tentQty.HeaderText = "Qty";
            this.tentQty.Name = "tentQty";
            this.tentQty.Width = 60;
            // 
            // tentCoverType
            // 
            this.tentCoverType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tentCoverType.HeaderText = "Cover Type";
            this.tentCoverType.Name = "tentCoverType";
            this.tentCoverType.ReadOnly = true;
            this.tentCoverType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentCoverType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tentCoverType.Width = 93;
            // 
            // tentHoldDown
            // 
            this.tentHoldDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tentHoldDown.HeaderText = "Tie Down";
            this.tentHoldDown.Name = "tentHoldDown";
            this.tentHoldDown.ReadOnly = true;
            this.tentHoldDown.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentHoldDown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tentHoldDown.Width = 81;
            // 
            // tentWalls
            // 
            this.tentWalls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tentWalls.HeaderText = "Walls";
            this.tentWalls.Name = "tentWalls";
            this.tentWalls.ReadOnly = true;
            this.tentWalls.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentWalls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tentWalls.Width = 53;
            // 
            // tentLegs
            // 
            this.tentLegs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.tentLegs.HeaderText = "Legs";
            this.tentLegs.Name = "tentLegs";
            this.tentLegs.ReadOnly = true;
            this.tentLegs.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentLegs.Width = 67;
            // 
            // hiddenTieDownIndex
            // 
            this.hiddenTieDownIndex.HeaderText = "Hidden Tie Down Index";
            this.hiddenTieDownIndex.Name = "hiddenTieDownIndex";
            this.hiddenTieDownIndex.Visible = false;
            this.hiddenTieDownIndex.Width = 195;
            // 
            // hiddenWallsIndex
            // 
            this.hiddenWallsIndex.HeaderText = "Hidden Walls Index";
            this.hiddenWallsIndex.Name = "hiddenWallsIndex";
            this.hiddenWallsIndex.Visible = false;
            this.hiddenWallsIndex.Width = 167;
            // 
            // hiddenLegsIndex
            // 
            this.hiddenLegsIndex.HeaderText = "Hidden Legs Index";
            this.hiddenLegsIndex.Name = "hiddenLegsIndex";
            this.hiddenLegsIndex.Visible = false;
            this.hiddenLegsIndex.Width = 162;
            // 
            // tentContextMenu
            // 
            this.tentContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSmallTentToolStripMenuItem,
            this.addLargeTentToolStripMenuItem,
            this.addFrameToolStripMenuItem,
            this.addClearSpanToolStripMenuItem,
            this.toolStripSeparator1,
            this.editRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.tentContextMenu.Name = "tentContextMenu";
            this.tentContextMenu.Size = new System.Drawing.Size(155, 142);
            // 
            // addSmallTentToolStripMenuItem
            // 
            this.addSmallTentToolStripMenuItem.Name = "addSmallTentToolStripMenuItem";
            this.addSmallTentToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addSmallTentToolStripMenuItem.Text = "Add Small Tent";
            // 
            // addLargeTentToolStripMenuItem
            // 
            this.addLargeTentToolStripMenuItem.Name = "addLargeTentToolStripMenuItem";
            this.addLargeTentToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addLargeTentToolStripMenuItem.Text = "Add Large Tent";
            // 
            // addFrameToolStripMenuItem
            // 
            this.addFrameToolStripMenuItem.Name = "addFrameToolStripMenuItem";
            this.addFrameToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addFrameToolStripMenuItem.Text = "Add Frame";
            // 
            // addClearSpanToolStripMenuItem
            // 
            this.addClearSpanToolStripMenuItem.Name = "addClearSpanToolStripMenuItem";
            this.addClearSpanToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addClearSpanToolStripMenuItem.Text = "Add ClearSpan";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // editRowToolStripMenuItem
            // 
            this.editRowToolStripMenuItem.Name = "editRowToolStripMenuItem";
            this.editRowToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editRowToolStripMenuItem.Text = "Edit Row...";
            this.editRowToolStripMenuItem.Click += new System.EventHandler(this.editRowToolStripMenuItem_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // accGroupBox
            // 
            this.accGroupBox.Controls.Add(this.accDGV);
            this.accGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accGroupBox.Location = new System.Drawing.Point(12, 398);
            this.accGroupBox.Name = "accGroupBox";
            this.accGroupBox.Size = new System.Drawing.Size(215, 291);
            this.accGroupBox.TabIndex = 1;
            this.accGroupBox.TabStop = false;
            this.accGroupBox.Text = "Accessories";
            // 
            // accDGV
            // 
            this.accDGV.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.accDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.accDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Accessory,
            this.Qty});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.accDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.accDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accDGV.Location = new System.Drawing.Point(3, 25);
            this.accDGV.Name = "accDGV";
            this.accDGV.ReadOnly = true;
            this.accDGV.RowHeadersVisible = false;
            this.accDGV.Size = new System.Drawing.Size(209, 263);
            this.accDGV.TabIndex = 0;
            // 
            // Accessory
            // 
            this.Accessory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Accessory.HeaderText = "Accessory";
            this.Accessory.Name = "Accessory";
            this.Accessory.ReadOnly = true;
            this.Accessory.Width = 104;
            // 
            // Qty
            // 
            this.Qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Qty.HeaderText = "Quantity";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 95;
            // 
            // btn_addSmallTent
            // 
            this.btn_addSmallTent.Location = new System.Drawing.Point(12, 72);
            this.btn_addSmallTent.Name = "btn_addSmallTent";
            this.btn_addSmallTent.Size = new System.Drawing.Size(100, 25);
            this.btn_addSmallTent.TabIndex = 2;
            this.btn_addSmallTent.Text = "Add Small Tent";
            this.btn_addSmallTent.UseVisualStyleBackColor = true;
            this.btn_addSmallTent.Click += new System.EventHandler(this.btn_addSmallTent_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTruckLoadToolStripMenuItem,
            this.openToolStripMenuItem,
            this.printToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(37, 20);
            this.file.Text = "File";
            // 
            // newTruckLoadToolStripMenuItem
            // 
            this.newTruckLoadToolStripMenuItem.Name = "newTruckLoadToolStripMenuItem";
            this.newTruckLoadToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newTruckLoadToolStripMenuItem.Text = "New Truck Load";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Truck:";
            // 
            // tb_truck
            // 
            this.tb_truck.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tb_truck.Location = new System.Drawing.Point(65, 32);
            this.tb_truck.Name = "tb_truck";
            this.tb_truck.Size = new System.Drawing.Size(100, 20);
            this.tb_truck.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(184, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trailer:";
            // 
            // tb_trailer
            // 
            this.tb_trailer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tb_trailer.Location = new System.Drawing.Point(247, 32);
            this.tb_trailer.Name = "tb_trailer";
            this.tb_trailer.Size = new System.Drawing.Size(100, 20);
            this.tb_trailer.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(374, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Driver:";
            // 
            // tb_driver
            // 
            this.tb_driver.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tb_driver.Location = new System.Drawing.Point(436, 32);
            this.tb_driver.Name = "tb_driver";
            this.tb_driver.Size = new System.Drawing.Size(124, 20);
            this.tb_driver.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(622, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date:";
            // 
            // dateTime
            // 
            this.dateTime.CalendarForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateTime.CalendarMonthBackground = System.Drawing.SystemColors.ActiveBorder;
            this.dateTime.CalendarTitleBackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTime.Location = new System.Drawing.Point(673, 32);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(171, 20);
            this.dateTime.TabIndex = 12;
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.AutoSize = true;
            this.previewGroupBox.Controls.Add(this.previewDGV);
            this.previewGroupBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewGroupBox.Location = new System.Drawing.Point(566, 72);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(383, 617);
            this.previewGroupBox.TabIndex = 13;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // previewDGV
            // 
            this.previewDGV.AllowUserToAddRows = false;
            this.previewDGV.AllowUserToDeleteRows = false;
            this.previewDGV.AllowUserToResizeColumns = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.previewDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.previewDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.previewDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.previewDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Quantity});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.previewDGV.DefaultCellStyle = dataGridViewCellStyle12;
            this.previewDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewDGV.Location = new System.Drawing.Point(3, 31);
            this.previewDGV.Name = "previewDGV";
            this.previewDGV.ReadOnly = true;
            this.previewDGV.RowHeadersVisible = false;
            this.previewDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.previewDGV.Size = new System.Drawing.Size(377, 583);
            this.previewDGV.TabIndex = 0;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Item.FillWeight = 75F;
            this.Item.HeaderText = "Item";
            this.Item.MinimumWidth = 250;
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 250;
            // 
            // Quantity
            // 
            this.Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Quantity.FillWeight = 25F;
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 118;
            // 
            // btn_addLargeTent
            // 
            this.btn_addLargeTent.Location = new System.Drawing.Point(117, 72);
            this.btn_addLargeTent.Name = "btn_addLargeTent";
            this.btn_addLargeTent.Size = new System.Drawing.Size(100, 25);
            this.btn_addLargeTent.TabIndex = 15;
            this.btn_addLargeTent.Text = "Add Large Tent";
            this.btn_addLargeTent.UseVisualStyleBackColor = true;
            this.btn_addLargeTent.Click += new System.EventHandler(this.btn_addLargeTent_Click);
            // 
            // btn_addFrame
            // 
            this.btn_addFrame.Location = new System.Drawing.Point(223, 72);
            this.btn_addFrame.Name = "btn_addFrame";
            this.btn_addFrame.Size = new System.Drawing.Size(100, 25);
            this.btn_addFrame.TabIndex = 16;
            this.btn_addFrame.Text = "Add Frame";
            this.btn_addFrame.UseVisualStyleBackColor = true;
            this.btn_addFrame.Click += new System.EventHandler(this.btn_addFrame_Click);
            // 
            // btn_addClearSpan
            // 
            this.btn_addClearSpan.Location = new System.Drawing.Point(330, 72);
            this.btn_addClearSpan.Name = "btn_addClearSpan";
            this.btn_addClearSpan.Size = new System.Drawing.Size(100, 25);
            this.btn_addClearSpan.TabIndex = 17;
            this.btn_addClearSpan.Text = "Add ClearSpan";
            this.btn_addClearSpan.UseVisualStyleBackColor = true;
            this.btn_addClearSpan.Click += new System.EventHandler(this.btn_addClearSpan_Click);
            // 
            // btn_AddAcc
            // 
            this.btn_AddAcc.Location = new System.Drawing.Point(437, 72);
            this.btn_AddAcc.Name = "btn_AddAcc";
            this.btn_AddAcc.Size = new System.Drawing.Size(100, 25);
            this.btn_AddAcc.TabIndex = 18;
            this.btn_AddAcc.Text = "Accessories";
            this.btn_AddAcc.UseVisualStyleBackColor = true;
            this.btn_AddAcc.Click += new System.EventHandler(this.btn_AddAcc_Click);
            // 
            // btn_GeneratePDF
            // 
            this.btn_GeneratePDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GeneratePDF.Location = new System.Drawing.Point(233, 634);
            this.btn_GeneratePDF.Name = "btn_GeneratePDF";
            this.btn_GeneratePDF.Size = new System.Drawing.Size(147, 50);
            this.btn_GeneratePDF.TabIndex = 19;
            this.btn_GeneratePDF.Text = "Generate List";
            this.btn_GeneratePDF.UseVisualStyleBackColor = true;
            this.btn_GeneratePDF.Click += new System.EventHandler(this.btn_GeneratePDF_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(877, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(291, 411);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(223, 136);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // btn_ClearTents
            // 
            this.btn_ClearTents.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearTents.Location = new System.Drawing.Point(386, 578);
            this.btn_ClearTents.Name = "btn_ClearTents";
            this.btn_ClearTents.Size = new System.Drawing.Size(171, 50);
            this.btn_ClearTents.TabIndex = 22;
            this.btn_ClearTents.Text = "Clear Tents";
            this.btn_ClearTents.UseVisualStyleBackColor = true;
            this.btn_ClearTents.Click += new System.EventHandler(this.btn_ClearTents_Click);
            // 
            // btn_ClearAcc
            // 
            this.btn_ClearAcc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearAcc.Location = new System.Drawing.Point(386, 634);
            this.btn_ClearAcc.Name = "btn_ClearAcc";
            this.btn_ClearAcc.Size = new System.Drawing.Size(171, 50);
            this.btn_ClearAcc.TabIndex = 23;
            this.btn_ClearAcc.Text = "Clear Accessories";
            this.btn_ClearAcc.UseVisualStyleBackColor = true;
            this.btn_ClearAcc.Click += new System.EventHandler(this.btn_ClearAcc_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(956, 696);
            this.Controls.Add(this.btn_ClearAcc);
            this.Controls.Add(this.btn_ClearTents);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_GeneratePDF);
            this.Controls.Add(this.btn_AddAcc);
            this.Controls.Add(this.btn_addClearSpan);
            this.Controls.Add(this.btn_addFrame);
            this.Controls.Add(this.btn_addLargeTent);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_driver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_trailer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_truck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_addSmallTent);
            this.Controls.Add(this.accGroupBox);
            this.Controls.Add(this.tentGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "UserInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PitchATent";
            this.tentGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tentDGV)).EndInit();
            this.tentContextMenu.ResumeLayout(false);
            this.accGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.previewGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tentGroupBox;
        private System.Windows.Forms.GroupBox accGroupBox;
        private System.Windows.Forms.Button btn_addSmallTent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem newTruckLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_truck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_trailer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_driver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView tentDGV;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.GroupBox previewGroupBox;
        private System.Windows.Forms.Button btn_addLargeTent;
        private System.Windows.Forms.Button btn_addFrame;
        private System.Windows.Forms.Button btn_addClearSpan;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btn_AddAcc;
        private System.Windows.Forms.ContextMenuStrip tentContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addSmallTentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLargeTentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFrameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addClearSpanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView accDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Accessory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentCoverType;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentHoldDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentWalls;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentLegs;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenTieDownIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenWallsIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddenLegsIndex;
        private System.Windows.Forms.DataGridView previewDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.Button btn_GeneratePDF;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_ClearTents;
        private System.Windows.Forms.Button btn_ClearAcc;
    }
}

