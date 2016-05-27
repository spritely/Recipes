﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Delegates.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    /// <summary>
    /// Serializes an object into JSON.
    /// </summary>
    /// <param name="instance">The instance to serialize.</param>
    /// <returns>The serialized JSON object.</returns>
    internal delegate string JsonWebTokenJsonSerialize(object instance);

    /// <summary>
    /// Deserializes JSON into an object.
    /// </summary>
    /// <param name="json">The json to be deserialized.</param>
    /// <returns>The deserialized object.</returns>
    internal delegate object JsonWebTokenJsonDeserialize(string json);
}