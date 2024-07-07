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
        BLL.DVH bllDvh = new BLL.DVH();


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

                    if (bllDvh.ValidarDigitoVerificador().Count > 0)
                    {

                        //Abrir ventana con opciones en caso de que el usuario sea el webmaster
                        if (savedUser.Username.Equals("webmaster"))
                        {
                            // Mostrar modal de inconsistencia
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#modalInconsistenciaBD').modal('show');", true);
                        }
                        else
                        {
                            // Mostrar mensaje de acceso denegado
                            ClientScript.RegisterStartupScript(this.GetType(), "AccessDenied", "alert('No se puede acceder al sistema. Contacte al webmaster.');", true);

                            FormsAuthentication.SignOut();
                            

                        }


                    }
                    else
                    {
                        Services.Bitacora bitacora = new Services.Bitacora();

                        bitacora.User = savedUser;
                        bitacora.Fecha = DateTime.Now;
                        bitacora.Operacion = TipoOperacion.Login;
                        bitacora.Modulo = TipoModulo.InicioSesion;
                        bllBitacora.Insertar(bitacora);


                        string returnUrl = Request.QueryString["ReturnUrl"];
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            returnUrl = "~/Emociones.aspx";
                        }


                        Response.Redirect(returnUrl);
                    }



                    
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

        protected void btnRecomponerDV_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}