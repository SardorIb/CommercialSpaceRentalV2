using System.Net.Mail;

namespace CommercialSpaceRentalV2.Constants.Methods
{
  public class EmailValidator
  {
    private string Email { get; set; }

    public EmailValidator(string email)
    {
      this.Email = email;
    }

    public bool IsValidEmail()
    {
      var trimmedEmail = Email.Trim();

      if (trimmedEmail.EndsWith("."))
      {
        return false;
      }

      try
      {
        var addr = new MailAddress(trimmedEmail);
        return addr.Address == trimmedEmail;
      }
      catch
      {
        return false;
      }
    }

    public static bool IsValid(string email)
    {
      return new EmailValidator(email).IsValidEmail();
    }
  }
}
