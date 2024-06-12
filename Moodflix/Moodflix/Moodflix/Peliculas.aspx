<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Peliculas.aspx.cs" Inherits="Moodflix._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       
        <div class="row my-4">
            <h3> Emocion: <span class="emocion_seleccionada p-1" ID="lblEmocion" runat="server"></span></h3>
        </div>

        <div class=" row" runat="server" id="cardsContainer">
            <%--<div class=" col-sm-3">
                <div class=" card mb-2">
                    <div class="card-header">
                        Pelicula
                    </div>
                    <img src="Imagenes/Peliculas/matrix.jpg" class="card-img-top"/>
                    <div class="card-body">
                        <h6 class="card-title">
                            MATRIX
                        </h6>
                        <div class="card-text">
                            $1200,00
                        </div>
                    </div>
                </div>
            </div>
            <div class=" col-sm-3">
                <div class=" card">
                    <div class="card-header">
                        Pelicula
                    </div>
                    <img src="Imagenes/Peliculas/matrix.jpg" class="card-img-top"/>
                    <div class="card-body">
                        <h6 class="card-title">
                            MATRIX
                        </h6>
                        <div class="card-text">
                            $1200,00
                        </div>
                    </div>
                </div>
            </div>
            <div class=" col-sm-3">
                <div class=" card">
                    <div class="card-header">
                        Pelicula
                    </div>
                    <img src="Imagenes/Peliculas/matrix.jpg" class="card-img-top"/>
                    <div class="card-body">
                        <h6 class="card-title">
                            MATRIX
                        </h6>
                        <div class="card-text">
                            $1200,00
                        </div>
                    </div>
                </div>
            </div>
            <div class=" col-sm-3">
                <div class=" card">
                    <div class="card-header">
                        Pelicula
                    </div>
                    <img src="Imagenes/Peliculas/matrix.jpg" class="card-img-top"/>
                    <div class="card-body">
                        <h6 class="card-title">
                            MATRIX
                        </h6>
                        <div class="card-text">
                            $1200,00
                        </div>
                    </div>
                </div>
            </div>
            <div class=" col-sm-3">
                <div class=" card">
                    <div class="card-header">
                        Pelicula
                    </div>
                    <img src="Imagenes/Peliculas/matrix.jpg" class="card-img-top"/>
                    <div class="card-body">
                        <h6 class="card-title">
                            MATRIX
                        </h6>
                        <div class="card-text">
                            $1200,00
                        </div>
                    </div>
                </div>
            </div>--%>

        </div>
        
        

    </main>

</asp:Content>
