using System;
using System.Windows.Forms;

namespace TidePod.Kuando.Winforms.Controls
{
    public partial class ColorPicker : UserControl
    {
        private bool triggeringChangeInternally;

        private byte previousRed;
        private byte previousGreen;
        private byte previousBlue;

        public ColorPicker()
        {
            InitializeComponent();

            this.triggeringChangeInternally = false;

            this.Red = 0;
            this.Green = 0;
            this.Blue = 0;

            this.previousRed = this.Red;
            this.redTextBox.Text = this.previousRed.ToString();
            this.redTextBox.TextChanged += (obj, e) => this.HandleRedChange();
            this.redTextBox.KeyPress += (obj, e) => this.HandleInput(e, this.TriggerColorChange);

            this.previousGreen = this.Green;
            this.greenTextBox.Text = this.previousGreen.ToString();
            this.greenTextBox.TextChanged += (obj, e) => this.HandleGreenChange();
            this.greenTextBox.KeyPress += (obj, e) => this.HandleInput(e, this.TriggerColorChange);

            this.previousBlue = this.Blue;
            this.blueTextBox.Text = this.previousBlue.ToString();
            this.blueTextBox.TextChanged += (obj, e) => this.HandleBlueChange();
            this.blueTextBox.KeyPress += (obj, e) => this.HandleInput(e, this.TriggerColorChange);

            this.SetButton.Click += (obj, e) => this.TriggerColorChange();

            this.OnColorSet += (obj, e) => this.LastSelected = e;

            this.SetColorPreview(this.previousRed, this.previousGreen, this.previousBlue);
        }

        public event EventHandler<ColorAdapter> OnColorSet;

        public ColorAdapter LastSelected { get; private set; }

        private byte Red { get; set; }

        private byte Green { get; set; }

        private byte Blue { get; set; }

        public void SetDisplayedColor(byte red, byte green, byte blue)
        {
            if (this.InvokeRequired)
            {
                SetDisplayedColorCallback callback = new SetDisplayedColorCallback(this.SetDisplayedColorInternal);
                this.Invoke(callback, red, green, blue);
            }
            else
            {
                this.SetDisplayedColorInternal(red, green, blue);
            }
        }

        private delegate void SetDisplayedColorCallback(byte red, byte green, byte blue);

        private void SetDisplayedColorInternal(byte red, byte green, byte blue)
        {
            this.triggeringChangeInternally = true;

            this.Red = red;
            this.Green = green;
            this.Blue = blue;

            this.previousRed = red;
            this.previousGreen = green;
            this.previousBlue = blue;

            this.redTextBox.Text = red.ToString();
            this.greenTextBox.Text = green.ToString();
            this.blueTextBox.Text = blue.ToString();

            this.SetColorPreview(this.Red, this.Green, this.Blue);

            this.triggeringChangeInternally = false;
        }

        private void HandleInput(KeyPressEventArgs args, Action onEnter)
        {
            if (args.KeyChar == (char)13)
            {
                onEnter.Invoke();
                args.Handled = true;
            }
        }

        private void TriggerColorChange()
        {
            if (this.triggeringChangeInternally)
            {
                return;
            }

            this.Red = this.previousRed;
            this.Green = this.previousGreen;
            this.Blue = this.previousBlue;

            this.OnColorSet?.Invoke(this, new ColorAdapter(this.Red, this.Green, this.Blue));
        }

        private void HandleRedChange()
        {
            if (this.triggeringChangeInternally)
            {
                return;
            }

            if (byte.TryParse(this.redTextBox.Text, out byte newRed))
            {
                this.SetColorPreview(newRed, this.previousGreen, this.previousBlue);

                this.previousRed = newRed;
            }
        }

        private void HandleGreenChange()
        {
            if (this.triggeringChangeInternally)
            {
                return;
            }

            if (byte.TryParse(this.greenTextBox.Text, out byte newGreen))
            {
                this.SetColorPreview(this.previousRed, newGreen, this.previousBlue);

                this.previousGreen = newGreen;
            }
        }

        private void HandleBlueChange()
        {
            if (this.triggeringChangeInternally)
            {
                return;
            }

            if (byte.TryParse(this.blueTextBox.Text, out byte newBlue))
            {
                this.SetColorPreview(this.previousRed, this.previousGreen, newBlue);

                this.previousBlue = newBlue;
            }
        }

        private void SetColorPreview(byte red, byte green, byte blue)
        {
            if (this.InvokeRequired)
            {
                SetColorPreviewCallback callback = new SetColorPreviewCallback(this.SetColorPreviewInternal);
                this.Invoke(callback, red, green, blue);
            }
            else
            {
                this.SetColorPreviewInternal(red, green, blue);
            }
        }

        private delegate void SetColorPreviewCallback(byte red, byte green, byte blue);

        private void SetColorPreviewInternal(byte red, byte green, byte blue)
        {
            this.ColorPreviewPanel.BackColor = new ColorAdapter(red, green, blue);
        }
    }
}
