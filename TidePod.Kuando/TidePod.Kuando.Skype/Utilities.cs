namespace TidePod.Kuando.Skype
{
    internal static class Utilities
    {
        public static bool TryParseUserState(string activity, out UserState state)
        {
            switch (activity)
            {
                case "Away":
                    state = UserState.Away;
                    return true;
                case "Available":
                    state = UserState.Available;
                    return true;
                case "Be right back":
                    state = UserState.BeRightBack;
                    return true;
                case "Busy":
                    state = UserState.Busy;
                    return true;
                case "Do not disturb":
                    state = UserState.DoNotDisturb;
                    return true;
                case "Inactive":
                    state = UserState.Inactive;
                    return true;
                case "In a call":
                    state = UserState.InCall;
                    return true;
                case "In a conference call":
                    state = UserState.InConferenceCall;
                    return true;
                case "In a meeting":
                    state = UserState.InMeeting;
                    return true;
                case "Off work":
                    state = UserState.OffWork;
                    return true;
            }

            state = default;
            return false;
        }
    }
}
