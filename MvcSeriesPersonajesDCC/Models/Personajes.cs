using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSeriesPersonajesDCC.Models
{
    [Table("PERSONAJES")]
    public class Personajes
    {
        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersonaje { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("IDSERIE")]
        public int IdSerie { get; set; }
    }
}
