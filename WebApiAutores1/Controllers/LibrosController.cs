using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApiAutores1.Entidades;

namespace WebApiAutores1.Controllers

{
    [ApiController]
    [Route("api/Libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            return await context.Libros.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existeAutor = await context.Autores.AnyAsync(x=> x.Id == libro.AutorId);
            if (!existeAutor)
            {
                return BadRequest($"No existe el autor de ID: {libro.AutorId}");
            }
            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
