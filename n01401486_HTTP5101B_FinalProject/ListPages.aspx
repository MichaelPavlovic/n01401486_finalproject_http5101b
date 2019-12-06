<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListPages.aspx.cs" Inherits="n01401486_HTTP5101B_FinalProject.ListPages" %>
<%@ Register Src="~/ViewPages.ascx" TagName="ViewPages" TagPrefix="asp"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ViewPages runat="server"></asp:ViewPages>
    <h2>Manage Pages</h2>
    <a href="AddPage.aspx">Add Page</a>
    <div class="table" runat="server">
        <div class="table-head">
            <div class="table-heading">Page Title</div>
            <div class="table-heading">Author</div>
            <div class="table-heading">Action</div>
        </div>
        <div id="results" class="table-body" runat="server">

        </div>
    </div>
</asp:Content>
