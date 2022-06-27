using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finanzas_backend_app.Models 
{
    public class BonoResumen {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idresumen { get; set; }

        public int idbono { get; set; }

        public Double precio { get; set; }
        public Double utilidad_perdida { get; set; }

        public Double TCEAemisor { get; set; } 
        public Double TCEAemisorescudo { get; set; } 
        
        public Double tirbonista { get; set;}
        public Double TREAbonista { get; set; }
        public Double duracion { get; set; }
        public Double duracionmod { get; set; }
        public Double convexidad { get; set; }
        public Double total { get; set; }

        public string? moneda { get; set;}
    }
}