<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectInfo.aspx.cs" Inherits="CeeLearnAndDo.ProjectInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-4 col-sm-4">
        <div class="preview">
            <div class="image">
                <img class="img-responsive" src="<%= project.Project_Image %>" />
            </div>
            <div class="options">
                <h3>
                    <asp:Label ID="lbNaam" runat="server" Font-Size="X-Large" ><%= project.Project_Name %></asp:Label>
                </h3>
                <p>
                    <asp:Label ID="lbDescription" runat="server"><%= project.Project_Description%></asp:Label>
                </p>
                <div>
                    <asp:Label ID="lbPublisher" runat="server" Font-Size="Smaller" ><%= project.Project_Publisher %></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
