namespace TidePod.Kuando.Winforms.Controls
{
    partial class SlackPicker
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
            this.btnSlackPicker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSlackPicker
            // 
            this.btnSlackPicker.Location = new System.Drawing.Point(29, 62);
            this.btnSlackPicker.Name = "btnSlackPicker";
            this.btnSlackPicker.Size = new System.Drawing.Size(92, 23);
            this.btnSlackPicker.TabIndex = 0;
            this.btnSlackPicker.Text = "TODO: Slack";
            this.btnSlackPicker.UseVisualStyleBackColor = true;
            // 
            // SlackPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSlackPicker);
            this.Name = "SlackPicker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSlackPicker;
    }
}
