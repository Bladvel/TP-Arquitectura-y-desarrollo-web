using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetNavbar();
        }

        void SetNavbar()
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                PlantillaUserAnonimo.Visible = false;
                PlantillaUserRegistrado.Visible = true;
                LinkProfile.Text = HttpContext.Current.User.Identity.Name;
            }
            else
            {
                PlantillaUserAnonimo.Visible = true;
                PlantillaUserRegistrado.Visible = false;
            }
        }

        protected void linkEmociones_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Emociones.aspx");
        }

        protected void linkLibros_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Libro.aspx");
        }


        protected void linkPeliculas_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Pelicula.aspx");
        }

        protected void linkLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void linkRegistro_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }



        public string ObtenerNombreDePagina()
        {
 
            string url = Request.Url.AbsolutePath;
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(url);
            string nombre = fileInfo.Name;

            if (nombre.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase))
            {
                nombre = nombre.Substring(0, nombre.Length - 5);
            }

            return nombre;
        }








        private BLL.Bitacora bllBitacora = new BLL.Bitacora();
        BLL.Usuario bllUsuario = new BLL.Usuario();
        protected void LinkLogout_OnClick(object sender, EventArgs e)
        {

            Services.Bitacora bitacora = new Services.Bitacora();
            bitacora.User = bllUsuario.GetUserByUsername(HttpContext.Current.User.Identity.Name);
            bitacora.Fecha = DateTime.Now;
            bitacora.Operacion = TipoOperacion.Logout;
            bitacora.Modulo = (TipoModulo)Enum.Parse(typeof(TipoModulo),ObtenerNombreDePagina());

            bllBitacora.Insertar(bitacora);


            FormsAuthentication.SignOut();

            //Agregar en bitacora el cierre de sesion.

            Response.Redirect("Login.aspx");
        }

        protected void ddlActions_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlActions.SelectedValue;

            // Realizar acciones basadas en el valor seleccionado
            switch (selectedValue)
            {
                case "Bitacora":
                    // Redirigir a la página de Bitácora
                    Response.Redirect("Bitacora.aspx");
                    break;
                case "ABM":
                    // Redirigir a la página de ABM
                    Response.Redirect("ABM.aspx");
                    break;
                default:
                    // Manejar caso por defecto si es necesario
                    break;
            }
        }
    }
}