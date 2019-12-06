<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ShowPage.aspx.cs" Inherits="FinalProjectHTTP5101.ShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">
     <div class="viewnav">
        <a class="left" href="ListPages.aspx">Back To List</a>
        <ASP:Button OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" OnClick="Delete_Page" CssClass="right spaced" Text="Delete" runat="server"/>   
        <a class="right" href="UpdatePage.aspx?pageid=<%= Request.QueryString["pageid"] %>">Edit</a>
        
    </div>
    <div id="http_page" runat="server">
        
       Page Title: <span id="page_title" runat="server"></span><br />
       Page body: <span id="page_body" runat="server"></span><br />
     
    </div>
    
    <div id="page_classes" class="_table" runat="server">

    </div>

</asp:Content>
