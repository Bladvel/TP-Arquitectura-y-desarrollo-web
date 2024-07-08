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
        BLL.DVV bllDvv = new BLL.DVV();
        BLL.Pelicula bllPelicula = new BLL.Pelicula();
        BLL.Libro bllLibro = new BLL.Libro();
        BLL.Emocion bllEmocion = new BLL.Emocion();

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

                    if (bllDvh.ValidarDigitoVerificador().Count > 0 || !bllDvv.ValidarDigitoVerificador())
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

                        bllDvh.Recalcular(bllDvh.Listar(),bllBitacora.Listar());
                        bllDvv.Recalcular();

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
            
            List<BE.Pelicula> peliculas = bllPelicula.Listar();
            List<BE.Emocion> emociones = bllEmocion.Listar();
            List<BE.Libro> libros = bllLibro.Listar();
            List<BE.Usuario> usuarios = bllUsuario.Listar();

            // Listar todos los DVH
            List<DVH> dVHs = bllDvh.Listar();
            List<DVV> dvvs = bllDvv.Listar();

            // Validar cantidad de registros
            
            bool peliculasValidas = bllDvh.ValidarCantidadRegistros(peliculas, dVHs, "PELICULA");
            bool emocionesValidas = bllDvh.ValidarCantidadRegistros(emociones, dVHs, "EMOCION");
            bool librosValidos = bllDvh.ValidarCantidadRegistros(libros, dVHs, "LIBRO");
            bool usuariosValidos = bllDvh.ValidarCantidadRegistros(usuarios, dVHs, "USUARIO");

            if ( peliculasValidas && emocionesValidas && librosValidos && usuariosValidos)
            {
                // Recalcular los dígitos verificadores para cada entidad
               
                bllDvh.Recalcular(dVHs, peliculas);
                bllDvh.Recalcular(dVHs, emociones);
                bllDvh.Recalcular(dVHs, libros); 
                bllDvh.Recalcular(dVHs, usuarios);

                bllDvv.Recalcular();

                ClientScript.RegisterStartupScript(this.GetType(), "Recalculado1", "alert('Se han recalculado los dígitos verificadores');", true);
                
            }
            else
            {
                bllDvh.BorrarRegistros();
                dVHs = bllDvh.Listar();

                // Recalcular los dígitos verificadores para cada entidad después de borrar los registros
                bllDvh.Recalcular(dVHs, peliculas);
                bllDvh.Recalcular(dVHs, emociones);
                bllDvh.Recalcular(dVHs, libros);
                bllDvh.Recalcular(dVHs, usuarios);

                bllDvv.Recalcular();

                ClientScript.RegisterStartupScript(this.GetType(), "Recalculado2", "alert('Se han recalculado los dígitos verificadores');", true);
            }







        }

        protected void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Backup.aspx");
        }
    }
}