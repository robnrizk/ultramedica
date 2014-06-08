<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUltraMedica.Models.FO>" %>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm(ViewData["Action"].ToString(), "FO", FormMethod.Post, new { @class = "content" }))
   {%>
<div class="content-col">
    <fieldset>
        <label for="LAB_ID">
            Laboratorium ID</label>
        <% if (ViewData["Action"].ToString().Equals("Create"))
           { %>
        <%: Html.TextBoxFor(m => m.LAB_ID, new {@class = "content-data"}) %>
        <%: Html.ValidationMessageFor(m => m.LAB_ID) %>
        <% }
           else
           { %>
        <%: Html.TextBoxFor(m => m.LAB_ID, new {@class = "content-data", @readonly = "readonly"}) %>
        <% } %>
    </fieldset>
    <fieldset>
        <label for="EMPLOYEE_ID">
            Nama Pegawai</label>
        <%: Html.DropDownListFor(m => m.EMPLOYEE_ID, Model.EMPLOYEE_LIST, new { @class = "content-data chosen" })%>
        <%: Html.ValidationMessageFor(m => m.EMPLOYEE_ID) %>
    </fieldset>
    <fieldset>
        <label for="YEAR_CHECKUP">
            Tahun</label>
        <%: Html.DropDownListFor(m => m.YEAR_CHECKUP, Model.YEAR_LIST, new { @class = "content-data chosen" })%>
        <%: Html.ValidationMessageFor(m => m.YEAR_CHECKUP) %>
    </fieldset>
    <fieldset>
        <label for="DATE">
            Tanggal</label>
        <%: Html.TextBoxFor(m => m.DATE, new { @class = "content-data datepicker", @Value = Model.DATE == null ? DateTime.Now.ToString("dd-MM-yyyy") : Model.DATE.Value.ToString("dd-MM-yyyy") })%>
    </fieldset>
    <fieldset>
        <label for="DISTRICT">
            Distrik</label>
        <%: Html.TextBoxFor(m => m.DISTRICT, new { @class = "content-data" })%>
    </fieldset>
</div>
<br style="clear: both" />
<div class="actions">
    <input type="submit" value="Simpan" class="btn btn-primary" />
    <%= Html.ActionLink("Kembali", "Index", "FO", new {@class= "btn btn-primary btn-danger"}) %>
</div>
<%} %>