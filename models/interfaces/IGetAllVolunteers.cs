using System.Collections.Generic;

namespace api.models.interfaces
{
    public interface IGetAllVolunteers
    {
        List<Volunteer> GetAllVolunteers();
    }
}