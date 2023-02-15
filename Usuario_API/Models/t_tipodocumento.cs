using System.ComponentModel.DataAnnotations;

namespace Usuario_API.Models
{
    public class t_tipodocumento
    {

        [Key]


        public int tipodocumentoid { get; set; }

        public string? tipodocumentonombre { get; set; }


    }
}
