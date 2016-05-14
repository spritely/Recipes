﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProcessingStatus.cs">
//     Copyright (c) 2016. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace $rootnamespace$
{
    using System;

    /// <summary>
    /// A processing status indicator.
    /// </summary>
    /// <typeparam name="T">The type of source item to report progress on.</typeparam>
#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#endif

    internal class ProcessingStatus<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ProcessingStatus{T}" /> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the source item.
        /// </summary>
        /// <value>The source item.</value>
        public T SourceItem { get; set; }

        /// <summary>
        /// Gets or sets the number of items processed.
        /// </summary>
        /// <value>The number of items processed.</value>
        public int ItemsProcessed { get; set; }

        /// <summary>
        /// Gets or sets the item count.
        /// </summary>
        /// <value>The item count.</value>
        public int ItemCount { get; set; }

        /// <summary>
        /// Gets or sets the percentage complete.
        /// </summary>
        /// <value>The percentage complete.</value>
        public double PercentageComplete { get; set; }

        /// <summary>
        /// Gets or sets the processing time.
        /// </summary>
        /// <value>The processing time.</value>
        public TimeSpan ProcessingTime { get; set; }

        /// <summary>
        /// Gets or sets the total processing time.
        /// </summary>
        /// <value>The total processing time.</value>
        public TimeSpan TotalProcessingTime { get; set; }

        /// <summary>
        /// Gets or sets the average time per item.
        /// </summary>
        /// <value>The average time per item.</value>
        public TimeSpan AverageTimePerItem { get; set; }

        /// <summary>
        /// Gets or sets the estimated time remaining.
        /// </summary>
        /// <value>The estimated time remaining.</value>
        public TimeSpan EstimatedTimeRemaining { get; set; }
    }
}
