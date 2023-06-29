// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace azure_special_properties
{
    /// <summary> The SubscriptionInMethod service client. </summary>
    public partial class SubscriptionInMethodClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal SubscriptionInMethodRestClient RestClient { get; }

        /// <summary> Initializes a new instance of SubscriptionInMethodClient for mocking. </summary>
        protected SubscriptionInMethodClient()
        {
        }

        /// <summary> Initializes a new instance of SubscriptionInMethodClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal SubscriptionInMethodClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new SubscriptionInMethodRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="subscriptionId"> This should appear as a method parameter, use value '1234-5678-9012-3456'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual async Task<Response> PostMethodLocalValidAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostMethodLocalValid");
            scope.Start();
            try
            {
                return await RestClient.PostMethodLocalValidAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="subscriptionId"> This should appear as a method parameter, use value '1234-5678-9012-3456'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual Response PostMethodLocalValid(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostMethodLocalValid");
            scope.Start();
            try
            {
                return RestClient.PostMethodLocalValid(subscriptionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = null, client-side validation should prevent you from making this call. </summary>
        /// <param name="subscriptionId"> This should appear as a method parameter, use value null, client-side validation should prvenet the call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual async Task<Response> PostMethodLocalNullAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostMethodLocalNull");
            scope.Start();
            try
            {
                return await RestClient.PostMethodLocalNullAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = null, client-side validation should prevent you from making this call. </summary>
        /// <param name="subscriptionId"> This should appear as a method parameter, use value null, client-side validation should prvenet the call. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual Response PostMethodLocalNull(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostMethodLocalNull");
            scope.Start();
            try
            {
                return RestClient.PostMethodLocalNull(subscriptionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="subscriptionId"> Should appear as a method parameter -use value '1234-5678-9012-3456'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual async Task<Response> PostPathLocalValidAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostPathLocalValid");
            scope.Start();
            try
            {
                return await RestClient.PostPathLocalValidAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="subscriptionId"> Should appear as a method parameter -use value '1234-5678-9012-3456'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual Response PostPathLocalValid(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostPathLocalValid");
            scope.Start();
            try
            {
                return RestClient.PostPathLocalValid(subscriptionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="subscriptionId"> The subscriptionId, which appears in the path, the value is always '1234-5678-9012-3456'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual async Task<Response> PostSwaggerLocalValidAsync(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostSwaggerLocalValid");
            scope.Start();
            try
            {
                return await RestClient.PostSwaggerLocalValidAsync(subscriptionId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST method with subscriptionId modeled in the method.  pass in subscription id = '1234-5678-9012-3456' to succeed. </summary>
        /// <param name="subscriptionId"> The subscriptionId, which appears in the path, the value is always '1234-5678-9012-3456'. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/> is null. </exception>
        public virtual Response PostSwaggerLocalValid(string subscriptionId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SubscriptionInMethodClient.PostSwaggerLocalValid");
            scope.Start();
            try
            {
                return RestClient.PostSwaggerLocalValid(subscriptionId, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
