using BulkyBook.Data;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook.Pages.Categories;
[BindProperties]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _db;
  
    public Catergory Catergory { get; set; }

    public EditModel(ApplicationDbContext db)
    {
        _db = db;
       
    }

    public void OnGet(int id)
    {
        Catergory = _db.Catergory.Find(id);
        Catergory = _db.Catergory.FirstOrDefault(u=>u.Id==id);
        Catergory = _db.Catergory.SingleOrDefault(u=>u.Id==id);
        Catergory = _db.Catergory.Where(u => u.Id == id).FirstOrDefault();
        
    }

    public async Task<IActionResult> OnPost(Catergory catergory)
    {
        if (Catergory.Name == Catergory.DisplayOrder.ToString())
        {
            ModelState.AddModelError(Catergory.Name, "The Display Order Cannot Exactly Match the name");
        }
        if (ModelState.IsValid)
        {
            _db.Catergory.Update(catergory);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Catergory updated successfully";
            return RedirectToPage("Index");
        }
        return Page();
       
    }
}
