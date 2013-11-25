<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckResult.aspx.cs" Inherits="CES.UI.Pages.EvaluationManagement.CheckResult" %>

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
                            <x:Button ID="Button_Export" runat="server" EnableAjax="false" Text="导出" ConfirmText="确定导出？" OnClick="Button_Export_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                        Title="Panel" Width="960px" >
                        <Items>
                            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <x:Label ID="Label_EvaluationStage" runat="server" Label="当前考评状态" Text="">
                                    </x:Label>
                                </Items>
                            </x:SimpleForm>
                            <x:Grid ID="Grid1" runat="server" Title="被考评人名单" Width="910px" EnableRowNumber="true"
                                DataKeyNames="ID,Name" AutoHeight="true" OnRowCommand="Grid1_RowCommand">
                                <Columns>
                                    <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="工号"
                                        Hidden="false" />
                                    <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名"
                                        Hidden="false" />
                                    <x:BoundField Width="50px" DataField="Sex" DataFormatString="{0}" HeaderText="性别"
                                        Hidden="false" />
                                    <x:BoundField Width="150px" ExpandUnusedSpace="true" DataField="Job" DataFormatString="{0}"
                                        HeaderText="职务" Hidden="false" />
                                    <x:BoundField Width="100px" DataField="Leader" DataFormatString="{0}" HeaderText="领导"
                                        Hidden="false" />
                                    <x:BoundField Width="100px" DataField="Cadres" DataFormatString="{0}" HeaderText="中层干部"
                                        Hidden="false" />
                                    <x:BoundField Width="100px" DataField="People" DataFormatString="{0}" HeaderText="群众"
                                        Hidden="false" />
                                    <x:BoundField Width="100px" DataField="Sum" DataFormatString="{0}" HeaderText="总分"
                                        Hidden="false" />
                                    <x:LinkButtonField Width="60px" HeaderText="操作" Text="查看详细" CommandName="Check" />
                                </Columns>
                            </x:Grid>
                            <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" Title="详细分数" Width="910px" LabelWidth="50px">
                                <Items>
                                    <x:Label ID="Label_Name" runat="server" Label="姓名" Text="">
                                    </x:Label>
                                    <x:Label ID="Label_Scores" runat="server" Label="详细" Text="">
                                    </x:Label>
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
