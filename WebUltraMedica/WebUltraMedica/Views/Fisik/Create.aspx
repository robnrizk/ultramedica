<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.FISIK>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Fisik - Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div id="main">
        <h1>FISIK / TAMBAH <%= Html.ActionLink("Kembali", "Index", "Fisik", new {@class= "btn btn-primary btn-danger right"}) %></h1>
        <br />
        <% Html.RenderPartial("form"); %>
    </div>

</asp:Content>

