using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;

namespace Moodflix
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Emociones.aspx");
        }

        BLL.Usuario bllUsuario = new BLL.Usuario();

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            string email = txtEmail.Value;
            string password = txtPassword.Value;

            Usuario user = new Usuario();
            user.Email = email;
            user.Password = password;

            if (bllUsuario.ValidarUsuario(user))
            {
                
                FormsAuthentication.SetAuthCookie("admin", false);
                
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                {
                    returnUrl = "~/Emociones.aspx";
                }
                Response.Redirect(returnUrl);
            }

            
        }

        protected void LinkInitRegistro_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}