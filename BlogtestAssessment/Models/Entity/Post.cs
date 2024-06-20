using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogtestAssessment.Models.Entity
{
    public class Post
    {
        [Key]
        [Column("PostId")]
        public int id { get; set; }

        public string? Ttle { get; set; }
        public string? Content { get; set; }
        public DateTimeOffset DatePublished { get; set; } = DateTimeOffset.Now;

        [ForeignKey(nameof(Blog))]
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }


    }
}
