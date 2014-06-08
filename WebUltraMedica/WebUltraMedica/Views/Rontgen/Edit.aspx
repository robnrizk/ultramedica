<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.RONTGEN>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rontgen - Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        RONTGEN / EDIT
        <%= Html.ActionLink("Kembali", "Index", "Rontgen", new {@class= "btn btn-primary btn-danger right"}) %></h1>
    <br />
    <% Html.RenderPartial("form"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
