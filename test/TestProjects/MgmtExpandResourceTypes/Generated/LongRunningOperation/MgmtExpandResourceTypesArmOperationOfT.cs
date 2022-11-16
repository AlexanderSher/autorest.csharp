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

namespace MgmtExpandResourceTypes
{
#pragma warning disable SA1649 // File name should match first type name
    internal class MgmtExpandResourceTypesArmOperation<T> : ArmOperation<T>
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal<T> _operation;

        /// <summary> Initializes a new instance of MgmtExpandResourceTypesArmOperation for mocking. </summary>
        protected MgmtExpandResourceTypesArmOperation()
        {
        }

        internal MgmtExpandResourceTypesArmOperation(Response<T> response)
        {
            _operation = OperationInternal<T>.Succeeded(response.GetRawResponse(), response.Value);
        }

        internal MgmtExpandResourceTypesArmOperation(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(source, pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _operation = new OperationInternal<T>(clientDiagnostics, nextLinkOperation, response, "MgmtExpandResourceTypesArmOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        internal MgmtExpandResourceTypesArmOperation(IOperationSource<T> source, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string id)
        {
            _operation = OperationInternal<T>.Create(id, source, clientDiagnostics, pipeline, "MgmtExpandResourceTypesArmOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        /// <inheritdoc />
        public override string Id => _operation.GetOperationId();

        /// <inheritdoc />
        public override T Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(CancellationToken cancellationToken = default) => _operation.WaitForCompletion(cancellationToken);

        /// <inheritdoc />
        public override Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletion(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
