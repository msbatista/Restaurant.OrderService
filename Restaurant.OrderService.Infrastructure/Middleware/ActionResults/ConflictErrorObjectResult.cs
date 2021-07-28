using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.OrderService.Infrastructure.Middleware.ActionResults
{
    public class ConflictErrorObjectResult : ObjectResult
    {
        public ConflictErrorObjectResult(object error) : base(error)
        {
            StatusCode = StatusCodes.Status409Conflict;
        }
    }
}
