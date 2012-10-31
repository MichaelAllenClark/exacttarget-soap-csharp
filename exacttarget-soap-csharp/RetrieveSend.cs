using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void RetrieveSend(SoapClient soapClient,
            string JobID)
        {
            RetrieveRequest rr = new RetrieveRequest();

            rr.ObjectType = "Send";

            SimpleFilterPart sf = new SimpleFilterPart();
            sf.Property = "ID";
            sf.SimpleOperator = SimpleOperators.equals;
            sf.Value = new String[] { JobID };
            rr.Filter = sf;

            rr.Properties = new string[] { "ID", "SendDate", "NumberSent", "NumberDelivered", "HardBounces", "SoftBounces", "OtherBounces", "Unsubscribes", "Status" };

            string sStatus = "";
            string sRequestId = "";
            APIObject[] rResults;

            sStatus = soapClient.Retrieve(rr, out sRequestId, out rResults);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("RequestID: " + sRequestId);

            foreach (Send s in rResults)
            {                                
                Console.WriteLine("ID (JobID): " + s.ID);
                Console.WriteLine("SendDate: " + s.SendDate.ToString());
                Console.WriteLine("NumberSent: " + s.NumberSent);
                Console.WriteLine("NumberDelivered: " + s.NumberDelivered);
                Console.WriteLine("SoftBounces: " + s.SoftBounces);
                Console.WriteLine("OtherBounces: " + s.OtherBounces);
                Console.WriteLine("Unsubscribes: " + s.Unsubscribes);
                Console.WriteLine("Status: " + s.Status);
            }

        }
    }
}
