using System.ComponentModel.DataAnnotations;

namespace OrdersChallenge.Models
{
    public class OrdersModel
    {
        public Guid Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Cliente { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        [Required]
        public Decimal Total { get; set; }
    }

}
