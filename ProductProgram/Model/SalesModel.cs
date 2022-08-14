namespace ProductProgram.Model
{
    public class SalesModel
    {
        public int? id { get; set; }

        public int? saleId { get; set; }

        public int? productId { get; set; }

        public int? qtd { get; set; }

        public float? value { get; set; }

        public DateTime? creationDate { get; set; }

        public DateTime? updateDate { get; set; }

        public DateTime? deletionDate { get; set; }
    }
}
