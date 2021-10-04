using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
    public class ConfirmBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
