using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        static void Main(string[] args)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "UserNameSoapBinding";
            binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.ReceiveTimeout = new TimeSpan(0, 5, 0);
            binding.OpenTimeout = new TimeSpan(0, 5, 0);
            binding.CloseTimeout = new TimeSpan(0, 5, 0);
            binding.SendTimeout = new TimeSpan(0, 5, 0);

            // Set the transport security to UsernameOverTransport for Plaintext usernames
            EndpointAddress endpoint = new EndpointAddress("https://webservice.exacttarget.com/Service.asmx");

            // Create the SOAP Client (and pass in the endpoint and the binding)
            SoapClient soapClient = new SoapClient(binding, endpoint);


            Console.WriteLine("Please enter API username");
            string username = Console.ReadLine();

            Console.WriteLine("Please enter API password");
            string password = Console.ReadLine();

            // Set the username and password
            soapClient.ClientCredentials.UserName.UserName = username;
            soapClient.ClientCredentials.UserName.Password = password;
            
            CreateTriggeredSend(soapClient);

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();


        }
    }
}
