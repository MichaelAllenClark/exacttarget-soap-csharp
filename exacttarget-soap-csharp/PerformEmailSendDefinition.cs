using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void PerformEmailSendDefinition(SoapClient soapClient,
            string EmailSendDefinitionCustomerKey)
        {
            EmailSendDefinition esd = new EmailSendDefinition();
            esd.CustomerKey = EmailSendDefinitionCustomerKey;

            string sStatus = "";
            string sStatusMessage = "";
            string sRequestId = "";

            PerformResult[] pResults = soapClient.Perform(new PerformOptions(), "start", new APIObject[] { esd }, out sStatus, out sStatusMessage, out sRequestId);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("Status Message: " + sStatusMessage);
            Console.WriteLine("Request ID: " + sRequestId);

            foreach (PerformResult pr in pResults)
            {
                // Task.ID Value is the JobID of the send that is initiated 
                Console.WriteLine("TaskID: " + pr.Task.ID);
                Console.WriteLine("StatusCode: " + pr.StatusCode);
                Console.WriteLine("ErrorCode: " + pr.ErrorCode);
                Console.WriteLine("StatusMessage: " + pr.StatusMessage);
            }
        }
    }
}
