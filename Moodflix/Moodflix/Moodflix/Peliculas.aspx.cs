using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Moodflix
{
    public partial class _Default : Page
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

                GenerateCards();
            }
        }



        private void GenerateCards()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["DanDesktop"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT NOMBRE, URI_RELATIVO, PRECIO FROM PELICULA";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string title = reader["NOMBRE"].ToString();
                        string imageUrl = reader["URI_RELATIVO"].ToString();
                        decimal price = Convert.ToDecimal(reader["PRECIO"]);

                        // Crear el contenedor de la tarjeta
                        HtmlGenericControl divCol = new HtmlGenericControl("div");
                        divCol.Attributes.Add("class", "col-6 col-sm-4 col-md-3");

                        // Crear la tarjeta
                        HtmlGenericControl divCard = new HtmlGenericControl("div");
                        divCard.Attributes.Add("class", "card mb-2");

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

                        // Crear el título de la tarjeta
                        HtmlGenericControl h6CardTitle = new HtmlGenericControl("h6");
                        h6CardTitle.Attributes.Add("class", "card-title");
                        h6CardTitle.InnerText = title;

                        // Crear el texto de la tarjeta
                        HtmlGenericControl divCardText = new HtmlGenericControl("div");
                        divCardText.Attributes.Add("class", "card-text");
                        divCardText.InnerText = "$" + price.ToString("N2");

                        // Agregar los elementos al contenedor de la tarjeta
                        divCardBody.Controls.Add(h6CardTitle);
                        divCardBody.Controls.Add(divCardText);
                        divCard.Controls.Add(divCardHeader);
                        divCard.Controls.Add(imgCard);
                        divCard.Controls.Add(divCardBody);
                        divCol.Controls.Add(divCard);

                        // Agregar la tarjeta al contenedor de la página
                        cardsContainer.Controls.Add(divCol);
                    }
                }
            }
        }
    }
}