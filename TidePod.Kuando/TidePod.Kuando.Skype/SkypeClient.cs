using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;

namespace TidePod.Kuando.Skype
{
    public class SkypeClient
    {
        private readonly LyncClient client;

        private ContactSubscription? subscription;

        public SkypeClient()
        {
            this.client = LyncClient.GetClient();
            this.subscription = null;
        }

        public async Task<SkypeUser> FindUser(string userEmail)
        {
            ContactManager manager = client.ContactManager;
            TaskCompletionSource<SearchResults> resultTaskCompletionSource = new TaskCompletionSource<SearchResults>();
            manager.BeginSearch(
                userEmail,
                SearchProviders.Default,
                SearchFields.EmailAddresses,
                SearchOptions.ContactsOnly,
                64,
                (x) =>
                {
                    try
                    {
                        if (x.IsCompleted)
                        {
                            resultTaskCompletionSource.SetResult(manager.EndSearch(x));
                            return;
                        }
                        else
                        {
                            resultTaskCompletionSource.SetException(
                                new InvalidOperationException("Callback was raised but search wasn't finished."));
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        resultTaskCompletionSource.SetException(e);
                        return;
                    }
                },
                null);

            SearchResults results = await resultTaskCompletionSource.Task;
            if (results.Contacts.Count == 1)
            {
                SkypeUser user = new SkypeUser(results.Contacts[0]);
                this.AddUserToSubscription(user);

                return user;
            }
            else
            {
                throw new InvalidOperationException("Multiple users were found with the specified email.");
            }
        }

        private void AddUserToSubscription(SkypeUser skypeUser)
        {
            bool hadNoExistingSubscription = false;
            if (this.subscription == null)
            {
                this.subscription = this.client.ContactManager.CreateSubscription();
                hadNoExistingSubscription = true;
            }

            this.subscription.AddContact(skypeUser.Contact);

            if (hadNoExistingSubscription)
            {
                this.subscription.Subscribe(
                    ContactSubscriptionRefreshRate.High,
                    new ContactInformationType[] { ContactInformationType.Activity });
            }
        }
    }
}
