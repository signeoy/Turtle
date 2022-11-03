using System.ComponentModel.DataAnnotations;

namespace test_4.Models
{
    public class Book
    {
        public Book() {}
        public Book(string title, string summary, DateTime published)
        {
            Title = title;
            Summary = summary;
            Published = published;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Summary { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Published { get; set; }

        // List of reviews. creates a one to many relationship together with BookId and Book in the Review model.
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        
        // List of authors of this book. Creates a many to many relationship with the list in the Author model.
        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}