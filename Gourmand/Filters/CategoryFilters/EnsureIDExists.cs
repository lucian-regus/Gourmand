using Gourmand.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Filters.CategoryFilters
{
    public class EnsureIDExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureIDExists(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["ID"] as int?;

            var category = _db.Category.FirstOrDefault(x => x.CategoryID == id);

            if (category == null)
            {
                context.ModelState.AddModelError("ID", "ID doesn't exists in the database.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            context.HttpContext.Items["Category"] = category;
        }
    }
}
