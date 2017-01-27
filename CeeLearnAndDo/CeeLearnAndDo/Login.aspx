<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CeeLearnAndDo.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <br /><br /><br /><br /><br /><br /><br /><br /><br />


    <div align="center">
    <fieldset style ="width:200px;">
    <legend>Login page </legend>
        <asp:TextBox ID="txtusername" placeholder="username" runat="server"
            Width="180px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="txtpassword" placeholder="password" runat="server"
            Width="180px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnsubmit" runat="server" Text="Submit"
           Width="81px" onclick="btnsubmit_Click" />
            <br />
            
    </fieldset>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />

</asp:Content>
