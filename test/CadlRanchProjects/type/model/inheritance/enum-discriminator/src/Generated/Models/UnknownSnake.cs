// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace _Type.Model.Inheritance.EnumDiscriminator.Models
{
    /// <summary> Unknown version of Snake. </summary>
    internal partial class UnknownSnake : Snake
    {
        /// <summary> Initializes a new instance of UnknownSnake. </summary>
        /// <param name="kind"> discriminator property. </param>
        /// <param name="length"> Length of the snake. </param>
        internal UnknownSnake(SnakeKind kind, int length) : base(kind, length)
        {
        }
    }
}
