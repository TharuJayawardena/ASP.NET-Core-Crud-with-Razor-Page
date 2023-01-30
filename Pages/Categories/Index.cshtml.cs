using BulkyBook.Data;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Catergory> Catergories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;    
        }
        public void OnGet()
        {
            Catergories = _db.Catergory;
        }
    }
}
