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

                switch (User.Identity.Name)
                {
                    case "admin":
                        PlantillaAdmin.Visible = true;
                        PlantillaWebmaster.Visible = false;
                        break;
                    case "webmaster":
                        PlantillaWebmaster.Visible = true;
                        PlantillaAdmin.Visible = false;
                        break;
                    default:
                        PlantillaAdmin.Visible = false;
                        PlantillaWebmaster.Visible = false;
                        break;
                }


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
            Response.Redirect("Libros.aspx");
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

        protected void ddlActions_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;

            string selectedValue = ddl.SelectedValue;


            switch (selectedValue)
            {
                case "Bitacora":

                    Response.Redirect("Bitacora.aspx");
                    break;
                case "ABM":

                    Response.Redirect("ABM.aspx");
                    break;
                default:

                    break;
            }
        }
    }
}