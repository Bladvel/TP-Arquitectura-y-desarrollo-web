<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Moodflix.Bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <h2>Bitácora</h2>
        <div class="form-group">
            <label for="txtFechaHoraInicio">Fecha y Hora de Inicio:</label>
            <input type="datetime-local" id="txtFechaHoraInicio" runat="server" class="form-control" />
        </div>
        <div class="form-group">
            <label for="txtFechaHoraFin">Fecha y Hora de Fin:</label>
            <input type="datetime-local" id="txtFechaHoraFin" runat="server" class="form-control" />
        </div>
        <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" Text="Filtrar" OnClick="btnFiltrar_OnClick" />

    </div>
    
    <asp:Label  ID="lblPrueba" runat="server"></asp:Label>
    
    
    <asp:GridView ID="gvBitacora" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" >
        
        <Columns>
            
            
            <asp:BoundField DataField="ID" HeaderText="ID"/>
            <asp:BoundField DataField="FECHA" HeaderText="FECHA"/>
            <asp:BoundField DataField="User" HeaderText="EMAIL USUARIO"/>
            <asp:BoundField DataField="MODULO" HeaderText="MODULO"/>
            <asp:BoundField DataField="OPERACION" HeaderText="OPERACION"/>

        </Columns>
        
          
        

    </asp:GridView>
    
    
    
    

</asp:Content>
