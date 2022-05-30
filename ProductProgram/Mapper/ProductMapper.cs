using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductProgram.Model;
using ProductProgram.Validators;
using static ProductProgram.EnumProgram.Enums;

namespace ProductProgram.Mapper
{
    internal class ProductMapper
    {
        public ProductModel ProducMapper(string name, string value, string type)
        {
            ProductValidator productValidator = new ProductValidator();
            productValidator.ValidateProduct(name, value, type);

            ProductModel productMapper = new ProductModel();
            
            productMapper.Name = name;
            productMapper.Value = value;
            productMapper.productType = (ProductType)Enum.Parse(typeof(ProductType), type);

            return productMapper;
        }
    }
}
