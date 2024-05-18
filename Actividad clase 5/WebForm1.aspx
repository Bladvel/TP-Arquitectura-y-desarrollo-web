<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="Practica_018___HTML5.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W#C//DTD XHTML 1.0 Transitional//EN"
"http://www.w3.org/TR/xhtml1//DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">

    <title></title>

    <script type="text/javascript">
        function retornarLienzo(x){
            var canvas = document.getElementById(x);
            if(canvas.getContext){
                var lienzo - canvas.getContext("2d");
                return lienzo;
            }else
                return false;
        }

        function dibujar(){
            var lienzo = retornarLienzo("lienzo1");
            if(lienzo){
                lienzo.strokeStyle = "rgb(255,0,0)";
                lienzo.strokeRect(10,10,50,50);
                lienzo.strokeStyle = "rgb(0,255,0)";
                lienzo.strokeRect(70,10,50,50);
                lienzo.strokeStyle = "rgb(0,0,255)";
                lienzo.strokeRect(130,10,50,50);
            }
        }
    </script>
    </head>
    <body onLoad="dibujar()">
        <canvas id="lienzo1" width="400" height="500">
        su navegador no permite utilizar canvas
        </canvas>
    </body>
</html>