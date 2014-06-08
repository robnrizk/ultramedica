<%@ Page Language="C#" MasterPageFile="~/Views/Shared/LogonForm.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.USER>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Ultra Medica - Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header" style="border: 0; margin: 1em auto 2em; font-family: MuseoSlab">
        <h1 class="text-center text-primary" style="font-size: 6em;color: #34495E">
            <img alt="" src="<%: Url.Content("~/Content/img/ULTRA MEDICA.png") %>" width="200" height="250" style="padding-bottom: -10px"/><br/>
            Ultra Medica
        </h1>
    </div>
    <% using (Html.BeginForm("LogOn", "Account", FormMethod.Post, new { @class = "login-box" }))
       { %>
             <%: Html.ValidationSummary(true, "Login was unsuccessful.", new { @class = "alert alert-danger alert-dismissable" })%>
            <div class="form-group"> 
                <%: Html.TextBoxFor(m => m.USERNAME, new { @placeholder = "Username", @class="form-control", @style="width:100%;"}) %>
                <%: Html.ValidationMessageFor(m => m.USERNAME) %>
            </div>
                
            <div class="form-group">
                <%: Html.PasswordFor(m => m.PASSWORD, new { @placeholder = "Password", @class = "form-control", @style = "width:100%;" })%>
                <%: Html.ValidationMessageFor(m => m.PASSWORD) %>
            </div>
            <input type="submit" value="MASUK" class="btn btn-danger" style="width:100%"/>
            
     <% } %>
</asp:Content>
