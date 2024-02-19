using ErrorOr;

namespace PatientsWebApi.ErrorsList
{
    public class ProblemDetailsHelper
    {
        public static IResult ProblemDetails(List<Error> errors)
        {
            var firstError = errors[0];
            var statusCode = firstError.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Results.Problem(
                title: firstError.Description,
                statusCode: statusCode,
                extensions: new Dictionary<string, object?>() { { "errorCodes", errors.Select(x => x.Code) } });
        }
    }
}
