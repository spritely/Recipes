﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonWebTokenAccessTokenExtensionsTest.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes.Test
{
    using System;
    using System.Net;
    using Newtonsoft.Json;
    using NUnit.Framework;
    
    [TestFixture]
    public class JsonWebTokenAccessTokenExtensionsTest
    {
        [Test]
        public void AddAuthorizationHeader_throws_on_null_arguments()
        {
            var token = JsonConvert.DeserializeObject(@"{ ""access_token"": ""access_token"", ""token_type"": ""token_type"", ""expires_in"": 130.5 }");
            var accessToken = new JsonWebTokenAccessToken(token);

            Assert.Throws<ArgumentNullException>(() => ((null) as WebClient).AddAuthorizationHeader(accessToken));
            using (var webClient = new WebClient())
            {
                Assert.Throws<ArgumentNullException>(() => webClient.AddAuthorizationHeader(null));
            }
        }

        [Test]
        public void Constructor_reads_access_token_and_sets_properties()
        {
            var token = JsonConvert.DeserializeObject(@"{ ""access_token"": ""access_token"", ""token_type"": ""token_type"", ""expires_in"": 130.5 }");
            var accessToken = new JsonWebTokenAccessToken(token);

            string authorizationHeader;
            using (var webClient = new WebClient())
            {
                webClient.AddAuthorizationHeader(accessToken);

                authorizationHeader = webClient.Headers[HttpRequestHeader.Authorization];
            }

            Assert.That(authorizationHeader, Is.Not.Null);
            Assert.That(authorizationHeader, Is.EqualTo("token_type access_token"));
        }
    }
}
