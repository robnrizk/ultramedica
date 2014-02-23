<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.FO>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	FO - Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div id="main">
        <h1>FO / TAMBAH <%= Html.ActionLink("Kembali", "Index", "FO", new {@class= "btn btn-primary btn-danger right"}) %></h1>
        <br />
        <% Html.RenderPartial("form"); %>
    </div>
</asp:Content>

