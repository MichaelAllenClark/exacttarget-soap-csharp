using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void CreateAutomation(SoapClient soapClient,
            string iEmailSendDefinitionName,
            string iEmailSendDefinitionCustomerKey,
            string iEmailSendDefinitionObjectID)
        {
            Automation automation = new Automation();
            automation.Name = "SOAPAPI Test2_" + Guid.NewGuid().ToString();
            // CustomerKey can be any string value, GUID is only used for example purposes 
            automation.CustomerKey = Guid.NewGuid().ToString();
            automation.Description = "SOAP API Created Example";
            automation.AutomationType = "scheduled";

            AutomationActivity activityOne = new AutomationActivity();
            activityOne = new AutomationActivity();
            // This is the ObjectID of the Definition Object
            activityOne.ObjectID = iEmailSendDefinitionObjectID;
            // This is the Name of the Definition Object
            activityOne.Name = iEmailSendDefinitionName;
            activityOne.Definition = new APIObject();
            EmailSendDefinition activityOneDefinition = new EmailSendDefinition();

            // Again this is the ObjectID of the Definition Object
            activityOneDefinition.ObjectID = iEmailSendDefinitionObjectID;
            // Again this is the Name of the Definition Object
            activityOneDefinition.Name = iEmailSendDefinitionName;
            activityOneDefinition.CustomerKey = iEmailSendDefinitionCustomerKey;

            activityOne.ActivityObject = activityOneDefinition;
            AutomationTask taskOne = new AutomationTask();
            taskOne.Name = "Task 1";
            taskOne.Activities = new AutomationActivity[] { activityOne };
            automation.AutomationTasks = new AutomationTask[] { taskOne };

            string RequestID = String.Empty;
            string OverallStatus = String.Empty;

            CreateResult[] createResults = soapClient.Create(new CreateOptions(), new APIObject[] { automation }, out RequestID, out OverallStatus);

            Console.WriteLine("Status: " + OverallStatus);
            foreach (CreateResult cr in createResults)
            {
                Console.WriteLine("NewObjectID: " + cr.NewObjectID);
                Console.WriteLine("StatusCode: " + cr.StatusCode);
                Console.WriteLine("ErrorCode: " + cr.ErrorCode);
                Console.WriteLine("StatusMessage: " + cr.StatusMessage);
            }         
        }
    }
}
