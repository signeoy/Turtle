using Microsoft.AspNetCore.Identity;
using test_4.Models;

namespace test_4.Data
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext db, UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm)
        {
            // Delete the database before we initialize it. This is common to do during development.
            db.Database.EnsureDeleted();

            // Recreate the database and tables according to our models
            db.Database.EnsureCreated();

            // Add test data to simplify debugging and testing

            var authors = new[]
            {
                new Author("Author 1", "Author 1", new DateTime(1981, 1, 1)),
                new Author("Author 2", "Author 2", new DateTime(1982, 2, 2)),
                new Author("Author 3", "Author 3", new DateTime(1983, 3, 3))
            };
            
            db.Authors.AddRange(authors);

            var books = new[]
            {
                new Book("Book 1", "Summary 1", new DateTime(2001, 1, 1)),
                new Book("Book 2", "Summary 2", new DateTime(2002, 2, 2)),
                new Book("Book 3", "Summary 3", new DateTime(2003, 3, 3))
            };
            
            db.Books.AddRange(books);
            
            // Save changes before adding relationships
            db.SaveChanges();
            
            // Add relationships. You do this directly on the objects.
            
            // The first book has 0 authors, the second book has 1 author and the third book has 2 authors
            books[1].Authors.Add(authors[1]);
            books[2].Authors.Add(authors[1]);
            books[2].Authors.Add(authors[2]);
            
            // Finally save the added relationships
            db.SaveChanges();
            
            
            // Lag roller
            var adminRole = new IdentityRole("Admin");
            rm.CreateAsync(adminRole).Wait(); //venter til den er ferdig med å opprette rollen før den kjører

            // Add standard users
            var admin = new ApplicationUser
                { UserName = "admin@uia.no", Email = "admin@uia.no", Nickname = "Admin User", EmailConfirmed = true};
            
            var user = new ApplicationUser
                { UserName = "user@uia.no", Email = "user@uia.no", Nickname = "user", EmailConfirmed = true };
            
            // sett passord
            um.CreateAsync(admin, "Password1.").Wait();
            um.CreateAsync(user, "Password1.").Wait();
            
            // gi bruker rolle admin
            um.AddToRoleAsync(admin, "Admin").Wait();
            
            
            
            //lager noen reviews
            var reviews = new[]
            {
                new Review( books[0], 5, "This book loves you", user)
            };
            
            db.Reviews.AddRange(reviews);


            db.SaveChanges();
        }
    }
}