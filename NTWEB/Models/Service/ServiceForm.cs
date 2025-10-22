using NTWEB._01_Framework;
using System.ComponentModel.DataAnnotations;

namespace NTWEB.Models.Service
{
    public class ServiceForm : FormBase
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ProjectType { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PaymentMethod { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Country { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string City { get; set; }
        public string Location { get; set; }
    }
}
