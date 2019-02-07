using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Carta
    {
        [Key]
        public int IdCarta { get; set; }
        public DateTime Fecha { get; set; }
        public int DestinarioId { get; set; }
        public string Cuerpo{ get; set; }

        public Carta()
        {
            IdCarta = 0;
            Fecha = DateTime.Now;
            DestinarioId = 0;
            Cuerpo = string.Empty;
        }

        public Carta(int idCarta, DateTime fecha, int destinarioId, string cuerpo)
        {
            IdCarta = idCarta;
            Fecha = fecha;
            DestinarioId = destinarioId;
            Cuerpo = cuerpo;
        }        
    }
}
