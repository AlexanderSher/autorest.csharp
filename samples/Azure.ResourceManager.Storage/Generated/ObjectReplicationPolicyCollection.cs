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

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="ObjectReplicationPolicyResource" /> and their operations.
    /// Each <see cref="ObjectReplicationPolicyResource" /> in the collection will belong to the same instance of <see cref="StorageAccountResource" />.
    /// To get an <see cref="ObjectReplicationPolicyCollection" /> instance call the GetObjectReplicationPolicies method from an instance of <see cref="StorageAccountResource" />.
    /// </summary>
    public partial class ObjectReplicationPolicyCollection : ArmCollection, IEnumerable<ObjectReplicationPolicyResource>, IAsyncEnumerable<ObjectReplicationPolicyResource>
    {
        private readonly ClientDiagnostics _objectReplicationPolicyClientDiagnostics;
        private readonly ObjectReplicationPoliciesRestOperations _objectReplicationPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="ObjectReplicationPolicyCollection"/> class for mocking. </summary>
        protected ObjectReplicationPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ObjectReplicationPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ObjectReplicationPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _objectReplicationPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Storage", ObjectReplicationPolicyResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ObjectReplicationPolicyResource.ResourceType, out string objectReplicationPolicyApiVersion);
            _objectReplicationPolicyRestClient = new ObjectReplicationPoliciesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, objectReplicationPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != StorageAccountResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, StorageAccountResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or update the object replication policy of the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="data"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<ObjectReplicationPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string objectReplicationPolicyId, ObjectReplicationPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(objectReplicationPolicyId, nameof(objectReplicationPolicyId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _objectReplicationPolicyClientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _objectReplicationPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, data, cancellationToken).ConfigureAwait(false);
                var operation = new StorageArmOperation<ObjectReplicationPolicyResource>(Response.FromValue(new ObjectReplicationPolicyResource(Client, response), response.GetRawResponse()));
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
        /// Create or update the object replication policy of the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="data"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<ObjectReplicationPolicyResource> CreateOrUpdate(WaitUntil waitUntil, string objectReplicationPolicyId, ObjectReplicationPolicyData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(objectReplicationPolicyId, nameof(objectReplicationPolicyId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _objectReplicationPolicyClientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _objectReplicationPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, data, cancellationToken);
                var operation = new StorageArmOperation<ObjectReplicationPolicyResource>(Response.FromValue(new ObjectReplicationPolicyResource(Client, response), response.GetRawResponse()));
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
        /// Get the object replication policy of the storage account by policy ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public virtual async Task<Response<ObjectReplicationPolicyResource>> GetAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(objectReplicationPolicyId, nameof(objectReplicationPolicyId));

            using var scope = _objectReplicationPolicyClientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _objectReplicationPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ObjectReplicationPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the object replication policy of the storage account by policy ID.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public virtual Response<ObjectReplicationPolicyResource> Get(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(objectReplicationPolicyId, nameof(objectReplicationPolicyId));

            using var scope = _objectReplicationPolicyClientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _objectReplicationPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new ObjectReplicationPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the object replication policies associated with the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ObjectReplicationPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ObjectReplicationPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _objectReplicationPolicyRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new ObjectReplicationPolicyResource(Client, ObjectReplicationPolicyData.DeserializeObjectReplicationPolicyData(e)), _objectReplicationPolicyClientDiagnostics, Pipeline, "ObjectReplicationPolicyCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// List the object replication policies associated with the storage account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ObjectReplicationPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ObjectReplicationPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _objectReplicationPolicyRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new ObjectReplicationPolicyResource(Client, ObjectReplicationPolicyData.DeserializeObjectReplicationPolicyData(e)), _objectReplicationPolicyClientDiagnostics, Pipeline, "ObjectReplicationPolicyCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(objectReplicationPolicyId, nameof(objectReplicationPolicyId));

            using var scope = _objectReplicationPolicyClientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = await _objectReplicationPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/objectReplicationPolicies/{objectReplicationPolicyId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ObjectReplicationPolicies_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="objectReplicationPolicyId"> For the destination account, provide the value 'default'. Configure the policy on the destination account first. For the source account, provide the value of the policy ID that is returned when you download the policy that was defined on the destination account. The policy is downloaded as a JSON file. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="objectReplicationPolicyId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="objectReplicationPolicyId"/> is null. </exception>
        public virtual Response<bool> Exists(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(objectReplicationPolicyId, nameof(objectReplicationPolicyId));

            using var scope = _objectReplicationPolicyClientDiagnostics.CreateScope("ObjectReplicationPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = _objectReplicationPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ObjectReplicationPolicyResource> IEnumerable<ObjectReplicationPolicyResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ObjectReplicationPolicyResource> IAsyncEnumerable<ObjectReplicationPolicyResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
