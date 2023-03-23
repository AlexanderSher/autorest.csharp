// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class CjkBigramTokenFilterScriptsExtensions
    {
        public static string ToSerialString(this CjkBigramTokenFilterScripts value) => value switch
        {
            CjkBigramTokenFilterScripts.Han => "han",
            CjkBigramTokenFilterScripts.Hiragana => "hiragana",
            CjkBigramTokenFilterScripts.Katakana => "katakana",
            CjkBigramTokenFilterScripts.Hangul => "hangul",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CjkBigramTokenFilterScripts value.")
        };

        public static CjkBigramTokenFilterScripts ToCjkBigramTokenFilterScripts(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "han")) return CjkBigramTokenFilterScripts.Han;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hiragana")) return CjkBigramTokenFilterScripts.Hiragana;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "katakana")) return CjkBigramTokenFilterScripts.Katakana;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "hangul")) return CjkBigramTokenFilterScripts.Hangul;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown CjkBigramTokenFilterScripts value.");
        }
    }
}
