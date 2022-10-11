using carte2Layer.Infrastructure;
using Carte2Layer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Carte2.Pages.Citoyens
{
        public class EditModel : PageModel
        {
            private readonly ICarte carteData;
            [BindProperty]
            public Citoyen Citoyen { get; set; }

            public EditModel(ICarte carteData)
            {
                this.carteData = carteData;
            }

            public IActionResult OnGet(int? id)
            {
                if (id.HasValue)
                {
                    Citoyen = carteData.GetById(id.Value);
                }
                else
                {
                    Citoyen = new Citoyen();
                }
                if (Citoyen == null)
                {
                    return RedirectToPage("./NotFound");
                }
                return Page();
            }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                { 
                    return Page();
                }

                if (Citoyen.Id == 0)
                {
                    carteData.Add(Citoyen);
                }
                else
                {
                    carteData.Update(Citoyen);
                }
                carteData.Commit();
                return RedirectToPage("./List");
            }
        }
}

