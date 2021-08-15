using System.Collections.Generic;

namespace api.models.interfaces
{
    public interface IGetAllAttendance
    {
        List<Attendance> GetAllAttendance();
    }
}