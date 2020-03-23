// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;

namespace AppConfiguration.Models
{
    /// <summary> The result of a list request. </summary>
    public partial class KeyValueListResult
    {
        /// <summary> Initializes a new instance of KeyValueListResult. </summary>
        internal KeyValueListResult()
        {
        }

        /// <summary> Initializes a new instance of KeyValueListResult. </summary>
        /// <param name="items"> The collection value. </param>
        /// <param name="nextLink"> The URI that can be used to request the next set of paged results. </param>
        internal KeyValueListResult(IList<KeyValue> items, string nextLink)
        {
            Items = items;
            NextLink = nextLink;
        }

        /// <summary> The collection value. </summary>
        public IList<KeyValue> Items { get; }
        /// <summary> The URI that can be used to request the next set of paged results. </summary>
        public string NextLink { get; }
    }
}
