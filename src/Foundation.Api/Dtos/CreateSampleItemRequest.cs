using System.ComponentModel.DataAnnotations;

namespace Foundation.Api.Dtos
{
    public class CreateSampleItemRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters." )]
        public string Name { get; set; } = string.Empty;
        public bool? IsActive { get; set; }
    }
}
