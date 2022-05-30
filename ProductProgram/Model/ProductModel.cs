using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProductProgram.EnumProgram.Enums;

namespace ProductProgram.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ProductType productType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeletionDate { get; set; }
    }
}
