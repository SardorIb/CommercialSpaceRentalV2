

using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{
  public interface ILocation:ICrudService<LocationModel>
  {
    Task <IEnumerable<LocationModel>> GetLocationsByPartnerId (int id);
  }
}
