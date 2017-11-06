using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebShop.DomainModel
{
    public class Product : BusinessObject
    {

        [Required(ErrorMessage = "A product name is required")]
        [MinLength(2, ErrorMessage = "A product name should at least contain two characters")]
        [MaxLength(50, ErrorMessage = "A product name contains at most 50 characters")]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A product description is required")]
        [MinLength(2, ErrorMessage = "A product description should at least contain two characters")]
        [MaxLength(255, ErrorMessage = "A product description contains at most 255 characters")]
        [RegularExpression(@"([\.,\-%/']|\w|\s)*", ErrorMessage="Only alphanumeric characters and some punctuations are allowed for Description")]
        [DataMember(IsRequired = true)]
        public string Description { get; set; }      

        [Required(ErrorMessage = "A product must have a price")]
        [Range(0.01, 10000, ErrorMessage = "The price should be between 0,01 and 10000")]
        [DataMember(IsRequired = true)]
        public decimal Price { get; set; }        
        
        [IgnoreDataMember()]
        public Collection<Comment> Comments { get; set; }
    }
}
