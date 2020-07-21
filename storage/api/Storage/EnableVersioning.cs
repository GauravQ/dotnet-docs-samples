using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
	public class EnableVersioning
	{
        // [START storage_enable_versioning]
        public static void Enable(string bucketName)
        {
            var storage = StorageClient.Create();
            var bucket = storage.GetBucket(bucketName);

            if (bucket.Versioning == null)
            {
                bucket.Versioning = new Bucket.VersioningData();
            }
            bucket.Versioning.Enabled = true;

            storage.UpdateBucket(bucket);
            Console.WriteLine($"Versioning enabled for bucket {bucketName}.");
        }
        // [END storage_enable_versioning]
    }
}
