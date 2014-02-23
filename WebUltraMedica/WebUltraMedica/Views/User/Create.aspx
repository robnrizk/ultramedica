<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.USER>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	User - Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="main">
        <h1>USER / TAMBAH <%= Html.ActionLink("Kembali", "Index", "User", new {@class= "btn btn-primary btn-danger right"}) %></h1>
        <br />
        <% Html.RenderPartial("form"); %>
    </div>

</asp:Content>

