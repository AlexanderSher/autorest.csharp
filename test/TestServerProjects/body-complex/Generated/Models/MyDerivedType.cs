// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace body_complex.Models
{
    /// <summary> The MyDerivedType. </summary>
    public partial class MyDerivedType : MyBaseType
    {
        /// <summary> Initializes a new instance of MyDerivedType. </summary>
        internal MyDerivedType()
        {
            Kind = "Kind1";
        }

        /// <summary> Initializes a new instance of MyDerivedType. </summary>
        /// <param name="propD1"> . </param>
        /// <param name="kind"> . </param>
        /// <param name="propB1"> . </param>
        /// <param name="propBH1"> . </param>
        internal MyDerivedType(string propD1, string kind, string propB1, string propBH1) : base(kind, propB1, propBH1)
        {
            PropD1 = propD1;
            Kind = kind ?? "Kind1";
        }

        public string PropD1 { get; }
    }
}
