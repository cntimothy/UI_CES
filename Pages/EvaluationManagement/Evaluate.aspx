<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluate.aspx.cs" Inherits="CES.UI.Pages.EvaluationManagement.Evaluate" %>

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
                            <x:Button ID="Button_Submit" runat="server" Text="提交" ConfirmText="确定提交？" OnClick="Button_Submit_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                        Title="Panel" Width="750px">
                        <Items>
                            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowBorder="false" ShowHeader="false">
                                <Items>
                                    <x:Label ID="Label_EvaluationStage" runat="server" Label="当前考评状态" Text="***">
                                    </x:Label>
                                </Items>
                            </x:SimpleForm>
                            <x:Grid ID="Grid1" runat="server" Title="被考评人名单" Width="730px" EnableRowNumber="true"
                                DataKeyNames="ID,Name" AutoHeight="true">
                                <Columns>
                                    <x:BoundField Width="100px" DataField="ID" DataFormatString="{0}" HeaderText="工号"
                                        Hidden="false" />
                                    <x:BoundField Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名"
                                        Hidden="false" />
                                    <x:BoundField Width="50px" DataField="Sex" DataFormatString="{0}" HeaderText="性别"
                                        Hidden="false" />
                                    <x:BoundField Width="150px" ExpandUnusedSpace="true" DataField="Job" DataFormatString="{0}"
                                        HeaderText="职务" Hidden="false" />
                                    <x:BoundField Width="150px" DataField="Status" DataFormatString="{0}" HeaderText="当前状态"
                                        Hidden="false" />
                                    <x:WindowField TextAlign="Center" Width="80px" WindowID="Window_ShowReport" Text="述职报告"
                                        ToolTip="查看述职报告" DataIFrameUrlFields="ID,Name" DataIFrameUrlFormatString="iframe_ShowReport.aspx?id={0}&name={1}"
                                        Title="操作" IFrameUrl="iframe_ShowReport.aspx" />
                                    <x:WindowField TextAlign="Center" Width="50px" WindowID="Window_Evaluate" Text="考评"
                                        ToolTip="开始考评" DataIFrameUrlFields="ID,Name" DataIFrameUrlFormatString="iframe_Evaluate.aspx?id={0}&name={1}"
                                        Title="操作" IFrameUrl="iframe_Evaluate.aspx" />
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="Window_ShowReport" Title="述职报告" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" EnableClose="true"
        IsModal="true" Width="800px" EnableConfirmOnClose="true"
        Height="550px">
    </x:Window>
    <x:Window ID="Window_Evaluate" Title="考评" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" EnableClose="true"
        OnClose="Window_Evaluate_Close" IsModal="true" Width="900px" EnableConfirmOnClose="true"
        Height="550px">
    </x:Window>
    </form>
</body>
</html>
