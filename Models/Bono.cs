using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finanzas_backend_app.Models 
{
    public class Bono 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idbono { get; set; }
        public int idbonista { get; set; }
        public Double valnominal { get; set; }
        public float valcomercial { get; set; }
        public string? moneda { get; set; }
        public int anios { get; set; }
        public int frecpago { get; set; }
        public int capitalizacion { get; set; }
        public string? tipotasa { get; set; }
        public Double tasainteres { get; set; }
        public Double tasadescuento { get; set; }
        public Double imprenta { get; set; }
        public DateTime? fecemision { get; set; }
        public Double percprima { get; set; }
        public Double percflotacion { get; set; }
        public Double percestructuracion { get; set; }
        public Double perccolocacion { get; set; }
        public Double perccavali { get; set; }
    }
}