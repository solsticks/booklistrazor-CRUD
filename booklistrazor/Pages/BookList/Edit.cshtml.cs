using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booklistrazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace booklistrazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _appDb;

        public EditModel(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id)
        {
            Book = await _appDb.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _appDb.Books.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Author= Book.Author;
                BookFromDb.ISBN = Book.ISBN;

                await _appDb.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
