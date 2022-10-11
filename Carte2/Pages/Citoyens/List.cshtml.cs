using carte2Layer.Infrastructure;
using Carte2Layer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Carte2.Pages.Citoyens
{
    public class ListModel : PageModel
    {
        private readonly ICarte carteData;

        public IEnumerable<Citoyen> Citoyens { get; set; }
        public ListModel(ICarte carteData)
        {
            this.carteData = carteData;
        }
        public IActionResult OnGet()
        {
            if(carteData != null)
            {
                Citoyens = carteData.GetAll().ToList();
                return Page();
            }
            else
            {
                return RedirectToPage("./NotFound");
            }
                
        }
    }
}
