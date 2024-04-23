using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.ClientFilters
{
    public class EnsureNewClient : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureNewClient(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var client = context.ActionArguments["client"] as ClientDTO;
            if (client != null)
            {
                if(_db.Client.Any(x => x.Username == client.Username)) { 
                    context.ModelState.AddModelError("Client", "Username already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (_db.Client.Any(x => x.Email == client.Email ))
                {
                    context.ModelState.AddModelError("Client", "Email already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (_db.Client.Any(x => x.Number == client.Number))
                {
                    context.ModelState.AddModelError("Client", "Number already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
