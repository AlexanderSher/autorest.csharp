// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtPartialResource
{
    internal class PublicIPAddressOperationSource : IOperationSource<PublicIPAddressResource>
    {
        private readonly ArmClient _client;

        internal PublicIPAddressOperationSource(ArmClient client)
        {
            _client = client;
        }

        PublicIPAddressResource IOperationSource<PublicIPAddressResource>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = PublicIPAddressData.DeserializePublicIPAddressData(document.RootElement);
            return new PublicIPAddressResource(_client, data);
        }

        async ValueTask<PublicIPAddressResource> IOperationSource<PublicIPAddressResource>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = PublicIPAddressData.DeserializePublicIPAddressData(document.RootElement);
            return new PublicIPAddressResource(_client, data);
        }
    }
}
