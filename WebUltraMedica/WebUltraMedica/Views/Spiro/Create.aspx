﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.SPIRO>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Spiro - Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        SPIRO / TAMBAH
        <%= Html.ActionLink("Kembali", "Index", "Spiro", new {@class= "btn btn-primary btn-danger right"}) %></h1>
    <br />
    <% Html.RenderPartial("form"); %>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">
        function GotoSpiroCreateByLabID() {
            var LAB_ID = $('#LabId').val();
            var YEAR_CHECKUP = $('#YEAR_CHECKUP').val();

            window.location = '\Create?LAB_ID=' + LAB_ID + '&&YEAR_CHECKUP=' + YEAR_CHECKUP;
        }
    </script>
</asp:Content>
