using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogtestAssessment.Models.Entity
{
    public class Blog
    {
        [Key]
        [Column("BlogId")]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Url { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
