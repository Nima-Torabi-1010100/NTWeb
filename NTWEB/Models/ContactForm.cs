using NTWEB._01_Framework;
using System.ComponentModel.DataAnnotations;

namespace NTWEB.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Email { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Subject { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Message { get; set; }
    }
}
