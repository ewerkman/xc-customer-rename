// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Customers;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines.Blocks;

    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            // Configure pipelines
            services.Sitecore().Pipelines(config => config

            //  .AddPipeline<ISamplePipeline, SamplePipeline>(
            //         configure =>
            //             {
            //                 configure.Add<SampleBlock>();
            //             })
            .AddPipeline<IRenameCustomerPipeline, RenameCustomerPipeline>(c => 
                    c.Add<Pipelines.Blocks.GetCustomerBlock>()
                    .Add<RenameCustomerBlock>()
                    .Add<RemoveOldCustomerIdBlock>()
                    .Add<Pipelines.Blocks.PersistCustomerBlock>()
                    .Add<PersistCustomerIdIndexBlock>())
            .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<ConfigureServiceApiBlock>()));

            services.RegisterAllCommands(assembly);
        }
    }
}