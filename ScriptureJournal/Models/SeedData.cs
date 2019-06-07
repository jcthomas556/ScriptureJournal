using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ScriptureJournal.Models
{
   public static class SeedData
   {
      public static void Initialize(IServiceProvider serviceProvider)
      {
         using (var context = new ScriptureJournalContext(
             serviceProvider.GetRequiredService<
                 DbContextOptions<ScriptureJournalContext>>()))
         {
            // Look for any movies.
            if (context.Book.Any())
            {
               return;   // DB has been seeded
            }

            context.Book.AddRange(
                new Book
                {
                   Title = "I Nephi",
                   ReleaseDate = DateTime.Parse("2019-2-6"),
                   Genre = "Book of Mormon",
                   Price = 7.99M,
                   Notes = "I like this scripture",
                },

                new Book
                {
                   Title = "Section 93",
                   ReleaseDate = DateTime.Parse("2015-3-12"),
                   Genre = "Doctrine and Covenants",
                   Price = 93.53M,
                   Notes = "It's easy to think that all we really need to read is the BoM but it says right here there is good info in the Bible too",
                },

                new Book
                {
                   Title = "Abraham",
                   ReleaseDate = DateTime.Parse("2013-2-23"),
                   Genre = "Pearl of Great Price",
                   Price = 3.7m,
                   Notes = "We don't always understand everything",
                },

                new Book
                {
                   Title = "II Nephi",
                   ReleaseDate = DateTime.Parse("2017-4-25"),
                   Genre = "Book of Mormon",
                   Price = 13.8M,
                   Notes = "",
                },
               new Book
               {
                  Title = "Ezra",
                  ReleaseDate = DateTime.Parse("2019-3-15"),
                  Genre = "Old Testament",
                  Price = 7.8M,
                  Notes = "He was king a long time!",
               },
               new Book
               {
                  Title = "II Nephi",
                  ReleaseDate = DateTime.Parse("2013-8-15"),
                  Genre = "Book of Mormon",
                  Price = 3.25M,
                  Notes = "",
               },
               new Book
               {
                  Title = "Section 40",
                  ReleaseDate = DateTime.Parse("2001-9-5"),
                  Genre = "Doctrine and Covenants",
                  Price = 40.2M,
                  Notes = "Better watch out",
               }
            );
            context.SaveChanges();
         }
      }
   }
}