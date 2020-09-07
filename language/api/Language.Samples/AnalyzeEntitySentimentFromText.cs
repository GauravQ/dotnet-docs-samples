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

// [START language_entity_sentiment_text]

using Google.Cloud.Language.V1;
using System.Collections.Generic;

public class AnalyzeEntitySentimentFromTextSample
{
    public IEnumerable<Entity> AnalyzeEntitySentimentFromText(string text)
    {
        var client = LanguageServiceClient.Create();
        var response = client.AnalyzeEntitySentiment(new Document()
        {
            Content = text,
            Type = Document.Types.Type.PlainText
        });
        return response.Entities;
    }
}
// [END language_entity_sentiment_text]