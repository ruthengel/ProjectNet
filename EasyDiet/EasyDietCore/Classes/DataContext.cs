using EasyDiet;
using EasyDietCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace EasyDietCore.Classes
{
    public class DataContext : IDataContext
    {

        public List<Customer> Customers { get; set; }
        public List<Diet> Diets { get; set; }
        public List<Coach> Coaches { get; set; }


        public DataContext()
        {
            Customers = new List<Customer>();
            Diets = new List<Diet>();
            Coaches = new List<Coach>();
        }
    }
}
