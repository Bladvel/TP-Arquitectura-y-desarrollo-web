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
                         <asp:PlaceHolder ID="PlantillaUserAnonimo" runat="server">
                             <asp:LinkButton CssClass="nav-link" ID="linkInitLogin" Text="Log in" OnClick="linkInitLogin_OnClick"  runat="server"> </asp:LinkButton>
                             <asp:LinkButton CssClass="nav-link" ID="LinkInitRegistro" Text="Registro" OnClick="LinkInitRegistro_OnClick"  runat="server"> </asp:LinkButton>

                         </asp:PlaceHolder>
                         
                         <asp:PlaceHolder ID="PlantillaUserRegistrado" runat="server">
                             
                             
                                 <asp:LinkButton CssClass="nav-link" ID="LinkProfile" runat="server"></asp:LinkButton>
                             
                             <asp:DropDownList ID="ddlActions" runat="server" CssClass="ddlHerramientas" AutoPostBack="true">
                                 <asp:ListItem Text="Herramientas" Value="" />
                                 <asp:ListItem Text="Bitacora" Value="Action1" />
                                 <asp:ListItem Text="ABM" Value="Action2" />
                                 
                             </asp:DropDownList>
                             

                                 <asp:LinkButton CssClass="nav-link" ID="LinkLogout" Text="Log out" OnClick="LinkLogout_OnClick" runat="server"></asp:LinkButton>
                            
                         </asp:PlaceHolder>


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
                <div class="col-6  col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion1" ImageUrl="Imagenes/Emociones/Aburrido.png" OnClick="btnEmocion1_OnClick"  Width="210px"/>
                    <h3 class=" w-100">Aburrido</h3>
                </div>
                <div class="col-6 col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion2" ImageUrl="Imagenes/Emociones/Amoroso.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Amoroso</h3>
                </div>
                <div class="col-6 col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion3" ImageUrl="Imagenes/Emociones/Ansiedad.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Ansiedad</h3>
                </div>
                <div class="col-6 col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion4" ImageUrl="Imagenes/Emociones/Curioso.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Curioso</h3>
                </div>
                <div class="col-6  col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion5" ImageUrl="Imagenes/Emociones/Disgusto.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Disgusto</h3>
                </div>
                <div class="col-6 col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion6" ImageUrl="Imagenes/Emociones/Enojo.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Enojo</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion7" ImageUrl="Imagenes/Emociones/Felicidad.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Felicidad</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion8" ImageUrl="Imagenes/Emociones/Miedo.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Miedo</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion9" ImageUrl="Imagenes/Emociones/Optimista.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Optimista</h3>
                </div>
                <div class="col-6 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion10" ImageUrl="Imagenes/Emociones/Pasion.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Pasion</h3>
                </div>
                <div class="col-6 col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion11" ImageUrl="Imagenes/Emociones/Sorpresa.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Sorpresa</h3>
                </div>
                <div class="col-6 col-md-4 col-lg-3 text-center">
                    <asp:ImageButton runat="server" ID="btnEmocion12" ImageUrl="Imagenes/Emociones/Tristeza.png" OnClick="btnEmocion1_OnClick" Width="210px"/>
                    <h3 class=" w-100">Tristeza</h3>
                </div>
            </div>
                
                
                
        </div>
                

    </form>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/Scripts/bootstrap.js") %>
    </asp:PlaceHolder>

    </body>
</html>
