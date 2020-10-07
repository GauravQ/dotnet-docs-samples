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

using Xunit;

[Collection(nameof(BucketFixture))]
public class BucketWebsiteConfigutationTest
{
    private readonly BucketFixture _bucketFixture;

    public BucketWebsiteConfigutationTest(BucketFixture bucketFixture)
    {
        _bucketFixture = bucketFixture;
    }

    [Fact]
    public void BucketWebsiteConfigutation()
    {
        BucketWebsiteConfigutation bucketWebsite = new BucketWebsiteConfigutation();

        var mainPageSuffix = "index.html";
        var notFoundPage = "404.html";

        var bucket = bucketWebsite.ConfigureWebsite(_bucketFixture.BucketNameGeneric, mainPageSuffix, notFoundPage);

        Assert.Equal(mainPageSuffix, bucket.Website.MainPageSuffix);
        Assert.Equal(notFoundPage, bucket.Website.NotFoundPage);
    }
}
