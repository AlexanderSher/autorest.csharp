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
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace MgmtListMethods
{
    /// <summary>
    /// A class representing a collection of <see cref="ResGrpParentWithNonResChResource" /> and their operations.
    /// Each <see cref="ResGrpParentWithNonResChResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="ResGrpParentWithNonResChCollection" /> instance call the GetResGrpParentWithNonResChes method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class ResGrpParentWithNonResChCollection : ArmCollection, IEnumerable<ResGrpParentWithNonResChResource>, IAsyncEnumerable<ResGrpParentWithNonResChResource>
    {
        private readonly ClientDiagnostics _resGrpParentWithNonResChClientDiagnostics;
        private readonly ResGrpParentWithNonResChesRestOperations _resGrpParentWithNonResChRestClient;

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithNonResChCollection"/> class for mocking. </summary>
        protected ResGrpParentWithNonResChCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ResGrpParentWithNonResChCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ResGrpParentWithNonResChCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _resGrpParentWithNonResChClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResGrpParentWithNonResChResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResGrpParentWithNonResChResource.ResourceType, out string resGrpParentWithNonResChApiVersion);
            _resGrpParentWithNonResChRestClient = new ResGrpParentWithNonResChesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, resGrpParentWithNonResChApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ResGrpParentWithNonResChResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resGrpParentWithNonResChName, ResGrpParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithNonResChName, nameof(resGrpParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resGrpParentWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithNonResChRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithNonResChResource>(Response.FromValue(new ResGrpParentWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="data"> Parameters supplied to the Create. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ResGrpParentWithNonResChResource> CreateOrUpdate(WaitUntil waitUntil, string resGrpParentWithNonResChName, ResGrpParentWithNonResChData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithNonResChName, nameof(resGrpParentWithNonResChName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _resGrpParentWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _resGrpParentWithNonResChRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<ResGrpParentWithNonResChResource>(Response.FromValue(new ResGrpParentWithNonResChResource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<ResGrpParentWithNonResChResource>> GetAsync(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithNonResChName, nameof(resGrpParentWithNonResChName));

            using var scope = _resGrpParentWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ResGrpParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public virtual Response<ResGrpParentWithNonResChResource> Get(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithNonResChName, nameof(resGrpParentWithNonResChName));

            using var scope = _resGrpParentWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.Get");
            scope.Start();
            try
            {
                var response = _resGrpParentWithNonResChRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ResGrpParentWithNonResChResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ResGrpParentWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ResGrpParentWithNonResChResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentWithNonResChRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resGrpParentWithNonResChRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithNonResChResource(Client, ResGrpParentWithNonResChData.DeserializeResGrpParentWithNonResChData(e)), _resGrpParentWithNonResChClientDiagnostics, Pipeline, "ResGrpParentWithNonResChCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Lists all in a resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ResGrpParentWithNonResChResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ResGrpParentWithNonResChResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _resGrpParentWithNonResChRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _resGrpParentWithNonResChRestClient.CreateListNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new ResGrpParentWithNonResChResource(Client, ResGrpParentWithNonResChData.DeserializeResGrpParentWithNonResChData(e)), _resGrpParentWithNonResChClientDiagnostics, Pipeline, "ResGrpParentWithNonResChCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithNonResChName, nameof(resGrpParentWithNonResChName));

            using var scope = _resGrpParentWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = await _resGrpParentWithNonResChRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.MgmtListMethods/resGrpParentWithNonResChes/{resGrpParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ResGrpParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resGrpParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resGrpParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resGrpParentWithNonResChName"/> is null. </exception>
        public virtual Response<bool> Exists(string resGrpParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resGrpParentWithNonResChName, nameof(resGrpParentWithNonResChName));

            using var scope = _resGrpParentWithNonResChClientDiagnostics.CreateScope("ResGrpParentWithNonResChCollection.Exists");
            scope.Start();
            try
            {
                var response = _resGrpParentWithNonResChRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resGrpParentWithNonResChName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ResGrpParentWithNonResChResource> IEnumerable<ResGrpParentWithNonResChResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ResGrpParentWithNonResChResource> IAsyncEnumerable<ResGrpParentWithNonResChResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
