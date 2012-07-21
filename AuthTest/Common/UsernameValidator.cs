using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Diagnostics;

namespace Common
{
    public class UsernameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string sessionId)
        {

            if (HttpContext.Current.Request.Path.Contains("AuthService.svc"))
            {
                HttpContext.Current.Items["AppId"] = userName;
                return;
            }

            if (null == userName || null == sessionId)
            {
                throw new ArgumentNullException();
            }


            var r = new Sider.RedisClient<SessionRegistry>(); 
            var keys = r.Keys("*");
            if (keys.Contains(sessionId))
            {
                var stp = Stopwatch.StartNew();
                var session = r.Get(sessionId);
                stp.Stop();
                Debug.WriteLine(stp.ElapsedMilliseconds + " ms for redis key");
                if (session.AppId != userName)
                {
                    throw new FaultException("Token is not valid!");
                }
                HttpContext.Current.Items["AppId"] = session.AppId;
                HttpContext.Current.Items["UserId"] = session.UserId;
                //HttpContext.Current.Items["password"] = password;
            }
            else
            {
                throw new FaultException("There is no session!");
            }

            //if (!(userName == "mucit" && password == "pass") && !(userName == "test2" && password == "2tset"))
            //{
            //    // This throws an informative fault to the client.
            //    throw new FaultException("Unknown Username or Incorrect Password");
            //    // When you do not want to throw an infomative fault to the client,
            //    // throw the following exception.
            //    // throw new SecurityTokenException("Unknown Username or Incorrect Password");
            //}
        }
    }
}