<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Moodflix.Login" %>

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
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark ">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <asp:ImageButton ID="ImageButton1" CssClass="logo" ImageUrl="Imagenes/moodflix-07.png" Width="200px" OnClick="ImageButton1_OnClick" runat="server" />
                </a>
                <div class="navbar-nav ms-auto">
                    <asp:LinkButton CssClass="nav-link" ID="LinkInitRegistro" Text="Registrarse"  runat="server"> </asp:LinkButton>
                </div>
            </div>
        </nav>
        
        <main >
            <div class="container  rounded shadow p-3 w-25 my-5">
                <div class=" row">
                    <label class="form-label">Email</label>
                </div>
                <div class=" mx-1 mb-3 row ">
   
                        <asp:TextBox ID="txtEmail" CssClass="form-control inputTextBox" runat="server"></asp:TextBox>


                </div>


                
                <div class=" row">
                    <label  class="form-label col">Contraseña</label>
                </div>
                <div class=" mx-1 mb-3 row">
                        <asp:TextBox ID="txtPassword" CssClass="form-control inputTextBox" runat="server"></asp:TextBox>
                </div>

                
                <div class="row mx-5 my-3">

                        <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" OnClick="Button1_OnClick" Text="Ingresar" />

                    
                </div>
                
            </div>

        </main>
        
        
        
        

    </form>
</body>
</html>
