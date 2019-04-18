using System;

namespace TidePod.Kuando.Slack
{
    public class UserMentionEventArgs : EventArgs
    {
        public SlackUser MentionedBy { get; }
    }
}
