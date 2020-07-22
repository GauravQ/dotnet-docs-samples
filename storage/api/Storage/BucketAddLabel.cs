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

// [START storage_add_bucket_label]

using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.Collections.Generic;

public class BucketAddLabel
{
    public Bucket AddLabel(string bucketName, string labelKey, string labelValue)
    {
        var storage = StorageClient.Create();
        var bucket = storage.GetBucket(bucketName);
        if (bucket.Labels == null)
        {
            bucket.Labels = new Dictionary<string, string>();
        }
        bucket.Labels[labelKey] = labelValue;

        bucket = storage.UpdateBucket(bucket);
        Console.WriteLine($"Updated labels on {bucketName}.");
        return bucket;
    }
}
// [END storage_add_bucket_label]
