﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sha256JsonWebTokenSignerTest.cs">
//     Copyright (c) 2017. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes.Test
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using NUnit.Framework;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Sha", Justification = "Name is designed to match algorithm name.")]
    [TestFixture]
    public class Sha256JsonWebTokenSignerTest
    {
        [Test]
        public void Constructor_throws_on_null_arguments()
        {
            Assert.Throws<ArgumentNullException>(() => new Sha256JsonWebTokenSigner(null));
        }

        [Test]
        public void Algorithm_is_set_to_RS256()
        {
            var certficateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificates\\TestCertificate.pfx");
            var certificate = new X509Certificate2(certficateFilePath, "Test", X509KeyStorageFlags.Exportable);
            var signer = new Sha256JsonWebTokenSigner(certificate);

            Assert.That(signer.AlgorithmName, Is.EqualTo("RS256"));
        }

        [Test]
        public void Sign_produces_expected_results()
        {
            // To generate certificate:
            // makecert -pe TestCertificate.cer -sv TestCertificate.pvk
            // Provide password "Test" in dialogs
            // pvk2pfx -pvk TestCertificate.pvk -pi Test -spc TestCertificate.cer -pfx TestCertificate.pfx
            var certficateFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificates\\TestCertificate.pfx");
            var certificate = new X509Certificate2(certficateFilePath, "Test", X509KeyStorageFlags.Exportable);
            var signer = new Sha256JsonWebTokenSigner(certificate);

            var testSignData = Encoding.UTF8.GetBytes("Test sign me");

            var cspBlob = ((RSACryptoServiceProvider)certificate.PrivateKey).ExportCspBlob(true);
            byte[] expectedResults;
            using (var cryptoServiceProvider = new RSACryptoServiceProvider())
            {
                cryptoServiceProvider.ImportCspBlob(cspBlob);
                expectedResults = cryptoServiceProvider.SignData(testSignData, "SHA256");
            }
            var actualResults = signer.Sign(testSignData);

            Assert.That(actualResults, Is.EqualTo(expectedResults));
        }
    }
}
