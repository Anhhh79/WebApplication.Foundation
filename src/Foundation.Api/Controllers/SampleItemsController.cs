using Foundation.Api.Dtos;
using Foundation.Api.Models;
using Foundation.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Api.Controllers
{
    [Route("api/sample-items")]
    [ApiController]
    public class SampleItemsController : ControllerBase
    {
        private readonly SampleItemService _sampleItemService;
        public SampleItemsController(SampleItemService sampleItemService)
        {
            _sampleItemService = sampleItemService;
        }

        // GET: api/sample-items
        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _sampleItemService.GetAll();
            return Ok(items);
        }

        // GET: api/sample-items/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _sampleItemService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/sample-items
        [HttpPost]
        public IActionResult Create([FromBody] CreateSampleItemRequest item)
        {
            var result = _sampleItemService.Add(item);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/sample-items/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSampleItemRequest item)
        {

            var result = _sampleItemService.Update(id, item);   

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/sample-items/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _sampleItemService.Delete(id);

            if (!existingItem)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
