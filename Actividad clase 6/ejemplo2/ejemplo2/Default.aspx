<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server"> Usuario</asp:Label>
            <asp:TextBox runat="server" ID="txtUsuario"></asp:TextBox>
            <br/>
            <asp:Label runat="server">Comentarios</asp:Label>
            <asp:TextBox runat="server" ID="txtComentarios"></asp:TextBox>
            <br/>
            <asp:Button runat="server" ID="btnEnviar" Text="Enviar" OnClick="btnEnviar_OnClick"/>
        </div>
    </form>
</body>
</html>
