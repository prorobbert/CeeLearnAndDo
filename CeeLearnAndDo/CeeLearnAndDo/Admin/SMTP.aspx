<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SMTP.Master" AutoEventWireup="true" CodeBehind="SMTP.aspx.cs" Inherits="CeeLearnAndDo.Admin.SMTP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SideBarPlaceholder" runat="server">

 <div class="sidebar-wrapper">
        <ul class="nav">
            <li>
                <a href="/Admin/FaqAdmin.aspx">
                    <i class="material-icons">settings</i>
                    <p>FAQ</p>
                </a>
            </li>
            <li>
                <a href="/Admin/ProductsAdmin.aspx">
                    <i class="material-icons">settings</i>
                    <p>Products</p>
                </a>
            </li>
            <li class="active">
                <a href="/Admin/SMTPsettings.aspx">
                    <i class="material-icons">settings</i>
                    <p>Mail Settings</p>
                </a>
            </li>
             <li>
                <a href="/Admin/NieuwsbriefAdmin.aspx">
                    <i class="material-icons">settings</i>
                    <p>Nieuwsbrief</p>
                </a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OptionsBarTopPlaceHolder" runat="server">

    <asp:Button runat="server" ID="btnPostbackLogOut" Style="display: none" OnClick="LogOut_OnClick" />
    <asp:Button runat="server" ID="btnPostbackRefreshPage" Style="display: none" OnClick="RefreshPage_OnClick" />
    <%--    <asp:Button runat="server" ID="GridViewReload" Style="display: none" OnClick="RefreshGridview_OnClick" />--%>


    <ul class="nav navbar-nav navbar-right">

        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <i class="material-icons">dashboard</i>
                <p class="hidden-lg hidden-md">Options</p>
            </a>
            <ul class="dropdown-menu">
                <li><a onclick="document.getElementById('<%= btnPostbackRefreshPage.ClientID %>').click()">Refresh Page</a></li>
                <%--                <li><a onclick="document.getElementById('<%= GridViewReload.ClientID %>').click()">Refresh Gridview</a></li>--%>
            </ul>
        </li>
        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <i class="material-icons">person</i>
                <p class="hidden-lg hidden-md">User</p>
            </a>
            <ul class="dropdown-menu">
                <li><a onclick="document.getElementById('<%= btnPostbackLogOut.ClientID %>').click()">Log-Out</a></li>
            </ul>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="COntentPart" runat="server">

    <div class="col-md-8">
        <div class="card">
            <div class="card-header" data-background-color="purple">
                <h4 class="title">Edit Settings</h4>
                <p class="category">SMTP mailing settings</p>
            </div>
            <div class="card-content">

                <div class="row">
                    <div class="col-md-5">
                        <div class="form-group label-floating">
                            <label class="control-label">Mail</label>
                            <input type="text" id="MailInput" runat="server" class="form-control">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group label-floating">
                            <label class="control-label">SMTP server</label>
                            <input type="text" runat="server" id="ServerInput" class="form-control">
                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group label-floating">
                            <label class="control-label">Password</label>
                            <input type="text" runat="server" id="PasswordInput" class="form-control">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group label-floating">
                            <label class="control-label">Port</label>
                            <input type="text" runat="server" id="PortInput" class="form-control">
                        </div>
                    </div>
                </div>

                <asp:Button ID="Button1" runat="server" OnClick="Update" class="btn btn-primary pull-right" Text="Update Settings" />
                <asp:Button ID="Button2" runat="server" OnClick="LoadSettings" class="btn btn-primary pull-right" Text="Load Settings" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>
    </asp:Content>