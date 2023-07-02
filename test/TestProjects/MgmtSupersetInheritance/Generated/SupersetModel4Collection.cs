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
using Azure.ResourceManager.Resources;

namespace MgmtSupersetInheritance
{
    /// <summary>
    /// A class representing a collection of <see cref="SupersetModel4Resource" /> and their operations.
    /// Each <see cref="SupersetModel4Resource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="SupersetModel4Collection" /> instance call the GetSupersetModel4s method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class SupersetModel4Collection : ArmCollection, IEnumerable<SupersetModel4Resource>, IAsyncEnumerable<SupersetModel4Resource>
    {
        private readonly ClientDiagnostics _supersetModel4ClientDiagnostics;
        private readonly SupersetModel4SRestOperations _supersetModel4RestClient;

        /// <summary> Initializes a new instance of the <see cref="SupersetModel4Collection"/> class for mocking. </summary>
        protected SupersetModel4Collection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SupersetModel4Collection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SupersetModel4Collection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _supersetModel4ClientDiagnostics = new ClientDiagnostics("MgmtSupersetInheritance", SupersetModel4Resource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SupersetModel4Resource.ResourceType, out string supersetModel4ApiVersion);
            _supersetModel4RestClient = new SupersetModel4SRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, supersetModel4ApiVersion);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="data"> The SupersetModel4Data to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SupersetModel4Resource>> CreateOrUpdateAsync(WaitUntil waitUntil, string supersetModel4SName, SupersetModel4Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel4SName, nameof(supersetModel4SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _supersetModel4ClientDiagnostics.CreateScope("SupersetModel4Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _supersetModel4RestClient.PutAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtSupersetInheritanceArmOperation<SupersetModel4Resource>(Response.FromValue(new SupersetModel4Resource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_Put</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="data"> The SupersetModel4Data to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SupersetModel4Resource> CreateOrUpdate(WaitUntil waitUntil, string supersetModel4SName, SupersetModel4Data data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel4SName, nameof(supersetModel4SName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _supersetModel4ClientDiagnostics.CreateScope("SupersetModel4Collection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _supersetModel4RestClient.Put(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, data, cancellationToken);
                var operation = new MgmtSupersetInheritanceArmOperation<SupersetModel4Resource>(Response.FromValue(new SupersetModel4Resource(Client, response), response.GetRawResponse()));
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public virtual async Task<Response<SupersetModel4Resource>> GetAsync(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel4SName, nameof(supersetModel4SName));

            using var scope = _supersetModel4ClientDiagnostics.CreateScope("SupersetModel4Collection.Get");
            scope.Start();
            try
            {
                var response = await _supersetModel4RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel4Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public virtual Response<SupersetModel4Resource> Get(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel4SName, nameof(supersetModel4SName));

            using var scope = _supersetModel4ClientDiagnostics.CreateScope("SupersetModel4Collection.Get");
            scope.Start();
            try
            {
                var response = _supersetModel4RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SupersetModel4Resource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SupersetModel4Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SupersetModel4Resource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _supersetModel4RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new SupersetModel4Resource(Client, SupersetModel4Data.DeserializeSupersetModel4Data(e)), _supersetModel4ClientDiagnostics, Pipeline, "SupersetModel4Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SupersetModel4Resource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SupersetModel4Resource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _supersetModel4RestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new SupersetModel4Resource(Client, SupersetModel4Data.DeserializeSupersetModel4Data(e)), _supersetModel4ClientDiagnostics, Pipeline, "SupersetModel4Collection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel4SName, nameof(supersetModel4SName));

            using var scope = _supersetModel4ClientDiagnostics.CreateScope("SupersetModel4Collection.Exists");
            scope.Start();
            try
            {
                var response = await _supersetModel4RestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/supersetModel4s/{supersetModel4sName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SupersetModel4s_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="supersetModel4SName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="supersetModel4SName"/> is null. </exception>
        public virtual Response<bool> Exists(string supersetModel4SName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(supersetModel4SName, nameof(supersetModel4SName));

            using var scope = _supersetModel4ClientDiagnostics.CreateScope("SupersetModel4Collection.Exists");
            scope.Start();
            try
            {
                var response = _supersetModel4RestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, supersetModel4SName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SupersetModel4Resource> IEnumerable<SupersetModel4Resource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SupersetModel4Resource> IAsyncEnumerable<SupersetModel4Resource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
