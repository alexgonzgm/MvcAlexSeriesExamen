using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcAlexSeriesExamen.Models
{
    [Table("SERIES")]
    public class Serie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IDSERIE")]
        public int IdSerie { get; set; }
        [Column("SERIE")]
        public string NombreSerie { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("PUNTUACION")]
        public double Puntuacion { get; set; }
        [Column("AÑO")]
        public int Year { get; set; }

    }
}
