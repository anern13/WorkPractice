// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MigrationOverview;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new BlogContext())
        {
            //db.Database.Migrate();

            db.Blogs.Add(new Blog { Name = "Another Blog " , Url = "askljdfhlkajsdfh"});
            db.SaveChanges();

            foreach (var blog in db.Blogs)
            {
                Console.WriteLine(blog.Name);
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}