<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="CeeLearnAndDo.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1>Some of our projects</h1>               
            </div>
            <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                    <div class="col-lg-4 col-sm-4">
                        <a href="ProjectInfo.aspx?id=<%# Eval("Project_Id")%>">
                        <div class="preview">
                            <div class="image">
                                <img class="img-responsive" src="<%# Eval("Project_Image") %>"/>                               
                            </div>
                            <div class="options">
                                <h3><asp:Label ID="lbNaam" runat="server" Text='<%# Eval("Project_Name") %>' font-size="X-Large"/></h3>
                                <p>
                                    <asp:Label ID="lbDescription" runat="server" Text='<%# Eval("Project_Description") %>' />
                                </p>
                                <div>
                                    <asp:Label ID="lbPublisher" runat="server" Text='<%# "Door " + Eval("Project_Publisher") %>' font-size="Smaller"/>
                                </div>
                            </div>
                        </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
