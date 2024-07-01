using Gourmand.Data;
using Gourmand.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.CourierFilters
{
    public class EnsureNewCourier : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureNewCourier(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var courier = context.ActionArguments["newCourier"] as CourierDTO;
            if (courier != null)
            {
                if (_db.Courier.Any(x => x.Username == courier.Username))
                {
                    context.ModelState.AddModelError("Courier", "Username already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (_db.Courier.Any(x => x.Email == courier.Email))
                {
                    context.ModelState.AddModelError("Courier", "Email already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }

                if (_db.Courier.Any(x => x.Number == courier.Number))
                {
                    context.ModelState.AddModelError("Courier", "Phone number already exists in the database.");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }
        }
    }
}
