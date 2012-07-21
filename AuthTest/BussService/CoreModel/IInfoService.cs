using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AuthService.CoreModel
{
    [ServiceContract]
    public interface IInfoService
    {
        [OperationContract]
        string GetSomeInformation(string param1);
    }
}
