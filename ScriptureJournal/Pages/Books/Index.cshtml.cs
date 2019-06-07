using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal.Models;

namespace ScriptureJournal.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal.Models.ScriptureJournalContext _context;

        public IndexModel(ScriptureJournal.Models.ScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
      [BindProperty(SupportsGet = true)]
      public string SearchString { get; set; }
      // Requires using Microsoft.AspNetCore.Mvc.Rendering;
      public SelectList Genres { get; set; }
      [BindProperty(SupportsGet = true)]
      public string BookGenre { get; set; }//changed from MovieGenre
      public async Task OnGetAsync()
        {
         IQueryable<string> genreQuery = from b in _context.Book
                                         orderby b.Genre
                                         select b.Genre;

         var books = from m in _context.Book
                      select m;
         if (!string.IsNullOrEmpty(SearchString))
         {
            books = books.Where(s => s.Title.Contains(SearchString));
         }
         if (!string.IsNullOrEmpty(BookGenre))
         {
            books = books.Where(x => x.Genre == BookGenre);
         }
         Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
         Book = await books.ToListAsync();
      }
    }
}
