// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using CognitiveSearch.Models;

namespace CognitiveSearch
{
    /// <summary> The Indexers service client. </summary>
    public partial class IndexersClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal IndexersRestClient RestClient { get; }

        /// <summary> Initializes a new instance of IndexersClient for mocking. </summary>
        protected IndexersClient()
        {
        }

        /// <summary> Initializes a new instance of IndexersClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The endpoint URL of the search service. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/>, <paramref name="pipeline"/>, <paramref name="endpoint"/> or <paramref name="apiVersion"/> is null. </exception>
        internal IndexersClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2019-05-06-Preview")
        {
            RestClient = new IndexersRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Resets the change tracking state associated with an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual async Task<Response> ResetAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Reset");
            scope.Start();
            try
            {
                return await RestClient.ResetAsync(indexerName, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Resets the change tracking state associated with an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to reset. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual Response Reset(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Reset");
            scope.Start();
            try
            {
                return RestClient.Reset(indexerName, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Runs an indexer on-demand. </summary>
        /// <param name="indexerName"> The name of the indexer to run. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual async Task<Response> RunAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Run");
            scope.Start();
            try
            {
                return await RestClient.RunAsync(indexerName, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Runs an indexer on-demand. </summary>
        /// <param name="indexerName"> The name of the indexer to run. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual Response Run(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Run");
            scope.Start();
            try
            {
                return RestClient.Run(indexerName, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new indexer or updates an indexer if it already exists. </summary>
        /// <param name="indexerName"> The name of the indexer to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> or <paramref name="indexer"/> is null. </exception>
        public virtual async Task<Response<Indexer>> CreateOrUpdateAsync(string indexerName, Enum0 prefer, Indexer indexer, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.CreateOrUpdate");
            scope.Start();
            try
            {
                return await RestClient.CreateOrUpdateAsync(indexerName, prefer, indexer, requestOptions, accessCondition, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new indexer or updates an indexer if it already exists. </summary>
        /// <param name="indexerName"> The name of the indexer to create or update. </param>
        /// <param name="prefer"> For HTTP PUT requests, instructs the service to return the created/updated resource on success. </param>
        /// <param name="indexer"> The definition of the indexer to create or update. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> or <paramref name="indexer"/> is null. </exception>
        public virtual Response<Indexer> CreateOrUpdate(string indexerName, Enum0 prefer, Indexer indexer, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.CreateOrUpdate");
            scope.Start();
            try
            {
                return RestClient.CreateOrUpdate(indexerName, prefer, indexer, requestOptions, accessCondition, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual async Task<Response> DeleteAsync(string indexerName, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Delete");
            scope.Start();
            try
            {
                return await RestClient.DeleteAsync(indexerName, requestOptions, accessCondition, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer to delete. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="accessCondition"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual Response Delete(string indexerName, RequestOptions requestOptions = null, AccessCondition accessCondition = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Delete");
            scope.Start();
            try
            {
                return RestClient.Delete(indexerName, requestOptions, accessCondition, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves an indexer definition. </summary>
        /// <param name="indexerName"> The name of the indexer to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual async Task<Response<Indexer>> GetAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Get");
            scope.Start();
            try
            {
                return await RestClient.GetAsync(indexerName, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieves an indexer definition. </summary>
        /// <param name="indexerName"> The name of the indexer to retrieve. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual Response<Indexer> Get(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Get");
            scope.Start();
            try
            {
                return RestClient.Get(indexerName, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all indexers available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the indexers to retrieve. Specified as a comma-separated list of JSON property names, or '*' for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListIndexersResult>> ListAsync(string select = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.List");
            scope.Start();
            try
            {
                return await RestClient.ListAsync(select, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all indexers available for a search service. </summary>
        /// <param name="select"> Selects which top-level properties of the indexers to retrieve. Specified as a comma-separated list of JSON property names, or '*' for all properties. The default is all properties. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListIndexersResult> List(string select = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.List");
            scope.Start();
            try
            {
                return RestClient.List(select, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new indexer. </summary>
        /// <param name="indexer"> The definition of the indexer to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexer"/> is null. </exception>
        public virtual async Task<Response<Indexer>> CreateAsync(Indexer indexer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Create");
            scope.Start();
            try
            {
                return await RestClient.CreateAsync(indexer, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Creates a new indexer. </summary>
        /// <param name="indexer"> The definition of the indexer to create. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexer"/> is null. </exception>
        public virtual Response<Indexer> Create(Indexer indexer, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.Create");
            scope.Start();
            try
            {
                return RestClient.Create(indexer, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns the current status and execution history of an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer for which to retrieve status. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual async Task<Response<IndexerExecutionInfo>> GetStatusAsync(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.GetStatus");
            scope.Start();
            try
            {
                return await RestClient.GetStatusAsync(indexerName, requestOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Returns the current status and execution history of an indexer. </summary>
        /// <param name="indexerName"> The name of the indexer for which to retrieve status. </param>
        /// <param name="requestOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="indexerName"/> is null. </exception>
        public virtual Response<IndexerExecutionInfo> GetStatus(string indexerName, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("IndexersClient.GetStatus");
            scope.Start();
            try
            {
                return RestClient.GetStatus(indexerName, requestOptions, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
