<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" action="calculo.aspx" runat="server">
        <div>
            APELLIDO
            <input type="text" id="apellido" name="apellido"/>
            EDAD
            <input type="text" id="edad" name="edad"/>
            

        </div>
        <input type="submit" value="enviar"/>
    </form>
</body>
</html>
