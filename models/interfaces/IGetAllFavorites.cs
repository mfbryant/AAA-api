using System.Collections.Generic;

namespace api.models.interfaces
{
    public interface IGetAllFavorites
    {
        List<Favorite> GetAllFavorites();
    }
}