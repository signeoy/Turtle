using System.ComponentModel.DataAnnotations;

namespace test_4.Models
{
    public class Review
    {
        Review() {}
        
        public Review(Book book, int stars, string text, ApplicationUser user)
        {
            Book = book;
            Stars = stars;
            Text = text;
            User = user;
        }

        public int Id { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }

        [StringLength(1000)]
        public string Text { get; set; } = string.Empty;
        
        // Foreign key to the Book model. This is configured automatically because of the name: <Model>Id
        public int BookId { get; set; }

        // Navigation property to the linked book
        public Book Book { get; set; } = null!;
        
        // Fremmednøkkel til den relevante ApplicationUser
        public string UserId { get; set; }
        
        // application property to user who made review. Lager kobling mellom bruker og review
        public ApplicationUser User { get; set; }
    }
}