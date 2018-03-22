﻿namespace PitchATent
{
    partial class formLargeTent
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
            this.cb_LT_size = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_LT_holddown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_LT_coverType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_LT_walls = new System.Windows.Forms.ComboBox();
            this.btn_LT_add = new System.Windows.Forms.Button();
            this.btn_LT_cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_LT_qty = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_LT_legs = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LT_qty)).BeginInit();
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
            // cb_LT_size
            // 
            this.cb_LT_size.FormattingEnabled = true;
            this.cb_LT_size.Items.AddRange(new object[] {
            "40x40",
            "40x60",
            "40x80",
            "40x100",
            "40x120",
            "40x140",
            "40x160",
            "40x180",
            "40x200",
            "40x220",
            "40x240",
            "40x260",
            "40x280",
            "40x300",
            "60x40",
            "60x60",
            "60x70",
            "60x80",
            "60x90",
            "60x100",
            "60x110",
            "60x120",
            "60x130",
            "60x140",
            "60x150",
            "60x160",
            "60x170",
            "60x180",
            "60x190",
            "60x200",
            "60x210",
            "60x220",
            "60x230",
            "60x240",
            "60x250",
            "90x60",
            "90x90",
            "90x120",
            "90x150",
            "90x180",
            "90x210",
            "90x240",
            "90x270",
            "90x300"});
            this.cb_LT_size.Location = new System.Drawing.Point(84, 10);
            this.cb_LT_size.Name = "cb_LT_size";
            this.cb_LT_size.Size = new System.Drawing.Size(121, 21);
            this.cb_LT_size.TabIndex = 1;
            this.cb_LT_size.Text = "40x40";
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
            // cb_LT_holddown
            // 
            this.cb_LT_holddown.FormattingEnabled = true;
            this.cb_LT_holddown.Items.AddRange(new object[] {
            "Pins",
            "Water Barrels",
            "Concrete Blocks"});
            this.cb_LT_holddown.Location = new System.Drawing.Point(84, 110);
            this.cb_LT_holddown.Name = "cb_LT_holddown";
            this.cb_LT_holddown.Size = new System.Drawing.Size(121, 21);
            this.cb_LT_holddown.TabIndex = 3;
            this.cb_LT_holddown.Text = "Pins";
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
            // cb_LT_coverType
            // 
            this.cb_LT_coverType.FormattingEnabled = true;
            this.cb_LT_coverType.Items.AddRange(new object[] {
            "Regular",
            "New",
            "Old",
            "Barbecue",
            "Soft"});
            this.cb_LT_coverType.Location = new System.Drawing.Point(85, 74);
            this.cb_LT_coverType.Name = "cb_LT_coverType";
            this.cb_LT_coverType.Size = new System.Drawing.Size(121, 21);
            this.cb_LT_coverType.TabIndex = 5;
            this.cb_LT_coverType.Text = "Regular";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Walls:";
            // 
            // cb_LT_walls
            // 
            this.cb_LT_walls.FormattingEnabled = true;
            this.cb_LT_walls.Items.AddRange(new object[] {
            "Full Plain",
            "Full Window",
            "Half Plain Half Window",
            "Full Plain Fiesta",
            "Full Window Fiesta",
            "Half Plain Half Window Fiesta",
            "None",
            "Custom..."});
            this.cb_LT_walls.Location = new System.Drawing.Point(84, 143);
            this.cb_LT_walls.Name = "cb_LT_walls";
            this.cb_LT_walls.Size = new System.Drawing.Size(121, 21);
            this.cb_LT_walls.TabIndex = 7;
            this.cb_LT_walls.Text = "Full Plain";
            this.cb_LT_walls.SelectedIndexChanged += new System.EventHandler(this.cb_LT_walls_SelectedIndexChanged);
            // 
            // btn_LT_add
            // 
            this.btn_LT_add.Location = new System.Drawing.Point(12, 266);
            this.btn_LT_add.Name = "btn_LT_add";
            this.btn_LT_add.Size = new System.Drawing.Size(75, 23);
            this.btn_LT_add.TabIndex = 10;
            this.btn_LT_add.Text = "Add";
            this.btn_LT_add.UseVisualStyleBackColor = true;
            this.btn_LT_add.Click += new System.EventHandler(this.btn_LT_add_Click);
            // 
            // btn_LT_cancel
            // 
            this.btn_LT_cancel.Location = new System.Drawing.Point(118, 266);
            this.btn_LT_cancel.Name = "btn_LT_cancel";
            this.btn_LT_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_LT_cancel.TabIndex = 11;
            this.btn_LT_cancel.Text = "Cancel";
            this.btn_LT_cancel.UseVisualStyleBackColor = true;
            this.btn_LT_cancel.Click += new System.EventHandler(this.btn_LT_cancel_Click);
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
            // nud_LT_qty
            // 
            this.nud_LT_qty.Location = new System.Drawing.Point(85, 45);
            this.nud_LT_qty.Name = "nud_LT_qty";
            this.nud_LT_qty.Size = new System.Drawing.Size(120, 20);
            this.nud_LT_qty.TabIndex = 13;
            this.nud_LT_qty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Notes:";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(85, 208);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(121, 38);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Legs:";
            // 
            // cb_LT_legs
            // 
            this.cb_LT_legs.FormattingEnabled = true;
            this.cb_LT_legs.Items.AddRange(new object[] {
            "8 ft",
            "10 ft"});
            this.cb_LT_legs.Location = new System.Drawing.Point(84, 170);
            this.cb_LT_legs.Name = "cb_LT_legs";
            this.cb_LT_legs.Size = new System.Drawing.Size(121, 21);
            this.cb_LT_legs.TabIndex = 17;
            this.cb_LT_legs.Text = "8 ft";
            // 
            // formLargeTent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 301);
            this.Controls.Add(this.cb_LT_legs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nud_LT_qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_LT_cancel);
            this.Controls.Add(this.btn_LT_add);
            this.Controls.Add(this.cb_LT_walls);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_LT_coverType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_LT_holddown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_LT_size);
            this.Controls.Add(this.label1);
            this.Name = "formLargeTent";
            this.ShowIcon = false;
            this.Text = "Add Large Tent";
            ((System.ComponentModel.ISupportInitialize)(this.nud_LT_qty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_LT_size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_LT_holddown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_LT_coverType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_LT_walls;
        private System.Windows.Forms.Button btn_LT_add;
        private System.Windows.Forms.Button btn_LT_cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_LT_qty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_LT_legs;
    }
}