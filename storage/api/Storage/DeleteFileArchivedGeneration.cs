using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
	public class DeleteFileArchivedGeneration
	{
        // [START storage_delete_file_archived_generation]
        public static void DeleteFileGeneration(string bucketName, string objectName, long generation)
        {
            var storage = StorageClient.Create();
            var deleteOptions = new DeleteObjectOptions();
            deleteOptions.Generation = generation;

            storage.DeleteObject(bucketName, objectName, deleteOptions);

            Console.WriteLine($"Deleted file {objectName} gen {generation} from bucket {bucketName}.");
        }
        // [END storage_delete_file_archived_generation]
    }
}
