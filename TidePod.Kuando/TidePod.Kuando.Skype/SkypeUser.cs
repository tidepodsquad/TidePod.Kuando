using System;
using Microsoft.Lync.Model;

namespace TidePod.Kuando.Skype
{
    public class SkypeUser
    {
        private UserState _state;

        internal SkypeUser(Contact underlyingContact)
        {
            this.Contact = underlyingContact;
            if (this.Contact.GetContactInformation(ContactInformationType.Activity) is string activity
                && Utilities.TryParseUserState(activity, out UserState state))
            {
                this.State = state;
            }
            else
            {
                throw new ArgumentException("Specified user has invalid Activity.");
            }

            this.Contact.ContactInformationChanged +=
                (obj, e) =>
                {
                    if (e.ChangedContactInformation.Contains(ContactInformationType.Activity))
                    {
                        if (this.Contact.GetContactInformation(ContactInformationType.Activity) is string activity
                            && Utilities.TryParseUserState(activity, out UserState state))
                        {
                            this.State = state;
                        }
                        else
                        {
                            throw new ArgumentException("Specified user has invalid Activity.");
                        }
                    }
                };
        }

        public event EventHandler<StateChangeEventArgs> OnStateChanged;

        public UserState State
        {
            get => this._state;
            set
            {
                this._state = value;
                this.OnStateChanged?.Invoke(this, new StateChangeEventArgs(value));
            }
        }

        internal Contact Contact { get; }
    }
}
