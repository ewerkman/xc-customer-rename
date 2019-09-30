// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistCustomerBlock.cs" company="Sitecore Corporation">
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

    [PipelineDisplayName("SitecoreServices.Commerce.Plugin.Customer.Pipelines.Blocks.PersistCustomerBlock")]
    public class PersistCustomerBlock : PipelineBlock<RenameCustomerArgument, Customer, CommercePipelineExecutionContext>
    {

        protected CommerceCommander Commander { get; set; }

        public PersistCustomerBlock(CommerceCommander commander)
            : base(null)
        {
            this.Commander = commander;
        }

        public override async Task<Customer> Run(RenameCustomerArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");

            var customer = context.CommerceContext.GetEntity<Customer>();

            var updatedCustomer = await Commander.Command<UpdateCustomerDetailsCommand>().Process(context.CommerceContext, customer);

            return updatedCustomer;
        }
    }
}