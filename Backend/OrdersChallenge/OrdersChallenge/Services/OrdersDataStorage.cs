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
                    Cliente = "Nombre Cliente",
                    Fecha = DateTime.Now,
                    Total = 76614
                }*/ 
            };

        }
    }
}
