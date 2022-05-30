using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProgram.EnumProgram
{
    public class Enums
    {
        public enum Menu
        {
            NewProduct = 1,
            RegisterProduct = 2,
            TotalProducts = 3,
            Exit = 4
        }

        public enum ProductType
        {
            Product = 0,
            Service = 1
        }
    }
}
