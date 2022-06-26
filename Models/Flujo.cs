using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finanzas_backend_app.Models 
{
    public class Flujo {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idflujo { get; set; }
        public int idbono { get; set; }
        public int n { get; set; }
        public Double bono { get; set; }
        public Double interes { get; set; }
        public Double cuota { get; set; }
        public Double amortizacion { get; set; }
        public Double prima { get; set; }
        public Double escudo { get; set; }
        public Double flujoemisor { get; set; } 
        public Double flujoemisorescudo { get; set; }
        public Double flujobonista { get; set; } 
        public Double flujoactual { get; set; }
        public Double faplazo { get; set; }
        public Double convexidad { get; set; }
    }
}