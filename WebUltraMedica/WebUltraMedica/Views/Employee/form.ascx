<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<WebUltraMedica.Models.EMPLOYEE>"%>

<% Html.EnableClientValidation(); %>
<% using(Html.BeginForm(ViewData["Action"].ToString(), "Employee", FormMethod.Post, new{@class="content"})){%>
    
    <% if (!string.IsNullOrEmpty(ViewData["ErrorMessage"].ToString()))
       { %>
        <div class="alert alert-danger alert-dismissable">
           <strong>Error : </strong><%: ViewData["ErrorMessage"].ToString() %>
        </div>
    <% }%>

    <div class="content-col">
        <fieldset>
            <label for="EMPLOYEE_ID">NRP</label>
            <% if(string.IsNullOrEmpty(Model.EMPLOYEE_ID))
               { %>
            <%: Html.TextBoxFor(m => m.EMPLOYEE_ID, new {@class = "content-data"}) %>      
            <%: Html.ValidationMessageFor(m => m.EMPLOYEE_ID) %>
            <% } else
               { %>
            <%: Html.TextBoxFor(m => m.EMPLOYEE_ID, new {@class = "content-data", @readonly = "readonly"}) %>       
            <% } %>
          
        </fieldset>
        
        <fieldset>
            <label for="NAME">Nama</label>
            <%: Html.TextBoxFor(m => m.NAME, new { @class = "content-data" })%>
        </fieldset>
        
        <fieldset>
            <label for="AGE">Umur</label>
            <%: Html.TextBoxFor(m => m.AGE, new { @class = "content-data" })%>
        </fieldset>
        
         <fieldset>
            <label for="SEX">Jenis Kelamin</label>
            <%: Html.DropDownListFor(m => m.SEX, Model.SEX_LIST, new { @class = "content-data chosen" })%>
        </fieldset>

        <fieldset>
            <label for="MESS_STATUS">Status Mess</label>
            <%: Html.DropDownListFor(m => m.MESS_STATUS, Model.MESS_LIST, new { @class = "content-data chosen" })%>
        </fieldset>
        
    </div>    
    
    <div class="content-col">
        <fieldset>
            <label for="POSITION">Posisi</label>
            <%: Html.TextBoxFor(m => m.POSITION, new { @class = "content-data" })%>
        </fieldset>

        <fieldset>
            <label for="DISTRICT">Distrik</label>
            <%: Html.TextBoxFor(m => m.DISTRICT, new { @class = "content-data" })%>
        </fieldset>

       <fieldset>
            <label for="DEPARTMENT">Departemen</label>
            <%: Html.TextBoxFor(m => m.DEPARTMENT, new { @class = "content-data" })%>
        </fieldset>
        
        <fieldset>
            <label for="COMPANY_ID">Nama Perusahaan</label>
            <%: Html.DropDownListFor(m => m.COMPANY_ID, Model.COMPANY_LIST, new { @class = "content-data chosen" })%>
        </fieldset>
        
        <fieldset>
            <label for="STATUS">Status</label>
            <%: Html.DropDownListFor(m => m.STATUS, Model.STATUS_LIST, new { @class = "content-data chosen" })%>
        </fieldset>
    </div>
    
    <br style="clear: both"/>
    <div class="actions">
        <input type="submit" value="Simpan" class="btn btn-primary"/>
        <%= Html.ActionLink("Kembali", "Index", "Employee", new {@class= "btn btn-primary btn-danger"}) %>
    </div>
<%} %>