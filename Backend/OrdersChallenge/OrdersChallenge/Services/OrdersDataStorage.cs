using OrdersChallenge.Models;

namespace OrdersChallenge.Services
{
    public class OrdersDataStorage
    {
        public List<OrdersModel> OrdersCollection { get; set; }

        public static OrdersDataStorage OrdersDs = new OrdersDataStorage();


        // Datos de prueba ..
        public OrdersDataStorage() {
            OrdersCollection = new List<OrdersModel>() {
                // Para pruebas de los protocolos
                /*new OrdersModel()
                {
                    Id = Guid.NewGuid(),
                    Cliente = "Juan Ramirez",
                    Fecha = DateTime.Now,
                    Total = 76614
                },
                new OrdersModel()
                {
                    Id = Guid.NewGuid(),
                    Cliente = "Amelia Alcantara",
                    Fecha = DateTime.Now,
                    Total = 55917
                },
                new OrdersModel()
                {
                    Id = Guid.NewGuid(),
                    Cliente = "Augusto Martinez",
                    Fecha = DateTime.Now,
                    Total = 46548
                }*/

            };

        }
    }
}
