using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Usuario_API.Models
{
    public class t_usuario
    {
        [Key]
        public int Id { get; set; }

        public int tipodocumentoid { get; set; }

        public string? numdocumento { get; set; }

        public string? nombres { get; set; }

        public  string? apellidos { get; set; }

        public long  telefono { get; set; }

        public int rolid { get; set; }
        [ForeignKey("rolid")]

        public t_rol? t_rol { get; set; }




    }
}
