using Gourmand.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Filters.CourierFilters
{
    public class EnsureIDExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureIDExists(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["ID"] as int?;

            var courier = _db.Courier.FirstOrDefault(x => x.CourierID == id);

            if (courier == null)
            {
                context.ModelState.AddModelError("ID", "ID doesn't exists in the database.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            context.HttpContext.Items["Courier"] = courier;
        }
    }
}
