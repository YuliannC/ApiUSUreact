using Microsoft.EntityFrameworkCore;
using Usuario_API.Models;

namespace Usuario_API
{
    public class usuarioDbContext : DbContext
    {
        public usuarioDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<t_rol> t_rol { get; set; }

        public DbSet<t_tipodocumento> t_tipodocumento { get; set; }

        public DbSet<t_usuario> t_usuario { get; set; }

        public DbSet<t_producto> t_producto { get; set; }
        public DbSet<t_categoria> t_categoria { get; set;}





    }
}
