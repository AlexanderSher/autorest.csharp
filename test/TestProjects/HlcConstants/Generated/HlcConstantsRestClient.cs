// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using HlcConstants.Models;

namespace HlcConstants
{
    internal partial class HlcConstantsRestClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of HlcConstantsRestClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        public HlcConstantsRestClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            ClientDiagnostics = clientDiagnostics ?? throw new ArgumentNullException(nameof(clientDiagnostics));
            _pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
            _endpoint = endpoint ?? new Uri("http://localhost:3000");
        }

        internal HttpMessage CreateMixedRequest(RoundTripModel value, StringConstant? optionalStringQuery, bool? optionalBooleanQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/op", false);
            uri.AppendQuery("required-string-query", "default", true);
            uri.AppendQuery("required-boolean-query", true, true);
            if (optionalStringQuery != null)
            {
                uri.AppendQuery("optional-string-query", optionalStringQuery.Value.ToString(), true);
            }
            if (optionalBooleanQuery != null)
            {
                uri.AppendQuery("optional-boolean-query", optionalBooleanQuery.Value, true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(value);
            request.Content = content;
            return message;
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="optionalStringQuery"> The Literal to use. The default value is AutoRest.CSharp.Output.Models.Types.EnumTypeValue. </param>
        /// <param name="optionalBooleanQuery"> The Literal to use. The default value is True. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public async Task<Response<RoundTripModel>> MixedAsync(RoundTripModel value, StringConstant? optionalStringQuery = null, bool? optionalBooleanQuery = null, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var message = CreateMixedRequest(value, optionalStringQuery, optionalBooleanQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoundTripModel value0 = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value0 = RoundTripModel.DeserializeRoundTripModel(document.RootElement);
                        return Response.FromValue(value0, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="optionalStringQuery"> The Literal to use. The default value is AutoRest.CSharp.Output.Models.Types.EnumTypeValue. </param>
        /// <param name="optionalBooleanQuery"> The Literal to use. The default value is True. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Response<RoundTripModel> Mixed(RoundTripModel value, StringConstant? optionalStringQuery = null, bool? optionalBooleanQuery = null, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var message = CreateMixedRequest(value, optionalStringQuery, optionalBooleanQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoundTripModel value0 = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value0 = RoundTripModel.DeserializeRoundTripModel(document.RootElement);
                        return Response.FromValue(value0, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreatePostSomethingRequest(RoundTripModel value, IntConstant? optionalIntQuery, FloatConstant? optionalFloatQuery)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/op2", false);
            uri.AppendQuery("required-int-query", 0, true);
            uri.AppendQuery("required-float-query", 3.14F, true);
            if (optionalIntQuery != null)
            {
                uri.AppendQuery("optional-int-query", optionalIntQuery.Value.ToSerialInt32(), true);
            }
            if (optionalFloatQuery != null)
            {
                uri.AppendQuery("optional-float-query", optionalFloatQuery.Value.ToSerialSingle(), true);
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(value);
            request.Content = content;
            return message;
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="optionalIntQuery"> The Literal to use. The default value is AutoRest.CSharp.Output.Models.Types.EnumTypeValue. </param>
        /// <param name="optionalFloatQuery"> The Literal to use. The default value is AutoRest.CSharp.Output.Models.Types.EnumTypeValue. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public async Task<Response<RoundTripModel>> PostSomethingAsync(RoundTripModel value, IntConstant? optionalIntQuery = null, FloatConstant? optionalFloatQuery = null, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var message = CreatePostSomethingRequest(value, optionalIntQuery, optionalFloatQuery);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoundTripModel value0 = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value0 = RoundTripModel.DeserializeRoundTripModel(document.RootElement);
                        return Response.FromValue(value0, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <param name="value"> The RoundTripModel to use. </param>
        /// <param name="optionalIntQuery"> The Literal to use. The default value is AutoRest.CSharp.Output.Models.Types.EnumTypeValue. </param>
        /// <param name="optionalFloatQuery"> The Literal to use. The default value is AutoRest.CSharp.Output.Models.Types.EnumTypeValue. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public Response<RoundTripModel> PostSomething(RoundTripModel value, IntConstant? optionalIntQuery = null, FloatConstant? optionalFloatQuery = null, CancellationToken cancellationToken = default)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            using var message = CreatePostSomethingRequest(value, optionalIntQuery, optionalFloatQuery);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        RoundTripModel value0 = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value0 = RoundTripModel.DeserializeRoundTripModel(document.RootElement);
                        return Response.FromValue(value0, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
