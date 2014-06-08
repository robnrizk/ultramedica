<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUltraMedica.Models.LAB>" %>
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
                <input type="button" value="Cari" class="btn btn-primary" onclick="GotoLabCreateByLabID();" />
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
<% using (Html.BeginForm(ViewData["Action"].ToString(), "Lab", FormMethod.Post, new { @class = "content" }))
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
    <legend>LABORATORIUM HEMATOLOGI</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="HB">
                HB</label>
            <%: Html.TextBoxFor(model => model.HB, new { @class = "content-data currency-bank" })%>
        </div>
        <div class="content-group">
            <label for="LEUKOSIT">
                LEUKOSIT</label>
            <%: Html.TextBoxFor(model => model.LEUKOSIT, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="ERITROSIT">
                ERITROSIT</label>
            <%: Html.TextBoxFor(model => model.ERITROSIT, new { @class = "content-data currency-bank" })%>
        </div>
        <div class="content-group">
            <label for="DIFMON">
                DIFMON</label>
            <%: Html.TextBoxFor(model => model.DIFMON, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="DIFGRAN">
                DIFGRAN</label>
            <%: Html.TextBoxFor(model => model.DIFGRAN, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="HCT">
                HCT</label>
            <%: Html.TextBoxFor(model => model.HCT, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="TROMBOSIT">
                TROMBOSIT</label>
            <%: Html.TextBoxFor(model => model.TROMBOSIT, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="LED">
                LED</label>
            <%: Html.TextBoxFor(model => model.LED, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="DIFLIM">
                DIFLIM</label>
            <%: Html.TextBoxFor(model => model.DIFLIM, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>LABORATORIUM SEROTOLOGI</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="HBSAG">
                HBSAG</label>
            <%: Html.DropDownListFor(m => m.HBSAG, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="VDRL">
                VDRL</label>
            <%: Html.DropDownListFor(m => m.VDRL, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="AHBS">
                AHBS</label>
            <%: Html.TextBoxFor(model => model.AHBS, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>LABORATORIUM KIMIA KLINIK</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="CHOLESTEROL">
                CHOLESTEROL</label>
            <%: Html.TextBoxFor(model => model.CHOLESTEROL, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="HDL">
                HDL</label>
            <%: Html.TextBoxFor(model => model.HDL, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="RCHOLESTEROL_HDL">
                R CHOLESTEROL/HDL</label>
            <%: Html.TextBoxFor(model => model.RCHOLESTEROL_HDL, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="CREATINE">
                CREATINE</label>
            <%: Html.TextBoxFor(model => model.CREATINE, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="BSN">
                BSN</label>
            <%: Html.TextBoxFor(model => model.BSN, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="OT">
                OT</label>
            <%: Html.TextBoxFor(model => model.OT, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="TRIGLISERIN">
                TRIGLISERIN</label>
            <%: Html.TextBoxFor(model => model.TRIGLISERIN, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="LDL">
                LDL</label>
            <%: Html.TextBoxFor(model => model.LDL, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="BUN">
                BUN</label>
            <%: Html.TextBoxFor(model => model.BUN, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="UA">
                UA</label>
            <%: Html.TextBoxFor(model => model.UA, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="_2JPP">
                2JPP</label>
            <%: Html.TextBoxFor(model => model._2JPP, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="PT">
                PT</label>
            <%: Html.TextBoxFor(model => model.PT, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>LABORATORIUM URINALISA</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="REDUKSI_PUASA">
                REDUKSI PUASA</label>
            <%: Html.DropDownListFor(m => m.REDUKSI_PUASA, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="WARNA_URINE">
                WARNA URINE</label>
            <%: Html.TextBoxFor(model => model.WARNA_URINE, new { @class = "content-data" })%>
        </div>
        <div class="content-group">
            <label for="PH">
                PH</label>
            <%: Html.TextBoxFor(model => model.PH, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="BIL">
                BIL</label>
            <%: Html.DropDownListFor(m => m.BIL, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="EPITEL">
                EPITEL</label>
            <%: Html.TextBoxFor(model => model.EPITEL, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="URINE_ERITROSIT">
                ERITROSIT</label>
            <%: Html.TextBoxFor(model => model.URINE_ERITROSIT, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="SIL">
                SIL</label>
            <%: Html.DropDownListFor(m => m.SIL, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="REDUKSI_2JPP">
                REDUKSI 2JPP</label>
            <%: Html.DropDownListFor(m => m.REDUKSI_2JPP, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="BJ">
                BJ</label>
            <%: Html.TextBoxFor(model => model.BJ, new { @class = "content-data  currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="KETON">
                KETON</label>
            <%: Html.DropDownListFor(m => m.KETON, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="NITRIT">
                NITRIT</label>
            <%: Html.DropDownListFor(m => m.NITRIT, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="URINE_LEKOSIT">
                Leukosit</label>
            <%: Html.TextBoxFor(model => model.URINE_LEKOSIT, new { @class = "content-data" })%>
        </div>
        <div class="content-group">
            <label for="BAKTERI">
                Bakteri</label>
            <%: Html.DropDownListFor(m => m.BAKTERI, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="KRISTAL">
                Kristal</label>
            <%: Html.DropDownListFor(m => m.KRISTAL, Model.POSITIVE_NEGATIVE_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>KESIMPULAN</legend>
    <div class="content-col-ful">
        <div class="content-group">
            <label for="LAB_RESUME">
                Kesimpulan Lab</label>
            <%: Html.TextAreaFor(m => m.LAB_RESUME, new { @class = "content-data", @style="width:80%;" })%>
        </div>
    </div>
</fieldset>
<div class="actions">
    <input type="submit" value="Simpan" class="btn btn-primary" />
    <%= Html.ActionLink("Kembali", "Index", "Lab", new {@class= "btn btn-primary btn-danger"}) %>
</div>
<% } %>
<% } %>