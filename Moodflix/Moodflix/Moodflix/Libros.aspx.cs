using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BE;

namespace Moodflix
{
    public partial class Libros : System.Web.UI.Page
    {
        BLL.Libro bllLibro = new BLL.Libro();
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

                Session["Libros"] = bllLibro.Listar();

            }

            GenerateCards();


        }

        private void GenerateCards()
        {
            List<Libro> libros = Session["Libros"] as List<Libro>;

            foreach (var libro in libros)
            {
                string title = libro.Nombre;
                string imageUrl = libro.Uri;
                float price = libro.Precio;

                // Crear el contenedor de la tarjeta
                HtmlGenericControl divCol = new HtmlGenericControl("div");
                divCol.Attributes.Add("class", "col-6 col-sm-4 col-md-3");

                // Crear la tarjeta
                HtmlGenericControl divCard = new HtmlGenericControl("div");
                divCard.Attributes.Add("class", "card card-shadow mb-2");

                // Crear el encabezado de la tarjeta
                HtmlGenericControl divCardHeader = new HtmlGenericControl("div");
                divCardHeader.Attributes.Add("class", "card-header");
                divCardHeader.InnerText = "Libro";

                // Crear la imagen de la tarjeta
                HtmlGenericControl imgCard = new HtmlGenericControl("img");
                imgCard.Attributes.Add("class", "card-img-top");
                imgCard.Attributes.Add("src", imageUrl);

                // Crear el cuerpo de la tarjeta
                HtmlGenericControl divCardBody = new HtmlGenericControl("div");
                divCardBody.Attributes.Add("class", "card-body");


                HtmlGenericControl divFlex = new HtmlGenericControl("div");
                divFlex.Attributes.Add("class", "d-flex flex-column flex-md-row justify-content-between align-items-center");

                HtmlGenericControl divMarginBodyTittle = new HtmlGenericControl("div");
                divMarginBodyTittle.Attributes.Add("class", "mb-2 mb-md-0");


                // Crear el título de la tarjeta
                HtmlGenericControl h6CardTitle = new HtmlGenericControl("h6");
                h6CardTitle.Attributes.Add("class", "card-title");
                h6CardTitle.InnerText = title;

                // Crear el texto de la tarjeta
                HtmlGenericControl divCardText = new HtmlGenericControl("div");
                divCardText.Attributes.Add("class", "card-text");
                divCardText.InnerText = "$" + price.ToString("N2");


                Button btnAgregarCarrito = new Button();
                btnAgregarCarrito.CssClass = "btn btn-primary btn-sm";
                btnAgregarCarrito.CommandArgument = libro.ID.ToString();
                btnAgregarCarrito.Click += BtnAgregarCarrito_Click;
                btnAgregarCarrito.Text = "Agregar";


                // Agregar los elementos al contenedor de la tarjeta

                divMarginBodyTittle.Controls.Add(h6CardTitle);
                divMarginBodyTittle.Controls.Add(divCardText);

                divFlex.Controls.Add(divMarginBodyTittle);
                divFlex.Controls.Add(btnAgregarCarrito);

                divCardBody.Controls.Add(divFlex);
                divCard.Controls.Add(divCardHeader);
                divCard.Controls.Add(imgCard);
                divCard.Controls.Add(divCardBody);
                divCol.Controls.Add(divCard);

                // Agregar la tarjeta al contenedor de la página
                cardsContainer.Controls.Add(divCol);




            }
        }



        private void BtnAgregarCarrito_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }













    }
}