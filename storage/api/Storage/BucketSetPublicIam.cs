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

// [START storage_set_bucket_public_iam]

using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;
using System.Linq;

public class BucketSetPublicIam
{
	public void SetPublicAccess(string bucketName)
    {
        var role = "roles/storage.objectViewer";

        var storage = StorageClient.Create();

		var bucketPolicy = storage.GetBucketIamPolicy(bucketName);

        Policy policy = storage.GetBucketIamPolicy(bucketName);
        Policy.BindingsData binding = policy.Bindings
            .Where(b => b.Role == role)
            .FirstOrDefault();

        if (binding == null)
        {
            binding = new Policy.BindingsData { Role = role, Members = new List<string> { } };
            policy.Bindings.Add(binding);
        }
        binding.Members.Add("allUsers");

        storage.SetBucketIamPolicy(bucketName, policy);

        Console.WriteLine($"bucket {bucketName} is now publicly accessible.");
	}
}
// [END storage_set_bucket_public_iam]
