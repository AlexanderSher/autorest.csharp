// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using MgmtMultipleParentResource;

namespace MgmtMultipleParentResource.Models
{
    /// <summary> The operation to update the run command. </summary>
    public partial class AnotherParentUpdateOperation : Operation<AnotherParent>, IOperationSource<AnotherParent>
    {
        private readonly OperationInternals<AnotherParent> _operation;

        private readonly ArmClient _armClient;

        /// <summary> Initializes a new instance of AnotherParentUpdateOperation for mocking. </summary>
        protected AnotherParentUpdateOperation()
        {
        }

        internal AnotherParentUpdateOperation(ArmClient armClient, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<AnotherParent>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "AnotherParentUpdateOperation");
            _armClient = armClient;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override AnotherParent Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AnotherParent>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<AnotherParent>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        AnotherParent IOperationSource<AnotherParent>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = AnotherParentData.DeserializeAnotherParentData(document.RootElement);
            return new AnotherParent(_armClient, data);
        }

        async ValueTask<AnotherParent> IOperationSource<AnotherParent>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = AnotherParentData.DeserializeAnotherParentData(document.RootElement);
            return new AnotherParent(_armClient, data);
        }
    }
}
