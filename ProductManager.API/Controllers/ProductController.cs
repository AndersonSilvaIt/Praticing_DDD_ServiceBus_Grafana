using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Application.Commands;
using ProductManager.Application.Queries;

namespace ProductManager.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProdutoController: ControllerBase
	{
		private readonly IMediator _mediator;

		public ProdutoController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var query = new GetAllProductsQuery();
			var response = await _mediator.Send(query);

			return Ok(response);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var query = new GetProductByIdQuery(id);
			var response = await _mediator.Send(query);

			if(response == null)
				return NotFound();

			return Ok(response);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
		{
			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			var id = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetById), new { id }, id);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductCommand command)
		{
			if(!ModelState.IsValid)
				return BadRequest(ModelState);

			command.Id = id;
			var result = await _mediator.Send(command);

			if(!result)
				return NotFound();

			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteProductCommand(id);
			var result = await _mediator.Send(command);

			if(!result)
				return NotFound();

			return NoContent();
		}
	}
}
