using Gourmand.Data;
using Gourmand.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Gourmand.Filters.BasketFilters
{
    public class EnsureUniqueBasketItem : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureUniqueBasketItem(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var basket = context.ActionArguments["newItem"] as BasketDTO;
            if (basket != null)
            {
                if (_db.Basket.Any(x => x.OrderID == basket.OrderID && x.ProductID == basket.ProductID && x.IsRemoved == false))
                {
                    context.ModelState.AddModelError("Basket", "Product already exists in the basket.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
