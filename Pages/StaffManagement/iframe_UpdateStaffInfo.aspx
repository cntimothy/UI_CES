<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_UpdateStaffInfo.aspx.cs"
    Inherits="CES.UI.Pages.StaffManagement.iframe_UpdateStaffInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="Fit">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="Button_Reset" runat="server" Text="重置" OnClick="Button_Reset_Click">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Save" runat="server" Text="保存" OnClick="Button_Save_Click" ConfirmText="确定保存？">
                            </x:Button>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="Button_Close" runat="server" Text="关闭">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                        Title="Panel">
                        <Items>
                            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false" LabelWidth="50px">
                                <Items>
                                    <x:Label ID="Label_ID" runat="server" Label="工号" Text="">
                                    </x:Label>
                                    <x:TextBox ID="TextBox_Name" runat="server" Label="姓名" Text="">
                                    </x:TextBox>
                                    <x:DropDownList ID="DropDownList_Sex" runat="server" Label="性别">
                                        <x:ListItem EnableSelect="true" Text="男" Value="男" />
                                        <x:ListItem EnableSelect="true" Text="女" Value="女" />
                                    </x:DropDownList>
                                    <x:DropDownList ID="DropDownList_Job" runat="server" Label="职务">
                                    </x:DropDownList>
                                    <x:DropDownList ID="DropDownList_Role" runat="server" Label="分类">
                                        <x:ListItem EnableSelect="true" Text="领导" Value="0" />
                                        <x:ListItem EnableSelect="true" Text="中层干部" Value="1" />
                                        <x:ListItem EnableSelect="true" Text="群众" Value="2" />
                                    </x:DropDownList>
                                    <x:NumberBox ID="NumberBox_Tele" runat="server" Label="电话">
                                    </x:NumberBox>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
