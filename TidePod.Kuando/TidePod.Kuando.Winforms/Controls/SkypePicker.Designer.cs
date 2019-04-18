namespace TidePod.Kuando.Winforms.Controls
{
    partial class SkypePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.ckbEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(-3, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(277, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "To monitor Skype for Business activity, enter email below:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(0, 16);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(204, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // ckbEnabled
            // 
            this.ckbEnabled.AutoSize = true;
            this.ckbEnabled.Location = new System.Drawing.Point(211, 18);
            this.ckbEnabled.Name = "ckbEnabled";
            this.ckbEnabled.Size = new System.Drawing.Size(65, 17);
            this.ckbEnabled.TabIndex = 2;
            this.ckbEnabled.Text = "Enabled";
            this.ckbEnabled.UseVisualStyleBackColor = true;
            this.ckbEnabled.CheckedChanged += new System.EventHandler(this.CkbEnabled_CheckedChanged);
            // 
            // SkypePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbEnabled);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblDescription);
            this.Name = "SkypePicker";
            this.Size = new System.Drawing.Size(287, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox ckbEnabled;
    }
}
