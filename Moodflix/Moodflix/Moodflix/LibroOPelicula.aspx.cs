using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class LibroOPelicula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbVerPeliculas_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void imgbVerLibros_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void imgbVerTodo_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void LinkInitRegistro2_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}