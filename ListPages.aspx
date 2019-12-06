<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="FinalProjectHTTP5101.ListPages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">

     <h1>Manage Pages</h1>
    <div id="page_nav">
        <asp:label for="page_search" runat="server">Search:</asp:label>
        <asp:TextBox ID="page_search" runat="server"></asp:TextBox>
        <asp:Button runat="server" text="submit"/>
        <div id="sql_debugger" runat="server"></div>
        
       
    </div>
    <a  href="NewPage.aspx">New Page</a>
    <div class="_table" runat="server">
        <div class="listitem">
            <div class="col5">Page Title</div>
            <div class="col5">Page Body</div>
            <div class="col5">View the Page</div>
            <div class="col5">Edit/Delete</div>
            <div class="col5last">Update</div>
            
            
            
        </div>
        <div id="pages_result" runat="server">

        </div>
    </div>


</asp:Content>
