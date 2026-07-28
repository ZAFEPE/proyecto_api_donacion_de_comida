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
    }
}