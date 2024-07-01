using Gourmand.Data;
using Gourmand.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.CategoryFilters
{
    public class EnsureUniqueName : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureUniqueName(GourmandDBContext db) => this._db = db;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var category = context.ActionArguments["category"] as CategoryDTO;

            if (category != null)
            {
                if (_db.Category.Any(x => x.Name == category.Name))
                {
                    context.ModelState.AddModelError("Category", "Category already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
