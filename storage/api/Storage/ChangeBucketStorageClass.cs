using Google.Cloud.Storage.V1;
using System;

namespace Storage
{
	public class ChangeBucketStorageClass
	{
		// [START storage_change_default_storage_class]
		public static void ChangeStorageClass(string bucketName)
		{
			var storage = StorageClient.Create();
			var bucket = storage.GetBucket(bucketName);
			bucket.StorageClass = StorageClasses.Coldline;

			storage.UpdateBucket(bucket);
			Console.WriteLine($"Default storage class for bucket {bucketName} changed to {StorageClasses.Coldline}.");
		}
		// [END storage_change_default_storage_class]
	}
}
