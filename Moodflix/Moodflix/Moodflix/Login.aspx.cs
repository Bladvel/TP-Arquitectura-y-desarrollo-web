using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Emociones.aspx");
        }
    }
}