// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace head_LowLevel
{
    /// <summary> The HttpSuccess service client. </summary>
    public partial class HttpSuccessClient
    {
        private const string AuthorizationHeader = "Fake-Subscription-Key";
        private readonly AzureKeyCredential _keyCredential;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of HttpSuccessClient for mocking. </summary>
        protected HttpSuccessClient()
        {
        }

        /// <summary> Initializes a new instance of HttpSuccessClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public HttpSuccessClient(AzureKeyCredential credential, Uri endpoint = null, HttpSuccessClientOptions options = null)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            endpoint ??= new Uri("http://localhost:3000");
            options ??= new HttpSuccessClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> Head200Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpSuccessClient.Head200");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead200Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 200 status code if successful. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response Head200(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpSuccessClient.Head200");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead200Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> Head204Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpSuccessClient.Head204");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead204Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 204 status code if successful. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response Head204(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpSuccessClient.Head204");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead204Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 404 status code if successful. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual async Task<Response> Head404Async(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpSuccessClient.Head404");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead404Request(context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Return 404 status code if successful. </summary>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        public virtual Response Head404(RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("HttpSuccessClient.Head404");
            scope.Start();
            try
            {
                using HttpMessage message = CreateHead404Request(context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateHead200Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200404);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/200", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateHead204Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204404);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/204", false);
            request.Uri = uri;
            return message;
        }

        internal HttpMessage CreateHead404Request(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204404);
            var request = message.Request;
            request.Method = RequestMethod.Head;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/http/success/404", false);
            request.Uri = uri;
            return message;
        }

        private static ResponseClassifier _responseClassifier200404;
        private static ResponseClassifier ResponseClassifier200404 => _responseClassifier200404 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 404 });
        private static ResponseClassifier _responseClassifier204404;
        private static ResponseClassifier ResponseClassifier204404 => _responseClassifier204404 ??= new StatusCodeClassifier(stackalloc ushort[] { 204, 404 });
    }
}
