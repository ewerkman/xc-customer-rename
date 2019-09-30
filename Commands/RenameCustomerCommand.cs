// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenameCustomerCommand.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Commands
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines.Arguments;
    using System;
    using System.Threading.Tasks;

    public class RenameCustomerCommand : CommerceCommand
    {
        protected CommerceCommander Commander { get; set; }

        public RenameCustomerCommand(CommerceCommander commander, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.Commander = commander;
        }
       
        public async Task<CommerceCommand> Process(CommerceContext commerceContext, string fromUsername, string toUsername)
        {
            using (CommandActivity.Start(commerceContext, this))
            {
                var contextOptions = commerceContext.GetPipelineContextOptions();
                var argument = new RenameCustomerArgument(fromUsername, toUsername);

                var result = await Commander.Pipeline<IRenameCustomerPipeline>().Run(argument, contextOptions).ConfigureAwait(false);

                return this;
            }
        }
    }
}