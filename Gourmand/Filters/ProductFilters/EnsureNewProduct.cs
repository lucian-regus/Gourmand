using Gourmand.Data;
using Gourmand.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.ProductFilters
{
    public class EnsureNewProduct : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureNewProduct(GourmandDBContext db) => this._db = db;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var product = context.ActionArguments["product"] as ProductDTO;
            if (product != null)
            {
                if(!_db.Category.Any(x => x.CategoryID == product.CategoryID))
                {
                    context.ModelState.AddModelError("Category", "No such category.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                    return;
                }

                if (_db.Product.Any(x => x.Name == product.Name) && _db.Product.Any(x => x.Price == product.Price))
                {
                    context.ModelState.AddModelError("Product", "Product already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

            }
        }
    }
}

