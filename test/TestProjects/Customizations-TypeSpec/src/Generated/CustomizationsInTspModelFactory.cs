// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CustomizationsInTsp.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class CustomizationsInTspModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.ModelToChangeNamespace"/>. </summary>
        /// <param name="requiredInt"> Required int. </param>
        /// <param name="propertyReadWriteToReadOnly"> Read-write property that will be changed to readonly. </param>
        /// <returns> A new <see cref="Models.ModelToChangeNamespace"/> instance for mocking. </returns>
        public static ModelToChangeNamespace ModelToChangeNamespace(int requiredInt = default, bool? propertyReadWriteToReadOnly = null)
        {
            return new ModelToChangeNamespace(requiredInt, propertyReadWriteToReadOnly, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.OutputBaseModelWithDiscriminator"/>. </summary>
        /// <param name="kind"> Discriminator. </param>
        /// <returns> A new <see cref="Models.OutputBaseModelWithDiscriminator"/> instance for mocking. </returns>
        public static OutputBaseModelWithDiscriminator OutputBaseModelWithDiscriminator(string kind = null)
        {
            return new UnknownOutputBaseModelWithDiscriminator(kind, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="Models.FirstDerivedOutputModel"/>. </summary>
        /// <param name="first"></param>
        /// <returns> A new <see cref="Models.FirstDerivedOutputModel"/> instance for mocking. </returns>
        public static FirstDerivedOutputModel FirstDerivedOutputModel(bool first = default)
        {
            return new FirstDerivedOutputModel("first", serializedAdditionalRawData: null, first);
        }

        /// <summary> Initializes a new instance of <see cref="Models.SecondDerivedOutputModel"/>. </summary>
        /// <param name="second"></param>
        /// <returns> A new <see cref="Models.SecondDerivedOutputModel"/> instance for mocking. </returns>
        public static SecondDerivedOutputModel SecondDerivedOutputModel(bool second = default)
        {
            return new SecondDerivedOutputModel("second", serializedAdditionalRawData: null, second);
        }
    }
}
