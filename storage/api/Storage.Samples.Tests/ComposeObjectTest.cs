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

using Google.Cloud.Storage.V1;
using System.IO;
using Xunit;

[Collection(nameof(BucketFixture))]
public class ComposeObjectTest
{
    private readonly BucketFixture _bucketFixture;

    public ComposeObjectTest(BucketFixture bucketFixture)
    {
        _bucketFixture = bucketFixture;
    }

    [Fact]
    public void ComposeObject()
    {
        UploadFileSample uploadFileSample = new UploadFileSample();
        ComposeObject composeObject = new ComposeObject();
        DownloadFileSample downloadFileSample = new DownloadFileSample();

        var objectName1 = "HelloComposeObject.txt";
        var objectName2 = "HelloComposeObjectAdditional.txt";
        var objectName3 = "HelloComposedDownload.txt";

        uploadFileSample.UploadFile( _bucketFixture.BucketNameGeneric, "Resources/Hello.txt", _bucketFixture.Collect(objectName1));

        uploadFileSample.UploadFile(_bucketFixture.BucketNameGeneric, "Resources/HelloDownloadCompleteByteRange.txt", _bucketFixture.Collect(objectName2));

        composeObject.ComposeFile(_bucketFixture.BucketNameGeneric, _bucketFixture.Collect(objectName3), new string[] { objectName1, objectName2 });

        //Download the composed file
        downloadFileSample.DownloadFile(_bucketFixture.BucketNameGeneric, objectName3, objectName3);

        //Content from both file should exists in the downloaded file
        Assert.Contains(File.ReadAllText("Resources/Hello.txt"), File.ReadAllText(objectName3));
        Assert.Contains(File.ReadAllText("Resources/HelloDownloadCompleteByteRange.txt"), File.ReadAllText(objectName3));

        File.Delete(objectName3);
    }
}
