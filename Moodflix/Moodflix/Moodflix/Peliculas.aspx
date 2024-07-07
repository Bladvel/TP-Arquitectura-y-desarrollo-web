<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Peliculas.aspx.cs" Inherits="Moodflix._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       
        <div class="row my-4">
            <h3> Emocion: <span class="emocion_seleccionada p-1" ID="lblEmocion" runat="server"></span></h3>
        </div>

        <div class=" row" runat="server" id="cardsContainer">
            <%--<div class=" col-sm-3">
                <div class=" card card-shadow mb-2">
                    <div class="card-header">
                        Pelicula
                    </div>
                    <img src="Imagenes/Peliculas/matrix.jpg" class="card-img-top"/>
                    
                    
                  
                        <div class="card-body">
                            <div class="d-flex flex-column flex-md-row justify-content-between align-items-center">
                                <div class="mb-2 mb-md-0">
                                    <h6 class="card-title mb-0">MATRIX</h6>
                                    <div class="card-text">$1200,00</div>
                                </div>
                                <asp:Button runat="server" ID="btnAgregarCarrito" CssClass="btn btn-primary btn-sm" Text="Agregar"/>
                            </div>
                        </div>

                    

                    
                </div>
            </div>--%>
            

        </div>
        
        

    </main>

</asp:Content>
