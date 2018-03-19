namespace PitchATent
{
    partial class formSmallTent
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_ST_size = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_ST_holddown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_ST_coverType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_ST_walls = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_ST_legs = new System.Windows.Forms.ComboBox();
            this.btn_ST_add = new System.Windows.Forms.Button();
            this.btn_ST_cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_ST_qty = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ST_qty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size:";
            // 
            // cb_ST_size
            // 
            this.cb_ST_size.FormattingEnabled = true;
            this.cb_ST_size.Items.AddRange(new object[] {
            "10x10",
            "10x15",
            "10x20",
            "15x15",
            "20x20",
            "20x30",
            "20x40",
            "30x30",
            "Hexagon",
            ""});
            this.cb_ST_size.Location = new System.Drawing.Point(84, 10);
            this.cb_ST_size.Name = "cb_ST_size";
            this.cb_ST_size.Size = new System.Drawing.Size(121, 21);
            this.cb_ST_size.TabIndex = 1;
            this.cb_ST_size.Text = "10x10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hold Down: ";
            // 
            // cb_ST_holddown
            // 
            this.cb_ST_holddown.FormattingEnabled = true;
            this.cb_ST_holddown.Items.AddRange(new object[] {
            "Pins",
            "Water Barrels",
            "Concrete Blocks"});
            this.cb_ST_holddown.Location = new System.Drawing.Point(84, 110);
            this.cb_ST_holddown.Name = "cb_ST_holddown";
            this.cb_ST_holddown.Size = new System.Drawing.Size(121, 21);
            this.cb_ST_holddown.TabIndex = 3;
            this.cb_ST_holddown.Text = "Pins";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cover Type:";
            // 
            // cb_ST_coverType
            // 
            this.cb_ST_coverType.FormattingEnabled = true;
            this.cb_ST_coverType.Items.AddRange(new object[] {
            "Regular",
            "New",
            "Old",
            "Barbecue",
            "Soft"});
            this.cb_ST_coverType.Location = new System.Drawing.Point(85, 74);
            this.cb_ST_coverType.Name = "cb_ST_coverType";
            this.cb_ST_coverType.Size = new System.Drawing.Size(121, 21);
            this.cb_ST_coverType.TabIndex = 5;
            this.cb_ST_coverType.Text = "Regular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Walls:";
            // 
            // cb_ST_walls
            // 
            this.cb_ST_walls.FormattingEnabled = true;
            this.cb_ST_walls.Items.AddRange(new object[] {
            "Full Plain",
            "Full Window",
            "Half Plain Half Window",
            "Full Plain Fiesta",
            "Full Window Fiesta",
            "Half Plain Half Window Fiesta",
            "None",
            "Custom..."});
            this.cb_ST_walls.Location = new System.Drawing.Point(84, 145);
            this.cb_ST_walls.Name = "cb_ST_walls";
            this.cb_ST_walls.Size = new System.Drawing.Size(121, 21);
            this.cb_ST_walls.TabIndex = 7;
            this.cb_ST_walls.Text = "Full Plain";
            this.cb_ST_walls.SelectedIndexChanged += new System.EventHandler(this.cb_ST_walls_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Legs:";
            // 
            // cb_ST_legs
            // 
            this.cb_ST_legs.FormattingEnabled = true;
            this.cb_ST_legs.Items.AddRange(new object[] {
            "8 ft",
            "8 ft Adjustable",
            "10 ft",
            "10 ft Adjustable",
            "Hexagon"});
            this.cb_ST_legs.Location = new System.Drawing.Point(84, 175);
            this.cb_ST_legs.Name = "cb_ST_legs";
            this.cb_ST_legs.Size = new System.Drawing.Size(121, 21);
            this.cb_ST_legs.TabIndex = 9;
            this.cb_ST_legs.Text = "8 ft";
            // 
            // btn_ST_add
            // 
            this.btn_ST_add.Location = new System.Drawing.Point(12, 265);
            this.btn_ST_add.Name = "btn_ST_add";
            this.btn_ST_add.Size = new System.Drawing.Size(75, 23);
            this.btn_ST_add.TabIndex = 10;
            this.btn_ST_add.Text = "Add";
            this.btn_ST_add.UseVisualStyleBackColor = true;
            this.btn_ST_add.Click += new System.EventHandler(this.btn_ST_add_Click);
            // 
            // btn_ST_cancel
            // 
            this.btn_ST_cancel.Location = new System.Drawing.Point(118, 265);
            this.btn_ST_cancel.Name = "btn_ST_cancel";
            this.btn_ST_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_ST_cancel.TabIndex = 11;
            this.btn_ST_cancel.Text = "Cancel";
            this.btn_ST_cancel.UseVisualStyleBackColor = true;
            this.btn_ST_cancel.Click += new System.EventHandler(this.btn_ST_cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Quantity: ";
            // 
            // nud_ST_qty
            // 
            this.nud_ST_qty.Location = new System.Drawing.Point(85, 45);
            this.nud_ST_qty.Name = "nud_ST_qty";
            this.nud_ST_qty.Size = new System.Drawing.Size(120, 20);
            this.nud_ST_qty.TabIndex = 13;
            this.nud_ST_qty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Notes:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(84, 208);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(121, 38);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // formSmallTent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 300);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nud_ST_qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_ST_cancel);
            this.Controls.Add(this.btn_ST_add);
            this.Controls.Add(this.cb_ST_legs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_ST_walls);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_ST_coverType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_ST_holddown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_ST_size);
            this.Controls.Add(this.label1);
            this.Name = "formSmallTent";
            this.ShowIcon = false;
            this.Text = "Add Small Tent";
            ((System.ComponentModel.ISupportInitialize)(this.nud_ST_qty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_ST_size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_ST_holddown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_ST_coverType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_ST_walls;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_ST_legs;
        private System.Windows.Forms.Button btn_ST_add;
        private System.Windows.Forms.Button btn_ST_cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_ST_qty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}