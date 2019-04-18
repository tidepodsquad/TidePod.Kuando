namespace TidePod.Kuando.Winforms
{
    partial class MainWindow
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
            this.RedButton = new System.Windows.Forms.Button();
            this.YellowButton = new System.Windows.Forms.Button();
            this.GreenButton = new System.Windows.Forms.Button();
            this.BlueButton = new System.Windows.Forms.Button();
            this.WhiteButton = new System.Windows.Forms.Button();
            this.OffButton = new System.Windows.Forms.Button();
            this.SlackPicker = new TidePod.Kuando.Winforms.Controls.SlackPicker();
            this.SkypeForBusinessPicker = new TidePod.Kuando.Winforms.Controls.SkypePicker();
            this.ManualColorPicker = new TidePod.Kuando.Winforms.Controls.ColorPicker();
            this.SuspendLayout();
            // 
            // RedButton
            // 
            this.RedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.RedButton.Location = new System.Drawing.Point(12, 49);
            this.RedButton.Name = "RedButton";
            this.RedButton.Size = new System.Drawing.Size(68, 68);
            this.RedButton.TabIndex = 1;
            this.RedButton.Text = "Red";
            this.RedButton.UseVisualStyleBackColor = false;
            // 
            // YellowButton
            // 
            this.YellowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.YellowButton.Location = new System.Drawing.Point(86, 49);
            this.YellowButton.Name = "YellowButton";
            this.YellowButton.Size = new System.Drawing.Size(68, 68);
            this.YellowButton.TabIndex = 2;
            this.YellowButton.Text = "Yellow";
            this.YellowButton.UseVisualStyleBackColor = false;
            // 
            // GreenButton
            // 
            this.GreenButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.GreenButton.Location = new System.Drawing.Point(160, 49);
            this.GreenButton.Name = "GreenButton";
            this.GreenButton.Size = new System.Drawing.Size(68, 68);
            this.GreenButton.TabIndex = 3;
            this.GreenButton.Text = "Green";
            this.GreenButton.UseVisualStyleBackColor = false;
            // 
            // BlueButton
            // 
            this.BlueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BlueButton.Location = new System.Drawing.Point(12, 123);
            this.BlueButton.Name = "BlueButton";
            this.BlueButton.Size = new System.Drawing.Size(68, 68);
            this.BlueButton.TabIndex = 4;
            this.BlueButton.Text = "Blue";
            this.BlueButton.UseVisualStyleBackColor = false;
            // 
            // WhiteButton
            // 
            this.WhiteButton.BackColor = System.Drawing.Color.White;
            this.WhiteButton.Location = new System.Drawing.Point(86, 123);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(68, 68);
            this.WhiteButton.TabIndex = 5;
            this.WhiteButton.Text = "White";
            this.WhiteButton.UseVisualStyleBackColor = false;
            // 
            // OffButton
            // 
            this.OffButton.Location = new System.Drawing.Point(160, 123);
            this.OffButton.Name = "OffButton";
            this.OffButton.Size = new System.Drawing.Size(68, 68);
            this.OffButton.TabIndex = 6;
            this.OffButton.Text = "Off";
            this.OffButton.UseVisualStyleBackColor = true;
            // 
            // SlackPicker
            // 
            this.SlackPicker.Location = new System.Drawing.Point(12, 288);
            this.SlackPicker.Name = "SlackPicker";
            this.SlackPicker.Size = new System.Drawing.Size(150, 150);
            this.SlackPicker.TabIndex = 8;
            // 
            // SkypeForBusinessPicker
            // 
            this.SkypeForBusinessPicker.Location = new System.Drawing.Point(12, 221);
            this.SkypeForBusinessPicker.Name = "SkypeForBusinessPicker";
            this.SkypeForBusinessPicker.Size = new System.Drawing.Size(287, 37);
            this.SkypeForBusinessPicker.TabIndex = 7;
            // 
            // ManualColorPicker
            // 
            this.ManualColorPicker.Location = new System.Drawing.Point(12, 12);
            this.ManualColorPicker.Name = "ManualColorPicker";
            this.ManualColorPicker.Size = new System.Drawing.Size(289, 31);
            this.ManualColorPicker.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 447);
            this.Controls.Add(this.SlackPicker);
            this.Controls.Add(this.SkypeForBusinessPicker);
            this.Controls.Add(this.OffButton);
            this.Controls.Add(this.WhiteButton);
            this.Controls.Add(this.BlueButton);
            this.Controls.Add(this.GreenButton);
            this.Controls.Add(this.YellowButton);
            this.Controls.Add(this.RedButton);
            this.Controls.Add(this.ManualColorPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(330, 490);
            this.MinimumSize = new System.Drawing.Size(330, 490);
            this.Name = "MainWindow";
            this.Text = "Kuando Interface";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ColorPicker ManualColorPicker;
        private System.Windows.Forms.Button RedButton;
        private System.Windows.Forms.Button YellowButton;
        private System.Windows.Forms.Button GreenButton;
        private System.Windows.Forms.Button BlueButton;
        private System.Windows.Forms.Button WhiteButton;
        private System.Windows.Forms.Button OffButton;
        private Controls.SkypePicker SkypeForBusinessPicker;
        private Controls.SlackPicker SlackPicker;
    }
}