<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebUltraMedica.Models.EMPLOYEE>>" %>

<%@ Import Namespace="WebUltraMedica.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Employee - Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        INDEKS PEGAWAI
        <%= Html.ActionLink("Tambah", "Create", "Employee", new {@class= "btn btn-primary right"}) %></h1>
    <br />
    <% var roles = Session["roles"].ToString().Split(',');%>
    <table class="tableblue tablesorter sortable tablesorterFilters">
        <thead>
            <tr>
                <th class="sorter-false, filter-false" width="1%">
                    #
                </th>
                <th class="" width="10%">
                    ID
                </th>
                <th class="">
                    Nama
                </th>
                <th class="sorter-false, filter-false" width="15%">
                    Perusahaan
                </th>
                <th class="sorter-false, filter-false" width="12%">
                </th>
            </tr>
        </thead>
        <tbody>
            <% int i = 0; %>
            <% foreach (var employee in Model)
               {%>
            <tr>
                <td>
                    <%: i += 1 %>
                </td>
                <td>
                    <%: employee.EMPLOYEE_ID %>
                </td>
                <td>
                    <%: employee.NAME %>
                </td>
                <td>
                    <%: employee.COMPANY_NAME %>
                </td>
                <td>
                    <%if (roles.Any(m => m.Equals("Admin")))
                      { %>
                    <%: Html.ActionLink("Edit", "Edit", new {employeeId = employee.EMPLOYEE_ID},
                                                                 new {@class = "btn btn-primary btn-xs"}) %>
                    <button id="deleteFisik" onclick="javascript: DeleteMasterData('<%:employee.EMPLOYEE_ID %>');"
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
        <%= Html.ActionLink("Tambah", "Create", "Employee", new {@class= "btn btn-primary"}) %>
    </div>
</asp:Content>
