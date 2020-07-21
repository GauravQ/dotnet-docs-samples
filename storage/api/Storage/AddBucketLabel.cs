using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;

namespace Storage
{
	public class AddBucketLabel
	{
		// [START storage_add_bucket_label]
		public static void AddLabel(string bucketName, string labelKey, string labelValue)
		{
			var storage = StorageClient.Create();
			var bucket = storage.GetBucket(bucketName);
			if (bucket.Labels == null)
			{
				bucket.Labels = new Dictionary<string, string>();
			}
			bucket.Labels[labelKey] = labelValue;

			storage.UpdateBucket(bucket);
			Console.WriteLine($"Updated label {labelKey} wih value {labelValue} on bucket {bucketName}.");
		}
		// [END storage_add_bucket_label]
	}
}
