using System;

namespace TidePod.Kuando.Skype
{
    public class StateChangeEventArgs : EventArgs
    {
        internal StateChangeEventArgs(UserState state)
        {
            this.State = state;
        }

        public UserState State { get; }
    }
}
