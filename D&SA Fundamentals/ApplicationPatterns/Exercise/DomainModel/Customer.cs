using System.ComponentModel.DataAnnotations;

namespace WebShop.DomainModel
{
    public class Customer : BusinessObject
    {
        [Required(ErrorMessage="An address is required")]
        [MinLength(2, ErrorMessage="An address should at least contain two characters")]
        [MaxLength(255, ErrorMessage="Address is too long, maximum is 255 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage="Email address is required")]       
        [EmailAddress(ErrorMessage="Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your name is required")]
        [MinLength(2, ErrorMessage = "Name should at least contain two characters")]
        [MaxLength(255, ErrorMessage = "Name is too long, maximum is 255 characters")]
        public string Name { get; set; }

    }
}
