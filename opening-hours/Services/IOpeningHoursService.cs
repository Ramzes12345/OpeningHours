using opening_hours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opening_hours.Services
{
    public interface IOpeningHoursService
    {
        Response ProcessRequest(DayOfWeekInput inputDto);
    }
}
