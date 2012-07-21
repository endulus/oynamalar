using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AuthService.CoreModel
{
    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract] // u:appId p:<nil>
        string Logon(string username, string password, string mode);

        [OperationContract] // u:appId
        string ValidateTransfer(string sourceAppId, string userId, string transferId, string transferToken);
    }
}
