using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models;
using TeamSite.Repositories.Implementations;

namespace TeamSite.Helpers
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));

        }

        public static CartRepository GetJson(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(CartRepository) : JsonConvert.DeserializeObject<CartRepository>(sessionData);
        }
    }
}

