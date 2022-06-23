using ProductProgram.Model;
using ProductProgram.Validators;
using static ProductProgram.EnumProgram.Enums;

namespace ProductProgram.Mapper
{
    public class ProductMapper
    {
        public ProductModel ProductDTO(string name, float value, string type)
        {
            ProductValidator productValidator = new ProductValidator();
            productValidator.ValidateProduct(name, value, type);

            ProductModel productMapper = new ProductModel();
            
            productMapper.name = name;
            productMapper.value = value;
            productMapper.productType = (ProductType)Enum.Parse(typeof(ProductType), type);

            return productMapper;
        }
    }
}
