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

// [START storage_object_get_kms_key]

using Google.Cloud.Storage.V1;
using System;

public class ObjectGetKMSKey
{
	/// <summary>
	/// Retrieve the KMS key of an object
	/// </summary>
	/// <param name="bucketName">Name of your bucket</param>
	/// <param name="objectName">Name of your object</param>
	/// <returns>string containing KMS key name</returns>
	public string GetKeyName(string bucketName = "your-bucket-name", string objectName = "your-object-name")
	{
		var storage = StorageClient.Create();
		var file = storage.GetObject(bucketName, objectName);

		var keyName = file.KmsKeyName;

		Console.WriteLine($"KMS key name for object {objectName} is {keyName}");
		return keyName;
	}
}
// [END storage_object_get_kms_key]
