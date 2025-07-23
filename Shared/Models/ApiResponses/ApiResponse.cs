namespace Shared.Models.ApiResponses
{
  public class ApiResponse<T>
  {
    public bool success { get; set; }
    public string message { get; set; }
    public T? results { get; set; }
    public int? statusCode { get; set; }

    public ApiResponse(bool success, string message, T? result = default, int? statusCode = null)
    {
      this.success = success;
      this.message = message;
      this.results = result;
      this.statusCode = statusCode;
    }

    public static ApiResponse<T> SuccessResponse(T data, string message = "Success", int? statusCode = 200) =>
        new(true, message, data, statusCode);

    public static ApiResponse<T> Failure(string message, int? statusCode = 400, T? errorDetails = default) =>
        new(false, message, errorDetails, statusCode);
  }
}
