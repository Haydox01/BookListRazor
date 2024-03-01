using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task <IActionResult> GetAll()
        {
            return Json(new {data = db.Book.ToListAsync()});
        }
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromdb = await db.Book.FirstOrDefaultAsync(x => x.Id == id);
            if (bookFromdb == null)
            {
                return Json(new {success = false, message= "Error while deleting"});
            }
            db.Book.Remove(bookFromdb);
            db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
            
                
            
        }
    }

}
