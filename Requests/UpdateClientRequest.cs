using System.ComponentModel.DataAnnotations;

namespace CrudClientAPI.Requests
{
    public class UpdateClientRequest
    {
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Birth date")]
        public DateTime BirthDate { get; set; }
    }
}