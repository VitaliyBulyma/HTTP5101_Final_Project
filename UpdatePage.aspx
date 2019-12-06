<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="UpdatePage.aspx.cs" Inherits="FinalProjectHTTP5101.UpdatePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
 <div id="http_page" runat="server">
        <div class="viewnav">
            <a class="left" href="ShowPage.aspx?pageid=<%=Request.QueryString["pageid"] %>">Cancel</a>

        </div>
        <h2>Updating Page <span id="page_title_main" runat="server"></span></h2>
        
        <div class="formrow">
            <label>Page Title</label>
            <asp:TextBox runat="server" ID="page_title"></asp:TextBox>
        </div>
        <div class="formrow">
            <label>Page Body</label>
            <asp:TextBox runat="server" ID="page_body"></asp:TextBox>
        </div>
        

        <asp:Button Text="Update Page" OnClick="Update_Page" runat="server" />
    </div>

</asp:Content>
