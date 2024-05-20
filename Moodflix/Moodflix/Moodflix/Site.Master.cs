using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void linkEmociones_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Emociones.aspx");
        }

        protected void linkLibros_OnClick(object sender, EventArgs e)
        {
            
        }


        protected void linkPeliculas_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void linkLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}