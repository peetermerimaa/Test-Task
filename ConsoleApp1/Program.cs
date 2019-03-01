using System;
using System.Collections.Generic;
using System.Globalization;


namespace ConsoleApp1
{
    class Program
    {
        static GenerationValues generationValues = new GenerationValues("C:\\Test_task\\");
        private static DateTime userDate;
        private static DateTime userInput;

        static void Main(string[] args)
        {
            List<DateProfile> listOfDateProfiles = generationValues.ReadDateProfiles();
            List<DateProfileHoursData> listOfHoursData = generationValues.ReadHoursData();
            
            Boolean moreAsking = true;
            while (moreAsking)
            {
                Boolean noException = false;
                while (!noException)
                {
                    try
                    {
                        System.Console.WriteLine("Please input period (m/yyyy): ");
                        string userInput = System.Console.ReadLine();
                        string pattern = "M/yyyy";
                        DateTime userDate = DateTime.ParseExact(userInput, pattern, CultureInfo.InvariantCulture);
                        noException = true;
                    } catch (Exception e)
                    {
                        System.Console.WriteLine("Wrong input format. Please try again.");
                    }
                       
                }
                
                int[] generated = generationValues.CheckUserInput(userDate);

                System.Console.WriteLine("Date Period: {0}", userInput);
                if (generated[24] <= 0)
                {
                    System.Console.WriteLine("No Power Generated In Period {0}", userInput);
                }
                else
                {
                    CalculateNumbers(listOfDateProfiles,listOfHoursData, userDate, generated);
                }

                System.Console.WriteLine("Lets Calculate One More Time? y/n");
                string answer = "a";
                while (!answer.Equals("n")&& !answer.Equals("y")) {
                    answer = System.Console.ReadLine();
                    if (answer.Equals("n")) { moreAsking = false; }
                } 
            }   
        }

        public static void CalculateNumbers(List<DateProfile> listOfDateProfiles,
            List<DateProfileHoursData> listOfHoursData, DateTime userDate, int[] generated)
        {
            int powerOnPeak = 0;
            decimal revenueOnPeak = 0.0M;
            int powerOffPeak = 0;
            decimal revenueOffPeak = 0.0M;

            for (int i=0;i<=23;i++)
            {
                foreach(DateProfileHoursData item in listOfHoursData)
                {
                    if(item.Prevailing_start_date_time.Equals(userDate.AddHours(i)))
                    {
                        foreach(DateProfile profile in listOfDateProfiles)
                        {
                            if(profile.Date_profile_id == item.Date_profile_id)
                            {
                                if(profile.Name.Equals("Off Peak"))
                                {
                                    revenueOffPeak += profile.Price * generated[i];
                                    powerOffPeak += generated[i];

                                } else if (profile.Name.Equals("On Peak"))
                                {
                                    revenueOnPeak += profile.Price * generated[i];
                                    powerOnPeak += generated[i];
                                }
                            } 
                        }
                            
                    }
                }
            }        
             System.Console.WriteLine("Power Generated On Peak: {0}MW, {1}$", powerOnPeak, revenueOnPeak);
             System.Console.WriteLine("Power Generated Off Peak: {0}MW, {1}$", powerOffPeak, revenueOffPeak);
        }
    }
}
