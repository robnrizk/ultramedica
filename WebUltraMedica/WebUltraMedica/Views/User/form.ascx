<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUltraMedica.Models.USER>" %>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm(ViewData["Action"].ToString(), "User", FormMethod.Post, new { @class = "content" }))
   {%>
<div class="content-col">
    <fieldset>
        <label for="NIK">
            NIK</label>
        <% if (string.IsNullOrEmpty(Model.NIK))
           { %>
        <%: Html.TextBoxFor(m => m.NIK, new {@class = "content-data"}) %>
        <%: Html.ValidationMessageFor(m => m.NIK) %>
        <% }
           else
           { %>
        <%: Html.TextBoxFor(m => m.NIK, new {@class = "content-data", @readonly = "readonly"}) %>
        <% } %>
    </fieldset>
    <fieldset>
        <label for="NAMA">
            Nama</label>
        <%: Html.TextBoxFor(m => m.NAMA, new { @class = "content-data" })%>
    </fieldset>
    <fieldset>
        <label for="POSISI">
            Posisi</label>
        <%: Html.TextBoxFor(m => m.POSISI, new { @class = "content-data" })%>
    </fieldset>
</div>
<div class="content-col">
    <fieldset>
        <label for="USERNAME">
            Username</label>
        <%: Html.TextBoxFor(m => m.USERNAME, new { @class = "content-data" })%>
    </fieldset>
    <fieldset>
        <label for="PASSWORD">
            Password</label>
        <%: Html.PasswordFor(m => m.PASSWORD, new { @class = "content-data" })%>
    </fieldset>
    <fieldset>
        <label for="ROLES">
            Role</label>
        <select multiple="multiple" class="chosen" id="ROLES" name="ROLES">
            <% var rolelist = new string[0];
               if (!string.IsNullOrEmpty(Model.ROLES)) rolelist = Model.ROLES.Split(','); %>
            <% for (int i = 0; i < Model.MasterRoles().Count(); i++)
               { %>
            <option value="<%: Model.MasterRoles()[i] %>" <%if(rolelist.Any(m => m.Equals(Model.MasterRoles()[i]))) {%>
                selected="selected" <%}%>>
                <%: Model.MasterRoles()[i] %></option>
            <%}%>
        </select>
    </fieldset>
</div>
<br style="clear: both" />
<div class="actions">
    <input type="submit" value="Simpan" class="btn btn-primary" />
    <%= Html.ActionLink("Kembali", "Index", "User", new { @class = "btn btn-primary btn-danger" })%>
</div>
<% }%>
