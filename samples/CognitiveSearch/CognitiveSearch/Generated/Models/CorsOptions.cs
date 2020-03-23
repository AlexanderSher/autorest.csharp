// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> Defines options to control Cross-Origin Resource Sharing (CORS) for an index. </summary>
    public partial class CorsOptions
    {
        /// <summary> Initializes a new instance of CorsOptions. </summary>
        /// <param name="allowedOrigins"> The list of origins from which JavaScript code will be granted access to your index. Can contain a list of hosts of the form {protocol}://{fully-qualified-domain-name}[:{port#}], or a single &apos;*&apos; to allow all origins (not recommended). </param>
        public CorsOptions(IList<string> allowedOrigins)
        {
            AllowedOrigins = allowedOrigins;
        }

        /// <summary> Initializes a new instance of CorsOptions. </summary>
        /// <param name="allowedOrigins"> The list of origins from which JavaScript code will be granted access to your index. Can contain a list of hosts of the form {protocol}://{fully-qualified-domain-name}[:{port#}], or a single &apos;*&apos; to allow all origins (not recommended). </param>
        /// <param name="maxAgeInSeconds"> The duration for which browsers should cache CORS preflight responses. Defaults to 5 minutes. </param>
        internal CorsOptions(IList<string> allowedOrigins, long? maxAgeInSeconds)
        {
            AllowedOrigins = allowedOrigins;
            MaxAgeInSeconds = maxAgeInSeconds;
        }

        /// <summary> The list of origins from which JavaScript code will be granted access to your index. Can contain a list of hosts of the form {protocol}://{fully-qualified-domain-name}[:{port#}], or a single &apos;*&apos; to allow all origins (not recommended). </summary>
        public IList<string> AllowedOrigins { get; } = new List<string>();
        /// <summary> The duration for which browsers should cache CORS preflight responses. Defaults to 5 minutes. </summary>
        public long? MaxAgeInSeconds { get; set; }
    }
}
