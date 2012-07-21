using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    [Serializable]
    public class AppRegistry
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string FriendlyName { get; set; }
    }

    [Serializable]
    public class SessionRegistry
    {
        public string SessionCookie { get; set; }
        public string UserId { get; set; }
        public string AppId { get; set; }
        public string Age { get; set; }
        public DateTime CreateTime { get; set; }
    
    }

    [Serializable]
    public class TransferToken
    {
        public string AppId { get; set; }
        public string UserId { get; set; }
        public string ExpireTime { get; set; }
    }
}
