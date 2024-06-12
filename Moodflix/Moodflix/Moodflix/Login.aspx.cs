using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using Services;

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
        private BLL.Bitacora bllBitacora = new BLL.Bitacora();

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            string email = txtEmail.Value;
            string password = txtPassword.Value;

            Usuario user = new Usuario();
            user.Email = email;
            user.Password = password;

            try
            {
                if (bllUsuario.ValidarUsuario(user))
                {
                    var savedUser = bllUsuario.GetUser(user.Email);

                    FormsAuthentication.SetAuthCookie(savedUser.Username, false);

                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        returnUrl = "~/Emociones.aspx";
                    }

                    Services.Bitacora bitacora = new Services.Bitacora();

                    bitacora.User = savedUser;
                    bitacora.Fecha = DateTime.Now;
                    bitacora.Operacion = TipoOperacion.Login;
                    bitacora.Modulo = TipoModulo.InicioSesion;

                    bllBitacora.Insertar(bitacora);

                    Response.Redirect(returnUrl);
                }
            }
            catch (LoginException exception)
            {
                switch (exception.Result)
                {
                    case LoginResult.InvalidEmail:
                        lblErrorMessage.Text = "El email es incorrecto";
                        pnlErrorMessage.Visible = true;
                        break;
                    case LoginResult.InvalidPassword:
                        lblErrorMessage.Text = "La contraseña es incorrecta";
                        pnlErrorMessage.Visible = true;
                        break;

                }
            }

            

            
        }

        protected void LinkInitRegistro_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Registrarse.aspx");
        }
    }
}