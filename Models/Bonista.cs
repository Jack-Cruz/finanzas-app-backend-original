using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace finanzas_backend_app.Models 
{
    public class Bonista
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idbonista { get; set; }
                
        [StringLength(50)]
        [Required]
        public string? nombre { get; set; }
        
        [StringLength(50)]
        [Required]
        public string? apellido { get; set;}
        [StringLength(10)]
        public string? DNI { get; set; }
        [StringLength(50)]
        public string? correo { get; set; }
        [StringLength(50)]
        public string? celular { get; set; }
        [StringLength(50)]
        public string? usuario { get; set; }
        [StringLength(50)]
        public string? contrasenia { get; set; }
        [StringLength(50)]
        public string? RUC { get; set; }
        [StringLength(100)]
        public string? direccion { get; set; }
        [StringLength(50)]
        public string? region { get; set; }
        [StringLength(50)]
        public string? provincia { get; set; }
        [StringLength(50)]
        public string? distrito { get; set; }
    }
}