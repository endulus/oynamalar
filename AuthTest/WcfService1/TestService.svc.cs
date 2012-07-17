using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace AuthService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class TestService : ITestService
    {
        public string GetData(int value)
        {

            ServiceReference1.LogicServiceClient c = new ServiceReference1.LogicServiceClient();
            c.ClientCredentials.UserName.UserName = HttpContext.Current.Items["userName"].ToString();
            c.ClientCredentials.UserName.Password = HttpContext.Current.Items["password"].ToString();
            c.DoWork();

            return string.Format("You entered: {0}", value);


        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
