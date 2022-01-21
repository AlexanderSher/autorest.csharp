// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Pagination;

namespace Pagination.Models
{
    public partial class PageSizeNumericModelCreateOrUpdateOperation : Operation<PageSizeNumericModel>
    {
        private readonly OperationOrResponseInternals<PageSizeNumericModel> _operation;

        /// <summary> Initializes a new instance of PageSizeNumericModelCreateOrUpdateOperation for mocking. </summary>
        protected PageSizeNumericModelCreateOrUpdateOperation()
        {
        }

        internal PageSizeNumericModelCreateOrUpdateOperation(ArmClient armClient, Response<PageSizeNumericModelData> response)
        {
            _operation = new OperationOrResponseInternals<PageSizeNumericModel>(Response.FromValue(new PageSizeNumericModel(armClient, response.Value), response.GetRawResponse()));
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override PageSizeNumericModel Value => _operation.Value;

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
        public override ValueTask<Response<PageSizeNumericModel>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<PageSizeNumericModel>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}
