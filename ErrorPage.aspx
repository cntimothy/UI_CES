<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="CES.UI.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
        Title="Panel">
        <Items>
            <x:Label ID="Label_ErrorInfo" runat="server" Label="Label" Text="Label">
            </x:Label>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
