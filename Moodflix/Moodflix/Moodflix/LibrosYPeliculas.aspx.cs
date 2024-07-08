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
    public partial class LibrosYPeliculas : System.Web.UI.Page
    {
        BLL.Pelicula bllPelicula = new BLL.Pelicula();
        BLL.Libro bllLibro = new BLL.Libro();
        private string emocion = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            emocion = Session["Emocion"] as string;
            if (emocion != null)
            {
                lblEmocion.InnerHtml = emocion;
            }
            else
            {
                emocion = TipoEmocion.Aburrido.ToString();
                lblEmocion.InnerHtml = emocion;
            }
            if (!IsPostBack)
            {
                

                Session["Peliculas"] = bllPelicula.Listar();
                Session["Libros"] = bllLibro.Listar();

            }
            GenerateMoviesCards();
            GenerateBooksCards();

        }

        private void GenerateBooksCards()
        {
            List<Libro> libros = Session["Libros"] as List<Libro>;
            var librosFiltrados = libros.Where(l => l.Emocion.TipoEmocion.ToString() == emocion).ToList();

            foreach (var libro in librosFiltrados)
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
                btnAgregarCarrito.Click += BtnAgregarLibroCarrito_Click;
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

        private void GenerateMoviesCards()
        {
            List<Pelicula> peliculas = Session["Peliculas"] as List<Pelicula>;
            var peliculasFiltradas = peliculas.Where(p => p.Emocion.TipoEmocion.ToString() == emocion).ToList();



            foreach (var pelicula in peliculasFiltradas)
            {
                string title = pelicula.Nombre;
                string imageUrl = pelicula.Uri;
                float price = pelicula.Precio;

                // Crear el contenedor de la tarjeta
                HtmlGenericControl divCol = new HtmlGenericControl("div");
                divCol.Attributes.Add("class", "col-6 col-sm-4 col-md-3");

                // Crear la tarjeta
                HtmlGenericControl divCard = new HtmlGenericControl("div");
                divCard.Attributes.Add("class", "card card-shadow mb-2");

                // Crear el encabezado de la tarjeta
                HtmlGenericControl divCardHeader = new HtmlGenericControl("div");
                divCardHeader.Attributes.Add("class", "card-header");
                divCardHeader.InnerText = "Pelicula";

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
                btnAgregarCarrito.CommandArgument = pelicula.ID.ToString();
                btnAgregarCarrito.Click += BtnAgregarPeliculaCarrito_Click;
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




        private void BtnAgregarLibroCarrito_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = int.Parse(btn.CommandArgument);


            List<Producto> carrito = Session["Carrito"] as List<Producto>;
            if (carrito == null)
            {
                carrito = new List<Producto>();
            }


            carrito.Add(bllLibro.ObtenerPorId(id));


            Session["Carrito"] = carrito;

            // Mostrar un mensaje de confirmación
            ClientScript.RegisterStartupScript(this.GetType(), "AgregarCarrito1", "alert('El ítem se agregó al carrito');", true);

        }
        private void BtnAgregarPeliculaCarrito_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = int.Parse(btn.CommandArgument);


            List<Producto> carrito = Session["Carrito"] as List<Producto>;
            if (carrito == null)
            {
                carrito = new List<Producto>();
            }


            carrito.Add(bllPelicula.ObtenerPorId(id));


            Session["Carrito"] = carrito;

            // Mostrar un mensaje de confirmación
            ClientScript.RegisterStartupScript(this.GetType(), "AgregarCarrito2", "alert('El ítem se agregó al carrito');", true);

        }


















    }
}