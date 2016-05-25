﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonConfiguration.cs">
//   Copyright (c) 2016. All rights reserved.
//   Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     Static container for common Json settings defaults.
    /// </summary>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#endif
    internal static partial class JsonConfiguration
    {
        /// <summary>
        ///     Gets or sets the default JSON serialization settings.
        /// </summary>
        /// <value>
        ///     The JSON serialization settings.
        /// </value>
        public static JsonSerializerSettings DefaultSerializerSettings {
            get
            {
                return new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Include,
                    ContractResolver = CamelCasePropertyNamesWithConstructorParametersRequiredContractResolver.Instance,
                    Converters = new List<JsonConverter>
                    {
                        new StringEnumConverter { CamelCaseText = true },
                        new SecureStringJsonConverter(),
                        new InheritedTypeJsonConverter()
                    }
                };
            }
        }

        /// <summary>
        ///     Gets or sets the compact JSON serialization settings.
        /// </summary>
        /// <value>
        ///     The JSON serialization settings.
        /// </value>
        public static JsonSerializerSettings CompactSerializerSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    Formatting = Formatting.None,
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = CamelCasePropertyNamesWithConstructorParametersRequiredContractResolver.Instance,
                    Converters = new List<JsonConverter>
                    {
                        new StringEnumConverter { CamelCaseText = true },
                        new SecureStringJsonConverter(),
                        new InheritedTypeJsonConverter()
                    }
                };
            }
        }
    }
}
