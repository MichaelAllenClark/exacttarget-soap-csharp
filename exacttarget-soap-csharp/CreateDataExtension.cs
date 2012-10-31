using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void CreateDateExtension(SoapClient soapClient,
            string iDataExtensionName,
            string iDataExtensionCustomerKey)
        {
            DataExtension de = new DataExtension();
            de.Name = iDataExtensionName;
            de.CustomerKey = iDataExtensionCustomerKey;

            de.IsSendable = true;
            de.IsSendableSpecified = true;

            DataExtensionField def = new DataExtensionField();
            def.Name = "EMAIL";
            de.SendableDataExtensionField = def;

            //Sendable SubscriberField will be "Email Address" by default
            //If SubscriberKey option is enabled then value needs to be "Subscriber Key"
            ExactTargetSOAPAPI.Attribute attr = new ExactTargetSOAPAPI.Attribute();
            attr.Name = "Email Address";
            de.SendableSubscriberField = attr;            

            DataExtensionField emailField = new DataExtensionField();
            emailField.Name = "EMAIL";
            emailField.FieldType = DataExtensionFieldType.EmailAddress;
            emailField.FieldTypeSpecified = true;
            emailField.IsRequired = true;
            emailField.IsRequiredSpecified = true;
            emailField.IsPrimaryKey = true;
            emailField.IsPrimaryKeySpecified = true;
            emailField.MaxLength = 50;
            emailField.MaxLengthSpecified = true;

            DataExtensionField fnameField = new DataExtensionField();            
            fnameField.Name = "FIRST NAME";
            fnameField.FieldType = DataExtensionFieldType.Text;
            fnameField.FieldTypeSpecified = true;

            DataExtensionField lnameField = new DataExtensionField();            
            lnameField.Name = "LAST NAME";
            lnameField.FieldType = DataExtensionFieldType.Text;
            lnameField.FieldTypeSpecified = true;

            de.Fields = new DataExtensionField[] { emailField, fnameField, lnameField };

            string sStatus = "";
            string sRequestId = "";

            CreateResult[] aoResults = soapClient.Create(new CreateOptions(), new APIObject[] { de }, out sRequestId, out sStatus);

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
