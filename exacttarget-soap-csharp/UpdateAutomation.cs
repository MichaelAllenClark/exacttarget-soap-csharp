using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void UpdateAutomation(SoapClient soapClient,
            string AutomationObjectID,
            string NewNameForAutomation)
        {
            Automation automation = new Automation();
            automation.ObjectID = AutomationObjectID;
            automation.Name = NewNameForAutomation;

            string RequestID = String.Empty;
            string OverallStatus = String.Empty;

            UpdateResult[] createResults = soapClient.Update(new UpdateOptions(), new APIObject[] { automation }, out RequestID, out OverallStatus);

            Console.WriteLine("Status: " + OverallStatus);
            foreach (UpdateResult ur in createResults)
            {                
                Console.WriteLine("StatusCode: " + ur.StatusCode);
                Console.WriteLine("ErrorCode: " + ur.ErrorCode);
                Console.WriteLine("StatusMessage: " + ur.StatusMessage);
            }
        }
    }
}
