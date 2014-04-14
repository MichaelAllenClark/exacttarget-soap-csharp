using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void ExtractDataExtension(SoapClient soapClient, string DataExtensionCustomerKey, string FileName) {
            ExtractRequest er = new ExtractRequest();


            er.ID = "bb94a04d-9632-4623-be47-daabc3f588a6";

            // Always set an StartDate to the value specified
            ExtractParameter epOne = new ExtractParameter();
            epOne.Name = "StartDate";
            epOne.Value = "1/1/1900 1:00:00 AM";

            // Always set an StartDate to the value specified
            ExtractParameter epTwo = new ExtractParameter();
            epTwo.Name = "EndDate";
            epTwo.Value = "1/1/1900 1:00:00 AM";

            // Always set an _Async to 0
            ExtractParameter epThree = new ExtractParameter();
            epThree.Name = "_AsyncID";
            epThree.Value = "0";	

            ExtractParameter epFour = new ExtractParameter();
            epFour.Name = "OutputFileName";
            epFour.Value = FileName;

            ExtractParameter epFive = new ExtractParameter();
            epFive.Name = "DECustomerKey";
            epFive.Value = DataExtensionCustomerKey;	

            ExtractParameter epSix = new ExtractParameter();
            epSix.Name = "HasColumnHeaders";
            epSix.Value = "true";	

            er.Parameters = new ExtractParameter[] {epOne, epTwo, epThree, epFour, epFive, epSix };

            string sRequestId;
            string sStatus;
            ExtractResult[] results;
            sStatus = soapClient.Extract(new ExtractRequest[] { er }, out sRequestId, out results);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("Request ID: " + sRequestId);

            foreach (ExtractResult eresult in results)
            {
                Console.WriteLine("StatusCode: " + eresult.StatusCode);
                Console.WriteLine("ErrorCode: " + eresult.ErrorCode);
                Console.WriteLine("StatusMessage: " + eresult.StatusMessage);
            }
        }
    }
}
