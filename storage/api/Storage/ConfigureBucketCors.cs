using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;

namespace Storage
{
	public class ConfigureBucketCors
	{
		// [START storage_cors_configuration]
		public static void ConfigureCors(string bucketName)
		{
			var storage = StorageClient.Create();
			var bucket = storage.GetBucket(bucketName);

			Bucket.CorsData corsData = new Bucket.CorsData();
			corsData.Origin = new string[] { "*" };
			corsData.ResponseHeader = new string[] { "Content-Type", "x-goog-resumable" };
			corsData.Method = new string[] { "PUT", "POST" };
			corsData.MaxAgeSeconds = 3600; //One Hour

			if (bucket.Cors == null)
			{
				bucket.Cors = new List<Bucket.CorsData>();
			}
			bucket.Cors.Add(corsData);

			storage.UpdateBucket(bucket);
			Console.WriteLine($"Cors configured for bucket {bucketName} with Origin {corsData.Origin[0]}, Methods {corsData.Method[0]}.");
		}
		// [END storage_cors_configuration]
	}
}
