<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.EMPLOYEE>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Employee - Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="main">
        <h1>PEGAWAI / EDIT <%= Html.ActionLink("Kembali", "Index", "Employee", new {@class= "btn btn-primary btn-danger right"}) %></h1>
        <br />
        <% Html.RenderPartial("form"); %>
    </div>

</asp:Content>
