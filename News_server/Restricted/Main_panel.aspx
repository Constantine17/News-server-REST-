<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_panel.aspx.cs" Inherits="News_server.Restricted.Main_panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Панель управления:<br />
            <br />
            <asp:Button ID="Searh_speders" runat="server" OnClick="Searh_speders_Click" Text="Управление поисковыми ботами" Width="275px" />
            <br />
            <br />
            <asp:Button ID="Control_users" runat="server" OnClick="Control_users_Click" Text="Управление пользователями" Width="276px" />
        </div>
    </form>
</body>
</html>
