using Application.Order.Commands.CreateOrder;
using Application.Order.Commands.DeleteOrder;
using Application.Order.Commands.UpdateOrder;
using Application.Order.Queries.GetAllOrders;
using Application.Order.Queries.GetOrderById;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet("{orderId:guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid orderId, CancellationToken cancellationToken)
        {
            var order = await Sender.Send(new GetOrderQuery { Id = orderId }, cancellationToken);

            return Ok(order);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
        {
            var orders = await Sender.Send(new GetOrdersQuery(), cancellationToken);

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateOrderCommand
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                UserId = request.UserId,
                CustomerId = request.CustomerId,
                ItemId = request.ItemId
            };

            var orderId = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetOrderById), new { orderId }, orderId);
        }

        [HttpDelete("{orderId:guid}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] Guid orderId, CancellationToken cancellationToken)
        {
            var command = new DeleteOrderCommand
            {
                Id = orderId
            };

            await Sender.Send(command, cancellationToken);

            return NoContent();        }

        [HttpPut("{orderId:guid}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid orderId, [FromBody] UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateOrderCommand
            {
                Id = orderId,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            await Sender.Send(command, cancellationToken);

            return Ok();
        }
    }
}
