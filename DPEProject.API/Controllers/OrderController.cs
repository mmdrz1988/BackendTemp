using DPEprojectTask.Domain.Commands.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DPEProject.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> AddOrder(AddOrderCommand addOrderCommand)
        {
            var order = await _mediator.Send(addOrderCommand);
            return Ok(order);
        }
    }
}
