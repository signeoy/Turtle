using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_4.Models
{
    public class Author
    {
        public Author() {}
        
        public Author(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DisplayName("Last name")]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayName("Birthdate")]
        public DateTime Birthdate { get; set; }
        
        // List of books written by this author. Creates a many to many relationship with the list in the Book model.
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}