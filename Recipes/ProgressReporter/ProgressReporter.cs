﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProgressReporter.cs">
//     Copyright (c) 2015. All rights reserved. Licensed under the MIT license. See LICENSE file in
//     the project root for full license information.
// </copyright>
// <auto-generated>
// Sourced from NuGet package. Will be overwritten with package update except in Spritely.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace Spritely.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

#if !RecipesProject
    [System.Diagnostics.DebuggerStepThrough]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("Spritely.Recipes", "See package version number")]
#endif

    /// <summary>
    /// Object to report progress status on iterations through a loop.
    /// </summary>
    /// <typeparam name="T">The type of source item to report progress on.</typeparam>
    internal class ProgressReporter<T>
    {
        private readonly Action<ProcessingStatus<T>> reportProgress;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProgressReporter{T}" /> class.
        /// </summary>
        /// <param name="reportProgress">The report progress.</param>
        public ProgressReporter(Action<ProcessingStatus<T>> reportProgress)
        {
            if (reportProgress == null)
            {
                throw new ArgumentNullException("reportProgress");
            }

            this.reportProgress = reportProgress;
        }

        /// <summary>
        /// Processes each item in source by calling action on each item one at a time. Progress is
        /// reported after each step.
        /// </summary>
        /// <param name="source">The source to iterate.</param>
        /// <param name="action">The action to perform on each iteration.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "This code is designed to catch and report exceptions, skip errant code, and continue processing the batch.")]
        public void ForEach(ICollection<T> source, Func<T, bool> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            var itemCount = source.Count;
            var itemsProcessed = 0;
            var stopWatch = new Stopwatch();
            var totalElapsed = new TimeSpan(0);

            foreach (var item in source)
            {
                stopWatch.Reset();
                stopWatch.Start();

                var processingStatus = new ProcessingStatus<T>
                {
                    SourceItem = item,
                    ItemCount = itemCount
                };

                try
                {
                    processingStatus.Success = action(item);
                }
                catch (Exception ex)
                {
                    processingStatus.Exception = ex;
                }

                stopWatch.Stop();

                itemsProcessed++;
                totalElapsed += stopWatch.Elapsed;

                processingStatus.ItemsProcessed = itemsProcessed;
                processingStatus.ProcessingTime = stopWatch.Elapsed;
                processingStatus.TotalProcessingTime = totalElapsed;
                processingStatus.PercentageComplete = Convert.ToDouble(itemsProcessed) / itemCount;

                var averageTimePerItem = new TimeSpan(totalElapsed.Ticks / itemsProcessed);
                var estimatedTimeRemaining = new TimeSpan(averageTimePerItem.Ticks * (itemCount - itemsProcessed));

                processingStatus.AverageTimePerItem = averageTimePerItem;
                processingStatus.EstimatedTimeRemaining = estimatedTimeRemaining;

                reportProgress(processingStatus);
            }
        }
    }
}
