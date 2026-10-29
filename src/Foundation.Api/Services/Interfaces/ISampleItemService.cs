using Foundation.Api.Dtos;
using Foundation.Api.Models;

namespace Foundation.Api.Services.Interfaces
{
    public interface ISampleItemService
    {
        Task<List<SampleItem>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<SampleItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<SampleItem> CreateAsync(CreateSampleItemRequest item, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(int id, UpdateSampleItemRequest updatedItem, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

    }
}
