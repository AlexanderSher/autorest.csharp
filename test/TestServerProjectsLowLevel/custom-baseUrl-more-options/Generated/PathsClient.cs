// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace custom_baseUrl_more_options_LowLevel
{
    /// <summary> The Paths service client. </summary>
    public partial class PathsClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _subscriptionId;
        private readonly string _dnsSuffix;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of PathsClient for mocking. </summary>
        protected PathsClient()
        {
        }

        /// <summary> Initializes a new instance of PathsClient. </summary>
        /// <param name="subscriptionId"> The subscription id with value &apos;test12&apos;. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="dnsSuffix"> A string value that is used as a global part of the parameterized host. Default value &apos;host&apos;. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="credential"/>, or <paramref name="dnsSuffix"/> is null. </exception>
        public PathsClient(string subscriptionId, AzureKeyCredential credential, string dnsSuffix = "host", PathsClientOptions options = null)
        {
            subscriptionId = subscriptionId ?? throw new ArgumentNullException(nameof(subscriptionId));
            credential = credential ?? throw new ArgumentNullException(nameof(credential));
            dnsSuffix = dnsSuffix ?? throw new ArgumentNullException(nameof(dnsSuffix));
            options ??= new PathsClientOptions();

            _clientDiagnostics = new ClientDiagnostics(options);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _subscriptionId = subscriptionId;
            _dnsSuffix = dnsSuffix;
        }

        /// <summary> Get a 200 to test a valid base uri. </summary>
        /// <param name="vault"> The vault name, e.g. https://myvault. </param>
        /// <param name="secret"> Secret value. </param>
        /// <param name="keyName"> The key name with value &apos;key1&apos;. </param>
        /// <param name="keyVersion"> The key version. Default value &apos;v1&apos;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vault"/>, <paramref name="secret"/>, or <paramref name="keyName"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual async Task<Response> GetEmptyAsync(string vault, string secret, string keyName, string keyVersion = null, RequestContext context = null)
#pragma warning restore AZC0002
        {
            vault = vault ?? throw new ArgumentNullException(nameof(vault));
            secret = secret ?? throw new ArgumentNullException(nameof(secret));
            keyName = keyName ?? throw new ArgumentNullException(nameof(keyName));

            using var scope = _clientDiagnostics.CreateScope("PathsClient.GetEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEmptyRequest(vault, secret, keyName, keyVersion, context);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a 200 to test a valid base uri. </summary>
        /// <param name="vault"> The vault name, e.g. https://myvault. </param>
        /// <param name="secret"> Secret value. </param>
        /// <param name="keyName"> The key name with value &apos;key1&apos;. </param>
        /// <param name="keyVersion"> The key version. Default value &apos;v1&apos;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vault"/>, <paramref name="secret"/>, or <paramref name="keyName"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Response Error</c>:
        /// <code>{
        ///   status: number,
        ///   message: string
        /// }
        /// </code>
        /// 
        /// </remarks>
#pragma warning disable AZC0002
        public virtual Response GetEmpty(string vault, string secret, string keyName, string keyVersion = null, RequestContext context = null)
#pragma warning restore AZC0002
        {
            vault = vault ?? throw new ArgumentNullException(nameof(vault));
            secret = secret ?? throw new ArgumentNullException(nameof(secret));
            keyName = keyName ?? throw new ArgumentNullException(nameof(keyName));

            using var scope = _clientDiagnostics.CreateScope("PathsClient.GetEmpty");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetEmptyRequest(vault, secret, keyName, keyVersion, context);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetEmptyRequest(string vault, string secret, string keyName, string keyVersion, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(vault, false);
            uri.AppendRaw(secret, false);
            uri.AppendRaw(_dnsSuffix, false);
            uri.AppendPath("/customuri/", false);
            uri.AppendPath(_subscriptionId, true);
            uri.AppendPath("/", false);
            uri.AppendPath(keyName, true);
            if (keyVersion != null)
            {
                uri.AppendQuery("keyVersion", keyVersion, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }

        private sealed class ResponseClassifier200 : ResponseClassifier
        {
            private static ResponseClassifier _instance;
            public static ResponseClassifier Instance => _instance ??= new ResponseClassifier200();
            public override bool IsErrorResponse(HttpMessage message)
            {
                return message.Response.Status switch
                {
                    200 => false,
                    _ => true
                };
            }
        }
    }
}
