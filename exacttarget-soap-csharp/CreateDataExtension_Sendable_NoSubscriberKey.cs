using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void CreateDateExtension_Sendable(SoapClient soapClient)
        {
            DataExtension de = new DataExtension();
            de.Name = "API Created DE " + Guid.NewGuid().ToString();
            de.CustomerKey = Guid.NewGuid().ToString();
            de.IsSendable = true;
            de.IsSendableSpecified = true;
            de.SendableDataExtensionField = new DataExtensionField();
            de.SendableDataExtensionField.Name = "EMAIL";
            de.SendableSubscriberField = new ExactTargetSOAPAPI.Attribute();
            de.SendableSubscriberField.Name = "Email Address";
            List<DataExtensionField> fields = new List<DataExtensionField>();

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
            fnameField = new DataExtensionField();
            fnameField.Name = "FIRST NAME";
            fnameField.FieldType = DataExtensionFieldType.Text;
            fnameField.FieldTypeSpecified = true;

            DataExtensionField lnameField = new DataExtensionField();
            lnameField = new DataExtensionField();
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
                Console.WriteLine(cr.StatusCode);
                Console.WriteLine(cr.ErrorCode);
                Console.WriteLine(cr.StatusMessage);
            }
        }
    }
}
