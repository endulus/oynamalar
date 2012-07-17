using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AuthService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class TokenService : ITokenService
    {
        public static Dictionary<string, string> TokenDictionary = new Dictionary<string, string>();


        public string CreateToken(string userName, string password)
        {
            if (userName == "mucit" && password == "pass")
            {
                var guid = Guid.NewGuid().ToString();

                Sider.RedisClient<string> c = new Sider.RedisClient<string>();
                c.Set(userName, guid);



                //TokenDictionary["mucit"] = guid;
                return guid;
            }
            return string.Empty;
        }
    }
}
