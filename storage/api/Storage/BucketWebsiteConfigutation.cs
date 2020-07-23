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

// [START storage_define_bucket_website_configuration]

using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;

public class BucketWebsiteConfigutation
{
	public Bucket ConfigureWebsite(string bucketName, string mainPageSuffix, string notFoundPage)
	{
		var storage = StorageClient.Create();
		var bucket = storage.GetBucket(bucketName);

		if (bucket.Website == null)
		{
			bucket.Website = new Bucket.WebsiteData();
		}
		bucket.Website.MainPageSuffix = mainPageSuffix;
		bucket.Website.NotFoundPage = notFoundPage;

		bucket = storage.UpdateBucket(bucket);
		Console.WriteLine($"Website configured for bucket {bucketName} with values {mainPageSuffix}, {notFoundPage}.");
		return bucket;
	}
}
// [END storage_define_bucket_website_configuration]
