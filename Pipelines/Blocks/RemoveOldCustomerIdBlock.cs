// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveOldCustomerReferenceBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Pipelines.Blocks
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines.Arguments;
    using System.Threading.Tasks;
    using Sitecore.Commerce.Plugin.Customers;

    /// <summary>
    ///     Changing the username of the Customer does not remove the EntityIndex of the "old" username. We need to remove it otherwise
    ///     it would remain there pointing at the updated Customer and you would still be able to find it using the old username.
    /// </summary>
    [PipelineDisplayName("Change to <Project>Constants.Pipelines.Blocks.<Block Name>")]
    public class RemoveOldCustomerIdBlock : PipelineBlock<RenameCustomerArgument, RenameCustomerArgument, CommercePipelineExecutionContext>
    {
        protected CommerceCommander Commander { get; set; }

        public RemoveOldCustomerIdBlock(CommerceCommander commander)
            : base(null)
        {

            this.Commander = commander;

        }

        public override async Task<RenameCustomerArgument> Run(RenameCustomerArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");
            
            var oldCustomerIndexEntityId = $"{EntityIndex.IndexPrefix<Customer>("Id")}{arg.FromUsername}";
            var result = await Commander.DeleteEntity(context.CommerceContext, oldCustomerIndexEntityId);

            return arg;
        }
    }
}