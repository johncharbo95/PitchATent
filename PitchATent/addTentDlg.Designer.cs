namespace PitchATent
{
    partial class AddTentDlg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTentDlg));
            this.label1 = new System.Windows.Forms.Label();
            this.cb_size = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_holddown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_coverType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_walls = new System.Windows.Forms.ComboBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nud_qty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_legs = new System.Windows.Forms.ComboBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_qty)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size:";
            // 
            // cb_size
            // 
            this.cb_size.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cb_size.FormattingEnabled = true;
            this.cb_size.Location = new System.Drawing.Point(84, 10);
            this.cb_size.Name = "cb_size";
            this.cb_size.Size = new System.Drawing.Size(121, 21);
            this.cb_size.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hold Down: ";
            // 
            // cb_holddown
            // 
            this.cb_holddown.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cb_holddown.FormattingEnabled = true;
            this.cb_holddown.Location = new System.Drawing.Point(84, 110);
            this.cb_holddown.Name = "cb_holddown";
            this.cb_holddown.Size = new System.Drawing.Size(121, 21);
            this.cb_holddown.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cover Type:";
            // 
            // cb_coverType
            // 
            this.cb_coverType.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cb_coverType.FormattingEnabled = true;
            this.cb_coverType.Location = new System.Drawing.Point(85, 74);
            this.cb_coverType.Name = "cb_coverType";
            this.cb_coverType.Size = new System.Drawing.Size(121, 21);
            this.cb_coverType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Walls:";
            // 
            // cb_walls
            // 
            this.cb_walls.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cb_walls.FormattingEnabled = true;
            this.cb_walls.Location = new System.Drawing.Point(84, 143);
            this.cb_walls.Name = "cb_walls";
            this.cb_walls.Size = new System.Drawing.Size(121, 21);
            this.cb_walls.TabIndex = 7;
            this.cb_walls.SelectedIndexChanged += new System.EventHandler(this.cb_walls_SelectedIndexChanged);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(6, 241);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(205, 48);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "Done";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(5, 210);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 25);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(2, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Quantity: ";
            // 
            // nud_qty
            // 
            this.nud_qty.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.nud_qty.Location = new System.Drawing.Point(85, 45);
            this.nud_qty.Name = "nud_qty";
            this.nud_qty.Size = new System.Drawing.Size(120, 20);
            this.nud_qty.TabIndex = 13;
            this.nud_qty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Legs:";
            // 
            // cb_legs
            // 
            this.cb_legs.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.cb_legs.FormattingEnabled = true;
            this.cb_legs.Location = new System.Drawing.Point(84, 170);
            this.cb_legs.Name = "cb_legs";
            this.cb_legs.Size = new System.Drawing.Size(121, 21);
            this.cb_legs.TabIndex = 17;
            this.cb_legs.Text = "8 ft";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(111, 210);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(100, 25);
            this.btn_Reset.TabIndex = 18;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // AddTentDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(223, 301);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.cb_legs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nud_qty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.cb_walls);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_coverType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_holddown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_size);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "AddTentDlg";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.addTentDlg_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nud_qty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_holddown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_coverType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_walls;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nud_qty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_legs;
        private System.Windows.Forms.Button btn_Reset;
    }
}