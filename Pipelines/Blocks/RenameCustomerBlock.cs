// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenameCustomerBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Pipelines.Blocks
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using System.Threading.Tasks;
    using Sitecore.Commerce.Plugin.Customers;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines.Arguments;

    [PipelineDisplayName("Change to <Project>Constants.Pipelines.Blocks.<Block Name>")]
    public class RenameCustomerBlock : PipelineBlock<RenameCustomerArgument, RenameCustomerArgument, CommercePipelineExecutionContext>
    {

        protected CommerceCommander Commander { get; set; }

        public RenameCustomerBlock(CommerceCommander commander)
            : base(null)
        {
            this.Commander = commander;
        }

        public override Task<RenameCustomerArgument> Run(RenameCustomerArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");

            var customer = context.CommerceContext.GetEntity<Customer>();

            customer.UserName = arg.ToUsername;
            customer.Email = customer.LoginName;

            return Task.FromResult(arg);
        }
    }
}