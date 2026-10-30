using System.ComponentModel.DataAnnotations;

namespace Foundation.Api.Models
{
    public class SampleItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public string? InternalNote { get; set; }
    }
}
