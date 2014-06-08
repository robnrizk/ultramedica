<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.FISIK>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Fisik - Create
</asp:Content>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript">
        function GotoFisikCreateByLabID() {
            var LAB_ID = $('#LabId').val();
            var YEAR_CHECKUP = $('#YEAR_CHECKUP').val();

            window.location = '\Create?LAB_ID=' + LAB_ID + '&&YEAR_CHECKUP=' + YEAR_CHECKUP;
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     
        <h1>FISIK / TAMBAH <%= Html.ActionLink("Kembali", "Index", "Fisik", new {@class= "btn btn-primary btn-danger right"}) %></h1>
        <br />
        <% Html.RenderPartial("form"); %>
    

</asp:Content>

