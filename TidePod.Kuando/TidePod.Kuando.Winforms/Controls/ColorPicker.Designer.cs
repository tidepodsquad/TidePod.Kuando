namespace TidePod.Kuando.Winforms.Controls
{
    partial class ColorPicker
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
            this.SetButton = new System.Windows.Forms.Button();
            this.redTextBox = new System.Windows.Forms.TextBox();
            this.greenTextBox = new System.Windows.Forms.TextBox();
            this.blueTextBox = new System.Windows.Forms.TextBox();
            this.ColorPreviewPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // SetButton
            // 
            this.SetButton.Location = new System.Drawing.Point(211, 4);
            this.SetButton.Name = "SetButton";
            this.SetButton.Size = new System.Drawing.Size(75, 23);
            this.SetButton.TabIndex = 3;
            this.SetButton.Text = "Set";
            this.SetButton.UseVisualStyleBackColor = true;
            // 
            // redTextBox
            // 
            this.redTextBox.Location = new System.Drawing.Point(4, 5);
            this.redTextBox.Name = "redTextBox";
            this.redTextBox.Size = new System.Drawing.Size(47, 20);
            this.redTextBox.TabIndex = 0;
            // 
            // greenTextBox
            // 
            this.greenTextBox.Location = new System.Drawing.Point(57, 5);
            this.greenTextBox.Name = "greenTextBox";
            this.greenTextBox.Size = new System.Drawing.Size(47, 20);
            this.greenTextBox.TabIndex = 1;
            // 
            // blueTextBox
            // 
            this.blueTextBox.Location = new System.Drawing.Point(110, 5);
            this.blueTextBox.Name = "blueTextBox";
            this.blueTextBox.Size = new System.Drawing.Size(47, 20);
            this.blueTextBox.TabIndex = 2;
            // 
            // ColorPreviewPanel
            // 
            this.ColorPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColorPreviewPanel.Location = new System.Drawing.Point(164, 4);
            this.ColorPreviewPanel.Name = "ColorPreviewPanel";
            this.ColorPreviewPanel.Size = new System.Drawing.Size(41, 24);
            this.ColorPreviewPanel.TabIndex = 4;
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ColorPreviewPanel);
            this.Controls.Add(this.blueTextBox);
            this.Controls.Add(this.greenTextBox);
            this.Controls.Add(this.redTextBox);
            this.Controls.Add(this.SetButton);
            this.Name = "ColorPicker";
            this.Size = new System.Drawing.Size(289, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SetButton;
        private System.Windows.Forms.TextBox redTextBox;
        private System.Windows.Forms.TextBox greenTextBox;
        private System.Windows.Forms.TextBox blueTextBox;
        private System.Windows.Forms.Panel ColorPreviewPanel;
    }
}
