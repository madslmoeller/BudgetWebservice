using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMVVM.Model
{
    class MainCatagory
    {
        // Bipin

        public int Id { get; set; } //yo property coz hamilai paxi newcat. vanera yo field bind garnu xa.
        public string Name { get; set; }

        public MainCatagory()
        {

        }

        public MainCatagory(int id, string name)
        {
            Id = id;
            Name = name;

        }

        public override string ToString()
        {
            return $"CategoryId: {Id}, Name: {Name}";
        }

    }
}
