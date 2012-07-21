using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel.Description;
using System.ServiceModel;
using AuthClient.AuthServiceNs;
using AuthClient.LogicServiceNS;
using Common;
using AuthClient.TransferServiceNs;


namespace AuthClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //LogicServiceNS.LogicServiceClient cx = new LogicServiceClient();
            //cx.ClientCredentials.UserName.UserName = "hasan";
            //cx.ClientCredentials.UserName.Password = "obali";
            //cx.DoWork();


            TokenService.TokenServiceClient c = new TokenService.TokenServiceClient();
            string token = c.CreateToken("mucit", "pass");


            TestService.TestServiceClient t = new TestService.TestServiceClient();
            t.ClientCredentials.UserName.UserName = "mucit";
            t.ClientCredentials.UserName.Password = token;
            using (var s = new OperationContextScope(t.InnerChannel))
            {
                AddHeader();
                t.GetData(12);
            }
            
        }

        private static void AddHeader()
        {
            var header = new MessageHeader<string>(new Random().Next(12345, 999999).ToString(CultureInfo.InvariantCulture));
            var untyped = header.GetUntypedHeader("Nonce", "http://mucit.us/");
            OperationContext.Current.OutgoingMessageHeaders.Add(untyped);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var c = new AuthServiceClient();
            c.ClientCredentials.UserName.UserName = "dombala";
            c.ClientCredentials.UserName.Password = "none";
            var sessionId = c.Logon("mucit", "endulus", "normal");

            var t = new TransferServiceClient();
            t.ClientCredentials.UserName.UserName = "dombala";
            t.ClientCredentials.UserName.Password = sessionId;
            var transferToken = t.Transfer("byshocala", "");

            Process.Start("http://localhost:30160/?u="+ "mucit" +"&" + transferToken);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var r = new Sider.RedisClient<Common.AppRegistry>();
            r.Select(1);
            r.Set("byshocala", new AppRegistry() { AppId = "byshocala", AppSecret = "{5D6864C7-1B17-46D4-9733-09B735233717}", FriendlyName = "Bys" });
            r.Set("dombala", new AppRegistry() { AppId = "dombala", AppSecret = "{9316D3C6-F805-41FE-9299-F844F5263EA1}", FriendlyName = "Bys" });
        }

        

    }
}
