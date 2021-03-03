using booklistrazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace booklistrazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly AppDbContext _appDb;

        public BookController(AppDbContext appDb)
        {
            _appDb = appDb;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _appDb.Books.ToListAsync() });
        }        

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _appDb.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _appDb.Books.Remove(bookFromDb);
            await _appDb.SaveChangesAsync();

            return Json(new { success = true, message = "Delete successful " });
        }
    }
}
