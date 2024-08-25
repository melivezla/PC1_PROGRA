using System;
using System.ComponentModel.DataAnnotations;

namespace PC1_TEO_PROGRA_CHAVEZMELI.Models
{
    public class OperacionBolsa
    {
        
        public OperacionBolsa()
        {
            Nombre = string.Empty;
            CorreoElectronico = string.Empty;
        }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string CorreoElectronico { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaOperacion { get; set; }

        public bool SP500 { get; set; }
        public bool DowJones { get; set; }
        public bool BonosUS { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal MontoAbonar { get; set; }

        public decimal IGV { get; set; }
        public decimal Comision { get; set; }
        public decimal TotalPagar { get; set; }
    }
}

