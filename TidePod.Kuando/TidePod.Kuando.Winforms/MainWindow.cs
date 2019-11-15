using Busylight;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TidePod.Kuando.Skype;
using TidePod.Kuando.Slack;

namespace TidePod.Kuando.Winforms
{
    public partial class MainWindow : Form
    {
        private readonly TaskCompletionSource<int> exitTaskCompletionSource;
        private readonly SDK busylight;

        private ColorAdapter? lastHumanColor;

        public MainWindow()
        {
            InitializeComponent();
            this.busylight = new SDK();

            this.exitTaskCompletionSource = new TaskCompletionSource<int>();
            this.ExitTask = this.exitTaskCompletionSource.Task;

            this.FormClosed +=
                (_, _2) =>
                {
                    int returnCode = 0;
                    try
                    {
                        busylight.Terminate();
                    }
                    catch (Exception e)
                    {
                        returnCode = 1;
                    }
                    finally
                    {
                        this.exitTaskCompletionSource.SetResult(returnCode);
                    }
                };

            this.ManualColorPicker.OnColorSet +=
                (obj, color) =>
                {
                    this.HumanChangedColor(color);
                };

            this.RedButton.Click += (obj, e) => this.HumanChangedColor(ColorAdapter.Red);
            this.GreenButton.Click += (obj, e) => this.HumanChangedColor(ColorAdapter.Green);
            this.BlueButton.Click += (obj, e) => this.HumanChangedColor(ColorAdapter.Blue);
            this.YellowButton.Click += (obj, e) => this.HumanChangedColor(ColorAdapter.Yellow);
            this.WhiteButton.Click += (obj, e) => this.HumanChangedColor(ColorAdapter.White);
            this.OffButton.Click += (obj, e) => this.HumanChangedColor(ColorAdapter.Off);

            this.SkypeForBusinessPicker.OnUserStateChange += this.SkypeStatusChanged;

            this.SlackPicker.OnUserMention += this.SlackUserMentioned;

            this.lastHumanColor = null;
        }

        public Task<int> ExitTask { get; }

        private void HumanChangedColor(ColorAdapter adapter)
        {
            this.lastHumanColor = adapter;
            this.ChangeColor(adapter);
        }

        private void ComputerWantsToTakeControl(ColorAdapter adapter)
        {
            this.ChangeColor(adapter);
        }

        private void ComputerWantsToGiveBackControl(ColorAdapter fallback)
        {
            this.ChangeColor(
                this.lastHumanColor.HasValue
                    ? this.lastHumanColor.Value
                    : ColorAdapter.Green);
        }

        private void ChangeColor(ColorAdapter adapter)
        {
            this.UpdateColorPicker(adapter);
            this.busylight.Light(adapter);
        }

        private void UpdateColorPicker(ColorAdapter adapter)
        {
            this.ManualColorPicker.SetDisplayedColor(adapter.SystemColor.R, adapter.SystemColor.G, adapter.SystemColor.B);
        }

        private void SkypeStatusChanged(object sender, UserState e)
        {
            switch (e)
            {
                case UserState.Available:
                    this.ComputerWantsToGiveBackControl(ColorAdapter.Green);
                    break;
                case UserState.Away:
                case UserState.Inactive:
                    this.ComputerWantsToTakeControl(ColorAdapter.Yellow);
                    break;
                case UserState.BeRightBack:
                    this.ComputerWantsToTakeControl(ColorAdapter.Citron);
                    break;
                case UserState.Busy:
                    this.ComputerWantsToTakeControl(ColorAdapter.Orange);
                    break;
                case UserState.DoNotDisturb:
                case UserState.InCall:
                case UserState.InConferenceCall:
                case UserState.InMeeting:
                case UserState.Presenting:
                    this.ComputerWantsToTakeControl(ColorAdapter.Red);
                    break;
                case UserState.OffWork:
                    this.ComputerWantsToTakeControl(ColorAdapter.Off);
                    break;
                default:
                    throw new InvalidOperationException("Unrecognized UserState.");
            }
        }

        private void SlackUserMentioned(object sender, UserMentionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
