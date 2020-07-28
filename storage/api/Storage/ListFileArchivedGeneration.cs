// Copyright 2020 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// [START storage_list_file_archived_generations]

using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;

public class ListFileArchivedGeneration
{
	/// <summary>
	/// Lists all the objects in the bucket with generation
	/// </summary>
	/// <param name="bucketName">Name of your bucket</param>
	/// <returns>Enumerable collection of Storage objects</returns>
	public IEnumerable<Google.Apis.Storage.v1.Data.Object> ListAllFiles(string bucketName = "your-bucket-name")
	{
		var storage = StorageClient.Create();

		var listOptions = new ListObjectsOptions
		{
			Versions = true
		};
		var storageObjects = storage.ListObjects(bucketName, options: listOptions);

		foreach (var storageObject in storageObjects)
		{
			Console.WriteLine($"Filename: {storageObject.Name}, Generation: {storageObject.Generation}");
		}

		return storageObjects;
	}
}
// [END storage_list_file_archived_generations]
