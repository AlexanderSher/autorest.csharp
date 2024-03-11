// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Type.Property.AdditionalProperties.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class TypePropertyAdditionalPropertiesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ExtendsUnknownAdditionalPropertiesDiscriminated"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <param name="kind"> The discriminator. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.ExtendsUnknownAdditionalPropertiesDiscriminated"/> instance for mocking. </returns>
        public static ExtendsUnknownAdditionalPropertiesDiscriminated ExtendsUnknownAdditionalPropertiesDiscriminated(string name = null, string kind = null, IDictionary<string, BinaryData> additionalProperties = null)
        {
            additionalProperties ??= new Dictionary<string, BinaryData>();

            return new UnknownExtendsUnknownAdditionalPropertiesDiscriminated(name, kind, additionalProperties);
        }

        /// <summary> Initializes a new instance of <see cref="Models.IsUnknownAdditionalPropertiesDiscriminated"/>. </summary>
        /// <param name="name"> The name property. </param>
        /// <param name="kind"> The discriminator. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.IsUnknownAdditionalPropertiesDiscriminated"/> instance for mocking. </returns>
        public static IsUnknownAdditionalPropertiesDiscriminated IsUnknownAdditionalPropertiesDiscriminated(string name = null, string kind = null, IDictionary<string, BinaryData> additionalProperties = null)
        {
            additionalProperties ??= new Dictionary<string, BinaryData>();

            return new UnknownIsUnknownAdditionalPropertiesDiscriminated(name, kind, additionalProperties);
        }
    }
}
