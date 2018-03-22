namespace PitchATent
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
            this.tentGroupBox = new System.Windows.Forms.GroupBox();
            this.tentDGV = new System.Windows.Forms.DataGridView();
            this.tentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentCoverType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentHoldDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentWalls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tentLegs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accGroupBox = new System.Windows.Forms.GroupBox();
            this.btn_tentAddSmall = new System.Windows.Forms.Button();
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
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_tentAddLarge = new System.Windows.Forms.Button();
            this.btn_addFrame = new System.Windows.Forms.Button();
            this.btn_addClearSpan = new System.Windows.Forms.Button();
            this.tentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tentDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tentGroupBox
            // 
            this.tentGroupBox.Controls.Add(this.tentDGV);
            this.tentGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tentGroupBox.Location = new System.Drawing.Point(12, 101);
            this.tentGroupBox.Name = "tentGroupBox";
            this.tentGroupBox.Size = new System.Drawing.Size(630, 291);
            this.tentGroupBox.TabIndex = 0;
            this.tentGroupBox.TabStop = false;
            this.tentGroupBox.Text = "Tents";
            // 
            // tentDGV
            // 
            this.tentDGV.AllowUserToAddRows = false;
            this.tentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tentDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tentType,
            this.tentQty,
            this.tentCoverType,
            this.tentHoldDown,
            this.tentWalls,
            this.tentLegs});
            this.tentDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tentDGV.GridColor = System.Drawing.SystemColors.Control;
            this.tentDGV.Location = new System.Drawing.Point(3, 25);
            this.tentDGV.Name = "tentDGV";
            this.tentDGV.RowHeadersVisible = false;
            this.tentDGV.Size = new System.Drawing.Size(624, 263);
            this.tentDGV.TabIndex = 0;
            this.tentDGV.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.tentDGV_DataError);
            // 
            // tentType
            // 
            this.tentType.HeaderText = "Tent";
            this.tentType.Name = "tentType";
            this.tentType.ReadOnly = true;
            this.tentType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tentQty
            // 
            this.tentQty.HeaderText = "Qty";
            this.tentQty.Name = "tentQty";
            this.tentQty.Width = 50;
            // 
            // tentCoverType
            // 
            this.tentCoverType.HeaderText = "Cover Type";
            this.tentCoverType.Name = "tentCoverType";
            this.tentCoverType.ReadOnly = true;
            this.tentCoverType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentCoverType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tentHoldDown
            // 
            this.tentHoldDown.HeaderText = "Tie Down";
            this.tentHoldDown.Name = "tentHoldDown";
            this.tentHoldDown.ReadOnly = true;
            this.tentHoldDown.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentHoldDown.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tentWalls
            // 
            this.tentWalls.HeaderText = "Walls";
            this.tentWalls.Name = "tentWalls";
            this.tentWalls.ReadOnly = true;
            this.tentWalls.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentWalls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tentLegs
            // 
            this.tentLegs.HeaderText = "Legs";
            this.tentLegs.Name = "tentLegs";
            this.tentLegs.ReadOnly = true;
            this.tentLegs.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // accGroupBox
            // 
            this.accGroupBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accGroupBox.Location = new System.Drawing.Point(12, 398);
            this.accGroupBox.Name = "accGroupBox";
            this.accGroupBox.Size = new System.Drawing.Size(630, 291);
            this.accGroupBox.TabIndex = 1;
            this.accGroupBox.TabStop = false;
            this.accGroupBox.Text = "Accessories";
            // 
            // btn_tentAddSmall
            // 
            this.btn_tentAddSmall.Location = new System.Drawing.Point(12, 72);
            this.btn_tentAddSmall.Name = "btn_tentAddSmall";
            this.btn_tentAddSmall.Size = new System.Drawing.Size(100, 25);
            this.btn_tentAddSmall.TabIndex = 2;
            this.btn_tentAddSmall.Text = "Add Small Tent";
            this.btn_tentAddSmall.UseVisualStyleBackColor = true;
            this.btn_tentAddSmall.Click += new System.EventHandler(this.AddSmallTent_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(970, 24);
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
            this.tb_truck.Location = new System.Drawing.Point(65, 32);
            this.tb_truck.Name = "tb_truck";
            this.tb_truck.Size = new System.Drawing.Size(100, 20);
            this.tb_truck.TabIndex = 5;
            this.tb_truck.TextChanged += new System.EventHandler(this.tb_truck_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trailer:";
            // 
            // tb_trailer
            // 
            this.tb_trailer.Location = new System.Drawing.Point(305, 32);
            this.tb_trailer.Name = "tb_trailer";
            this.tb_trailer.Size = new System.Drawing.Size(100, 20);
            this.tb_trailer.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(467, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "Driver:";
            // 
            // tb_driver
            // 
            this.tb_driver.Location = new System.Drawing.Point(530, 33);
            this.tb_driver.Name = "tb_driver";
            this.tb_driver.Size = new System.Drawing.Size(124, 20);
            this.tb_driver.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(698, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date:";
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(749, 34);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(171, 20);
            this.dateTime.TabIndex = 12;
            // 
            // previewGroupBox
            // 
            this.previewGroupBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewGroupBox.Location = new System.Drawing.Point(691, 101);
            this.previewGroupBox.Name = "previewGroupBox";
            this.previewGroupBox.Size = new System.Drawing.Size(261, 546);
            this.previewGroupBox.TabIndex = 13;
            this.previewGroupBox.TabStop = false;
            this.previewGroupBox.Text = "Preview";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh.Location = new System.Drawing.Point(648, 653);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(144, 35);
            this.btn_refresh.TabIndex = 14;
            this.btn_refresh.Text = "Refresh Preview";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // btn_tentAddLarge
            // 
            this.btn_tentAddLarge.Location = new System.Drawing.Point(117, 72);
            this.btn_tentAddLarge.Name = "btn_tentAddLarge";
            this.btn_tentAddLarge.Size = new System.Drawing.Size(100, 25);
            this.btn_tentAddLarge.TabIndex = 15;
            this.btn_tentAddLarge.Text = "Add Large Tent";
            this.btn_tentAddLarge.UseVisualStyleBackColor = true;
            this.btn_tentAddLarge.Click += new System.EventHandler(this.btn_tentAddLarge_Click);
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
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 700);
            this.Controls.Add(this.btn_addClearSpan);
            this.Controls.Add(this.btn_addFrame);
            this.Controls.Add(this.btn_tentAddLarge);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.previewGroupBox);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_driver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_trailer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_truck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_tentAddSmall);
            this.Controls.Add(this.accGroupBox);
            this.Controls.Add(this.tentGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UserInterface";
            this.Text = "PitchATent";
            this.tentGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tentDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox tentGroupBox;
        private System.Windows.Forms.GroupBox accGroupBox;
        private System.Windows.Forms.Button btn_tentAddSmall;
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
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_tentAddLarge;
        private System.Windows.Forms.Button btn_addFrame;
        private System.Windows.Forms.Button btn_addClearSpan;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentCoverType;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentHoldDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentWalls;
        private System.Windows.Forms.DataGridViewTextBoxColumn tentLegs;
    }
}

