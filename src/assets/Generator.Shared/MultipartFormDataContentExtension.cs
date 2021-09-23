// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Azure.Core
{
    internal static class MultipartFormDataContentExtension
    {
        private static Dictionary<string, string> CreatePrimitiveTypeHeaders()
            => new() {{ "Content-Type", "text/plain" }};

        public static void AddPart(this MultipartFormDataContent content, string name, bool value)
            => content.AddPart(name, TypeFormatters.ToString(value));

        public static void AddPart(this MultipartFormDataContent content, string name, float value)
            => content.AddPart(name, value.ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture));

        public static void AddPart(this MultipartFormDataContent content, string name, double value)
            => content.AddPart(name, value.ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture));

        public static void AddPart(this MultipartFormDataContent content, string name, int value)
            => content.AddPart(name, value.ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture));

        public static void AddPart(this MultipartFormDataContent content, string name, long value)
            => content.AddPart(name, value.ToString(TypeFormatters.DefaultNumberFormat, CultureInfo.InvariantCulture));

        public static void AddPart(this MultipartFormDataContent content, string name, DateTimeOffset value, string format)
            => content.AddPart(name, TypeFormatters.ToString(value, format));

        public static void AddPart(this MultipartFormDataContent content, string name, TimeSpan value, string format)
            => content.AddPart(name, TypeFormatters.ToString(value, format));

        public static void AddPart(this MultipartFormDataContent content, string name, Guid value)
            => content.AddPart(name, value.ToString());

        public static void AddPart(this MultipartFormDataContent content, string name, string value)
            => content.Add(new StringRequestContent(value), name, CreatePrimitiveTypeHeaders());
    }
}
