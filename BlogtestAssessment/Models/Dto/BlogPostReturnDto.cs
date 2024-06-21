using BlogtestAssessment.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogtestAssessment.Models.Dto
{
    public class BlogPostReturnDto
    {
        public int id { get; set; }

        public string? Ttle { get; set; }
        public string? Content { get; set; }
        public DateTimeOffset DatePublished { get; set; }
        public int BlogId { get; set; }
    }
}
