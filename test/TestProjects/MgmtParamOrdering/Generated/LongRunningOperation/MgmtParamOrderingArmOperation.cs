// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtParamOrdering
{
#pragma warning disable SA1649 // File name should match first type name
    internal class MgmtParamOrderingArmOperation : ArmOperation
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal _operation;

        /// <summary> Initializes a new instance of MgmtParamOrderingArmOperation for mocking. </summary>
        protected MgmtParamOrderingArmOperation()
        {
        }

        internal MgmtParamOrderingArmOperation(Response response)
        {
            _operation = OperationInternal.Succeeded(response);
        }

        internal MgmtParamOrderingArmOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _operation = new OperationInternal(clientDiagnostics, nextLinkOperation, response, "MgmtParamOrderingArmOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        internal MgmtParamOrderingArmOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string id)
        {
            _operation = OperationInternal.Create(id, clientDiagnostics, pipeline, "MgmtParamOrderingArmOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        /// <inheritdoc />
        public override string Id => _operation.GetOperationId();

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponse(cancellationToken);

        /// <inheritdoc />
        public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponse(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);
    }
}
