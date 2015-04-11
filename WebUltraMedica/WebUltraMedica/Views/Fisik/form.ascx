<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUltraMedica.Models.FISIK>" %>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm(ViewData["Action"].ToString(), "Fisik", FormMethod.Post, new { @class = "content" }))
   {%>
<fieldset>
    <legend>HEADER</legend>
    <% if (Model.LabId != 0)
       {%>
    <div class="content-col">
        <div class="content-group">
            <label for="LAB_ID">
                Laboratorium ID</label>
            <%: Html.TextBoxFor(model => model.LabId, new { @class = "content-data", @readonly = "readonly" })%>
        </div>
    </div>
    <% } %>
    <div class="content-col">
        <div class="content-group">
            <label for="EMPLOYEE_ID">
                Nama Pegawai</label>
            <%: Html.TextBoxFor(model => model.EMPLOYEE_ID, new { @class = "content-data", @readonly = "readonly" })%>
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
    <legend>LINGKUNGAN KERJA</legend>
    <div class="content-col-ful">
        <div class="content-group">
            <label for="TEMPAT_KERJA">
                Tempat Kerja</label>
            <%: Html.DropDownListFor(m => m.TEMPAT_KERJA, Model.TEMPAT_KERJA_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="POSISI_KERJA">
                Posisi Kerja</label>
            <%: Html.DropDownListFor(m => m.POSISI_KERJA, Model.POSISI_BEKERJA_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="METODE_KERJA">
                Metode Kerja</label>
            <%: Html.DropDownListFor(m => m.METODE_KERJA, Model.METODE_BEKERJA_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="PAPARAN">
                Paparan</label>
            <%: Html.DropDownListFor(m => m.PAPARAN, Model.PAPARAN_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>RIWAYAT PENYAKIT PRIBADI DAN KELUARGA</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="RIWAYAT_ASMA">
                Riwayat Asma</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_ASMA, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_LEPRA">
                Riwayat Lepra</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_LEPRA, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_DEPRESI">
                Riwayat Depresi</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_DEPRESI, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_PROSTAT">
                Riwayat Prostat</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_PROSTAT, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_KELAMIN">
                Riwayat Kelamin</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_KELAMIN, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_OPERASI">
                Riwayat Operasi</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_OPERASI, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="RIWAYAT_EPILEPSI">
                Riwayat Epilepsi</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_EPILEPSI, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_ANSIETAS">
                Riwayat Ansietas</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_ANSIETAS, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_DM">
                Riwayat DM</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_DM, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_HEMOROID">
                Riwayat Hemoroid</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_HEMOROID, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="VAKSIN_HEPATITIS">
                Vaksin Hepatitis B</label>
            <%: Html.DropDownListFor(m => m.VAKSIN_HEPATITIS, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="RIWAYAT_KECELAKAAN_KERJA">
                Riwayat Kecelakaan Kerja</label>
            <%: Html.DropDownListFor(m => m.RIWAYAT_KECELAKAAN_KERJA, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
    <div class="content-col-ful">
        <div class="content-group">
            <label for="SUMMARY_RIWAYAT_PENYAKIT">
                Summary Riwayat Penyakit</label>
            <%: Html.TextAreaFor(m => m.SUMMARY_RIWAYAT_PENYAKIT, new { @class = "content-data", @style="width:80%;" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>KEBIASAAN - KEBIASAAN</legend>
    <div class="content-col-ful">
        <div class="content-group">
            <label for="KEBIASAAN_ALKOHOL">
                Kebiasan Alkohol</label>
            <%: Html.DropDownListFor(m => m.KEBIASAAN_ALKOHOL, Model.KEBIASAAN_ALKOHOL_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="KEBIASAAN_OLAHRAGA">
                Kebiasan Olahraga</label>
            <%: Html.DropDownListFor(m => m.KEBIASAAN_OLAHRAGA, Model.KEBIASAAN_OLAHRAGA_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="KEBIASAAN_MEROKOK">
                Kebiasan Merokok</label>
            <%: Html.DropDownListFor(m => m.KEBIASAAN_MEROKOK, Model.KEBIASAAN_MEROKOK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="KEBIASAAN_NARKOBA">
                Kebiasan Narkoba</label>
            <%: Html.DropDownListFor(m => m.KEBIASAAN_NARKOBA, Model.KEBIASAAN_NARKOBA_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>PEMERIKSAAN FISIK UMUM</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="TINGGI_BADAN">
                Tinggi Badan (cm)</label>
            <%: Html.TextBoxFor(model => model.TINGGI_BADAN, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="BMI">
                BMI (18-25)</label>
            <%: Html.TextBoxFor(model => model.BMI, new { @class = "content-data  currency-bank" })%>
        </div>
        <div class="content-group">
            <label for="LKR_PRT">
                LKR PRT (L: < 90 P: < 80)</label>
            <%: Html.TextBoxFor(model => model.LKR_PRT, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="T_DIASTOL">
                T. Diastol (60 - 85)</label>
            <%: Html.TextBoxFor(model => model.T_DIASTOL, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="RESPIRASI">
                Respirasi (<24/menit)</label>
            <%: Html.TextBoxFor(model => model.RESPIRASI, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="BERAT_BADAN">
                Berat Badan (kg)</label>
            <%: Html.TextBoxFor(model => model.BERAT_BADAN, new { @class = "content-data  currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="LKR_DD">
                LKR DD</label>
            <%: Html.TextBoxFor(model => model.LKR_DD, new { @class = "content-data  currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="T_SISTOL">
                T. Sistol (90 - 130)</label>
            <%: Html.TextBoxFor(model => model.T_SISTOL, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="NADI">
                Nadi (<100/menit)</label>
            <%: Html.TextBoxFor(model => model.NADI, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>PENGLIHATAN JAUH</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="VISUS_JAUH_TANPA_KACMATA">
                Visus J OD/OS tnp KM (6/6 m)</label>
            <%: Html.TextBoxFor(model => model.VISUS_JAUH_TANPA_KACMATA, new { @class="content-data"}) %>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="VISUS_JAUH_DENGAN">
                Visus J OD/OS dgn KM (6/6 m)</label>
            <%: Html.TextBoxFor(model => model.VISUS_JAUH_DENGAN, new { @class="content-data"}) %>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>PENGLIHATAN DEKAT</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="VISUS_DEKAT_TANPA_KACAMATA">
                Visus D OD/OS tnp KM (30/30 cm)</label>
            <%: Html.TextBoxFor(model => model.VISUS_DEKAT_TANPA_KACAMATA, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="BUTA_WARNA">
                Buta Warna</label>
            <%: Html.DropDownListFor(m => m.BUTA_WARNA, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="VISUS_DEKAT_DENGAN_KACAMATA">
                Visus d OD/OS dgn KM (30/30 cm)</label>
            <%: Html.TextBoxFor(model => model.VISUS_DEKAT_DENGAN_KACAMATA, new { @class="content-data"}) %>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>ANAMNESA</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="ANAMNESA_KELUHAN_UTAMA">
                Keluhan Utama</label>
            <%: Html.TextBoxFor(model => model.ANAMNESA_KELUHAN_UTAMA, new { @class="content-data"}) %>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="ANAMNESA_KELUHAN_TAMBAHAN">
                Keluhan Tambahan</label>
            <%: Html.TextBoxFor(model => model.ANAMNESA_KELUHAN_TAMBAHAN, new { @class="content-data"}) %>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>PEMERIKASAAN ORGAN SUPERFICIAL</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="MATA">
                MATA</label>
            <%: Html.TextBoxFor(model => model.MATA, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="MULUT">
                Mulut</label>
            <%: Html.TextBoxFor(model => model.MULUT, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="FARING">
                Faring</label>
            <%: Html.TextBoxFor(model => model.FARING, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="THYROID">
                Thyroid</label>
            <%: Html.TextBoxFor(model => model.THYROID, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="DADA">
                Dada</label>
            <%: Html.TextBoxFor(model => model.DADA, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="HERNIA">
                Hernia</label>
            <%: Html.TextBoxFor(model => model.HERNIA, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="PAYUDARA">
                Payudara</label>
            <%: Html.TextBoxFor(model => model.PAYUDARA, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="KULIT_KUKU">
                Kulit / Kuku</label>
            <%: Html.TextBoxFor(model => model.KULIT_KUKU, new { @class="content-data"}) %>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="TELINGA">
                Telinga</label>
            <%: Html.TextBoxFor(model => model.TELINGA, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="HIDUNG">
                Hidung</label>
            <%: Html.TextBoxFor(model => model.HIDUNG,new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="TONSIL">
                Tonsil</label>
            <%: Html.TextBoxFor(model => model.TONSIL,new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="LYMP_NODE">
                Lymp Node</label>
            <%: Html.TextBoxFor(model => model.LYMP_NODE,new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="PERUT">
                Perut</label>
            <%: Html.TextBoxFor(model => model.PERUT,new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="PERUT">
                Anus</label>
            <%: Html.TextBoxFor(model => model.ANUS,new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="PERUT">
                Variches / Hemoroid / H</label>
            <%: Html.TextBoxFor(model => model.VARICHES_HEMOROID,new { @class="content-data"}) %>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>PEMERIKSAAN ORGAN VISCERAL</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="PULMO_SIST_RESPIRASI">
                Pulmo Sistem Respirasi</label>
            <%: Html.TextBoxFor(model => model.PULMO_SIST_RESPIRASI, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="HATI_LIEN_GIT">
                Hati, Lien & GIT</label>
            <%: Html.TextBoxFor(model => model.HATI_LIEN_GIT, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="SIST_REPROD">
                Sistem Reproduksi</label>
            <%: Html.TextBoxFor(model => model.SIST_REPROD, new { @class="content-data"}) %>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="COR_SIST_CV">
                COR & Sist CV</label>
            <%: Html.TextBoxFor(model => model.COR_SIST_CV, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="SUG">
                SUG</label>
            <%: Html.TextBoxFor(model => model.SUG,new { @class="content-data"}) %>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>PEMERIKSAAN EXTRIMITAS OTOT DAN TULANG</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="EXTRIMITAS_ATAS">
                Extrimitas Atas</label>
            <%: Html.TextBoxFor(model => model.EXTRIMITAS_ATAS, new { @class="content-data"}) %>
        </div>
        <div class="content-group">
            <label for="OTOT_TULANG_LAIN">
                Otot dan Tulang Lain</label>
            <%: Html.TextBoxFor(model => model.OTOT_TULANG_LAIN, new { @class="content-data"}) %>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="EXTRIMITAS_BAWAH">
                Extrimitas Bawah</label>
            <%: Html.TextBoxFor(model => model.EXTRIMITAS_BAWAH, new { @class="content-data"}) %>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>PEMERIKSAAN GIGI</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="BAU_MULUT">
                Bau Mulut</label>
            <%: Html.DropDownListFor(m => m.BAU_MULUT, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="TANGGAL">
                Tanggal</label>
            <%: Html.TextBoxFor(model => model.TANGGAL, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="KARIES">
                Karies
            </label>
            <%: Html.TextBoxFor(model => model.KARIES, new { @class = "content-data currency-expense" })%>
        </div>
        <div class="content-group">
            <label for="SISA_AKAR">
                Sisa Akar</label>
            <%: Html.TextBoxFor(model => model.SISA_AKAR, new { @class = "content-data currency-expense" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>SYARAF DAN KOORDINASI</legend>
    <div class="content-col">
        <div class="content-group">
            <label for="REFLEX_PATOLOGIS">
                Reflek Patologis</label>
            <%: Html.DropDownListFor(m => m.REFLEX_PATOLOGIS, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="PARESE">
                Parese</label>
            <%: Html.DropDownListFor(m => m.PARESE, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="PATRICK_SIGN">
                Patrick Sign</label>
            <%: Html.DropDownListFor(m => m.PATRICK_SIGN, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
    <div class="content-col">
        <div class="content-group">
            <label for="PARESTESI">
                Parestesi</label>
            <%: Html.DropDownListFor(m => m.PARESTESI, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
        <div class="content-group">
            <label for="LASSAGUESIGN">
                Lassague Sign</label>
            <%: Html.DropDownListFor(m => m.LASSAGUESIGN, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>>
        </div>
        <div class="content-group">
            <label for="CONTRA_PATRICK_SIGN">
                Contra Patrick Sign</label>
            <%: Html.DropDownListFor(m => m.CONTRA_PATRICK_SIGN, Model.YA_TIDAK_LIST, new { @class = "content-data chosen" })%>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>KESIMPULAN</legend>
    <div class="content-col-ful">
        <div class="content-group">
            <label for="SUMMARY_KESIMPULAN">
                Kesimpulan</label>
            <%: Html.TextAreaFor(m => m.SUMMARY_KESIMPULAN, new { @class = "content-data", @style="width:80%;" })%>
        </div>
    </div>
</fieldset>
<div class="actions">
    <input type="submit" value="Simpan" class="btn btn-primary" />
    <%= Html.ActionLink("Kembali", "Index", "Fisik", new {@class= "btn btn-primary btn-danger"}) %>
</div>
<% }%>
