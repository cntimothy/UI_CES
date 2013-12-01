<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMsg.aspx.cs" Inherits="CES.UI.Pages.MsgManagement.SendMsg" %>

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
                            <x:Button ID="Button_Refresh" runat="server" Text="刷新" OnClick="Button_Refresh_Click">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Send" runat="server" Text="发送" OnClick="Button_Send_Click" ConfirmText="确定发送？">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                        Title="Panel" Layout="Column" Width="1200px">
                        <Items>
                            <x:Panel ID="Panel5" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                                Title="Panel">
                                <Items>
                                    <x:CheckBox ID="CheckBox_OnlyShowUnsubmitted" runat="server" Label="Label" Text="只显示未提交"
                                        AutoPostBack="true" OnCheckedChanged="CheckBox_OnlyShowUnsubmitted_CheckedChanged">
                                    </x:CheckBox>
                                    <x:Grid ID="Grid1" runat="server" Title="员工名单" AllowPaging="true" PageSize="20" EnableRowNumber="true"
                                        Height="520px" Width="780px" DataKeyNames="ID" EnableCheckBoxSelect="true" CheckBoxSelectOnly="true"
                                        OnPageIndexChange="Grid1_PageIndexChange" ClearSelectedRowsAfterPaging="false">
                                        <Columns>
                                            <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="工号"
                                                Hidden="false" />
                                            <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名"
                                                Hidden="false" />
                                            <x:BoundField Width="50px" DataField="Sex" DataFormatString="{0}" HeaderText="性别"
                                                Hidden="false" />
                                            <x:BoundField Width="150px" ExpandUnusedSpace="true" DataField="Job" DataFormatString="{0}"
                                                HeaderText="职务" Hidden="false" />
                                            <x:BoundField Width="80px" DataField="Role" DataFormatString="{0}" HeaderText="分类"
                                                Hidden="false" />
                                            <x:BoundField Width="150px" ExpandUnusedSpace="true" DataField="Tele" DataFormatString="{0}"
                                                HeaderText="电话" Hidden="false" />
                                            <x:BoundField Width="100px" DataField="Status" DataFormatString="{0}"
                                                HeaderText="状态" Hidden="false" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Panel>
                            <x:HiddenField ID="hfSelectedIDS" runat="server">
                            </x:HiddenField>
                            <x:Panel ID="Panel4" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                                Title="Panel">
                                <Items>
                                    <x:TextArea ID="TextArea_Msg" runat="server" Label="Label" Text="" Width="300px"
                                        Height="200px" EmptyText="请输入短信内容">
                                    </x:TextArea>
                                    <x:CheckBox ID="CheckBox_AddMsg" runat="server" Label="Label" Text="是否自动加用户名和密码">
                                    </x:CheckBox>
                                </Items>
                            </x:Panel>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
