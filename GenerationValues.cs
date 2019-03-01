namespace ConsoleApp1
{
    public class GenerationValues
    {





        public List<DateProfile> readDateProfiles()
        {
            List<DateProfile> listOfDateProfiles = new List<DateProfile>();
            using (var reader = new StreamReader(dirName + "Dateprofile.csv"))
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
    }

}
