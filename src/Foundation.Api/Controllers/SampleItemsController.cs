using Foundation.Api.Dtos;
using Foundation.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Foundation.Api.Controllers
{
    [Route("api/sample-items")]
    [ApiController]
    public class SampleItemsController : ControllerBase
    {
        private static readonly List<SampleItem> _items = new List<SampleItem>()
        {
            new SampleItem
            {
                Id = 1,
                Name = "Laptop",
                IsActive = true
            },
            new SampleItem
            {
                Id = 2,
                Name = "Mouse",
                IsActive = true
            },
            new SampleItem
            {
                Id = 3,
                Name = "Keyboard",
                IsActive = false
            }
        };

        // GET: api/sample-items
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_items);
        }

        // GET: api/sample-items/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _items.FirstOrDefault(i => i.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST: api/sample-items
        [HttpPost]
        public IActionResult Create([FromBody] CreateSampleItemRequest item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            int newId = _items.Any() ? _items.Max(i => i.Id) + 1 : 1;

            var newItem = new SampleItem
            {
                Id = newId,
                Name = item.Name,
                IsActive = item.IsActive
            };

            _items.Add(newItem);
            return CreatedAtAction(nameof(GetById), new { id =  newId }, newItem);
        }

        // PUT: api/sample-items/id
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSampleItemRequest item)
        {

            var existingItem = _items.FirstOrDefault(i => i.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = item.Name;
            existingItem.IsActive = item.IsActive;

            return NoContent();
        }

        // PATCH: api/sample-items/id
        [HttpPatch("{id}")]
        public IActionResult PartialUpdate(int id, [FromBody] UpdateSampleItemRequest item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(item.Name))
            {
                existingItem.Name = item.Name;
            }
            existingItem.IsActive = item.IsActive;
            return NoContent();
        }

        // DELETE: api/sample-items/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _items.Remove(existingItem);
            return NoContent();
        }
    }
}
