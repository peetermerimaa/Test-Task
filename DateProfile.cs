namespace ConsoleApp1
{
    internal class DateProfile
    {
        private int date_profile_id;
        private string name;
        private decimal price;

        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public int Date_profile_id { get => date_profile_id; set => date_profile_id = value; }
    }


}