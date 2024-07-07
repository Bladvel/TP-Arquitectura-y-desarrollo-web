using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Services;

namespace Moodflix
{
    public partial class Emociones : System.Web.UI.Page
    {
        BLL.DVH bllDvh = new BLL.DVH();
        BLL.Usuario  bllUsuario = new BLL.Usuario();
        BLL.Pelicula bllPelicula = new BLL.Pelicula();
        BLL.Libro bllLibro = new BLL.Libro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetNavbar();
                Session["Emociones"] = bllEmocion.Listar();

                //bllDvh.Recalcular(bllDvh.Listar(), bllLibro.Listar());



            }
            GenerateCards();
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

        BLL.Emocion bllEmocion = new BLL.Emocion();
        public void GenerateCards()
        {
            List<BE.Emocion> emociones = Session["Emociones"] as List<BE.Emocion>;


            foreach (var emocion in emociones)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "col-6  col-md-4 col-lg-3 text-center");

                ImageButton btn = new ImageButton();
                btn.ImageUrl = emocion.Uri;
                btn.Width = Unit.Pixel(210);
                btn.Click += btnEmocion1_OnClick;

                HtmlGenericControl h3 = new HtmlGenericControl("h3");
                h3.Attributes.Add("class", "w-100");
                h3.InnerText = emocion.TipoEmocion.ToString();

                div.Controls.Add(btn);
                div.Controls.Add(h3);


                emotionsContainer.Controls.Add(div);
            }


        }



        protected void OnClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Emociones.aspx");
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


        protected void btnEmocion1_OnClick(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = sender as ImageButton;
            string path = btn.ImageUrl;

            string emocion = StringManager.ExtraerPalabraAntesPng(path);
            Session["Emocion"] = emocion;

            Response.Redirect("LibroOPelicula.aspx");
        }

        protected void linkInitLogin_OnClick(object sender, EventArgs e)
        {
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