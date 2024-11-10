namespace EasyDiet
{
    public class Weight
    {
        public DateTime Date { get; set; }
        public double CurrentWeight { get; set; }

        public Weight(DateTime date, double currentWeight)
        {
            Date = date;
            CurrentWeight = currentWeight;
        }
    }
}
