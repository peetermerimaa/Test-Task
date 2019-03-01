using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    internal class GenerationValues
    {
        
        private string dirName;

        internal string DirName { get => dirName; set => dirName = value; }

        public GenerationValues(string dirName)
        {
            DirName = dirName;
        }

        public List<DateProfile> ReadDateProfiles()
        {
            List<DateProfile> listOfDateProfiles = new List<DateProfile>();
            using (var reader = new StreamReader(dirName + "DateProfile.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    DateProfile dateProfile = new DateProfile();
                    for (int i = 0; i < values.Length; i++)
                    {
                        dateProfile.Date_profile_id = int.Parse(values[0]);
                        dateProfile.Name = values[1];
                        dateProfile.Price = decimal.Parse(values[2]);
                    }
                    listOfDateProfiles.Add(dateProfile);
                }
            }
            return listOfDateProfiles;
        }

        public List<DateProfileHoursData> ReadHoursData()
        {
            List<DateProfileHoursData> listOfHoursData = new List<DateProfileHoursData>();
            using (var reader = new StreamReader(dirName + "DateProfileHoursData.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    DateProfileHoursData hoursData = new DateProfileHoursData();
                    for (int i = 0; i < values.Length; i++)
                    {
                        hoursData.Id = int.Parse(values[0]);
                        hoursData.Date_profile_id = int.Parse(values[1]);
                        string pattern = "M/d/yyyy H:mm";
                        hoursData.Prevailing_start_date_time = DateTime.ParseExact(values[2], pattern, CultureInfo.InvariantCulture);
                    }
                    listOfHoursData.Add(hoursData);
                }
            }
            return listOfHoursData;
        }

        public int[] CheckUserInput(DateTime userDate) {

            int[] arr = new int[26];

            using (var reader = new StreamReader(dirName + "GenerationValues.csv"))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    string pattern = "d-MMM-yy";
                    DateTime monthDate = DateTime.ParseExact(values[0], pattern, CultureInfo.InvariantCulture);

                    if (monthDate.Equals(userDate))
                    {
                        for (int i = 1; i <=24; i++)
                        {
                        
                            if(values[i]==null) { values[i] = "0"; }
                            arr[i-1] = int.Parse(values[i]);
                            arr[24]+= int.Parse(values[i]);
                            
                        }
                        return arr; 
                    }
                }
            }
            arr[25] = -1;
            return arr;
        }

    }
}