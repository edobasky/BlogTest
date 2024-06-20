using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BlogtestAssessment.Features.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<bool>
    {
        [Required]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is a required field")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
