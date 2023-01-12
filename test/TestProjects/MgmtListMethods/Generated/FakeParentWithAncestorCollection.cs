// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="FakeParentWithAncestorResource" /> and their operations.
    /// Each <see cref="FakeParentWithAncestorResource" /> in the collection will belong to the same instance of <see cref="FakeResource" />.
    /// To get a <see cref="FakeParentWithAncestorCollection" /> instance call the GetFakeParentWithAncestors method from an instance of <see cref="FakeResource" />.
    /// </summary>
    public partial class FakeParentWithAncestorCollection : ArmCollection, IEnumerable<FakeParentWithAncestorResource>, IAsyncEnumerable<FakeParentWithAncestorResource>
    {
        private readonly ClientDiagnostics _fakeParentWithAncestorClientDiagnostics;
        private readonly FakeParentWithAncestorsRestOperations _fakeParentWithAncestorRestClient;

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorCollection"/> class for mocking. </summary>
        protected FakeParentWithAncestorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="FakeParentWithAncestorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal FakeParentWithAncestorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeParentWithAncestorClientDiagnostics = new ClientDiagnostics("MgmtListMethods", FakeParentWithAncestorResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(FakeParentWithAncestorResource.ResourceType, out string fakeParentWithAncestorApiVersion);
            _fakeParentWithAncestorRestClient = new FakeParentWithAncestorsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fakeParentWithAncestorApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != FakeResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, FakeResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FakeParentWithAncestorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string fakeParentWithAncestorName, FakeParentWithAncestorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorResource>(Response.FromValue(new FakeParentWithAncestorResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FakeParentWithAncestorResource> CreateOrUpdate(WaitUntil waitUntil, string fakeParentWithAncestorName, FakeParentWithAncestorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeParentWithAncestorResource>(Response.FromValue(new FakeParentWithAncestorResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual async Task<Response<FakeParentWithAncestorResource>> GetAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<FakeParentWithAncestorResource> Get(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Get");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeParentWithAncestorResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors
        /// Operation Id: FakeParentWithAncestors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FakeParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeParentWithAncestorResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentWithAncestorRestClient.CreateListRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentWithAncestorRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorResource(Client, FakeParentWithAncestorData.DeserializeFakeParentWithAncestorData(e)), _fakeParentWithAncestorClientDiagnostics, Pipeline, "FakeParentWithAncestorCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors
        /// Operation Id: FakeParentWithAncestors_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FakeParentWithAncestorResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeParentWithAncestorResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeParentWithAncestorRestClient.CreateListRequest(Id.SubscriptionId, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _fakeParentWithAncestorRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new FakeParentWithAncestorResource(Client, FakeParentWithAncestorData.DeserializeFakeParentWithAncestorData(e)), _fakeParentWithAncestorClientDiagnostics, Pipeline, "FakeParentWithAncestorCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Exists");
            scope.Start();
            try
            {
                var response = await _fakeParentWithAncestorRestClient.GetAsync(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}
        /// Operation Id: FakeParentWithAncestors_Get
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        public virtual Response<bool> Exists(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(fakeParentWithAncestorName, nameof(fakeParentWithAncestorName));

            using var scope = _fakeParentWithAncestorClientDiagnostics.CreateScope("FakeParentWithAncestorCollection.Exists");
            scope.Start();
            try
            {
                var response = _fakeParentWithAncestorRestClient.Get(Id.SubscriptionId, Id.Name, fakeParentWithAncestorName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<FakeParentWithAncestorResource> IEnumerable<FakeParentWithAncestorResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<FakeParentWithAncestorResource> IAsyncEnumerable<FakeParentWithAncestorResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
