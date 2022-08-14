using static ProductProgram.EnumProgram.Enums;

namespace ProductProgram.Model
{
    public class ProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public float value { get; set; }
        public ProductType productType { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
        public DateTime deletionDate { get; set; }
    }
}
