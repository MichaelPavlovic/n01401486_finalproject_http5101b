<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="n01401486_HTTP5101B_FinalProject.DeletePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <a href="ListPages.aspx">Click to go back</a>
    </div>
    <div id="pageinfo" runat="server">
        <h2>Delete Page</h2>
        Page Title: <span id="page_title" runat="server"></span>
        Author: <span id="page_author" runat="server"></span>
        Page Body: <span id="page_body" runat="server"></span>
        Page Column 1: <span id="page_col1" runat="server"></span>
        Page Column 2: <span id="page_col2" runat="server"></span>
    </div>
    <asp:Button OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" OnClick="Delete_Page" runat="server" CssClass="delete" Text="Delete" />
</asp:Content>
