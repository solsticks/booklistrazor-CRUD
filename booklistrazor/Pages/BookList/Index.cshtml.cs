using booklistrazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace booklistrazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _appDb;

        public IndexModel(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        public IEnumerable<Book> Books { get; set; }
        public async Task OnGet()
        {
            Books = await _appDb.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _appDb.Books.FindAsync(id);
            if(book == null)
            {
                return NotFound();
            }
            _appDb.Books.Remove(book);
            await _appDb.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
