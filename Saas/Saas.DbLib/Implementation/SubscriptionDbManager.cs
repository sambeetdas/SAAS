using Saas.DbLib.Interface;
using Saas.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saas.DbLib.Implementation
{
    public class SubscriptionDbManager : ISubscriptionDbManager
    {
        private readonly string _sqlConnectionStr;
        public SubscriptionDbManager(string sqlConnectionStr)
        {
            _sqlConnectionStr = sqlConnectionStr;
        }

        public List<SubscriptionModel> GetAllActiveSubscription()
        {
            List<SubscriptionModel> result = new List<SubscriptionModel>();
            try
            {
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.SubscriptionModel.Where(i => i.Status.ToUpper() == "A").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public SubscribedModel InsertSubscription(SubscribedModel subscribe)
        {
            try
            {
                var subscribedUser = GetsubscriptionForUser(subscribe.SubscribedEmail, subscribe.SubscribedPhone);
                if (subscribedUser == null)
                {
                    using (var context = new SaasDbContext(_sqlConnectionStr))
                    {
                        context.Add<SubscribedModel>(subscribe);
                        context.SaveChanges();
                    }

                    return subscribe;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public SubscribedModel GetsubscriptionForUser(string email, string phone)
        {
            dynamic result = null;
            try
            {
                using (var context = new SaasDbContext(_sqlConnectionStr))
                {
                    result = context.SubscribedModel.FirstOrDefault(i => i.SubscribedEmail.ToUpper() == email.ToUpper() && i.SubscribedPhone == phone);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
