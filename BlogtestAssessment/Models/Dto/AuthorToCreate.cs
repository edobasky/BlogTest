using System.ComponentModel.DataAnnotations;

namespace BlogtestAssessment.Models.Dto
{
    public class AuthorToCreate
    {
        [Required]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is a required field")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
