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

using System.Linq;
using Xunit;

public class AnalyzeEntityFromTextTest
{
    [Fact]
    public void AnalyzeEntityFromText()
    {
        var analyzeEntityFromTextSample = new AnalyzeEntityFromTextSample();
        var entities = analyzeEntityFromTextSample.AnalyzeEntityFromText(LoggingFixture.text).ToList();

        Assert.Contains(entities, e => e.Name == "movie");
        Assert.Contains(entities, e => e.Name == "Santa Claus Conquers the Martians");
        Assert.Contains(entities, e => e.Name == "example");
    }
}