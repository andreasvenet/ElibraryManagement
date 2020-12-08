<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        Your name:<br />
        <asp:TextBox runat="server" id="txtName" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtName" ValidationGroup="group"></asp:RequiredFieldValidator>
        <br /><br />
    <div class="form-group">
                                    <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder="Due Date" TextMode="Date" ValidationGroup="group"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="group" ControlToValidate="TextBox6"></asp:RequiredFieldValidator>
                            
                                </div>
        <asp:Button runat="server" id="btnSubmitForm" text="Ok" OnClick="btnSubmitForm_Click" ValidationGroup="group" />
    
</asp:Content>
