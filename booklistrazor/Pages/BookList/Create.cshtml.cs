using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using booklistrazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace booklistrazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _appDb;

        public CreateModel(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _appDb.AddAsync(Book);
                await _appDb.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
