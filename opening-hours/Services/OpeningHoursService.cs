using opening_hours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opening_hours.Services
{
    public class OpeningHoursService : IOpeningHoursService
    {
        public Response ProcessRequest(DayOfWeekInput input)
        {
            try
            {
                var monday = ComputeForDay(input.Monday);
                var tuesday = ComputeForDay(input.Tuesday);
                var wednesday = ComputeForDay(input.Wednesday);
                var thurday = ComputeForDay(input.Thursday);
                var friday = ComputeForDay(input.Friday);
                var saturday = ComputeForDay(input.Saturday);
                var sunday = ComputeForDay(input.Sunday);

                var info = new List<string>();
                info.Add($"Monday: {monday}");
                info.Add($"Tuesday: {tuesday}");
                info.Add($"Wednesday: {wednesday}");
                info.Add($"Thurday: {thurday}");
                info.Add($"Friday: {friday}");
                info.Add($"Saturday: {saturday}");
                info.Add($"Sunday: {sunday}");

                return new Response
                {
                    IsSuccess = true,
                    Message = "Data retrieve successfully",
                    Info = info
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ComputeForDay(List<OpeningHoursInput> openingHours)
        {
            var hours = string.Empty;
            var dateTime = DateTime.Now;
            var time = string.Empty;

            if (openingHours.Count == 0)
            {
                hours += "closed";
            }

            foreach (var item in openingHours)
            {

                if (item.Type.ToLower() == "open")
                {
                    dateTime = UnixTimeToDateTime(item.Value);

                    time = dateTime.ToString("HH:mm:ss:tt");

                    hours += time;
                }
                else
                {
                    dateTime = UnixTimeToDateTime(item.Value);

                    time = dateTime.ToString("HH:mm:ss:tt");

                    if (openingHours[0] == item)
                    {
                        hours += $"{time},";
                    }
                    else
                    {
                        hours += $" - {time},";
                    }

                }

            }

            return hours.TrimEnd(',');
        }

        private DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(unixtime).ToLocalTime();
            return dtDateTime;
        }
    }
}
