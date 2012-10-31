using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void CreateEmailSendDefinition(SoapClient soapClient,
            string EmailSendDefinitionName,
            string EmailSendDefinitionCustomerKey,
            int EmailID,
            string SendClassificationCustomerKey,
            string DataExtensionCustomerKey)
        {
            EmailSendDefinition esd = new EmailSendDefinition();
            esd.Name = EmailSendDefinitionName;
            esd.CustomerKey = EmailSendDefinitionCustomerKey;

            Email em = new Email();
            em.ID = EmailID;
            em.IDSpecified = true;
            esd.Email = em;

            SendDefinitionList sdl = new SendDefinitionList();
            sdl.SendDefinitionListType = SendDefinitionListTypeEnum.SourceList;
            sdl.SendDefinitionListTypeSpecified = true;
            sdl.CustomerKey = DataExtensionCustomerKey;
            sdl.DataSourceTypeID = DataSourceTypeEnum.CustomObject;
            sdl.DataSourceTypeIDSpecified = true;
            esd.SendDefinitionList = new SendDefinitionList[] {sdl};

            SendClassification sc = new SendClassification();
            sc.CustomerKey = SendClassificationCustomerKey;
            esd.SendClassification = sc;

            string sStatus = "";
            string sRequestId = "";

            CreateResult[] aoResults = soapClient.Create(new CreateOptions(), new APIObject[] { esd }, out sRequestId, out sStatus);

            Console.WriteLine("Status: " + sStatus);
            Console.WriteLine("Request ID: " + sRequestId);
            foreach (CreateResult cr in aoResults)
            {
                Console.WriteLine("StatusCode: " + cr.StatusCode);
                Console.WriteLine("ErrorCode: " + cr.ErrorCode);
                Console.WriteLine("StatusMessage: " + cr.StatusMessage);
            }
        }
    }
}
