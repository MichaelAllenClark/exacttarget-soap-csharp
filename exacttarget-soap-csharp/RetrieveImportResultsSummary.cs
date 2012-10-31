using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void RetrieveImportResultsSummary(SoapClient soapClient,
            string TaskID)
        {
            RetrieveRequest rr = new RetrieveRequest();
            
            rr.ObjectType = "ImportResultsSummary";

            SimpleFilterPart sf = new SimpleFilterPart();
            sf.Property = "TaskResultID";
            sf.SimpleOperator = SimpleOperators.equals;            
            sf.Value = new String[] { TaskID };
            rr.Filter = sf;

            rr.Properties = new string[] { "ImportStatus" };

            string sStatus = "";
            string sRequestId = "";
            APIObject[] rResults;

            sStatus = soapClient.Retrieve(rr, out sRequestId, out rResults);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("RequestID: " + sRequestId);

            foreach (ImportResultsSummary irs in rResults)
            {
                // Possible values for ImportStatus are New, Processing, Completed, Error, IOWork, and Unknown
                Console.WriteLine("ImportStatus: " + irs.ImportStatus);
            }

        }
    }
}
