namespace OrdersChallenge.Models
{
    public class OrdersModel
    {
        public Guid Id { get; set; }

        public string Cliente { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public Decimal Total { get; set; }
    }

}
