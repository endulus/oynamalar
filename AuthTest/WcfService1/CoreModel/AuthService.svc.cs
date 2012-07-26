using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Common;
using Sider;

namespace AuthService.CoreModel
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class AuthService : IAuthService
    {

        public string Logon(string username, string password, string mode)
        {
            if (username == "mucit" && password == "endulus")
            {
                string sessionguid = Guid.NewGuid().ToString();
                var redis = new RedisClient<Common.SessionRegistry>();
                var appId = HttpContext.Current.Items["AppId"] as string;
                redis.Set(sessionguid, new SessionRegistry() {SessionCookie=sessionguid, AppId=appId, UserId=username});
                return sessionguid;
            }
            else throw new FaultException<UnauthorizedAccessException>(new UnauthorizedAccessException("şifre yanlış"));
        }

        public string ValidateTransfer(string sourceAppId, string userId, string transferId, string transferToken)
        {
            var red = new RedisClient<string>();
            var result = red.Get("transfertoken:" + transferId);
            if (!string.IsNullOrEmpty(result))
            {
                var redResult = red.Del("transfertoken:" + transferId);

                var redapp = new RedisClient<AppRegistry>();
                redapp.Select(1);
                var app = redapp.Get(HttpContext.Current.Items["AppId"] as string);

                var str = "UserId=" + userId + "&TransferId=" + transferId + "&Salt=" + app.AppSecret ;
                str = Hash.GetHash(str, Hash.HashType.SHA256);

                if (transferToken != str)
                {
                    throw new FaultException<UnauthorizedAccessException>(new UnauthorizedAccessException("token yanlış"));
                }


                string sessionguid = Guid.NewGuid().ToString();
                var redis = new RedisClient<Common.SessionRegistry>();
                var appId = HttpContext.Current.Items["AppId"] as string;
                redis.Set(sessionguid, new SessionRegistry() { SessionCookie = sessionguid, AppId = appId, UserId = userId });
                return sessionguid;
            }
            return null;
        }
    }
}
