<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeletePage.aspx.cs" Inherits="n01401486_HTTP5101B_FinalProject.DeletePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageinfo" runat="server">
        <h2>Delete Page</h2>
        <h3>Page Title:</h3> <span id="page_title" runat="server"></span>
        <h3>Author:</h3><span id="page_author" runat="server"></span>
        <h3>Page Body:</h3><span id="page_body" runat="server"></span>
        <h3>Page Column 1:</h3><span id="page_col1" runat="server"></span>
        <h3>Page Column 2:</h3><span id="page_col2" runat="server"></span>
    </div>
    <div class="button-container">
        <asp:Button OnClientClick="if(!confirm('Are you sure you want to delete this?')) return false;" OnClick="Delete_Page" runat="server" CssClass="delete" Text="Delete" />
        <a class="cancel" href="ListPages.aspx">Cancel</a>
    </div>
</asp:Content>
