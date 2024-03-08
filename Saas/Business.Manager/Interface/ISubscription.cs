using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Business.Interface
{
    public interface ISubscription
    {
        List<SubscriptionModel> GetAllSubscription();
        SubscribedModel AddSubscription(SubscribedModel subscribe);
        SubscribedModel ValidateSubscription(SubscribedModel subscribe);
    }
}
