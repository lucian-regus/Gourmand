using Gourmand.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.ClientFilters
{
    public class EnsureIDExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureIDExists(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["ID"] as int?;

            var client = _db.Client.FirstOrDefault(x => x.ClientID == id);

            if (client == null)
            {
                context.ModelState.AddModelError("ID", "ID doesn't exists in the database.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
             
            context.HttpContext.Items["Client"] = client;
        }
    }
}
