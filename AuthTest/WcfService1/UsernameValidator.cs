using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Diagnostics;

namespace AuthService
{
    public class UsernameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }


            var r = new Sider.RedisClient<string>(); 
            var keys = r.Keys("*");
            if (keys.Contains(userName))
            {
                var stp = Stopwatch.StartNew();
                var pass = r.Get(userName);
                stp.Stop();
                Debug.WriteLine(stp.ElapsedMilliseconds + " ms for redis key");
                if (pass != password)
                {
                    throw new FaultException("Token is not valid!");
                }
                HttpContext.Current.Items["userName"] = userName;
                HttpContext.Current.Items["password"] = password;
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