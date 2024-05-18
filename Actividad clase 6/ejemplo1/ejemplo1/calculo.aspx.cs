using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class calculo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "POST")
        {
            string apellido;
            int edad;
            string edadEnMes;

            apellido = Request.Form["apellido"];
            edad = int.Parse(Request.Form["EDAD"]);
            edadEnMes = (edad * 12).ToString();

            divResult.InnerHtml = $"{apellido} su edad en meses es {edadEnMes}";
        }


    }
}