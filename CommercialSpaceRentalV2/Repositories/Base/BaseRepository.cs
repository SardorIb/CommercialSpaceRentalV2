using CommercialSpaceRentalV2.Repositories;
using Sensirion.Data.DB;

public abstract class BaseRepository
{
  protected readonly SQLHelper _helper;
  protected readonly ClientInfoService clientInfo;

  protected BaseRepository(SQLHelper helper, ClientInfoService clientInfo)
  {
    _helper = helper;
    this.clientInfo = clientInfo;
  }
}
