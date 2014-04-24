using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Configuration;
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
            binding.Security.Message.ClientCredentialType = 
                BasicHttpMessageCredentialType.UserName;
            binding.ReceiveTimeout = new TimeSpan(0, 5, 0);
            binding.OpenTimeout = new TimeSpan(0, 5, 0);
            binding.CloseTimeout = new TimeSpan(0, 5, 0);
            binding.SendTimeout = new TimeSpan(0, 5, 0);

            // Set the transport security to UsernameOverTransport for Plaintext usernames
            EndpointAddress endpoint = 
                new EndpointAddress("https://webservice.exacttarget.com/Service.asmx");

            // Create the SOAP Client (and pass in the endpoint and the binding)
            SoapClient soapClient = new SoapClient(binding, endpoint);

            // Username and Password are stored in the app.config file
            // Rename the app.config.template file in the project to app.config 
            // Replace the putUsernameHere and putPasswordHere with credentials from your account
            soapClient.ClientCredentials.UserName.UserName = 
                System.Configuration.ConfigurationManager.AppSettings["wsUserName"];
            soapClient.ClientCredentials.UserName.Password = 
                System.Configuration.ConfigurationManager.AppSettings["wsPassword"];

            ///
            /// Uncomment out the lines below in order to test the request you are interested in             
            ///
            //CreateTriggeredSend(soapClient, "ExampleTSD", "example@example.com", "Darth", "Vader");
            //CreateDateExtension(soapClient, "API Created DE Example - CSharp", "API Created DE Example - CSharp");
            //CreateImportDefinition(soapClient,"API Created ImportDefinition -CSharp", "APICreatedID", "API Created DE Example - CSharp","importexample.csv");
            //PerformImportDefinition(soapClient, "APICreatedID");
            //RetrieveImportResultsSummary(soapClient, "126572217");
            //CreateEmailSendDefinition(soapClient, "API Created EmailSendDefinition-CSharp", "API Created ESD-CSharp", 3113962, "2239", "ad36ce5a-7f1a-46ac-bcfe-e99027672e72");
            //PerformEmailSendDefinition(soapClient, "API Created ESD-CSharp");
            //RetrieveSend(soapClient, "11417771");
            //UpdateSubscriber(soapClient, "help@exacttarget.com", 1947888);
            //ExtractDataExtension(soapClient, "Bademails", "CSharpExtractDE.csv");
            //CreateAutomation(soapClient, "OnlyMac", "OnlyMac", "03770105-973c-e111-aaac-984be1783c78");
            //RetrieveAutomation(soapClient, "aa697ba2-3531-4c26-8669-20594a949145");
            PerformAutomation(soapClient, "8b6aea33-6f91-4556-bae3-794650b328eb");


            Console.WriteLine("Press enter to continue");
            Console.ReadLine();


        }
    }
}
