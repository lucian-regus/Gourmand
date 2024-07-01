using Gourmand.Data;
using Gourmand.DTO;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gourmand.Filters.RestaurantFilters
{
    public class EnsureNewRestaurant : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureNewRestaurant(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var restaurant = context.ActionArguments["newRestaurant"] as RestaurantDTO;
            if (restaurant != null)
            {
                if (_db.Restaurant.Any(x => x.Name == restaurant.Name))
                {
                    context.ModelState.AddModelError("Restaurant", "Name already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (_db.Restaurant.Any(x => x.Username == restaurant.Username))
                {
                    context.ModelState.AddModelError("Restaurant", "Username already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (_db.Restaurant.Any(x => x.Email == restaurant.Email))
                {
                    context.ModelState.AddModelError("Restaurant", "Email already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (_db.Restaurant.Any(x => x.Number == restaurant.Number))
                {
                    context.ModelState.AddModelError("Restaurant", "Phone number already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
