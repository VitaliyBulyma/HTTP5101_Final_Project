<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="FinalProjectHTTP5101.WelcomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
</head>
<body>
    <form id="form1" runat="server">
     
    <div>
            <h1 id="welcome_page_main_heading" >Welcome to MyWordpress</h1>

        <div id="welcome_message_container">
             <p id="welcome_message"> Where you can create your own webpages</p>
        </div>
        <div id="welcome_button_container">
        <asp:LinkButton runat="server" href="NewPage.aspx" >Click to Create your own page</asp:LinkButton>
    </div>
        </div>
    </form>
</body>
</html>
