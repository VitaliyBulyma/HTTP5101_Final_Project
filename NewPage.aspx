<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="FinalProjectHTTP5101.NewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="body" runat="server">

     <h2>New Web Page</h2>
    <a class="left" href="ListPages.aspx">Back To List</a>
    <div class="formrow">
        <label>Enter Page Title</label>
        <asp:TextBox runat="server" ID="page_title"></asp:TextBox>
    </div>
    <div class="formrow">
        <label>Enter Page Text</label>
        <asp:TextBox MODE="multiline" Columns="50" Rows="50" runat="server" ID="page_body"></asp:TextBox>
    </div>
    

    <asp:Button OnClick="Add_Page" Text="Add Page" runat="server" />
</asp:Content>
