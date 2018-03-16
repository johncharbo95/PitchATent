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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tentDGV = new System.Windows.Forms.DataGridView();
            this.tentExport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tentHoldDown = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tentWalls = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddTent = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.newTruckLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_truck = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_trailer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_driver = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tentDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tentDGV);
            this.groupBox1.Location = new System.Drawing.Point(12, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 291);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tents";
            // 
            // tentDGV
            // 
            this.tentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tentDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tentExport,
            this.tentType,
            this.tentHoldDown,
            this.tentWalls});
            this.tentDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tentDGV.Location = new System.Drawing.Point(3, 16);
            this.tentDGV.Name = "tentDGV";
            this.tentDGV.Size = new System.Drawing.Size(934, 272);
            this.tentDGV.TabIndex = 0;
            // 
            // tentExport
            // 
            this.tentExport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tentExport.HeaderText = "Selection";
            this.tentExport.Name = "tentExport";
            // 
            // tentType
            // 
            this.tentType.HeaderText = "Tent";
            this.tentType.Name = "tentType";
            // 
            // tentHoldDown
            // 
            this.tentHoldDown.HeaderText = "Tie Down";
            this.tentHoldDown.Name = "tentHoldDown";
            // 
            // tentWalls
            // 
            this.tentWalls.HeaderText = "Walls";
            this.tentWalls.Name = "tentWalls";
            this.tentWalls.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tentWalls.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 398);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 291);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accessories";
            // 
            // AddTent
            // 
            this.AddTent.Location = new System.Drawing.Point(12, 62);
            this.AddTent.Name = "AddTent";
            this.AddTent.Size = new System.Drawing.Size(75, 23);
            this.AddTent.TabIndex = 2;
            this.AddTent.Text = "Add Tent";
            this.AddTent.UseVisualStyleBackColor = true;
            this.AddTent.Click += new System.EventHandler(this.AddTent_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(964, 24);
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
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
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
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 700);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_driver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_trailer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_truck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddTent);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "UserInterface";
            this.Text = "PitchATent";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tentDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddTent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem newTruckLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_truck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_trailer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_driver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView tentDGV;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tentExport;
        private System.Windows.Forms.DataGridViewComboBoxColumn tentType;
        private System.Windows.Forms.DataGridViewComboBoxColumn tentHoldDown;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tentWalls;
    }
}

