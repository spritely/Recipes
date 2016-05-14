// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonWebTokenAccessTokenExtensions.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    using System;
    using System.Net;

    /// <summary>
    /// Set of extensions related to JsonWebTokenAccessToken.
    /// </summary>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#endif
    internal static class JsonWebTokenAccessTokenExtensions
    {
        /// <summary>
        /// Adds the authorization header to the given web client.
        /// </summary>
        /// <param name="webClient">The web client.</param>
        /// <param name="accessToken">The access token.</param>
        public static void AddAuthorizationHeader(this WebClient webClient, JsonWebTokenAccessToken accessToken)
        {
            if (webClient == null)
            {
                throw new ArgumentNullException("webClient");
            }

            if (accessToken == null)
            {
                throw new ArgumentNullException("accessToken");
            }

            webClient.Headers.Add(HttpRequestHeader.Authorization, accessToken.TokenType + " " + accessToken.AccessToken);
        }
    }
}
