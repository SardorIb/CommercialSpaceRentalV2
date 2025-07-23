using CommercialSpaceRentalV2.Models;

namespace CommercialSpaceRentalV2.Services.Interfaces
{
  public interface ILocationService: ICrudService<LocationServiceModel>
  {
    Task <IEnumerable<LocationServiceModel>> GetLocationServicesByLocationId (int id);
  }
}
