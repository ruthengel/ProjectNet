namespace EasyDiet
{
    public class Diet
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public static int CountMembers { get; set; } = 0;
        public int Coach { get; set; }
        public bool Status { get; set; }
        public Diet(string name, double price,int coach)// Coach coach)
        {
            Code = ++CountMembers;
            Name = name;
            Price = price;
            Coach = coach;
            Status = true;
        }
    }
}
