using CommercialSpaceRentalV2.DTOs;
using CommercialSpaceRentalV2.Models.ApiResponses;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Net;
using System.Text.Json;

namespace CommercialSpaceRentalV2.Middlewares
{   public class ErrorHandlingMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
      _next = next;
      _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Unhandled exception occurred.");

        context.Response.ContentType = "application/json";

        var (statusCode, message) = ex switch
        {
          ValidationException => (HttpStatusCode.BadRequest, ex.Message),
          UnauthorizedAccessException => (HttpStatusCode.Unauthorized, "Unauthorized access."),
          DbException => (HttpStatusCode.InternalServerError, "A database error occurred."),
          NotImplementedException =>(HttpStatusCode.NotImplemented, "The feature wasn't implemented, contact develeopment team."),
          _ => (HttpStatusCode.InternalServerError, ex.Message??"An unexpected error occurred.")
        };

        context.Response.StatusCode = (int)statusCode;

        var response = ApiResponse<string>.Failure(message);
        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
      }
    }
  }

}
