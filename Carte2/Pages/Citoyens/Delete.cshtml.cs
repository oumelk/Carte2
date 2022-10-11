using carte2Layer.Infrastructure;
using Carte2Layer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Carte2.Pages.Citoyens
{
        public class DeleteModel : PageModel
        {
            private readonly ICarte carteData;

            public Citoyen Citoyen { get; set; }

            public DeleteModel(ICarte carteData)
            {
                this.carteData = carteData;
            }
            public IActionResult OnGet(int id)
            {
                Citoyen = carteData.GetById(id);
                if (Citoyen == null)
                {
                    return RedirectToPage("./NotFound");

                }
                return Page();

            }

            public IActionResult OnPost(int id)
            {
                Citoyen citoyen = carteData.Delete(id);
                carteData.Commit();
                if (Citoyen == null)
                {
                    return RedirectToPage("./NotFound");
                }
                return RedirectToPage("./List");
            }
        }
}

