<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CeeLearnAndDo.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center"><h3>Heeft u een vraag? Neem dan contact met ons op.</h3><br /></div>
    <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblEmail" runat="server" Text="Email adres:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbEmail" runat="server"></asp:TextBox></asp:TableCell>           
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblName" runat="server" Text="Naam:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbName" runat="server"></asp:TextBox></asp:TableCell>   
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblVraag" runat="server" Text="Vraag:"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="tbVraag" runat="server"></asp:TextBox></asp:TableCell>   
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></asp:TableCell>
            <asp:TableCell></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell></asp:TableCell>
            <asp:TableCell><asp:Button ID="btnVerzenden" runat="server" Text="Verzenden" OnClick="btnVerzenden_Click"/></asp:TableCell>   
        </asp:TableRow>
    </asp:Table>
    <br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>
