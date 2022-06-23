using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProgram.Model
{
    public class SaleModel
    {
        public int id { get; set; }
        public int qtd { get; set; }
        public string productsIds { get; set; }
        public float value { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
        public DateTime deletionDate { get; set; }
    }
}
