using System.ComponentModel.DataAnnotations;

namespace OrdersChallenge.Models
{
    public class AddOrderModel
    {
        [MaxLength(40)]
        [Required]
        public string Cliente { get; set; } = string.Empty;

        [Required]
        public Decimal Total { get; set; } = Decimal.Zero;
    }
}
