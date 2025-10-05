namespace OrdersChallenge.Models
{
    public class AddOrderModel
    {
        public string Cliente { get; set; } = string.Empty;

        public Decimal Total { get; set; } = Decimal.Zero;
    }
}
