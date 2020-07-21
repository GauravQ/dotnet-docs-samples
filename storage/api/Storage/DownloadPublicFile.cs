using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Storage
{
	public class DownloadPublicFile
	{
        // [START storage_download_public_file]
        public static void Download(string bucketName, string objectName, string localPath = null)
        {
            var storage = StorageClient.CreateUnauthenticated();
            localPath = localPath ?? Path.GetFileName(objectName);
            using (var outputFile = File.OpenWrite(localPath))
            {
                storage.DownloadObject(bucketName, objectName, outputFile);
            }
            Console.WriteLine($"downloaded public file {objectName} to {localPath}.");
        }
        // [END storage_download_public_file]
    }
}
