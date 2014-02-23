<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MainForm.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<WebUltraMedica.Models.FISIK>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Fisik - Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="main">
        <h1>INDEKS FISIK <%= Html.ActionLink("Tambah", "Create", "Fisik", new {@class= "btn btn-primary right"}) %></h1>
        <br/>
        <% var roles = Session["roles"].ToString().Split(';');%>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th width="15%">Laboratorium ID</th>
                    <th>Nama</th>
                    <th width="15%">Tahun</th>
                    <th width="12%"></th>
                </tr>   
            </thead>
            <tbody class="">
               <% int i = 0; %>
            <% foreach (var fo in Model)
               {%>
                <tr>
                    <td style="text-align:center;"><%: fo.LAB_ID%></td>
                    <td><%: fo.EMPLOYEE_ID %></td>
                    <td><%: fo.YEAR_CHECKUP %></td>
                    <td>
                        <%if ((roles.Any(m => m.Equals("Fisik"))) || roles.Any(m => m.Equals("Fisik")))
                          { %>
                        <%: Html.ActionLink("Edit", "Edit", new {employee_id = fo.EMPLOYEE_ID, year = fo.YEAR_CHECKUP},
                                                                 new {@class = "btn btn-primary btn-xs"}) %>
                        <%: Html.ActionLink("Hapus", "Delete", new { employee_id = fo.EMPLOYEE_ID, year = fo.YEAR_CHECKUP },
                                                                 new {@class = "btn btn-danger btn-xs"}) %>
                        <% }%>
                    </td>
                </tr>
             <% }%>
             </tbody>
        </table>
        <div class="actions">
            <%= Html.ActionLink("Tambah", "Create", "Fisik", new {@class= "btn btn-primary"}) %>
        </div>
    </div>

</asp:Content>

