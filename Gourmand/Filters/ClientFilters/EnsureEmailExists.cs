using Gourmand.Data;
using Gourmand.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.ClientFilters
{
    public class EnsureEmailExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureEmailExists(GourmandDBContext db) => _db = db;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var resetData = context.ActionArguments["resetPasswordData"] as EmailResetPasswordDTO;

            var client = _db.Client.FirstOrDefault(x => x.Email == resetData.email);

            if (client == null)
            {
                context.ModelState.AddModelError("Email", "The email doesn't exist in the database.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            context.HttpContext.Items["Client"] = client;

        }
    }
}
