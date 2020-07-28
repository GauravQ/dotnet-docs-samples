﻿// Copyright 2020 Google Inc.
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

// [START storage_delete_file_archived_generation]

using Google.Cloud.Storage.V1;
using System;

public class DeleteFileArchivedGeneration
{
	/// <summary>
	/// Delete an object in the bucket with the given generation
	/// </summary>
	/// <param name="bucketName">Name of your bucket</param>
	/// <param name="objectName">Name of your object</param>
	/// <param name="generation">Generation of the object</param>
	public void Delete(string bucketName = "your-bucket-name", string objectName = "your-object-name", long? generation = 1579287380533984)
	{
		var storage = StorageClient.Create();
		var deleteOptions = new DeleteObjectOptions
		{
			Generation = generation
		};

		storage.DeleteObject(bucketName, objectName, deleteOptions);

		Console.WriteLine($"Deleted file {objectName} gen {generation} from bucket {bucketName}.");
	}
}
// [END storage_delete_file_archived_generation]
