using Foundation.Api.Dtos;
using Foundation.Api.Models;
using Foundation.Api.Services;
using Foundation.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Api.Controllers
{
    [Route("api/sample-items")]
    [ApiController]
    public class SampleItemsController : ControllerBase
    {
        private readonly ISampleItemService _sampleItemService;
        public SampleItemsController(ISampleItemService sampleItemService)
        {
            _sampleItemService = sampleItemService;
        }

        // GET: api/sample-items
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var items = await _sampleItemService.GetAllAsync(cancellationToken);
            return Ok(items);
        }

        // GET: api/sample-items/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var item = await _sampleItemService.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/sample-items
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSampleItemRequest item, CancellationToken cancellationToken)
        {
            var result = await _sampleItemService.CreateAsync(item, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/sample-items/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSampleItemRequest item, CancellationToken cancellationToken)
        {

            var result = await _sampleItemService.UpdateAsync(id, item, cancellationToken);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/sample-items/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var existingItem = await _sampleItemService.DeleteAsync(id, cancellationToken);

            if (!existingItem)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
