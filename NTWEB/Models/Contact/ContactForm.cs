using NTWEB._01_Framework;
using System.ComponentModel.DataAnnotations;

namespace NTWEB.Models.Contact
{
    public class ContactForm : FormBase
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Subject { get; set; }
    }
}
