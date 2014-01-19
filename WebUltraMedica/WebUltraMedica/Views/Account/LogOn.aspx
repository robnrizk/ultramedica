<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUltraMedica.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Ultra Medica - Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header" style="border: 0; margin: 6em auto 3em; font-family: Source Sans Pro">
        <h1 class="text-center text-primary" style="font-size: 6em;">Ultra Medica <br/><small class="text-muted">Internal System</small></h1>
    </div>
    <% using (Html.BeginForm("LogOn", "Account", FormMethod.Post, new { @class = "login-box" }))
       { %>
        <%: Html.ValidationSummary(true, "Login was unsuccessful. Please correct the errors and try again.") %>
            <div class="form-group"> 
                <%: Html.TextBoxFor(m => m.UserName, new { @placeholder = "username", @class="form-control"}) %>
                <%: Html.ValidationMessageFor(m => m.UserName) %>
            </div>
                
            <div class="form-group">
                <%: Html.PasswordFor(m => m.Password, new { @placeholder = "password", @class = "form-control" })%>
                <%: Html.ValidationMessageFor(m => m.Password) %>
            </div>
            <input type="submit" value="LOGIN" class="btn btn-primary"/>
     <% } %>
</asp:Content>
