using Saas.Business.Interface;
using Saas.DbLib.Interface;
using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Business.Implementation
{
    public class Subscription : ISubscription
    {
        private readonly ISubscriptionDbManager _subscriptionDbManager;

        public Subscription(ISubscriptionDbManager subscriptionDbManager)
        {
            _subscriptionDbManager = subscriptionDbManager;
        }

        public List<SubscriptionModel> GetAllSubscription()
        {
            var subscriptionDetails = _subscriptionDbManager.GetAllActiveSubscription();
            return subscriptionDetails;
        }

        public SubscribedModel AddSubscription(SubscribedModel subscribe)
        {
            subscribe.SubcriptionStartDate = DateTime.Now;
            subscribe.SubcriptionEndDate = subscribe.SubcriptionStartDate.AddYears(1);

            var subscribedUser = _subscriptionDbManager.InsertSubscription(subscribe);
            return subscribedUser;
        }

        public SubscribedModel ValidateSubscription(SubscribedModel subscribe)
        {
            
            var subscribedUser = _subscriptionDbManager.ValidateSubsription(subscribe);
            return subscribedUser;
        }
    }
}
