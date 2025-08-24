using NTWEB._01_Framework;
using System.ComponentModel.DataAnnotations;

namespace NTWEB.Models.Service
{
    public class ServiceForm : FormBase
    {
        public string PhoneNumber { get; set; }
        public string ProjectName { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ProjectType { get; set; }
        public string CompanyName { get; set; }
        public int Budget { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string PaymentMethod { get; set; }
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
    }
}
