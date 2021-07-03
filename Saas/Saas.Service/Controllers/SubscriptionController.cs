using Microsoft.AspNetCore.Mvc;
using Saas.Business.Interface;
using Saas.DbLib.Interface;
using Saas.Model.Core;
using Saas.Model.Service;
using Saas.Script.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Saas.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly ISubscription _subscription;

        public SubscriptionController(ISubscription subscription)
        {
            _subscription = subscription;
        }

        [HttpGet]
        public List<SubscriptionModel> GetAllSubscription()
        {
            var subscriptionDetails = _subscription.GetAllSubscription();
            return subscriptionDetails;
        }
        
        [HttpPost]
        public SubscribedModel AddSubscription([FromBody] SubscribedModel subscribe)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid Model");
            }
            var subscribedUser = _subscription.AddSubscription(subscribe);
            return subscribedUser;
        }

        [HttpPost]
        public SubscribedModel ValidateSubscription([FromBody] SubscribedModel subscribe)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid Model");
            }
            var subscribedUser = _subscription.ValidateSubscription(subscribe);
            return subscribedUser;
        }
    }
}
