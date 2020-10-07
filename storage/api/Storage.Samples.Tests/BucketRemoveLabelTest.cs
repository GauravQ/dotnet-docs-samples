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
public class BucketRemoveLabelTest
{
    private readonly BucketFixture _bucketFixture;

    public BucketRemoveLabelTest(BucketFixture bucketFixture)
    {
        _bucketFixture = bucketFixture;
    }

    [Fact]
    public void BucketRemoveLabel()
    {
        BucketAddLabel bucketAddLabel = new BucketAddLabel();
        BucketRemoveLabel bucketRemoveLabel = new BucketRemoveLabel();

        var labelKey = "usage";
        var labelValue = "chat-attachments";

        //Add Label
        var bucket = bucketAddLabel.AddLabel(_bucketFixture.BucketNameGeneric, labelKey, labelValue);
        Assert.True(bucket.Labels.Keys.Contains(labelKey));
        Assert.Equal(labelValue, bucket.Labels[labelKey]);

        //Remove Label
        bucket = bucketRemoveLabel.RemoveLabel(_bucketFixture.BucketNameGeneric, labelKey);
        Assert.Null(bucket.Labels);
    }
}
