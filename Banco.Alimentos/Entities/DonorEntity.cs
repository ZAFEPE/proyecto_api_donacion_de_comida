using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAlimentos.Entities
{
    public class DonorEntity : BaseEntityProyect
    {
        public string? TipoDeDonante { get; set; } // Categoría: Particular, Supermercado, Restaurante, Empresa, ONG.
        public string? Nombre { get; set; } // nombre del donante
        public string? DNI { get; set; } // Numero de identidad asociado al donante
        public string? NumeroDeContacto { get; set; } // numero de telefono para contactar al donante.
        public string? CorreoElectronico { get; set; } // ps un correo obvio 
    }
}