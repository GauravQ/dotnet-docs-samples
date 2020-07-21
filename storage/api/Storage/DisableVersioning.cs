using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
	public class DisableVersioning
	{
		// [START storage_disable_versioning]
		public static void Disable(string bucketName)
		{
			var storage = StorageClient.Create();
			var bucket = storage.GetBucket(bucketName);

			if(bucket.Versioning == null)
			{
				bucket.Versioning = new Bucket.VersioningData();
			}
			bucket.Versioning.Enabled = false;

			storage.UpdateBucket(bucket);
			Console.WriteLine($"Versioning disabled for bucket {bucketName}.");
		}
		// [END storage_disable_versioning]
	}
}
