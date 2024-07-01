using Gourmand.Data;
using Gourmand.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Gourmand.Filters.ClientFilters
{
    public class EnsureCodeExists : ActionFilterAttribute
    {
        private readonly GourmandDBContext _db;
        public EnsureCodeExists(GourmandDBContext db) => this._db = db;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var resetData = context.ActionArguments["resetPasswordData"] as CodeResetPassordDTO;

            var client = _db.Client.FirstOrDefault(x => x.ForgotPasswordCode == resetData.code);

            if(client == null) {
                context.ModelState.AddModelError("Code", "Code doesn't exists in the database.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }

            context.HttpContext.Items["Client"] = client;
        }
    }
}
