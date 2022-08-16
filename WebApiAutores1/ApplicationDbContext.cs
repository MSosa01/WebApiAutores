using Microsoft.EntityFrameworkCore;
using WebApiAutores1.Entidades;

namespace WebApiAutores1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

    }
}
