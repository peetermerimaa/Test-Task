using System;

namespace ConsoleApp1
{
    internal class DateProfileHoursData
    {
        
        private int id;
        private int date_profile_id;
        private DateTime prevailing_start_date_time;

        internal int Id { get => id; set => id = value; }
        internal int Date_profile_id { get => date_profile_id; set => date_profile_id = value; }
        internal DateTime Prevailing_start_date_time { get => prevailing_start_date_time; set => prevailing_start_date_time = value; }
    }
}
