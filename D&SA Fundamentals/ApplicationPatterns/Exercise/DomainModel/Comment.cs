using System.ComponentModel.DataAnnotations;

namespace WebShop.DomainModel
{
    public class Comment : BusinessObject
    {
        [Required()]
        public Customer Customer { get; set; }

        [RegularExpression(@"(\w|\s|[-,.'])*", ErrorMessage = "Only alphanumeric characters and the characters hyphen, comma, dot and single quote are allowed for comments")]
        [Required(ErrorMessage = "Comment is a required field")]
        [MinLength(2, ErrorMessage = "A comment should at least contain two characters")]
        [MaxLength(500, ErrorMessage = "This comment is too long, maximum is 500 characters")]
        public string CommentText { get; set; }
    }
}
