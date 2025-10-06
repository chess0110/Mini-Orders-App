using System.Data;
using Microsoft.AspNetCore.Mvc;
using OrdersChallenge.Models;
using OrdersChallenge.Services;


namespace OrdersChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<OrdersModel>> GetOrders()
        {
            try
            {
                return OrdersDataStorage.OrdersDs.OrdersCollection;
            }
            catch (Exception ex) { 
                return StatusCode(500, ex);
            }
            
        }


        [HttpGet("{idOrder}")]
        public ActionResult<OrdersModel> GetOrder(Guid idOrder)
        {
            var Order = OrdersDataStorage.OrdersDs.OrdersCollection.FirstOrDefault(i => i.Id == idOrder);
            if (Order == null)
            {
                return NotFound("No se encontro la orden.");
            }

            return Ok(Order);
        }


        [HttpPost]
        public ActionResult<OrdersModel> PostOrder([FromBody]AddOrderModel currentPost)
        {
            
            if (currentPost.Total == 0)
            {
                return BadRequest("Total debe ser mayor que cero");
            }
            
            var orderToPost = new OrdersModel()
            {
                Id = Guid.NewGuid(),
                Cliente = currentPost.Cliente,
                Fecha = DateTime.Now,
                Total = currentPost.Total
            };

            OrdersDataStorage.OrdersDs.OrdersCollection.Add(orderToPost);

            return CreatedAtAction(nameof(GetOrder), 
                new { idOrder = orderToPost.Id},
                orderToPost);
        }


        [HttpDelete("{idOrder}")]
        public ActionResult DeleteOrder(Guid idOrder) {
            var orderToRemove = OrdersDataStorage.OrdersDs.OrdersCollection.FirstOrDefault(i => i.Id == idOrder);
            if (orderToRemove == null)
            {
                return NotFound("No se encontro la orden.");
            }
            OrdersDataStorage.OrdersDs.OrdersCollection.Remove(orderToRemove);
            return NoContent();
        }


        [HttpPut("{idOrder}")]
        public ActionResult<OrdersModel> PutOrder([FromRoute]Guid idOrder, [FromBody]AddOrderModel orderToPut)
        {
            var findOrderToPut = OrdersDataStorage.OrdersDs.OrdersCollection.FirstOrDefault(i => i.Id == idOrder);
            if (findOrderToPut == null)
            {
                return NotFound("No se encontro la orden.");
            }else if(findOrderToPut.Total == 0)
            {
                return BadRequest("Total debe ser mayor que cero");
            }


            findOrderToPut.Cliente = orderToPut.Cliente;
            findOrderToPut.Total = orderToPut.Total;
            findOrderToPut.Fecha = DateTime.Now;

            return Ok(findOrderToPut);
        }
    }
}
