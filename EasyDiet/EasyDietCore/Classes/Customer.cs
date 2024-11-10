namespace EasyDiet
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Weight> MyWeigths { get; set; }
        public Diet MyDiet { get; set; }
        public bool Status { get; set; }

        public Customer(int id, string name, Diet myDiet)
        {
            Id = id;
            Name = name;
            MyWeigths = new List<Weight>();
            MyDiet = myDiet;
            Status = true;
        }
    }
}
