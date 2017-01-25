﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminPage.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="CeeLearnAndDo.Admin.Projects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PlaceHolderHead" runat="server">
    <!---->
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitleContentPlaceholder" runat="server">
    <h4 class="title">Projects</h4>
    <p class="category">Project Options</p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="OptionsBarTopPlaceHolder" runat="server">

    <asp:Button runat="server" ID="btnPostbackLogOut" Style="display: none" OnClick="LogOut_OnClick" />
    <asp:Button runat="server" ID="btnPostbackRefreshPage" Style="display: none" OnClick="RefreshPage_OnClick" />
    <%--        <asp:Button runat="server" ID="GridViewReload" Style="display: none" OnClick="RefreshGridview_OnClick" />--%>


    <ul class="nav navbar-nav navbar-right">

        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <i class="material-icons">dashboard</i>
                <p class="hidden-lg hidden-md">Options</p>
            </a>
            <ul class="dropdown-menu">
                <li><a onclick="document.getElementById('<%= btnPostbackRefreshPage.ClientID %>').click()">Refresh Page</a></li>
                <%--             <li><a onclick="document.getElementById('<%= GridViewReload.ClientID %>').click()">Refresh Gridview</a></li>--%>
                <li><a onclick="RefreshGrid()">Refresh Gridview</a></li>
                <script>
                    function RefreshGrid() {
                        var updatePanelId = '<%= UpdatePanel1.ClientID %>';
                        __doPostBack(updatePanelId, '');

                    }

                </script>
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



<asp:Content ID="Content4" ContentPlaceHolderID="GridviewFAQPlaceholder" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView
                ID="GridViewProducts"
                runat="server"
                CssClass="table table-hover"
                AllowPaging="True"
                DataKeyNames="Tickertape_Id"
                AutoGenerateDeleteButton="True"
                AutoGenerateEditButton="True"
                OnRowDeleting="GridView1_RowDeleting"
                OnRowCancelingEdit="GridView1_RowCancelingEdit"
                OnRowEditing="GridView1_RowEditing"
                OnRowUpdating="GridView1_RowUpdating"
                GridLines="None">
            </asp:GridView>
        </ContentTemplate>
        <%--        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GridViewReload" EventName="Click" />
            <asp:PostBackTrigger ControlID="GridViewReload" />
        </Triggers>--%>
    </asp:UpdatePanel>

</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="InputFAQPlaceholder" runat="server">



    <div class="col-md-8">
        <div class="card">
            <div class="card-header" data-background-color="purple">
                <h4 class="title">Project</h4>
                <p class="category">Edit project descritpion</p>
            </div>
            <div class="card-content">

                <div class="row">
                    <div class="col-md-5">
                        <div class="form-group label-floating">
                            <label class="control-label">Description</label>
                            <input type="text" id="Description" runat="server" class="form-control">
                        </div>
                    </div>
                </div>



                <asp:Button ID="Button1" runat="server" OnClick="InputBoxButton_Clicked" class="btn btn-primary pull-right" Text="Send" />
                <div class="clearfix"></div>
            </div>
        </div>
    </div>



</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="SideBarPlaceholder" runat="server">


    <div class="sidebar-wrapper">
        <ul class="nav">
            <li class="active">
                <a href="/Admin/TickerTape.aspx">
                    <i class="material-icons">settings</i>
                    <p>TickerTape</p>
                </a>
            </li>
            <li>
                <a href="/Admin/ProductsAdmin.aspx">
                    <i class="material-icons">settings</i>
                    <p>Products</p>
                </a>
            </li>
            <li>
                <a href="/Admin/SMTPsettings.aspx">
                    <i class="material-icons">settings</i>
                    <p>Settings</p>
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