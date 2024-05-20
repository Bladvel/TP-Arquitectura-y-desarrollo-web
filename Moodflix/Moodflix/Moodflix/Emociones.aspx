<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emociones.aspx.cs" Inherits="Moodflix.Emociones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Estilos/Style.css"/>
</head>
<body class="background-emociones">
    <form id="form1" runat="server">
        
        
        <!--BARRA DE NAVEGACION -->
        
            <nav class="navbar navbar-expand-lg navbar-dark ">
                <div class="container-fluid">
                     <div class="navbar-nav ms-auto">
                        <asp:LinkButton CssClass="nav-link" ID="linkInitLogin" Text="Registro"  runat="server"> </asp:LinkButton>
                        <asp:LinkButton CssClass="nav-link" ID="LinkInitRegistro" Text="Log In" OnClick="LinkInitRegistro_OnClick"  runat="server"> </asp:LinkButton>
                    </div>
                </div>
            </nav>

        

        

        <div class="container justify-content-center ">
            <div class="row">
                <div class ="col col-sm-6">

                    <asp:ImageButton runat="server" CssClass="logo-emociones" ImageUrl="Imagenes/moodflix-02.png" OnClick="OnClick"/>
                    <%--<img class="logo-emociones" src="Imagenes/moodflix-02.png"/>--%>

                </div>
                <div class = "col col-sm-6 align-content-center" style>
                    
                    <h1> Elegí una emoción para empezar:</h1>

                </div>

            </div>
            <div class="row mt-2">
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png" Width="214.3px"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png" Width="214.3px"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
            </div>
            <div class="row mt-4">
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png" Width="214.3px"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ImageUrl="Imagenes/Felicidad.png" Width="214.3px"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
