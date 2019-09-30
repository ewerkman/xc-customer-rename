// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandsController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace SitecoreServices.Commerce.Plugin.Customer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sitecore.Commerce.Core;
    using SitecoreServices.Commerce.Plugin.Customer.Commands;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.OData;

    public class CommandsController : CommerceController
    {
        public CommandsController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
            : base(serviceProvider, globalEnvironment)
        {
    
        }

        [HttpPut]
        [Route("RenameCustomer()")]
        public async Task<IActionResult> RenameCustomer([FromBody] ODataActionParameters value)
        {
            if (!this.ModelState.IsValid)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            var fromUsername = (string)value["fromUsername"];
            var toUsername = (string)value["toUsername"];

            var command = this.Command<RenameCustomerCommand>();
            await command.Process(this.CurrentContext, fromUsername, toUsername ).ConfigureAwait(continueOnCapturedContext: false);

            return new ObjectResult(command);
        }
    }
}