﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviar_OnClick(object sender, EventArgs e)
    {
        Session["Usuario"] = txtUsuario.Text;
        Session["Comentarios"] = txtComentarios.Text;

        Response.Redirect("RespuestaEjercicioVarSesion.aspx");
    }
}