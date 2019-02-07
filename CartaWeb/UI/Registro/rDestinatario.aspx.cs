using BLL;
using CartaWeb.Utilitarios;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaWeb.UI.Registro
{
    public partial class rDestinatario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LimpiarCampos()
        {
            DestinatarioidTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextBox.Text = "";
            CETextBox.Text = "0";
        }

        private void LlenaCampos(Destinatario destinatario)
        {
            DestinatarioidTextBox.Text = destinatario.DestinatarioId.ToString();
            NombreTextBox.Text = destinatario.Nombre;
            CETextBox.Text = destinatario.CantidadCarta.ToString();
        }

        private Destinatario LlenaClase()
        {
            Destinatario destinatario = new Destinatario();

            destinatario.DestinatarioId = Utils.ToInt(DestinatarioidTextBox.Text);
            destinatario.Fecha = Convert.ToDateTime(FechaTextBox.Text).Date;
            destinatario.Nombre = NombreTextBox.Text;
            destinatario.CantidadCarta = Utils.ToInt(CETextBox.Text);

            return destinatario;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatario> repositoriobase = new RepositorioBase<Destinatario>();
            Destinatario destinatario = repositoriobase.Buscar(Utils.ToInt(DestinatarioidTextBox.Text));
            if (destinatario != null)
                if (destinatario != null)
                {
                    LlenaCampos(destinatario);
                    Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
                }
                else
                {
                    Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
                }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatario> repositorio = new RepositorioBase<Destinatario>();
            Destinatario destinatario = new Destinatario();
            bool paso = false;

            destinatario = LlenaClase();

            if (destinatario.DestinatarioId == 0)
            {
                paso = repositorio.Guardar(destinatario);
                Utils.ShowToastr(this, "Guardado Exitosamente!!", "Exito", "success");
                LimpiarCampos();
            }
            else
            {
                Destinatario user = new Destinatario();
                int id = Utils.ToInt(DestinatarioidTextBox.Text);
                RepositorioBase<Destinatario> repository = new RepositorioBase<Destinatario>();
                destinatario = repository.Buscar(id);

                if (user != null)
                {
                    paso = repositorio.Modificar(LlenaClase());
                    Utils.ShowToastr(this, "Modificado Exitosamente!!", "Exito", "success");
                }
                else
                    Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
            }

            if (paso)
            {
                LimpiarCampos();
            }
            else
                Utils.ShowToastr(this, "Fallo!! no ha podido Guardar", "Error", "error");

        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Destinatario> repositorio = new RepositorioBase<Destinatario>();
            int id = Utils.ToInt(DestinatarioidTextBox.Text);

            var Destinatario = repositorio.Buscar(id);

            if (Destinatario != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado Exitosamente!!", "Exito", "info");
                    LimpiarCampos();
                }
                else
                    Utils.ShowToastr(this, "Fallo!! No se Puede Eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No Encontrado!!", "Error", "error");
        }
    }
}