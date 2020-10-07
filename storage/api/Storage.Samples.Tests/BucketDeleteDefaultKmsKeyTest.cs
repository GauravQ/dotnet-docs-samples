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

using System.IO;
using System.Net;
using Xunit;

[Collection(nameof(BucketFixture))]
public class BucketDeleteDefaultKmsKeyTest
{
    private readonly BucketFixture _bucketFixture;

    public BucketDeleteDefaultKmsKeyTest(BucketFixture bucketFixture)
    {
        _bucketFixture = bucketFixture;
    }

    [Fact]
    public void BucketDeleteDefaultKmsKey()
    {
        EnableDefaultKMSKeySample enableDefaultKMSKeySample = new EnableDefaultKMSKeySample();
        GetBucketMetadataSample getBucketMetadataSample = new GetBucketMetadataSample();
        BucketDeleteDefaultKmsKey deleteDefaultKmsKey = new BucketDeleteDefaultKmsKey();

        //Set default key
        var bucket = enableDefaultKMSKeySample.EnableDefaultKMSKey(_bucketFixture.ProjectId, _bucketFixture.BucketNameRegional,
              _bucketFixture.KmsKeyLocation, _bucketFixture.KmsKeyRing, _bucketFixture.KmsKeyName);
        _bucketFixture.SleepAfterBucketCreateUpdateDelete();

        //Verify default key
        var bucketMetadata = getBucketMetadataSample.GetBucketMetadata(_bucketFixture.BucketNameRegional);
        Assert.Equal(_bucketFixture.KmsKeyName, bucketMetadata.Encryption.DefaultKmsKeyName);

        //Remove default key
        deleteDefaultKmsKey.RemoveKMSKey(_bucketFixture.BucketNameRegional);

        //Verify removal
        bucketMetadata = getBucketMetadataSample.GetBucketMetadata(_bucketFixture.BucketNameRegional);
        Assert.NotEqual(_bucketFixture.KmsKeyName, bucketMetadata.Encryption.DefaultKmsKeyName);
    }
}
