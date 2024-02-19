using Carter;
using Microsoft.AspNetCore.Diagnostics;

namespace PatientsWebApi.ErrorsList
{
    public class Endpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.Map("/error", Error);
        }

        public IResult Error(HttpContext httpContext)
        {
            var error = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Results.Problem(statusCode: 400, detail: error?.Message);
        }
    }
}
