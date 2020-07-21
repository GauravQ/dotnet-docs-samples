using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
	public class ChangeFileStorageClass
	{
        // [START storage_change_file_storage_class]
        public static void ChangeStorageClass(string bucketName, string objectName)
        {
            var storage = StorageClient.Create();
            var file = storage.GetObject(bucketName, objectName);
            file.StorageClass = StorageClasses.Coldline;

            storage.UpdateObject(file);
            Console.WriteLine($"File {objectName}'s storage class changed to {StorageClasses.Coldline}.");
        }
        // [END storage_change_file_storage_class]
    }
}
