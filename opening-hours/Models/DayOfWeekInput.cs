using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opening_hours.Models
{
    public class DayOfWeekInput
    {
        public List<OpeningHoursInput> Monday { get; set; }
        public List<OpeningHoursInput> Tuesday { get; set; }
        public List<OpeningHoursInput> Wednesday { get; set; }
        public List<OpeningHoursInput> Thursday { get; set; }
        public List<OpeningHoursInput> Friday { get; set; }
        public List<OpeningHoursInput> Saturday { get; set; }
        public List<OpeningHoursInput> Sunday { get; set; }
    }
}
