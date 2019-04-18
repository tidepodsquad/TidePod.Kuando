using System;
using System.Windows.Forms;
using TidePod.Kuando.Skype;

namespace TidePod.Kuando.Winforms.Controls
{
    public partial class SkypePicker : UserControl
    {
        private readonly SkypeClient skypeClient;

        private SkypeUser? user;
        private string lastUser;

        public SkypePicker()
        {
            InitializeComponent();

            this.skypeClient = new SkypeClient();

            this.user = null;
            this.lastUser = this.txtEmail.Text;
            this.EventsEnabled = false;
        }

        public event EventHandler<UserState> OnUserStateChange;

        private bool EventsEnabled { get; set; }

        private async void CkbEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEnabled.Checked)
            {
                this.EventsEnabled = true;
                if (this.user == null || this.lastUser != this.txtEmail.Text)
                {
                    this.user = await this.skypeClient.FindUser(this.txtEmail.Text);
                    this.user.OnStateChanged +=
                        (obj, e) =>
                        {
                            if (this.EventsEnabled)
                            {
                                this.OnUserStateChange?.Invoke(this, e.State);
                            }
                        };
                    this.OnUserStateChange?.Invoke(this, this.user.State);
                }
            }
            else
            {
                this.EventsEnabled = false;
            }
        }
    }
}
