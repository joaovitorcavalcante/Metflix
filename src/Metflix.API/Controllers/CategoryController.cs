using MediatR;
using Metflix.Application.Categories.Commands.CreateCategory;
using Metflix.Application.Categories.Commands.RemoveCategoryById;
using Metflix.Application.Categories.Queries.GetAllCategories;
using Metflix.Application.Categories.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

namespace Metflix.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(
            [FromBody] CreateCategoryCommand command)
        {
            var category = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = category.Data.Id }, category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync(
            int pageNumber, int pageSize)
        {
            var query = new GetAllCategoriesQuery(pageNumber, pageSize);

            var paginatedCategories = await _mediator.Send(query);

            return Ok(paginatedCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByIdAsync(Guid id)
        {
            var query = new GetCategoryByIdQuery(id);

            var category = await _mediator.Send(query);

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategoryByIdAsync(Guid id)
        {
            var command = new RemoveCategoryByIdCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
