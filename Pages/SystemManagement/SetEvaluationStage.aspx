<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SetEvaluationStage.aspx.cs" Inherits="CES.UI.Pages.SystemManagement.SetEvaluationStage" %>

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
                            <x:Button ID="Button_Init" runat="server" Text="初始化" Enabled="false" OnClick="Button_Init_Click"  ConfirmText="确定初始化系统？">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Start" runat="server" Text="开始考评" Enabled="false" OnClick="Button_Start_Click"  ConfirmText="确定开始考评？">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Stop" runat="server" Text="结束考评" Enabled="false" OnClick="Button_Stop_Click"  ConfirmText="确定结束考评？">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                        Title="Panel" Width="980px" >
                        <Items>
                            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm" ShowBorder="false" ShowHeader="false">
                                <Items>
                            <x:Label ID="Label_EvaluationStage" runat="server" Label="当前考评状态" Text="">
                            </x:Label>
                                </Items>
                            </x:SimpleForm>
                            <x:Grid ID="Grid1" runat="server" Title="被考评人名单" AutoScroll="true" EnableRowNumber="true" AutoHeight="true" Width="930px">
                                <Columns>
                                    <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="工号"
                                        Hidden="false" />
                                    <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名"
                                        Hidden="false" />
                                    <x:BoundField Width="50px" DataField="Sex" DataFormatString="{0}" HeaderText="性别"
                                        Hidden="false" />
                                    <x:BoundField Width="150px" ExpandUnusedSpace="true" DataField="Job" DataFormatString="{0}" HeaderText="职务"
                                        Hidden="false" />
                                    <x:BoundField Width="400px" DataField="Status" DataFormatString="{0}" HeaderText="考评完成情况"
                                        Hidden="false" />
                                    <x:WindowField TextAlign="Center" Width="80px" WindowID="Window_ShowReport" Text="述职报告"
                                        ToolTip="查看述职报告" DataIFrameUrlFields="ID,Name" DataIFrameUrlFormatString="iframe_ShowReport.aspx?id={0}&name={1}"
                                        Title="操作" IFrameUrl="iframe_ShowReport.aspx" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="Window_ShowReport" Title="述职报告" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" EnableClose="false"
        IsModal="true" Width="800px" EnableConfirmOnClose="true" OnClose="Window_Close"
        Height="550px">
    </x:Window>
    </form>
</body>
</html>
