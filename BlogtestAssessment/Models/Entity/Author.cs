using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogtestAssessment.Models.Entity
{
    public class Author
    {
        [Key]
        [Column("AuthorId")]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<Blog>? Blogs { get; set; }
    }
}
