using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.ClientFilters
{
    public class EnsureClientExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureClientExists(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var client = context.ActionArguments["loginData"] as LoginDTO;

            Client dbClient = _db.Client.FirstOrDefault(x => x.Username.Equals(client.username));

            if (!BCrypt.Net.BCrypt.Verify(client.password, dbClient.Password))
            {
                context.ModelState.AddModelError("Client", "Invalid credentials.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

        }
    }
}

