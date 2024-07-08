<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="Moodflix.Backup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <div class="container mt-5">
        <h2>Restore</h2>
        <div class="form-group row">
            <label for="txtRutaRestore" class="col-sm-2 col-form-label">Ruta Restore:</label>
            <div class="col-sm-6">
                <asp:TextBox ID="txtRutaRestore" runat="server" CssClass="form-control readonly" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <asp:FileUpload ID="FileUploadRestore" runat="server" CssClass="d-none" />
                <button type="button" class="btn btn-secondary" onclick="document.getElementById('<%= FileUploadRestore.ClientID %>').click()">Examinar...</button>
            </div>
            <div class="col-sm-2">
                <asp:Button ID="btnComenzarRestore" runat="server" CssClass="btn btn-primary" Text="Comenzar Restore" OnClick="btnComenzarRestore_OnClick" />
            </div>
        </div>
        <asp:Label runat="server" ID="lblError"></asp:Label>
    </div>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ScriptsPersonales" runat="server">
    
    <script type="text/javascript">
        document.getElementById("<%= FileUploadRestore.ClientID %>").addEventListener("change", function (event) {
            var input = event.target;
            if (input.files.length > 0) {
                var filePath = input.files[0].name;
                document.getElementById("<%= txtRutaRestore.ClientID %>").value = filePath;
            }
        });
    </script>
    

</asp:Content>
