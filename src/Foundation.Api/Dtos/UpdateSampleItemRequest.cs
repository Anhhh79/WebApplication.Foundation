using System.ComponentModel.DataAnnotations;

namespace Foundation.Api.Dtos
{
    public class UpdateSampleItemRequest
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }
}
