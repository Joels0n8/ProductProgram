using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductProgram.Model;
using static ProductProgram.EnumProgram.Enums;

namespace ProductProgram.Validators
{
    public class ProductValidator
    {
        public ProductValidator()
        {

        }

        public void ValidateProduct(string name, string value, string type)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("o produto deve conter um nome");
            }

            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new Exception("o produto deve conter um valor");
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new Exception("o produto deve conter um tipo");
            }
        }
    }
}
