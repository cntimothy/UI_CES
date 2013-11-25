<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_ShowReport.aspx.cs"
    Inherits="CES.UI.Pages.EvaluationManagement.iframe_ShowReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" AutoScroll="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                Title="Panel">
                <Items>
                    <x:Label ID="Label_Report" runat="server" EncodeText="false" Label="Label" Text="">
                    </x:Label>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
