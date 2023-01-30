using BulkyBook.Data;
using BulkyBook.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyBook.Pages.Categories;
[BindProperties]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
  
    public Catergory Catergory { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
       
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(Catergory catergory)
    {
        if (Catergory.Name == Catergory.DisplayOrder.ToString())
        {
            ModelState.AddModelError(Catergory.Name, "The Display Order Cannot Exactly Match the name");
        }
        if (ModelState.IsValid)
        {
            await _db.Catergory.AddAsync(catergory);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Catergory created successfully";
            return RedirectToPage("Index");
        }
        return Page();
       
    }
}
