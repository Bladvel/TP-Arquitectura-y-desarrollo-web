<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="Moodflix.Bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    
    
    
    
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
