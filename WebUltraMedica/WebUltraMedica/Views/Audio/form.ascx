<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUltraMedica.Models.AUDIO>" %>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm(ViewData["Action"].ToString(), "Audio", FormMethod.Post, new { @class = "content", enctype = "multipart/form-data" }))
   {%>
<fieldset>
    <legend>HEADER</legend>
    <% if (Model.LabId != 0)
       {%>
    <div class="content-col">
        <div class="content-group">
            <label for="LAB_ID">
                Laboratorium ID</label>
            <%: Html.TextBoxFor(model => model.LabId, new { @class = "content-data", @readonly="readonly" })%>
        </div>
    </div>
    <% } %>
    <div class="content-col">
        <div class="content-group">
            <label for="EMPLOYEE_ID">
                Nama Pegawai</label>
            <%: Html.TextBoxFor(model => model.EMPLOYEE_NAME, new { @class = "content-data", @readonly = "readonly" })%>
            <%: Html.HiddenFor(model => model.EMPLOYEE_ID) %>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="YEAR_CHECKUP">
                Tahun Periksa</label>
            <%: Html.TextBoxFor(model => model.YEAR_CHECKUP, new { @class = "content-data", @readonly = "readonly" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>AUDIO</legend>
    <div class="content-col-ful">
        <div class="content-group">
            <label for="AUDIOMETRY_FILE_NAME">
                AUDIOMETRY FILE NAME</label>
            <% if (string.IsNullOrEmpty(Model.AUDIOMETRY_FILE_NAME))
                   { %> 
                   <label class="content-data">No File</label>
                 <%}
                   else 
                   { %>
                       <%= Html.ActionLink(Model.AUDIOMETRY_FILE_NAME, "Download", "File", new { @EMPLOYEE_ID = Model.EMPLOYEE_ID, @YEAR_CHECKUP = Model.YEAR_CHECKUP, @FILE_NAME = Model.AUDIOMETRY_FILE_NAME }, null) %>
                  <% }%>
        </div>
        <div class="content-group">
            <label for="FileAUDIO" style="float:left;">
                UPLOAD FILE</label>
             <%: Html.TextBoxFor(model => model.FileAUDIO, new { @class = "content-data", @type = "file", @Style="float:left;" })%>
             &nbsp; 
            <small class="text-danger">*Max file is <%= WebUltraMedica.Controllers.Helper.MaxRequestLength() / 1024 %> MB</small>
        </div>
        <div class="content-group" style="clear:both;">
            <label for="AUDIOMETRY_RESULT">
                AUDIOMETRY RESULT</label>
            <%: Html.TextBoxFor(model => model.AUDIOMETRY_RESULT, new { @class = "content-data" })%>
        </div>
    </div>
</fieldset>
<div class="actions">
    <input type="submit" value="Simpan" class="btn btn-primary" />
    <%= Html.ActionLink("Kembali", "Index", "Audio", new {@class= "btn btn-primary btn-danger"}) %>
</div>
<% } %>
