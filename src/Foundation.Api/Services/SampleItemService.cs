using Foundation.Api.Data;
using Foundation.Api.Dtos;
using Foundation.Api.Models;
using Foundation.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Foundation.Api.Services
{
    public class SampleItemService : ISampleItemService
    {
        private readonly ApplicationDbContext _context;

        public SampleItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SampleItem>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await _context.SampleItems.AsNoTracking().ToListAsync(cancellationToken);
            return items;
        }

        public async Task<SampleItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = await _context.SampleItems.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
            return item;
        }

        public async Task<SampleItem> CreateAsync(CreateSampleItemRequest item, CancellationToken cancellationToken = default)
        {
            var newItem = new SampleItem
            {
                Name = item.Name,
                IsActive = item.IsActive
            };
            _context.SampleItems.Add(newItem);
            await _context.SaveChangesAsync(cancellationToken);
            return newItem;
        }

        public async Task<bool> UpdateAsync(int id, UpdateSampleItemRequest updatedItem, CancellationToken cancellationToken = default)
        {
            var existingItem = await _context.SampleItems.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
            if (existingItem == null)
            {
                return false;
            }
            existingItem.Name = updatedItem.Name;
            existingItem.IsActive = updatedItem.IsActive;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var existingItem = await _context.SampleItems.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
            if (existingItem == null)
            {
                return false;
            }
            _context.SampleItems.Remove(existingItem);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}