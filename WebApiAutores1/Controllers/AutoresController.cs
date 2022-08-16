using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiAutores1.Entidades;

namespace WebApiAutores1.Controllers
{

    [ApiController]
    [Route("Api/autores")]
    public class AutoresController : ControllerBase

    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {

            return await context.Autores.ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{Id:int}")] 
        public async Task<ActionResult> Put(Autor autor, int Id)
        {
            if (autor.Id != Id)
            {
                return BadRequest("El ID del autor no es igual al de la URL");
            }

            var existe = await context.Autores.AnyAsync(x => x.Id == Id);
            if (!existe)
            {
                return NotFound("No se puede Actualizar porque el registro no existe");
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == Id);
            if (!existe)
            {
                return NotFound("No se puede eliminar porque el registro no existe");
            }
            context.Remove(new Autor { Id = Id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
