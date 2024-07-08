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
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarCarrito();
        }

        public void MostrarCarrito()
        {

            List<Producto> carrito = Session["Carrito"] as List<Producto>;
            if (carrito == null || carrito.Count == 0)
            {
                MostrarError("El carrito esta vacio");
                return;
            }


            carritoContainer.Controls.Clear();


            foreach (var item in carrito)
            {
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "col-12 col-md-6 col-lg-4 text-center");

                ImageButton btn = new ImageButton();
                btn.ImageUrl = item.Uri;
                btn.Width = Unit.Pixel(210);

                HtmlGenericControl h3 = new HtmlGenericControl("h3");
                h3.Attributes.Add("class", "w-100");
                h3.InnerText = item.Nombre;

                HtmlGenericControl divPrecio = new HtmlGenericControl("div");
                divPrecio.Attributes.Add("class", "card-text");
                divPrecio.InnerText = item.Precio.ToString("C");

                div.Controls.Add(btn);
                div.Controls.Add(h3);
                div.Controls.Add(divPrecio);

                carritoContainer.Controls.Add(div);
            }
        }

        private void MostrarError(string mensaje)
        {
            pnlError.Visible = true;
            lblError.Text = mensaje;
        }

    }
}