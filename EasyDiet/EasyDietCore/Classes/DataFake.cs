using EasyDiet;
using EasyDietCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyDietCore.Classes
{
    public class DataFake : IDataContext
    {

        public List<Customer> Customers { get; set; }
        public List<Diet> Diets { get; set; }
        public List<Coach> Coaches { get; set; }


        public DataFake()
        {
            Customers = new List<Customer>();
            Diets = new List<Diet>();
            Coaches = new List<Coach>() { };
            Coaches.Add(new Coach (  1, "ruth", "bb",  "0534150116"));
            Coaches.Add(new Coach(2, "ruth", "bb", "0534150116"));
        }
    }
}
