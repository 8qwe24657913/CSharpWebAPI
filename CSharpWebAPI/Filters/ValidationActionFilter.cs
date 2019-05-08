using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CSharpWebAPI.Filters {
    extern alias WebAlias;
    using HttpRequestMessageExtensions = WebAlias::System.Net.Http.HttpRequestMessageExtensions;
    public class ValidationActionFilter : ActionFilterAttribute {
        public override void OnActionExecuting(HttpActionContext context) {
            var modelState = context.ModelState;
            Console.WriteLine(modelState.IsValid);
            if (!modelState.IsValid) {
                dynamic errors = new JsonObject();
                foreach (var key in modelState.Keys) {
                    var state = modelState[key];
                    if (state.Errors.Any()) {
                        errors[key] = state.Errors.First().ErrorMessage;
                    }
                }
                context.Response = HttpRequestMessageExtensions.CreateResponse(context.Request, HttpStatusCode.BadRequest, errors, new JsonMediaTypeFormatter());
            }
            base.OnActionExecuting(context);
        }
    }
}
