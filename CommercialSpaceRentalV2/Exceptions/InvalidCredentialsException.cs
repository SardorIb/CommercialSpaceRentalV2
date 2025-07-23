namespace CommercialSpaceRentalV2.Exceptions
{
  public class InvalidCredentialsException : Exception
  {
    public int StatusCode { get; } = 401;

    public InvalidCredentialsException(string message = "Invalid email or password.")
        : base(message)
    {
    }

    public InvalidCredentialsException(string message, int statusCode)
        : base(message)
    {
      StatusCode = statusCode;
    }
  }
}
