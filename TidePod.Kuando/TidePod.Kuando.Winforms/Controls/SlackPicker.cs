using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TidePod.Kuando.Slack;

namespace TidePod.Kuando.Winforms.Controls
{
    public partial class SlackPicker : UserControl
    {
        public SlackPicker()
        {
            InitializeComponent();
        }

        public event EventHandler<UserMentionEventArgs> OnUserMention;
    }
}
