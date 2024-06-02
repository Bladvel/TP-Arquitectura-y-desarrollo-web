using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class Libro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string emocion = Session["Emocion"] as string;
                if (emocion != null)
                {
                    lblEmocion.InnerHtml = emocion;
                }
                else
                {
                    lblEmocion.InnerHtml = BE.TipoEmocion.Aburrido.ToString();
                }
            }
        }
    }
}