<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibroOPelicula.aspx.cs" Inherits="Moodflix.LibroOPelicula" %>

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
<body class=" background-emociones">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark ">
            <div class="container-fluid">
                <div class="navbar-nav ms-auto">
                    <asp:LinkButton CssClass="nav-link" ID="linkInitLogin2" Text="Registro"  runat="server"> </asp:LinkButton>
                    <asp:LinkButton CssClass="nav-link" ID="LinkInitRegistro2" Text="Log In" OnClick="LinkInitRegistro2_OnClick" runat="server"> </asp:LinkButton>
                </div>
            </div>
        </nav>
        
        <main class=" container">
            <div class=" row align-items-center">
                <section class=" col-12 col-xl-6">
                    <asp:Image ID="homeImage" ImageUrl="Imagenes/moodflix-02.png" Width="477px" runat="server" />
                </section>
                <aside class="col-12 col-xl-6">
                    <div class="row">
                        <div class="col-6">
                            <asp:ImageButton ID="imgbVerPeliculas" ImageUrl="Imagenes/Peliculas.png" Width="326px" OnClick="imgbVerPeliculas_OnClick" runat="server" />
                        </div>
                        <div class="col-6">
                            <asp:ImageButton ID="imgbVerLibros" ImageUrl="Imagenes/Libros.png" Width="326px" OnClick="imgbVerLibros_OnClick" runat="server" />
                        </div>
                    </div>
                    <div class="row justify-content-center">
                        <asp:ImageButton ID="imgbVerTodo" ImageUrl="Imagenes/VerTodo.png" Width="326px" OnClick="imgbVerTodo_OnClick" runat="server" />
                    </div>

                </aside>

            </div>

            
            

        </main>
        

        
        

    </form>
</body>
</html>
