using Gourmand.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Filters.RestaurantFilters
{
    public class EnsureIDExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureIDExists(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["ID"] as int?;

            var restaurant = _db.Restaurant.FirstOrDefault(x => x.RestaurantID == id);

            if (restaurant == null)
            {
                context.ModelState.AddModelError("ID", "ID doesn't exists in the database.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            context.HttpContext.Items["Restaurant"] = restaurant;
        }
    }
}
