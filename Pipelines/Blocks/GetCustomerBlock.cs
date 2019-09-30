// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCustomerBlockBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Pipelines.Blocks
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Catalog;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using SitecoreServices.Commerce.Plugin.Customer.Pipelines.Arguments;
    using System.Threading.Tasks;
    using Sitecore.Commerce.Plugin.Customers;

    [PipelineDisplayName("SitecoreServices.Commerce.Plugin.Customer.Pipelines.Blocks.GetCustomerBlock")]
    public class GetCustomerBlock : PipelineBlock<RenameCustomerArgument, RenameCustomerArgument, CommercePipelineExecutionContext>
    {
        /// <summary>
        /// Gets or sets the commander.
        /// </summary>
        /// <value>
        /// The commander.
        /// </value>
        protected CommerceCommander Commander { get; set; }

        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:Sitecore.Framework.Pipelines.PipelineBlock" /> class.</summary>
        /// <param name="commander">The commerce commander.</param>
        public GetCustomerBlock(CommerceCommander commander)
            : base(null)
        {
            this.Commander = commander;
        }

        public override async Task<RenameCustomerArgument> Run(RenameCustomerArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");

            // Get the customer using the "old" username
            var customerArg = new GetCustomerArgument(null, arg.FromUsername);

            var customer = await Commander.Command<GetCustomerCommand>().Process(context.CommerceContext, null, arg.FromUsername).ConfigureAwait(false);

            if(customer == null)
            {
                context.Abort($"Customer '{arg.FromUsername}' could not be found.", context);
            }

            context.CommerceContext.AddUniqueEntity(customer);

            return arg;
        }
    }
}