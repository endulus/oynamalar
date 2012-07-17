﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AuthService
{
    [ServiceContract]
    public interface ITokenService
    {
        [OperationContract]
        string CreateToken(string userName, string password);
    }
}
