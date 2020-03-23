// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> A single bucket of a facet query result. Reports the number of documents with a field value falling within a particular range or having a particular value or interval. </summary>
    public partial class FacetResult : IDictionary<string, object>
    {
        /// <summary> Initializes a new instance of FacetResult. </summary>
        internal FacetResult()
        {
        }

        /// <summary> Initializes a new instance of FacetResult. </summary>
        /// <param name="count"> The approximate count of documents falling within the bucket described by this facet. </param>
        /// <param name="additionalProperties"> . </param>
        internal FacetResult(long? count, IDictionary<string, object> additionalProperties)
        {
            Count = count;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> The approximate count of documents falling within the bucket described by this facet. </summary>
        public long? Count { get; }
        internal IDictionary<string, object> AdditionalProperties { get; } = new Dictionary<string, object>();
        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        public ICollection<string> Keys => AdditionalProperties.Keys;
        /// <inheritdoc />
        public ICollection<object> Values => AdditionalProperties.Values;
        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) => AdditionalProperties.TryGetValue(key, out value);
        /// <inheritdoc />
        public void Add(string key, object value) => AdditionalProperties.Add(key, value);
        /// <inheritdoc />
        public bool ContainsKey(string key) => AdditionalProperties.ContainsKey(key);
        /// <inheritdoc />
        public bool Remove(string key) => AdditionalProperties.Remove(key);
        /// <inheritdoc />
        int ICollection<KeyValuePair<string, object>>.Count => AdditionalProperties.Count;
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => AdditionalProperties.IsReadOnly;
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> value) => AdditionalProperties.Add(value);
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> value) => AdditionalProperties.Remove(value);
        /// <inheritdoc />
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> value) => AdditionalProperties.Contains(value);
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] destination, int offset) => AdditionalProperties.CopyTo(destination, offset);
        /// <inheritdoc />
        void ICollection<KeyValuePair<string, object>>.Clear() => AdditionalProperties.Clear();
        /// <inheritdoc />
        public object this[string key]
        {
            get => AdditionalProperties[key];
            set => AdditionalProperties[key] = value;
        }
    }
}
