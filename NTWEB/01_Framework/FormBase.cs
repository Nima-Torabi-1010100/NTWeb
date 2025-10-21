using System.ComponentModel.DataAnnotations;

namespace NTWEB._01_Framework
{
    public class FormBase
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired), EmailAddress(ErrorMessage = ValidationMessage.EmailRequired)]
        public string Email { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Message { get; set; }
    }
}
