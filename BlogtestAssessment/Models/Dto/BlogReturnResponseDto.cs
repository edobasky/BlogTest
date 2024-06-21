using BlogtestAssessment.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogtestAssessment.Models.Dto
{
    public class BlogReturnResponseDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Url { get; set; }

        public int AuthorId { get; set; }
    }
}
