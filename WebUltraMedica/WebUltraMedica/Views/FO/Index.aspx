<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebUltraMedica.Models.FO>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    FO - Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        INDEKS FO
        <%= Html.ActionLink("Tambah", "Create", "FO", new {@class= "btn btn-primary right"}) %></h1>
    <br />
    <% var roles = Session["roles"].ToString().Split(',');%>
    <table class="tableblue tablesorter sortable tablesorterFilters">
        <thead>
            <tr>
                <th width="15%">
                    Laboratorium ID
                </th>
                <th width="20%">
                    Employee ID
                </th>
                <th>
                    Nama
                </th>
                <th width="15%">
                    Tahun
                </th>
                <th class="sorter-false, filter-false" width="12%">
                </th>
            </tr>
        </thead>
        <tbody class="">
            <% int i = 0; %>
            <% foreach (var fo in Model)
               {%>
            <tr>
                <td style="text-align: center;">
                    <%: fo.LAB_ID%>
                </td>
                <td>
                    <%: fo.EMPLOYEE_ID %>
                </td>
                <td>
                    <%: fo.EMPLOYEE_NAME %>
                </td>
                <td>
                    <%: fo.YEAR_CHECKUP %>
                </td>
                <td>
                    <%if ((roles.Any(m => m.Equals("Admin"))) || roles.Any(m => m.Equals("FO")))
                      { %>
                    <%: Html.ActionLink("Edit", "Edit", new {labId = fo.LAB_ID},
                                                                 new {@class = "btn btn-primary btn-xs"}) %>
                    <button id="deleteFisik" onclick="javascript: DeleteMasterData('<%:fo.LAB_ID %>');"
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
        <%= Html.ActionLink("Tambah", "Create", "FO", new {@class= "btn btn-primary"}) %>
    </div>
</asp:Content>
