
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingRealClasses
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = MappingRealClassesDb"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>(b =>
            {
                b.HasKey(b => b.BlogId);

                b.HasMany(b => b.Titles)
                .WithMany(b => b.Blogs)
                .UsingEntity<BlogTitle>
                (
                    bt =>
                        bt.HasOne(bt => bt.Title)
                        .WithMany()
                        .HasForeignKey(bt => bt.TitlesTitleId),
                    bt =>
                        bt.HasOne(bt => bt.Blog)
                        .WithMany()
                        .HasForeignKey(bt => bt.BlogsBlogId),
                    bt =>
                    {
                        bt.HasKey(bt => new { bt.BlogsBlogId, bt.TitlesTitleId });
                        bt.Property(bt => bt.PublishDate)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");
                    }
                );
            });

            modelBuilder.Entity<Post>(p =>
            {
                p.HasKey(p => p.PostId);

                p.HasMany(p => p.Blogs).WithMany(p => p.Posts);//many to many with blog
                p.HasOne(p => p.Title).WithOne(t => t.Post);//one to one with post 

            });
        }
    }
}
