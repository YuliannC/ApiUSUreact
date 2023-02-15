using System.ComponentModel.DataAnnotations;

namespace Usuario_API.Models
{
    public class t_producto
 
        {

            [Key]

            public int pro_id  { get; set; }
            [Required]
            public int  pro_codigo { get; set; }
            public string? pro_nombre { get; set; }
            public decimal pro_precio { get; set; }
            public string? pro_descripcion { get; set; } 
            public int  pro_cat_id { get; set; }

        }
    }
