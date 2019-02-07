using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Destinatario
    {
        [Key]
        public int DestinatarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public int CantidadCarta { get; set; }

        public Destinatario()
        {
            DestinatarioId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            CantidadCarta = 0;
        }

        public Destinatario(int destinatarioId, DateTime fecha, string nombre, int cantidadCarta)
        {
            DestinatarioId = destinatarioId;
            Fecha = fecha;
            Nombre = nombre;
            CantidadCarta = cantidadCarta;
        }
    }
}
