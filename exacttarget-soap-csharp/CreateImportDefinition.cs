using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using exacttarget_soap_csharp.ExactTargetSOAPAPI;

namespace exacttarget_soap_csharp
{
    partial class Tester
    {
        public static void CreateImportDefinition(SoapClient soapClient,
            string iImportDefinitionName,
            string iImportDefinitionCustomerKey,
            string iTargetDataExtensionCustomerKey,
            string iImportFileName)
        {
            ImportDefinition id = new ImportDefinition();
            id.Name = iImportDefinitionName;
            id.CustomerKey = iImportDefinitionCustomerKey;
            
            // Optional value, if AllowErrors is true then it will not stop the import when
            // a single row has an error
            id.AllowErrors = true;
            id.AllowErrorsSpecified = true;

            // For this example, we are sending to a data extension
            // Value for CustomerKey will be for a data extension already created in your account
            DataExtension de = new DataExtension();
            de.CustomerKey = iTargetDataExtensionCustomerKey;
            id.DestinationObject = de;

            AsyncResponse ar = new AsyncResponse();
            ar.ResponseType = AsyncResponseType.email;
            ar.ResponseAddress = "example@bh.exacttarget.com";
            id.Notification = ar;
            
            FileTransferLocation ftl = new FileTransferLocation();
            ftl.CustomerKey = "ExactTarget Enhanced FTP";
            id.RetrieveFileTransferLocation = ftl;

            // Specify how the import will be handled
            // If data extension has no primary key specified then only "Overwrite" will work
            id.UpdateType = ImportDefinitionUpdateType.AddAndUpdate;
            id.UpdateTypeSpecified = true;

            id.FieldMappingType = ImportDefinitionFieldMappingType.InferFromColumnHeadings;
            id.FieldMappingTypeSpecified = true;

            id.FileSpec = iImportFileName;

            id.FileType = FileType.CSV;
            id.FileTypeSpecified = true;

            string sStatus = "";
            string sRequestId = "";

            CreateResult[] aoResults = soapClient.Create(new CreateOptions(), new APIObject[] { id }, out sRequestId, out sStatus);

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
