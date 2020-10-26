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

using Xunit;

[Collection(nameof(BucketFixture))]
public class ObjectRotateEncryptionKeyTest
{
    private readonly BucketFixture _bucketFixture;

    public ObjectRotateEncryptionKeyTest(BucketFixture bucketFixture)
    {
        _bucketFixture = bucketFixture;
    }

    [Fact]
    public void ObjectRotateEncryptionKey()
    {
        GenerateEncryptionKeySample generateEncryptionKeySample = new GenerateEncryptionKeySample();
        UploadEncryptedFileSample uploadEncryptedFileSample = new UploadEncryptedFileSample();
        GetMetadataSample getMetadataSample = new GetMetadataSample();
        ObjectRotateEncryptionKeySample objectRotateEncryptionKeySample = new ObjectRotateEncryptionKeySample();

        // Upload with csek
        var objectName = "HelloObjectRotateEncryptionKey.txt";
        string currentKey = generateEncryptionKeySample.GenerateEncryptionKey();
        string newKey = generateEncryptionKeySample.GenerateEncryptionKey();

        uploadEncryptedFileSample.UploadEncryptedFile(currentKey, _bucketFixture.BucketNameGeneric, _bucketFixture.FilePath, _bucketFixture.Collect(objectName));

        // Change key type to cmek
        objectRotateEncryptionKeySample.ObjectRotateEncryptionKey(_bucketFixture.BucketNameGeneric, objectName, currentKey, newKey);

        // Verify keyname
        var obj = getMetadataSample.GetMetadata(_bucketFixture.BucketNameGeneric, objectName);
        Assert.Equal(_bucketFixture.KmsKeyName, obj.KmsKeyName);
    }
}
