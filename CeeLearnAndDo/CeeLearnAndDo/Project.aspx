<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="CeeLearnAndDo.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1>Some of our projects</h1>
                <p class="lead">
                    To view all our projects, go to  <a target="_blank" href="/Project.aspx">Projects</a>.
                </p>
            </div>
            <asp:ListView ID="ListView1" runat="server">             
                <ItemTemplate>
                    <td runat="server" style="background-color:#DCDCDC;color: #000000;">Naam:
                        <asp:Label ID="NaamLabel" runat="server" Text='<%# Eval("Project_Name") %>' />
                        <br />Image:
                        <asp:Label ID="ImageLabel" runat="server" Text='<%# Eval("Project_Image") %>' />
                        <br />Publisher:
                        <asp:Label ID="PublisherLabel" runat="server" Text='<%# Eval("Project_Publisher") %>' />
                        <br />Description:
                        <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Project_Description") %>' />
                        <br /></td>
                </ItemTemplate>
            </asp:ListView>
            <div class="col-lg-4 col-sm-4">
                <div class="preview">
                    <div class="image">
                        <a>
                            <img class="img-responsive" src="images/htmlandcss.png" alt="HTML and CSS: Design and Build Websites, by Jon Duckett"></a>
                    </div>
                    <div class="options">
                        <h3>HTML &amp; CSS</h3>
                        <p>
                            Jon Duckett
                        </p>
                        <div>
                            <div class="btn-group">
                                <a class="btn btn-primary" href="#" target="_blank">Amazon</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-sm-4">
                <div class="preview">
                    <div class="image">
                        <a href="#" target="_blank">
                            <img class="img-responsive" src="images/eloquentjavascript.png" alt="Eloquent JavaScript, by Marijn Haverbeke"></a>
                    </div>
                    <div class="options">
                        <h3>Eloquent Android</h3>
                        <p>
                            Marijn Haverbeke
                        </p>
                        <div>
                            <div class="btn-group">
                                <a class="btn btn-primary" href="#" target="_blank">Amazon</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-sm-4">
                <div class="preview">
                    <div class="image">
                        <img class="img-responsive" src="images/beautifulwebdesign.png" alt="The Principles of Beautiful Web Design, by Jason Beaird"></a>
                    </div>
                    <div class="options">
                        <h3>Beautiful Mobile Web Design</h3>
                        <p>
                            Jason Beaird
                        </p>
                        <div>
                            <div class="btn-group">
                                <a class="btn btn-primary" href="#" target="_blank">Amazon</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
