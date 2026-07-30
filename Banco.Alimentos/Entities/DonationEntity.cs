using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAlimentos.Entities
{
    public class DonationEntity
    {
        public string?  IdDonante { get; set; }//id_donante	Clave foránea (FK)	Enlace con el id_donante de la tabla anterior. No me acorde como se hacia esto, Herencia de alguna forma supongo pero no se \(#o#)/
        public DateTime FechaDeDonacion { get; set; }// fecha cuando se hizo la donacion
        public string? TipoAlimento { get; set; }//Clasificación: Perecedero, No perecedero, Enlatados, Frescos, Bebidas.
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }
        public bool NecesitaRefrigeracion { get; set; } // pos eso si necesita refrigeracion.
        public string? ResponsableRecibir { get; set; }
        public string? Observaciones { get; set; }
        
    }
}