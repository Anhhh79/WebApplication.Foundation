using System.ComponentModel.DataAnnotations;

namespace Foundation.Api.Dtos
{
    public class UpdateSampleItemRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; } = false;
    }
}
