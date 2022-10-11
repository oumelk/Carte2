using carte2Layer.Infrastructure;
using Carte2Layer.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Carte2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitoyensController : ControllerBase
    {
        private readonly ICarte _context;

        public CitoyensController(ICarte context)
        {
            _context = context;
        }

        
        [HttpGet]
        public  IEnumerable<Citoyen> GetAll()
        {
            return  _context.GetAll();
        }

        
        [HttpGet("{id}")]
        public  Citoyen GetById (int id)
        {
            var citoyen =  _context.GetById(id);

            if (citoyen == null)
            {
                return null;
            }

            return citoyen;
        }

        
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Citoyen citoyen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != citoyen.Id)
            {
                return BadRequest();
            }
            _context.Update(citoyen);

            try
            {
                _context.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitoyenExists(id))
                {

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();

        }


        [HttpPost]
        public Citoyen Post(Citoyen citoyen)
        {
            _context.Add(citoyen);
            _context.Commit();

            return citoyen;
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var citoyen = _context.GetById(id);
            if (citoyen == null)
            {
                return NotFound();
            }

            _context.Delete(id);
            _context.Commit();

            return Ok(new { message = "Le citoyen est supprimé" });
        }

        private bool CitoyenExists(int id)
        {
            var citoyen = _context.GetById(id);
            if (citoyen == null) { return false; }
            else { return true; }
        }
    }
}
