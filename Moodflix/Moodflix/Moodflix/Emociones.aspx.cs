using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;

namespace Moodflix
{
    public partial class Emociones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetNavbar();

            }
                
        }

        void SetNavbar()
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                PlantillaUserAnonimo.Visible = false;
                PlantillaUserRegistrado.Visible = true;
                LinkProfile.Text = User.Identity.Name;
            }
            else
            {
                PlantillaUserAnonimo.Visible = true;
                PlantillaUserRegistrado.Visible = false;
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


        protected void ddlActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ddlActions.SelectedValue;

            switch (selectedValue)
            {
                case "Action1":
                    Response.Redirect("Action1.aspx");
                    break;
                case "Action2":
                    Response.Redirect("Action2.aspx");
                    break;
            }
        }
    }
}