using Microsoft.AspNetCore.Mvc;
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
        private readonly ISubscriptionDbManager _subscriptionDbManager;

        public SubscriptionController(ISubscriptionDbManager subscriptionDbManager)
        {
            _subscriptionDbManager = subscriptionDbManager;
        }

        [HttpGet]
        public List<SubscriptionModel> GetAllSubscription()
        {
            var serviceDetails = _subscriptionDbManager.GetAllActiveSubscription();
            return serviceDetails;
        }
        
        [HttpPost]
        public SubscribedModel AddSubscription([FromBody] SubscribedModel subscribe)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid Model");
            }

            subscribe.SubcriptionStartDate = DateTime.Now;
            subscribe.SubcriptionEndDate = subscribe.SubcriptionStartDate.AddYears(1);

            var subscribedUser = _subscriptionDbManager.InsertSubscription(subscribe);
            return subscribedUser;
        }

        [HttpPost]
        public SubscribedModel ValidateSubscription([FromBody] SubscribedModel subscribe)
        {
            if (!ModelState.IsValid)
            {
                throw new ValidationException("Invalid Model");
            }
            var subscribedUser = _subscriptionDbManager.ValidateSubsription(subscribe);
            return subscribedUser;
        }
    }
}
