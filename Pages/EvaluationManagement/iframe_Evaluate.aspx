<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iframe_Evaluate.aspx.cs"
    Inherits="CES.UI.Pages.EvaluationManagement.iframe_Evaluate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .x-grid3-row .x-grid3-cell-inner
        {
            white-space: normal;
            padding: 10px 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="Fit">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="Button_Save" runat="server" Text="保存" OnClick="Button_Save_Click">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Close" runat="server" Text="关闭">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                    <x:Grid ID="Grid1" runat="server" Title="关键岗位职责指标（优：81～100良：61～80中：31～60差：0～30）" ShowHeader="true" >
                        <Columns>
                            <x:BoundField Width="100px" DataField="Title" DataFormatString="{0}" HeaderText="标题" />
                            <x:BoundField Width="600px" DataField="Quota" DataFormatString="{0}" HeaderText="内容" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score1" runat="server" Width="80px" Text='<%# GetScore(Eval("Score")) %>'></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid2" runat="server" Title="关键岗位胜任能力指标（优：81～100良：61～80中：31～60差：0～30）" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" DataField="Title" DataFormatString="{0}" HeaderText="标题" />
                            <x:BoundField Width="150px" DataField="Quota1" DataFormatString="{0}" HeaderText="优" />
                            <x:BoundField Width="150px" DataField="Quota2" DataFormatString="{0}" HeaderText="良" />
                            <x:BoundField Width="150px" DataField="Quota3" DataFormatString="{0}" HeaderText="中" />
                            <x:BoundField Width="150px" DataField="Quota4" DataFormatString="{0}" HeaderText="差" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score2" runat="server" Width="80px" Text='<%# GetScore(Eval("Score")) %>'></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid3" runat="server" Title="关键工作态度指标（优：81～100良：61～80中：31～60差：0～30）" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" DataField="Title" DataFormatString="{0}" HeaderText="标题" />
                            <x:BoundField Width="150px" DataField="Quota1" DataFormatString="{0}" HeaderText="优" />
                            <x:BoundField Width="150px" DataField="Quota2" DataFormatString="{0}" HeaderText="良" />
                            <x:BoundField Width="150px" DataField="Quota3" DataFormatString="{0}" HeaderText="中" />
                            <x:BoundField Width="150px" DataField="Quota4" DataFormatString="{0}" HeaderText="差" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score3" runat="server" Width="80px" Text='<%# GetScore(Eval("Score")) %>'></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid4" runat="server" Title="岗位职责指标（优：81～100良：61～80中：31～60差：0～30）" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" DataField="Title" DataFormatString="{0}" HeaderText="标题" />
                            <x:BoundField Width="600px" DataField="Quota" DataFormatString="{0}" HeaderText="内容" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score4" runat="server" Width="80px" Text='<%# GetScore(Eval("Score")) %>'></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid5" runat="server" Title="岗位胜任能力指标（优：81～100良：61～80中：31～60差：0～30）" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" DataField="Title" DataFormatString="{0}" HeaderText="标题" />
                            <x:BoundField Width="150px" DataField="Quota1" DataFormatString="{0}" HeaderText="优" />
                            <x:BoundField Width="150px" DataField="Quota2" DataFormatString="{0}" HeaderText="良" />
                            <x:BoundField Width="150px" DataField="Quota3" DataFormatString="{0}" HeaderText="中" />
                            <x:BoundField Width="150px" DataField="Quota4" DataFormatString="{0}" HeaderText="差" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score5" runat="server" Width="80px" Text='<%# GetScore(Eval("Score")) %>'></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid6" runat="server" Title="工作态度指标（优：81～100良：61～80中：31～60差：0～30）" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" DataField="Title" DataFormatString="{0}" HeaderText="标题" />
                            <x:BoundField Width="150px" DataField="Quota1" DataFormatString="{0}" HeaderText="优" />
                            <x:BoundField Width="150px" DataField="Quota2" DataFormatString="{0}" HeaderText="良" />
                            <x:BoundField Width="150px" DataField="Quota3" DataFormatString="{0}" HeaderText="中" />
                            <x:BoundField Width="150px" DataField="Quota4" DataFormatString="{0}" HeaderText="差" />
                            <x:TemplateField HeaderText="得分" Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox_Score6" runat="server" Width="80px" Text='<%# GetScore(Eval("Score")) %>'></asp:TextBox>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Grid ID="Grid7" runat="server" Title="否决指标（0或者-10）" ShowHeader="true">
                        <Columns>
                            <x:BoundField Width="100px" DataField="Title" DataFormatString="{0}" HeaderText="标题" />
                            <x:BoundField Width="600px" DataField="Quota" DataFormatString="{0}" HeaderText="内容" />
                            <x:TemplateField Width="100px" HeaderText="得分">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" ID="DropDownList_Reject" Visible="false" >
                                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="-10" Value="-10"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </x:TemplateField>
                        </Columns>
                    </x:Grid>
                    <x:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <x:ToolbarFill ID="ToolbarFill2" runat="server">
                            </x:ToolbarFill>
                            <x:Button ID="Button_Submit_Shadow" runat="server" Text="保存" OnClick="Button_Save_Click">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="Button_Close_Shadow" runat="server" Text="关闭">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
