// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.Analytics.Purview.Account;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Account.Samples
{
    public partial class Samples_PurviewAccountCollections
    {
        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollection_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = client.GetCollection(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollection_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollection_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = client.GetCollection(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollection_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdateCollection_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            RequestContent content = RequestContent.Create(new object());
            Response response = client.CreateOrUpdateCollection(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdateCollection_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            RequestContent content = RequestContent.Create(new object());
            Response response = await client.CreateOrUpdateCollectionAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_CreateOrUpdateCollection_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            RequestContent content = RequestContent.Create(new
            {
                description = "<description>",
                friendlyName = "<friendlyName>",
                parentCollection = new
                {
                    referenceName = "<referenceName>",
                },
            });
            Response response = client.CreateOrUpdateCollection(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_CreateOrUpdateCollection_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            RequestContent content = RequestContent.Create(new
            {
                description = "<description>",
                friendlyName = "<friendlyName>",
                parentCollection = new
                {
                    referenceName = "<referenceName>",
                },
            });
            Response response = await client.CreateOrUpdateCollectionAsync(content);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
            Console.WriteLine(result.GetProperty("description").ToString());
            Console.WriteLine(result.GetProperty("friendlyName").ToString());
            Console.WriteLine(result.GetProperty("name").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
            Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
            Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteCollection_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = client.DeleteCollection();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteCollection_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.DeleteCollectionAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_DeleteCollection_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = client.DeleteCollection();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_DeleteCollection_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.DeleteCollectionAsync();

            Console.WriteLine(response.Status);
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionPath_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = client.GetCollectionPath(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionPath_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionPathAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollectionPath_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = client.GetCollectionPath(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("parentFriendlyNameChain")[0].ToString());
            Console.WriteLine(result.GetProperty("parentNameChain")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollectionPath_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            Response response = await client.GetCollectionPathAsync(null);

            JsonElement result = JsonDocument.Parse(response.ContentStream).RootElement;
            Console.WriteLine(result.GetProperty("parentFriendlyNameChain")[0].ToString());
            Console.WriteLine(result.GetProperty("parentNameChain")[0].ToString());
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollections_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient(null);

            foreach (BinaryData item in client.GetCollections(null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollections_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient(null);

            await foreach (BinaryData item in client.GetCollectionsAsync(null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetCollections_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient(null);

            foreach (BinaryData item in client.GetCollections("<skipToken>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetCollections_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient(null);

            await foreach (BinaryData item in client.GetCollectionsAsync("<skipToken>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("collectionProvisioningState").ToString());
                Console.WriteLine(result.GetProperty("description").ToString());
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("referenceName").ToString());
                Console.WriteLine(result.GetProperty("parentCollection").GetProperty("type").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("createdByType").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedAt").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedBy").ToString());
                Console.WriteLine(result.GetProperty("systemData").GetProperty("lastModifiedByType").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetChildCollectionNames_ShortVersion()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            foreach (BinaryData item in client.GetChildCollectionNames(null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetChildCollectionNames_ShortVersion_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            await foreach (BinaryData item in client.GetChildCollectionNamesAsync(null, null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public void Example_GetChildCollectionNames_AllParameters()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            foreach (BinaryData item in client.GetChildCollectionNames("<skipToken>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }

        [Test]
        [Ignore("Only validating compilation of examples")]
        public async Task Example_GetChildCollectionNames_AllParameters_Async()
        {
            Uri endpoint = new Uri("<endpoint>");
            TokenCredential credential = new DefaultAzureCredential();
            PurviewAccountCollections client = new PurviewAccountsClient(endpoint, credential).GetCollectionsClient("<CollectionName>");

            await foreach (BinaryData item in client.GetChildCollectionNamesAsync("<skipToken>", null))
            {
                JsonElement result = JsonDocument.Parse(item.ToStream()).RootElement;
                Console.WriteLine(result.GetProperty("friendlyName").ToString());
                Console.WriteLine(result.GetProperty("name").ToString());
            }
        }
    }
}
