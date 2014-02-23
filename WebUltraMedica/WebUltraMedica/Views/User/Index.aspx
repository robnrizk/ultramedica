<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebUltraMedica.Models.USER>>" %>

<%@ Import Namespace="WebUltraMedica.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User - Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main">
        <h1>
            INDEKS PEGAWAI
            <%= Html.ActionLink("Tambah", "Create", "User", new {@class= "btn btn-primary right"}) %></h1>
        <br />
        <% var roles = Session["roles"].ToString().Split(';');%>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th width="1%">
                        #
                    </th>
                    <th>
                        Nama
                    </th>
                    <th width="15%">
                        Posisi
                    </th>
                    <th width="12%">
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
                        <%: Html.ActionLink("Hapus", "Delete", new { userNik = user.NIK },
                                                                 new {@class = "btn btn-danger btn-xs"}) %>
                        <% }%>
                    </td>
                </tr>
                <% }%>
            </tbody>
        </table>
        <div class="actions">
            <%= Html.ActionLink("Tambah", "Create", "User", new {@class= "btn btn-primary"}) %>
        </div>
    </div>
</asp:Content>
