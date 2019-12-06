<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPage.aspx.cs" Inherits="n01401486_HTTP5101B_FinalProject.EditPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="pageinfo" runat="server">
        <h2>Edit Page</h2>
        <div class="form-field">
            <label for="page_title">Page Title:</label>
            <asp:TextBox runat="server" ID="page_title"></asp:TextBox>
            <asp:RequiredFieldValidator 
                runat="server"
                EnableClientScript="true"
                ControlToValidate="page_title" 
                ErrorMessage="Required."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-field">
            <label for="page_author">Author:</label>
            <asp:TextBox runat="server" ID="page_author"></asp:TextBox>
            <asp:RequiredFieldValidator 
                runat="server"
                EnableClientScript="true"
                ControlToValidate="page_author" 
                ErrorMessage="Required."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-field">
            <label for="page_body">Page Body:</label>
            <asp:TextBox runat="server" ID="page_body"></asp:TextBox>
            <asp:RequiredFieldValidator 
                runat="server"
                EnableClientScript="true"
                ControlToValidate="page_body" 
                ErrorMessage="Required."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-field">
            <label for="page_col1">Page Column 1:</label>
            <asp:TextBox runat="server" ID="page_col1"></asp:TextBox>
            <asp:RequiredFieldValidator 
                runat="server"
                EnableClientScript="true"
                ControlToValidate="page_col1" 
                ErrorMessage="Required."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-field">
            <label for="page_col2">Page Column 2:</label>
            <asp:TextBox runat="server" ID="page_col2"></asp:TextBox>
            <asp:RequiredFieldValidator 
                runat="server"
                EnableClientScript="true"
                ControlToValidate="page_col2" 
                ErrorMessage="Required."
                ForeColor="Red">
            </asp:RequiredFieldValidator>
        </div>
        <asp:Button OnClick="Edit_Page" runat="server" CssClass="add" Text="Confirm Changes"/>
    </div>
</asp:Content>
