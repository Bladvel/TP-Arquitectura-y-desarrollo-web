using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class LibroOPelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetNavbar();
        }

        void SetNavbar()
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                PlantillaUserAnonimo.Visible = false;
                PlantillaUserRegistrado.Visible = true;
                LinkProfile.Text = User.Identity.Name;
            }
            else
            {
                PlantillaUserAnonimo.Visible = true;
                PlantillaUserRegistrado.Visible = false;
            }
        }


        protected void imgbVerPeliculas_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Peliculas.aspx");
        }

        protected void imgbVerLibros_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Libro.aspx");
        }

        protected void imgbVerTodo_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Pelicula.aspx");
        }


        protected void linkInitLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void LinkInitRegistro_OnClick(object sender, EventArgs e)
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