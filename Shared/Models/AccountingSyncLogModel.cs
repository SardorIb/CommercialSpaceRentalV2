using Shared.Enums;
using System.Net.Http.Json;

namespace Shared.Models
{
  public class AccountingSyncLogModel
  {
    public  int Id { get; set; }
    public required int BookingId { get; set; }
    public required AccountSyncLogStatus Status { get; set; }
    public required JsonContent ResponsePayload { get; set; }
    public required DateTime CreatedAt { get; set; }


  }
}
