using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.DbLib.Interface
{
    public interface ISubscriptionDbManager
    {
        List<SubscriptionModel> GetAllActiveSubscription();
        SubscribedModel InsertSubscription(SubscribedModel subscribe);
        SubscribedModel GetsubscriptionForUser(string email, string phone);
        SubscribedModel ValidateSubsription(SubscribedModel subscribe);
    }
}
