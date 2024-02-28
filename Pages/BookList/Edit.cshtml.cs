using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext db;

        public EditModel(ApplicationDbContext db)
        {
            this.db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int Id)
        {
            
            Book = await db.Book.FindAsync(Id);
            
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Author = Book.Author;
                BookFromDb.ISBN =Book.ISBN;

                await db.SaveChangesAsync();

                return RedirectToPage("Index");

            }
            return RedirectToPage();
        }
    }
}
