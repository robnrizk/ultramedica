﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUltraMedica.Models.RONTGEN>" %>
<% Html.EnableClientValidation(); %>
<% if (Model.LabId == 0)
   {%>
<div class="content">
    <fieldset>
        <div class="content-col">
            <div class="content-group">
                <label for="LAB_ID">
                    Laboratorium ID</label>
                <%: Html.DropDownListFor(m => m.LabId, Model.LABID_LIST, new { @class = "content-data chosen" })%>
            </div>
            <div class="content-group">
                <label>
                    &nbsp;</label>
                <input type="button" value="Cari" class="btn btn-primary" onclick="GotoRontgenCreateByLabID();" />
            </div>
        </div>
        <div class="content-col">
            <div class="content-group">
                <label for="YEAR_CHECKUP">
                    Tahun Periksa</label>
                <%: Html.TextBoxFor(model => model.YEAR_CHECKUP, new { @class = "content-data" })%>
            </div>
        </div>
    </fieldset>
</div>
<% }
   else
   { %>
<% using (Html.BeginForm(ViewData["Action"].ToString(), "Rontgen", FormMethod.Post, new { @class = "content" }))
   {%>
<fieldset>
    <legend>HEADER</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="LAB_ID">
                Laboratorium ID</label>
            <%: Html.TextBoxFor(model => model.LabId, new { @class = "content-data" })%>
        </div>
        <div class="content-group">
            <label for="EMPLOYEE_ID">
                Nama Pegawai</label>
            <%: Html.TextBoxFor(model => model.EMPLOYEE_ID, new { @class = "content-data" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="YEAR_CHECKUP">
                Tahun Periksa</label>
            <%: Html.TextBoxFor(model => model.YEAR_CHECKUP, new { @class = "content-data" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>RONTGEN</legend>
    <div class="content-col-ful">
        <div class="content-group">
            <label for="RONTGEN_FILE_NAME">
                RONTGEN FILE NAME</label>
            <%: Html.TextBoxFor(model => model.RONTGEN_FILE_NAME, new { @class = "content-data" })%>
        </div>
        <div class="content-group">
            <label for="RONTGEN_RESULT">
                RONTGEN RESULT</label>
            <%: Html.TextBoxFor(model => model.RONTGEN_RESULT, new { @class = "content-data" })%>
        </div>
    </div>
</fieldset>
<div class="actions">
    <input type="submit" value="Simpan" class="btn btn-primary" />
    <%= Html.ActionLink("Kembali", "Index", "Rontgen", new {@class= "btn btn-primary btn-danger"}) %>
</div>
<% } %>
<% } %>