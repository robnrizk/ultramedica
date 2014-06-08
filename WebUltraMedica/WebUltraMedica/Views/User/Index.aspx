<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebUltraMedica.Models.USER>>" %>

<%@ Import Namespace="WebUltraMedica.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User - Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        INDEKS USER
        <%= Html.ActionLink("Tambah", "Create", "User", new {@class= "btn btn-primary right"}) %></h1>
    <br />
    <% var roles = Session["roles"].ToString().Split(',');%>
    <table class="tableblue tablesorter sortable tablesorterFilters">
        <thead>
            <tr>
                <th class="sorter-false, filter-false" width="1%">
                    #
                </th>
                <th>
                    Nama
                </th>
                <th width="15%">
                    Posisi
                </th>
                <th class="sorter-false, filter-false" width="12%">
                </th>
            </tr>
        </thead>
        <tbody class="">
            <% int i = 0; %>
            <% foreach (var user in Model)
               {%>
            <tr>
                <td>
                    <%: i += 1 %>
                </td>
                <td>
                    <%: user.NAMA %>
                </td>
                <td>
                    <%: user.POSISI %>
                </td>
                <td>
                    <%if (roles.Any(m => m.Equals("Admin")))
                      { %>
                    <%: Html.ActionLink("Edit", "Edit", new {userNik = user.NIK},
                                                                 new {@class = "btn btn-primary btn-xs"}) %>
                    <button id="deleteFisik" onclick="javascript: DeleteMasterData('<%:user.NIK %>');"
                        class="btn btn-danger btn-xs">
                        Hapus
                    </button>
                    <% }%>
                </td>
            </tr>
            <% }%>
        </tbody>
    </table>
    <br />
    <div class="actions">
        <%= Html.ActionLink("Tambah", "Create", "User", new {@class= "btn btn-primary"}) %>
    </div>
</asp:Content>
