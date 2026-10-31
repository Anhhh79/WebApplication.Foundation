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
            return Ok(items.Select(i => new SampleItemResponse
            {
                Id = i.Id,
                Name = i.Name,
                IsActive = i.IsActive
            }).ToList());
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
            return Ok(new SampleItemResponse
            {
                Id = item.Id,
                Name = item.Name,
                IsActive = item.IsActive
            });
        }

        // POST: api/sample-items
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSampleItemRequest item, CancellationToken cancellationToken)
        {
            if (item.IsActive == null)
            {
                return BadRequest("IsActive field is required.");
            }
            var Entity = new SampleItem
            {
                Name = item.Name,
                IsActive = item.IsActive.Value
            };
            var result = await _sampleItemService.CreateAsync(Entity, cancellationToken);

            if (result == null)
            {
                return Conflict("An item with the same name already exists.");
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, new SampleItemResponse
            {
                Id = result.Id,
                Name = result.Name,
                IsActive = result.IsActive
            });
        }

        // PUT: api/sample-items/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSampleItemRequest item, CancellationToken cancellationToken)
        {
            if (item.IsActive == null)
            {
                return BadRequest("IsActive field is required.");
            }
            var Entity = new SampleItem
            {
                Name = item.Name,
                IsActive = item.IsActive.Value
            };  
            var result = await _sampleItemService.UpdateAsync(id, Entity, cancellationToken);

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
