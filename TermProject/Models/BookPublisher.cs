using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class BookPublisher
    {
        [Key]
        public int BookID { get; set; }
        public int PublisherID { get; set; }
    }
}
