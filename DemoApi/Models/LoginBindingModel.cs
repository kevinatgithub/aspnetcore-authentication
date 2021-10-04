using System.ComponentModel.DataAnnotations;

namespace DemoApi.Models
{
    public class LoginBindingModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
