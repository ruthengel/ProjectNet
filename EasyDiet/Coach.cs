namespace EasyDiet
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public List<Diet> MyDiets { get; set; }
        public List<Customer> MyCustomers { get; set; }

        public Coach(int id, string name, string city, string phone)
        {
            Id = id;
            Name = name;
            City = city;
            Phone = phone;
            Status = true;
            MyDiets = new List<Diet>();
            MyCustomers = new List<Customer>();
        }
    }
}
