using Google.Cloud.Storage.V1;
using System;

namespace Storage
{
	public class CopyFileArchivedGeneration
	{
		// [START storage_copy_file_archived_generation]
		public static void CopyArchivedObject(string sourceBucketName, string sourceObjectName,
			string destBucketName, string destObjectName, long generation)
		{
			var storage = StorageClient.Create();
			var copyOptions = new CopyObjectOptions();
			copyOptions.SourceGeneration = generation;

			storage.CopyObject(sourceBucketName, sourceObjectName,
				destBucketName, destObjectName, copyOptions);

			Console.WriteLine($"Copied {sourceBucketName}/{sourceObjectName} gen {generation} to "
				+ $"{destBucketName}/{destObjectName}.");
		}
		// [END storage_copy_file_archived_generation]
	}
}
