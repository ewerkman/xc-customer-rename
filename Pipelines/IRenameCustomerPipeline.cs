// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRenameCustomerPipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Pipelines
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines.Arguments;
    using Sitecore.Commerce.Plugin.Customers;

    /// <summary>
    /// Defines the IRenameCustomerPipeline interface
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.IPipeline{PipelineArgumentOrEntity,
    ///         PipelineArgumentOrEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("[Insert Project Name].Pipeline.IRenameCustomerPipeline")]
    public interface IRenameCustomerPipeline : IPipeline<RenameCustomerArgument, Customer, CommercePipelineExecutionContext>
    {
    }
}
