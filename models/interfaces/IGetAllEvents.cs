using System.Collections.Generic;

namespace api.models.interfaces
{
    public interface IGetAllEvents
    {
        List<Event> GetAllEvents();
    }
}