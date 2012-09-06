using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void CreateTriggeredSend(SoapClient soapClient, 
            string iTriggeredSendCustomerKey, 
            string iEmailAddress, 
            string iFirstName, 
            string iLastName) 
        {
            TriggeredSend ts = new TriggeredSend();
            TriggeredSendDefinition tsd = new TriggeredSendDefinition();
            tsd.CustomerKey = iTriggeredSendCustomerKey;
            ts.TriggeredSendDefinition = tsd;

            Subscriber sub = new Subscriber();
            sub.EmailAddress = iEmailAddress;
            sub.SubscriberKey = iEmailAddress;

            ExactTargetSOAPAPI.Attribute firstName = new ExactTargetSOAPAPI.Attribute();
            firstName.Name = "First Name";
            firstName.Value = iFirstName;

            ExactTargetSOAPAPI.Attribute lastName = new ExactTargetSOAPAPI.Attribute();
            lastName.Name = "Last Name";
            lastName.Value = iLastName;

            sub.Attributes = new ExactTargetSOAPAPI.Attribute[] { firstName, lastName };

            ts.Subscribers = new Subscriber[] { sub };

            string sStatus = "";
            string sRequestId = "";

            CreateResult[] aoResults = 
                soapClient.Create(new CreateOptions(), new APIObject[] { ts }, out sRequestId, out sStatus);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("Request ID: " + sRequestId);
            foreach (TriggeredSendCreateResult tscr in aoResults)
            {
                if (tscr.SubscriberFailures != null)
                {
                    foreach (SubscriberResult sr in tscr.SubscriberFailures)
                    {
                        Console.WriteLine("ErrorCode: " + sr.ErrorCode);
                        Console.WriteLine("ErrorDescription: " + sr.ErrorDescription);
                    }
                }
            }
        }
    }
}
