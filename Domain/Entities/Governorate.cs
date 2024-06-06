namespace Domain
{
    public class Governorate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<User> Users { get; set; }

        public AddressCount? AddressCount { get; set; }
    }
}