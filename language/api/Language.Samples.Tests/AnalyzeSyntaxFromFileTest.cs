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

public class AnalyzeSyntaxFromFileTest
{
    [Fact]
    public void AnalyzeSyntaxFromFile()
    {
        var analyzeSyntaxFromFileSample = new AnalyzeSyntaxFromFileSample();
        var response = analyzeSyntaxFromFileSample.AnalyzeSyntaxFromFile(LoggingFixture.gscUri);

        Assert.Contains(response.Sentences, s => s.Text.Content == "Santa Claus Conquers the Martians is a terrible movie.");
        Assert.Contains(response.Sentences, s => s.Text.Content == "It's so bad, it's good.");
        Assert.Contains(response.Sentences, s => s.Text.Content == "This is a classic example.");

        Assert.NotNull(response.Tokens);
    }
}