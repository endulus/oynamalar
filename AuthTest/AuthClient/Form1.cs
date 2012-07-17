using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel.Description;
using System.ServiceModel;

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
            TokenService.TokenServiceClient c = new TokenService.TokenServiceClient();
            string token = c.CreateToken("mucit", "pass");


            TestService.TestServiceClient t = new TestService.TestServiceClient();
            t.ClientCredentials.UserName.UserName = "mucit";
            t.ClientCredentials.UserName.Password = token;
            using (OperationContextScope s = new OperationContextScope(t.InnerChannel))
            {
                AddHeader();
                t.GetData(12);
            }
            
        }

        private static void AddHeader()
        {
            MessageHeader<string> header = new MessageHeader<string>(new Random().Next(12345, 999999).ToString());
            var untyped = header.GetUntypedHeader("Nonce", "http://mucit.us/");
            OperationContext.Current.OutgoingMessageHeaders.Add(untyped);
        }
    }
}
