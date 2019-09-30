// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenameCustomerArgument.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Pipelines.Arguments
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// The RenameCustomerArgument.
    /// </summary>
    public class RenameCustomerArgument : PipelineArgument
    {
        public string FromUsername { get; set; }
        public string ToUsername { get; set; }

        public RenameCustomerArgument(string fromUsername, string toUsername)
        {
            this.FromUsername = fromUsername;
            this.ToUsername = toUsername;
        }
    }
}