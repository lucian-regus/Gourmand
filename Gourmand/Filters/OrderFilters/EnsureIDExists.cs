using Gourmand.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Filters.OrderFilters
{
    public class EnsureIDExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureIDExists(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["ID"] as int?;

            var order = _db.Order.FirstOrDefault(x => x.OrderID == id);

            if (order == null)
            {
                context.ModelState.AddModelError("ID", "ID doesn't exists in the database.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            context.HttpContext.Items["Order"] = order;
        }
    }
}
