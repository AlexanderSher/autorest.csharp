// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;
using _Type.Union;
using _Type.Union.Models;

namespace _Type.Union.Samples
{
    public partial class Samples_EnumsOnly
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnumsOnly_ShortVersion()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = client.GetEnumsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("lr").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("ud").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnumsOnly_ShortVersion_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetEnumsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("lr").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("ud").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnumsOnly_ShortVersion_Convenience()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response<GetEnumsOnlyResponseType> response = client.GetEnumsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnumsOnly_ShortVersion_Convenience_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response<GetEnumsOnlyResponseType> response = await client.GetEnumsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnumsOnly_AllParameters()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = client.GetEnumsOnly(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("lr").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("ud").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnumsOnly_AllParameters_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.GetEnumsOnlyAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").GetProperty("lr").ToString());
            Console.WriteLine(result.GetProperty("prop").GetProperty("ud").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetEnumsOnly_AllParameters_Convenience()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response<GetEnumsOnlyResponseType> response = client.GetEnumsOnly();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetEnumsOnly_AllParameters_Convenience_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response<GetEnumsOnlyResponseType> response = await client.GetEnumsOnlyAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_ShortVersion()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_ShortVersion_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_ShortVersion_Convenience()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_ShortVersion_Convenience_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_AllParameters()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = client.Send(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_AllParameters_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            using RequestContent content = RequestContent.Create(new
            {
                prop = "a",
            });
            Response response = await client.SendAsync(content);

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_AllParameters_Convenience()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_AllParameters_Convenience_Async()
        {
            EnumsOnly client = new UnionClient().GetEnumsOnlyClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }
    }
}
