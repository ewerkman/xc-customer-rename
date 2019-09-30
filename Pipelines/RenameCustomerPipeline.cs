// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenameCustomerPipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Pipelines
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines.Arguments;
    using Sitecore.Commerce.Plugin.Customers;

    /// <inheritdoc />
    /// <summary>
    ///  Defines the RenameCustomerPipeline pipeline.
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Commerce.Core.CommercePipeline{Namespace.PipelineArgumentOrEntity,
    ///         Namespace.PipelineArgumentOrEntity}
    ///     </cref>
    /// </seealso>
    /// <seealso cref="T:SitecoreServices.Commerce.Plugin.Customer.Pipelines.safeitemrootname" />
    public class RenameCustomerPipeline : CommercePipeline<RenameCustomerArgument, Customer>, IRenameCustomerPipeline
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:SitecoreServices.Commerce.Plugin.Customer.Pipelines.RenameCustomerPipeline" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public RenameCustomerPipeline(IPipelineConfiguration<IRenameCustomerPipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

