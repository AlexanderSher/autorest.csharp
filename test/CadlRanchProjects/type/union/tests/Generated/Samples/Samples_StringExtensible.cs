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
    public partial class Samples_StringExtensible
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringExtensible_ShortVersion()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = client.GetStringExtensible(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringExtensible_ShortVersion_Async()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = await client.GetStringExtensibleAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringExtensible_ShortVersion_Convenience()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response<GetStringExtensibleResponseType> response = client.GetStringExtensible();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringExtensible_ShortVersion_Convenience_Async()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response<GetStringExtensibleResponseType> response = await client.GetStringExtensibleAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringExtensible_AllParameters()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = client.GetStringExtensible(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringExtensible_AllParameters_Async()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = await client.GetStringExtensibleAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("prop").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetStringExtensible_AllParameters_Convenience()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response<GetStringExtensibleResponseType> response = client.GetStringExtensible();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetStringExtensible_AllParameters_Convenience_Async()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response<GetStringExtensibleResponseType> response = await client.GetStringExtensibleAsync();
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_ShortVersion()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

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
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

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
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_ShortVersion_Convenience_Async()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_Send_AllParameters()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

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
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

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
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = client.Send(SendRequestProp.A);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_Send_AllParameters_Convenience_Async()
        {
            StringExtensible client = new UnionClient().GetStringExtensibleClient(apiVersion: "1.0.0");

            Response response = await client.SendAsync(SendRequestProp.A);
        }
    }
}
