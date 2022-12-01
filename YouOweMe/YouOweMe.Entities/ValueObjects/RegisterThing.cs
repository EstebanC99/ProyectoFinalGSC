using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouOweMe.Entities.ValueObjects
{
    public class RegisterThing: ValueObject
    {
        public string? Name { get; set; }

        public string? Color { get; set; }

        public int Quantity { get; set; }

        public Category? Category { get; set; }

    }
}
