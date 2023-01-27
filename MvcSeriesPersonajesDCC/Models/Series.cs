using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcSeriesPersonajesDCC.Models
{
    [Table("SERIES")]
    public class Series
    {
        [Key]
        [Column("IDSERIE")]
        public int IdSerie { get; set; }
        [Column("NOMBRE")]
        public string Nombre { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("ANYO")]
        public int Anyo { get; set; }
    }
}
