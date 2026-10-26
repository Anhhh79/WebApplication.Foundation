using System.ComponentModel.DataAnnotations;

namespace Foundation.Api.Models
{
    public class SampleItem
    {
        [Range(1, int.MaxValue, ErrorMessage = "Id must be greater than 0.")]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
    }
}
