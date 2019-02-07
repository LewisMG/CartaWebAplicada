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
    public partial class rCarta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarDropDownList();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                IdCartaTextBox.Text = "0";
            }
        }

        private void LimpiarCampos()
        {
            IdCartaTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DestinatarioDropDownList.SelectedIndex = 0;
            CuerpoTextBox.Text = "";
        }

        public void LlenarCampos(Carta cartas)
        {
            LimpiarCampos();
            IdCartaTextBox.Text = cartas.IdCarta.ToString();
            FechaTextBox.Text = cartas.Fecha.ToString("yyyy-MM-dd");
            DestinatarioDropDownList.Text = Convert.ToString(cartas.DestinarioId);
            CuerpoTextBox.Text = cartas.Cuerpo;
        }

        private void LlenarDropDownList()
        {
            RepositorioBase<Carta> cartas = new RepositorioBase<Carta>();
            DestinatarioDropDownList.Items.Clear();
            DestinatarioDropDownList.DataSource = cartas.GetList(x => true);
            DestinatarioDropDownList.DataValueField = "DestinatarioId";
            DestinatarioDropDownList.DataTextField = "Nombre";
            DestinatarioDropDownList.DataBind();
        }

        private Carta LlenaClase()
        {
            Carta cartas = new Carta();

            cartas.IdCarta = Utils.ToInt(IdCartaTextBox.Text);
            cartas.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            cartas.DestinarioId = Utils.ToInt(DestinatarioDropDownList.Text);
            cartas.Cuerpo = CuerpoTextBox.Text;

            return cartas;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Carta> repositorio = new RepositorioBase<Carta>();
            Carta cartas = repositorio.Buscar(Utils.ToInt(IdCartaTextBox.Text));

            if (cartas != null)
            {
                LlenarCampos(cartas);
                Utils.ShowToastr(this, "Encontrado!!", "Exito", "info");
            }
            else
            {
                Utils.ShowToastr(this, "No Hay Resultado", "Error", "error");
            }
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioCarta repositorio = new RepositorioCarta();
            Carta cartas = LlenaClase();
            RepositorioBase<Destinatario> cuentas = new RepositorioBase<Destinatario>();

            bool paso = false;

            if (DestinatarioDropDownList != null)
            {

                if (Page.IsValid)
                {
                    if (IdCartaTextBox.Text == "0")
                    {
                        paso = repositorio.Guardar(cartas);
                    }
                    else
                    {
                        var verificar = repositorio.Buscar(Utils.ToInt(IdCartaTextBox.Text));
                        if (verificar != null)
                        {
                            paso = repositorio.Modificar(cartas);
                        }
                        else
                        {
                            Utils.ShowToastr(this, "No se encuentra el ID", "Fallo", "error");
                            return;
                        }
                    }
                    if (paso)
                    {
                        Utils.ShowToastr(this, "Registro Con Exito", "Exito", "success");
                    }
                    else
                    {
                        Utils.ShowToastr(this, "No se pudo Guardar", "Fallo", "error");
                    }
                    LimpiarCampos();
                    return;
                }
            }
            else
            {
                Utils.ShowToastr(this, "El Destinatario no existe", "Fallo", "error");
                return;
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioCarta repositorio = new RepositorioCarta();
            RepositorioBase<Carta> dep = new RepositorioBase<Carta>();

            int id = Utils.ToInt(IdCartaTextBox.Text);
            var carta = repositorio.Buscar(id);

            if (carta == null)
            {
                Utils.ShowToastr(this, "El deposito no existe", "Fallo", "error");
            }
            else
            {
                repositorio.Eliminar(id);

                Utils.ShowToastr(this, "Elimino Correctamente", "Exito", "info");
                LimpiarCampos();
            }
        }
    }
}