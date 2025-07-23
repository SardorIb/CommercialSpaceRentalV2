namespace CommercialSpaceRentalV2.Exceptions
{
  public class InvalidEmailFormatException: Exception
  {
      public InvalidEmailFormatException(string message = "Email format is not valid.") : base(message) { }

  }

}
