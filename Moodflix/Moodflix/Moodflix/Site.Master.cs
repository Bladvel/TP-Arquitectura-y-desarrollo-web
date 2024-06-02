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

        protected void LinkLogout_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
    }
}