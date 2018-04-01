namespace PitchATent
{
    partial class AddCustomWallsDlg
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
            this.lbl_Plain = new System.Windows.Forms.Label();
            this.nud_Plain = new System.Windows.Forms.NumericUpDown();
            this.lbl_Window = new System.Windows.Forms.Label();
            this.nud_Window = new System.Windows.Forms.NumericUpDown();
            this.btn_Done = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.lbl_FPlain = new System.Windows.Forms.Label();
            this.nud_FPlain = new System.Windows.Forms.NumericUpDown();
            this.lbl_FWindow = new System.Windows.Forms.Label();
            this.nud_FWindow = new System.Windows.Forms.NumericUpDown();
            this.btn_AllToZero = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Plain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Window)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPlain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Plain
            // 
            this.lbl_Plain.AutoSize = true;
            this.lbl_Plain.Location = new System.Drawing.Point(13, 13);
            this.lbl_Plain.Name = "lbl_Plain";
            this.lbl_Plain.Size = new System.Drawing.Size(57, 13);
            this.lbl_Plain.TabIndex = 0;
            this.lbl_Plain.Text = "Plain Wall:";
            // 
            // nud_Plain
            // 
            this.nud_Plain.Location = new System.Drawing.Point(152, 11);
            this.nud_Plain.Name = "nud_Plain";
            this.nud_Plain.Size = new System.Drawing.Size(120, 20);
            this.nud_Plain.TabIndex = 1;
            // 
            // lbl_Window
            // 
            this.lbl_Window.AutoSize = true;
            this.lbl_Window.Location = new System.Drawing.Point(12, 44);
            this.lbl_Window.Name = "lbl_Window";
            this.lbl_Window.Size = new System.Drawing.Size(49, 13);
            this.lbl_Window.TabIndex = 2;
            this.lbl_Window.Text = "Window:";
            // 
            // nud_Window
            // 
            this.nud_Window.Location = new System.Drawing.Point(152, 44);
            this.nud_Window.Name = "nud_Window";
            this.nud_Window.Size = new System.Drawing.Size(120, 20);
            this.nud_Window.TabIndex = 3;
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(129, 148);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(69, 25);
            this.btn_Done.TabIndex = 4;
            this.btn_Done.Text = "Done";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(204, 148);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(68, 25);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // lbl_FPlain
            // 
            this.lbl_FPlain.AutoSize = true;
            this.lbl_FPlain.Location = new System.Drawing.Point(12, 78);
            this.lbl_FPlain.Name = "lbl_FPlain";
            this.lbl_FPlain.Size = new System.Drawing.Size(88, 13);
            this.lbl_FPlain.TabIndex = 6;
            this.lbl_FPlain.Text = "Plain Fiesta Wall:";
            // 
            // nud_FPlain
            // 
            this.nud_FPlain.Location = new System.Drawing.Point(152, 76);
            this.nud_FPlain.Name = "nud_FPlain";
            this.nud_FPlain.Size = new System.Drawing.Size(120, 20);
            this.nud_FPlain.TabIndex = 7;
            // 
            // lbl_FWindow
            // 
            this.lbl_FWindow.AutoSize = true;
            this.lbl_FWindow.Location = new System.Drawing.Point(13, 116);
            this.lbl_FWindow.Name = "lbl_FWindow";
            this.lbl_FWindow.Size = new System.Drawing.Size(104, 13);
            this.lbl_FWindow.TabIndex = 8;
            this.lbl_FWindow.Text = "Window Fiesta Wall:";
            // 
            // nud_FWindow
            // 
            this.nud_FWindow.Location = new System.Drawing.Point(152, 109);
            this.nud_FWindow.Name = "nud_FWindow";
            this.nud_FWindow.Size = new System.Drawing.Size(120, 20);
            this.nud_FWindow.TabIndex = 9;
            // 
            // btn_AllToZero
            // 
            this.btn_AllToZero.Location = new System.Drawing.Point(13, 148);
            this.btn_AllToZero.Name = "btn_AllToZero";
            this.btn_AllToZero.Size = new System.Drawing.Size(100, 25);
            this.btn_AllToZero.TabIndex = 10;
            this.btn_AllToZero.Text = "Set All to Zero";
            this.btn_AllToZero.UseVisualStyleBackColor = true;
            this.btn_AllToZero.Click += new System.EventHandler(this.btn_AllToZero_Click);
            // 
            // AddCustomWallsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 185);
            this.Controls.Add(this.btn_AllToZero);
            this.Controls.Add(this.nud_FWindow);
            this.Controls.Add(this.lbl_FWindow);
            this.Controls.Add(this.nud_FPlain);
            this.Controls.Add(this.lbl_FPlain);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.nud_Window);
            this.Controls.Add(this.lbl_Window);
            this.Controls.Add(this.nud_Plain);
            this.Controls.Add(this.lbl_Plain);
            this.Name = "AddCustomWallsDlg";
            this.ShowIcon = false;
            this.Text = "Add Custom Walls";
            ((System.ComponentModel.ISupportInitialize)(this.nud_Plain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Window)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FPlain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_FWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Plain;
        private System.Windows.Forms.NumericUpDown nud_Plain;
        private System.Windows.Forms.Label lbl_Window;
        private System.Windows.Forms.NumericUpDown nud_Window;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label lbl_FPlain;
        private System.Windows.Forms.NumericUpDown nud_FPlain;
        private System.Windows.Forms.Label lbl_FWindow;
        private System.Windows.Forms.NumericUpDown nud_FWindow;
        private System.Windows.Forms.Button btn_AllToZero;
    }
}