using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void RetrieveAutomation(SoapClient soapClient,
            string iAutomationCustomerKey)
        {
            RetrieveRequest rr = new RetrieveRequest();
            rr.ObjectType = "Automation";

            SimpleFilterPart sf = new SimpleFilterPart();
            sf.Property = "CustomerKey";
            sf.SimpleOperator = SimpleOperators.equals;
            sf.Value = new String[] { iAutomationCustomerKey };
            rr.Filter = sf;

            rr.Properties = new string[] { "ObjectID", "Name", "Description", "Schedule.ID", "CustomerKey",  "IsActive", "CreatedDate",  "ModifiedDate", "Status"};

            string sStatus = "";
            string sRequestId = "";
            APIObject[] rResults;

            sStatus = soapClient.Retrieve(rr, out sRequestId, out rResults);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("RequestID: " + sRequestId);

            foreach (Automation automation in rResults)
            {
                Console.WriteLine("ObjectID: " + automation.ObjectID);
                Console.WriteLine("Name: " + automation.Name);
                Console.WriteLine("Description: " + automation.Description);
                if (automation.Schedule != null)
                {
                    Console.WriteLine("Schedule.ID: " + automation.Schedule.ID);
                }
                Console.WriteLine("CustomerKey: " + automation.CustomerKey);               
                Console.WriteLine("IsActive: " + automation.IsActive);
                Console.WriteLine("CreatedDate: " + automation.CreatedDate.ToString());
                Console.WriteLine("ModifiedDate: " + automation.ModifiedDate);
                Console.WriteLine("Status: " + automation.Status);
            }
        }
    }
}

