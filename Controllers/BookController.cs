using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Json(new {data = db.Book.ToList()});
        }
    }
}
