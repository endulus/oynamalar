using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using Sider;
using Common;

namespace AuthService.CoreModel
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TransferService" in code, svc and config file together.
    public class TransferService : ITransferService
    {

        public string Transfer(string targetAppId, string transferToken)
        {
            
            NameValueCollection nv = new NameValueCollection();
            nv["AppId"] = targetAppId;
            nv["Secret"] = Guid.NewGuid().ToString();
            nv["ExpireAt"] = DateTime.Now.AddMinutes(3).ToLongTimeString();

            var redis = new RedisClient<AppRegistry>();
            redis.Select(1);
            var app = redis.Get(targetAppId);

            string token = "AppId=" + targetAppId + "&UserId=" + HttpContext.Current.Items["UserId"]  + "&Secret=" + Guid.NewGuid().ToString() + "&ExpireAt=" + DateTime.Now.AddMinutes(3).ToLongTimeString();
            string transferId = Guid.NewGuid().ToString();
            string token2 = "UserId=" + HttpContext.Current.Items["UserId"] + "&TransferId=" + transferId + "&Salt=" + app.AppSecret;
            token2 = Common.Hash.GetHash(token2, Hash.HashType.SHA256);

            token = Common.Crypto.EncryptStringAES(token, app.AppSecret);

            var red = new RedisClient<string>();
            red.Set("transfertoken:" + transferId, token2);
            //red.ExpireAt("transfertoken:" + token, DateTime.Now.AddMinutes(1));

            return "tid=" + transferId + "&tkn=" + token2;
        }

        
    }
}
