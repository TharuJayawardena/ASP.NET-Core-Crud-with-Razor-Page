using BulkyBook.Data;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook.Pages.Categories;
[BindProperties]
public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _db;
  
    public Catergory Catergory { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
       
    }

    public void OnGet(int id)
    {
        Catergory = _db.Catergory.Find(id);
       
        
    }

    public async Task<IActionResult> OnPost(Catergory catergory)
    {
       
            var catergoryFromDb = _db.Catergory.Find(Catergory.Id);
            if( catergoryFromDb != null)
            {
                _db.Catergory.Remove(catergoryFromDb);
                await _db.SaveChangesAsync();
            TempData["Success"] = "Catergory deleted successfully";
            return RedirectToPage("Index");
            }
            
           
            
        
        return Page();
       
    }
}
