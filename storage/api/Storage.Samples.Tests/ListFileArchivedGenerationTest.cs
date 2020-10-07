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
using System.Linq;
using Xunit;

[Collection(nameof(BucketFixture))]
public class ListFileArchivedGenerationTest
{
    private readonly BucketFixture _bucketFixture;

    public ListFileArchivedGenerationTest(BucketFixture bucketFixture)
    {
        _bucketFixture = bucketFixture;
    }

    [Fact]
    public void ListFileArchivedGeneration()
    {
        UploadFileSample uploadFileSample = new UploadFileSample();
        ListFilesSample listFilesSample = new ListFilesSample();
        BucketEnableVersioning bucketEnableVersioning = new BucketEnableVersioning();
        GetMetadataSample getMetadataSample = new GetMetadataSample();
        DownloadFileSample downloadFileSample = new DownloadFileSample();
        ListFileArchivedGeneration listFileArchived = new ListFileArchivedGeneration();
        DeleteFileArchivedGeneration deleteFileArchived = new DeleteFileArchivedGeneration();
        BucketDisableVersioning bucketDisableVersioning = new BucketDisableVersioning();

        var objectName = "HelloListFileArchivedGeneration.txt";

        //Enable bucket versioning
        bucketEnableVersioning.Enable(_bucketFixture.BucketNameGeneric);

        //Uploaded for the first time
        uploadFileSample.UploadFile(_bucketFixture.BucketNameGeneric, _bucketFixture.FilePath, objectName);

        //Upload again to archive previous generation.
        uploadFileSample.UploadFile(_bucketFixture.BucketNameGeneric, "Resources/HelloDownloadCompleteByteRange.txt", objectName);

        var fileArchivedGeneration = (long?)0;
        var fileCurrentGeneration = (long?)0;

        try
        {
            var objects = listFileArchived.ListAllFiles(_bucketFixture.BucketNameGeneric);

            Assert.Equal(2, objects.Count(a => a.Name == objectName));

            //For garbage collection in finally
            var testFiles = objects.Where(a => a.Name == objectName).ToList();
            fileArchivedGeneration = testFiles[0].Generation;
            fileCurrentGeneration = testFiles[1].Generation;
        }
        finally
        {
            //Disable bucket versioning
            bucketDisableVersioning.Disable(_bucketFixture.BucketNameGeneric);

            //For garbage collection of files with versioning enabled.

            //Delete first generation of the file
            deleteFileArchived.Delete(_bucketFixture.BucketNameGeneric, objectName, fileArchivedGeneration);
            //Delete second generation of the file
            deleteFileArchived.Delete(_bucketFixture.BucketNameGeneric, objectName, fileCurrentGeneration);
        }
    }
}
