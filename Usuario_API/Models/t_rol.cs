using System.ComponentModel.DataAnnotations;

namespace Usuario_API.Models
{
    public class t_rol
    {

        [Key]

        public int Rolid { get; set; }
        [Required]

        public string? RolNombre { get; set; }


    }
}
