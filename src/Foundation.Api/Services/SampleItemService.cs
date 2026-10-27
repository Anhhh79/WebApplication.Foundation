using Foundation.Api.Dtos;
using Foundation.Api.Models;

namespace Foundation.Api.Services
{
    public class SampleItemService
    {
        public Guid InstanceId { get; } = Guid.NewGuid();
        private readonly List<SampleItem> _lstItem = new List<SampleItem>()
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

        public List<SampleItem> GetAll()
        {
            return _lstItem;
        }

        public SampleItem? GetById(int id)
        {   
            return _lstItem.FirstOrDefault(x => x.Id == id);
        }

        public SampleItem Add(CreateSampleItemRequest item)
        {
            int newId = _lstItem.Any() ? _lstItem.Max(i => i.Id) + 1 : 1;
            var newItem = new SampleItem
            {
                Id = newId,
                Name = item.Name,
                IsActive = item.IsActive
            };
            _lstItem.Add(newItem);
            return newItem;
        }

        public bool Update(int id,UpdateSampleItemRequest updatedItem)
        {
            var existingItem = _lstItem.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.Name = updatedItem.Name;
            existingItem.IsActive = updatedItem.IsActive;
            return true;
        }

        public bool Delete(int id)
        {
            var existingItem = _lstItem.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return false;
            }
            _lstItem.Remove(existingItem);
            return true;
        }
    }
}
