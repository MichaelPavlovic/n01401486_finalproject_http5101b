<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowPage.aspx.cs" Inherits="n01401486_HTTP5101B_FinalProject.ShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="pageinfo" runat="server">
        <h1><span id="page_title" runat="server"></span></h1>
        <p class="page-author">By: <span id="page_author" runat="server"></span></p>
        <main class="main"><span id="page_body" runat="server"></span></main>
        <div class="col1"><span id="page_col1" runat="server"></span></div>
        <div class="col2"><span id="page_col2" runat="server"></span></div>
    </div>
</asp:Content>
