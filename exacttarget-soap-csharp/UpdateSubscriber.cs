using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void UpdateSubscriber(SoapClient soapClient,
            string iEmailAddress,
            int iListID)
        {

            Subscriber sub = new Subscriber();
            sub.EmailAddress = iEmailAddress;

            // Define the SubscriberList and set the status to Active
            SubscriberList subList = new SubscriberList();
            subList.ID = iListID;
            subList.IDSpecified = true;
            subList.Status = SubscriberStatus.Active;
            // If no Action is specified at the SubscriberList level, the default action is to
            // update the subscriber if they already exist and create them if they do not.
            // subList.Action = "create";

            //Relate the SubscriberList defined to the Subscriber
            sub.Lists = new SubscriberList[] { subList };

            string sStatus = "";
            string sRequestId = "";

            UpdateResult[] uResults =
                soapClient.Update(new UpdateOptions(), new APIObject[] { sub }, out sRequestId, out sStatus);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("Request ID: " + sRequestId);
            foreach (UpdateResult ur in uResults)
            {
                Console.WriteLine("StatusCode: " + ur.StatusCode);
                Console.WriteLine("StatusMessage: " + ur.StatusMessage);
                Console.WriteLine("ErrorCode: " + ur.ErrorCode);
            }
        }
    }
}
