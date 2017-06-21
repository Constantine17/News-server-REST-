<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Control_spiders.aspx.cs" Inherits="News_server.Restricted.Control_spiders" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            Упровление поисковыми ботами</p>
        <p>
            <asp:Button ID="spider_theverge_com" runat="server" Text="theverge.com" Width="114px" OnClick="spider_theverge_com_Click" />
            <asp:Button ID="theverge_com_inXml" runat="server" Text="в XML" OnClick="theverge_com_inXml_Click" Width="60px" />
        </p>
        <p>
            <asp:Button ID="All" runat="server" OnClick="All_Click" Text="Кешировать все" Width="176px" />
        </p>
        <p>
            <asp:Button ID="back" runat="server" OnClick="back_Click" Text="Назад" />
        </p>
        <p>
            <asp:Label ID="Label" runat="server"></asp:Label>
        </p>
        <p>
 
            <asp:TextBox ID="Output_new" runat="server" TextMode="MultiLine" Height="557px" Width="1039px" ValidateRequestMode="Disabled"></asp:TextBox>
 
        </p>
    </form>
</body>
</html>
