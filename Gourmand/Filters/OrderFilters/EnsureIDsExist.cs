using Gourmand.Data;
using Gourmand.DTO;
using Gourmand.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Gourmand.Filters.OrderFilters
{
    public class EnsureIDsExist : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureIDsExist(GourmandDBContext db) => this._db = db;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var order = context.ActionArguments["order"] as OrderDTO;

            if (order != null)
            {
                if (!_db.Client.Any(x => x.ClientID == order.ClientID))
                {
                    context.ModelState.AddModelError("ClientID", "ClientID doesn't exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                if (!_db.Courier.Any(x => x.CourierID == order.CourierID))
                {
                    context.ModelState.AddModelError("CourierID", "CourierID doesn't exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                if (!_db.Restaurant.Any(x => x.RestaurantID == order.RestaurantID))
                {
                    context.ModelState.AddModelError("RestaurantID", "RestaurantID doesn't exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

            }
        }
    }
}
