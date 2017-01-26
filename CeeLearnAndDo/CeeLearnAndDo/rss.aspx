<%@ Page Language="C#" ContentType="text/xml" AutoEventWireup="true" CodeBehind="rss.aspx.cs" Inherits="CeeLearnAndDo.rss" %>
 
<asp:Repeater ID="RepeaterRSS" runat="server">
        <HeaderTemplate>
           <rss version="2.0">
                <channel>
                    <title>CeeLearnAndDo</title>
                    <link>http://www.google.com</link>
                    <description>
                    CeeLearnAndDo website voor school
                    </description>
        </HeaderTemplate>
        <ItemTemplate>
            <item>
                <title><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "Name")) %></title>
                <link>http://www.yourdomain.com/news.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "Id") %></link>
                <author><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "Publisher"))%></author>
                <description><%# RemoveIllegalCharacters(DataBinder.Eval(Container.DataItem, "Description"))%></description>
        </item>
        </ItemTemplate>
        <FooterTemplate>
                </channel>
            </rss>  
        </FooterTemplate>
</asp:Repeater>