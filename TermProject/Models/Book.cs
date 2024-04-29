using System.ComponentModel.DataAnnotations;

namespace TermProject.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
    }
}
