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

namespace MgmtOperations
{
    /// <summary>
    /// A class representing a collection of <see cref="AvailabilitySetChildResource" /> and their operations.
    /// Each <see cref="AvailabilitySetChildResource" /> in the collection will belong to the same instance of <see cref="AvailabilitySetResource" />.
    /// To get an <see cref="AvailabilitySetChildCollection" /> instance call the GetAvailabilitySetChildren method from an instance of <see cref="AvailabilitySetResource" />.
    /// </summary>
    public partial class AvailabilitySetChildCollection : ArmCollection, IEnumerable<AvailabilitySetChildResource>, IAsyncEnumerable<AvailabilitySetChildResource>
    {
        private readonly ClientDiagnostics _availabilitySetChildavailabilitySetChildClientDiagnostics;
        private readonly AvailabilitySetChildRestOperations _availabilitySetChildavailabilitySetChildRestClient;

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetChildCollection"/> class for mocking. </summary>
        protected AvailabilitySetChildCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="AvailabilitySetChildCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal AvailabilitySetChildCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _availabilitySetChildavailabilitySetChildClientDiagnostics = new ClientDiagnostics("MgmtOperations", AvailabilitySetChildResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(AvailabilitySetChildResource.ResourceType, out string availabilitySetChildavailabilitySetChildApiVersion);
            _availabilitySetChildavailabilitySetChildRestClient = new AvailabilitySetChildRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, availabilitySetChildavailabilitySetChildApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != AvailabilitySetResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, AvailabilitySetResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySetChild_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<AvailabilitySetChildResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string availabilitySetChildName, AvailabilitySetChildData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _availabilitySetChildavailabilitySetChildClientDiagnostics.CreateScope("AvailabilitySetChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _availabilitySetChildavailabilitySetChildRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtOperationsArmOperation<AvailabilitySetChildResource>(Response.FromValue(new AvailabilitySetChildResource(Client, response), response.GetRawResponse()));
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
        /// Create or update an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AvailabilitySetChild_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<AvailabilitySetChildResource> CreateOrUpdate(WaitUntil waitUntil, string availabilitySetChildName, AvailabilitySetChildData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _availabilitySetChildavailabilitySetChildClientDiagnostics.CreateScope("AvailabilitySetChildCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _availabilitySetChildavailabilitySetChildRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, data, cancellationToken);
                var operation = new MgmtOperationsArmOperation<AvailabilitySetChildResource>(Response.FromValue(new AvailabilitySetChildResource(Client, response), response.GetRawResponse()));
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
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual async Task<Response<AvailabilitySetChildResource>> GetAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));

            using var scope = _availabilitySetChildavailabilitySetChildClientDiagnostics.CreateScope("AvailabilitySetChildCollection.Get");
            scope.Start();
            try
            {
                var response = await _availabilitySetChildavailabilitySetChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new AvailabilitySetChildResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual Response<AvailabilitySetChildResource> Get(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));

            using var scope = _availabilitySetChildavailabilitySetChildClientDiagnostics.CreateScope("AvailabilitySetChildCollection.Get");
            scope.Start();
            try
            {
                var response = _availabilitySetChildavailabilitySetChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new AvailabilitySetChildResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetChild_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AvailabilitySetChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<AvailabilitySetChildResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _availabilitySetChildavailabilitySetChildRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new AvailabilitySetChildResource(Client, AvailabilitySetChildData.DeserializeAvailabilitySetChildData(e)), _availabilitySetChildavailabilitySetChildClientDiagnostics, Pipeline, "AvailabilitySetChildCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about an availability set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetChild_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AvailabilitySetChildResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<AvailabilitySetChildResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _availabilitySetChildavailabilitySetChildRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new AvailabilitySetChildResource(Client, AvailabilitySetChildData.DeserializeAvailabilitySetChildData(e)), _availabilitySetChildavailabilitySetChildClientDiagnostics, Pipeline, "AvailabilitySetChildCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));

            using var scope = _availabilitySetChildavailabilitySetChildClientDiagnostics.CreateScope("AvailabilitySetChildCollection.Exists");
            scope.Start();
            try
            {
                var response = await _availabilitySetChildavailabilitySetChildRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/availabilitySets/{availabilitySetName}/availabilitySetChildren/{availabilitySetChildName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>availabilitySetChild_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="availabilitySetChildName"> The name of the availability set child. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="availabilitySetChildName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="availabilitySetChildName"/> is null. </exception>
        public virtual Response<bool> Exists(string availabilitySetChildName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(availabilitySetChildName, nameof(availabilitySetChildName));

            using var scope = _availabilitySetChildavailabilitySetChildClientDiagnostics.CreateScope("AvailabilitySetChildCollection.Exists");
            scope.Start();
            try
            {
                var response = _availabilitySetChildavailabilitySetChildRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, availabilitySetChildName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<AvailabilitySetChildResource> IEnumerable<AvailabilitySetChildResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<AvailabilitySetChildResource> IAsyncEnumerable<AvailabilitySetChildResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
