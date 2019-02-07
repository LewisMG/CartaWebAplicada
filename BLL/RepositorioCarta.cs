using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioCarta : RepositorioBase<Carta>
    {
        public bool Guardar(Carta entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                if (contexto.cartas.Add(entity) != null)
                {

                    var cuenta = contexto.destinatarios.Find(entity.DestinarioId);
                    //Incrementar el balance
                    cuenta.CantidadCarta += 1;


                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Carta cartas = contexto.cartas.Find(id);

                if (cartas != null)
                {
                    var destinario = contexto.destinatarios.Find(cartas.DestinarioId);
                    //Incrementar la cantidad
                    destinario.CantidadCarta -= 1;
                    contexto.Entry(destinario).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public override bool Modificar(Carta entity)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            RepositorioBase<Carta> repositorio = new RepositorioBase<Carta>();
            try
            {

                //Buscar

                var depositosanterior = repositorio.Buscar(entity.IdCarta);

                var destinatario = contexto.destinatarios.Find(entity.DestinarioId);
                var Cuentasanterior = contexto.destinatarios.Find(depositosanterior.DestinarioId);

                if (entity.DestinarioId != depositosanterior.DestinarioId)
                {
                    destinatario.CantidadCarta += 1;
                    Cuentasanterior.CantidadCarta -= 1;
                }
               
                contexto.Entry(entity).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }
    }
}
