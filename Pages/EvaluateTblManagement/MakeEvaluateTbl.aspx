<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeEvaluateTbl.aspx.cs"
    Inherits="CES.UI.Pages.EvaluateTblManagement.MakeEvaluateTbl" %>

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
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
                Title="Panel" AutoScroll="true">
                <Items>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="SimpleForm"
                        ShowHeader="false">
                        <Items>
                            <x:DropDownList ID="DropDownList_Job" runat="server" Label="请选择职务">
                            </x:DropDownList>
                        </Items>
                    </x:SimpleForm>
                    <x:Panel ID="Panel_KeyResponse" runat="server" BodyPadding="5px" ShowBorder="true"
                        ShowHeader="true" Title="关键岗位职责指标" Collapsed="true" EnableCollapse="true">
                        <Items>
                            <x:SimpleForm ID="SimpleForm_KeyResponse1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyResponse1" runat="server" Label="1）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content_KeyResponse1" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyResponse2" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyResponse2" runat="server" Label="2）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content_KeyResponse2" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyResponse3" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyResponse3" runat="server" Label="3）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content_KeyResponse3" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyResponse4" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyResponse4" runat="server" Label="4）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content_KeyResponse4" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyResponse5" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyResponse5" runat="server" Label="5）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content_KeyResponse5" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel_KeyQualify" runat="server" BodyPadding="5px" ShowBorder="true"
                        ShowHeader="true" Title="关键岗位胜任能力指标" Collapsed="true" EnableCollapse="true">
                        <Items>
                            <x:SimpleForm ID="SimpleForm_KeyQualify1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyQualify1" runat="server" Label="1）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyQualify1" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyQualify1" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyQualify1" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyQualify1" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyQualify2" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyQualify2" runat="server" Label="2）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyQualify2" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyQualify2" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyQualify2" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyQualify2" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyQualify3" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyQualify3" runat="server" Label="3）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyQualify3" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyQualify3" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyQualify3" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyQualify3" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyQualify4" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyQualify4" runat="server" Label="4）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyQualify4" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyQualify4" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyQualify4" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyQualify4" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyQualify5" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyQualify5" runat="server" Label="5）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyQualify5" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyQualify5" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyQualify5" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyQualify5" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel_KeyAttitude" runat="server" BodyPadding="5px" ShowBorder="true"
                        ShowHeader="true" Title="关键工作态度指标" Collapsed="true" EnableCollapse="true">
                        <Items>
                            <x:SimpleForm ID="SimpleForm_KeyAttitude1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyAttitude1" runat="server" Label="1）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyAttitude1" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyAttitude1" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyAttitude1" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyAttitude1" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyAttitude2" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyAttitude2" runat="server" Label="2）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyAttitude2" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyAttitude2" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyAttitude2" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyAttitude2" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyAttitude3" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyAttitude3" runat="server" Label="3）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyAttitude3" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyAttitude3" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyAttitude3" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyAttitude3" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyAttitude4" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyAttitude4" runat="server" Label="4）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyAttitude4" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyAttitude4" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyAttitude4" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyAttitude4" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_KeyAttitude5" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_KeyAttitude5" runat="server" Label="5）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_KeyAttitude5" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_KeyAttitude5" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_KeyAttitude5" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_KeyAttitude5" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel_Response" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                        Title="岗位职责指标" Collapsed="true" EnableCollapse="true">
                        <Items>
                            <x:SimpleForm ID="SimpleForm_Response1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title1" runat="server" Label="1）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content1" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response2" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title2" runat="server" Label="2）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content2" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response3" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title3" runat="server" Label="3）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content3" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response4" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title4" runat="server" Label="4）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content4" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response5" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title5" runat="server" Label="5）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content5" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response6" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title6" runat="server" Label="6）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content6" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response7" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title7" runat="server" Label="7）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content7" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response8" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title8" runat="server" Label="8）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content8" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response9" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title9" runat="server" Label="9）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content9" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Response10" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Response_Title10" runat="server" Label="10）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Response_Content10" runat="server" Height="50px" Label="内容"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel_Qualify" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                        Title="岗位胜任能力指标" Collapsed="true" EnableCollapse="true">
                        <Items>
                            <x:SimpleForm ID="SimpleForm_Qualify1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Qualify1" runat="server" Label="1）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Qualify1" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Qualify1" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Qualify1" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Qualify1" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Qualify2" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Qualify2" runat="server" Label="2）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Qualify2" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Qualify2" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Qualify2" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Qualify2" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Qualify3" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Qualify3" runat="server" Label="3）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Qualify3" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Qualify3" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Qualify3" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Qualify3" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Qualify4" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Qualify4" runat="server" Label="4）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Qualify4" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Qualify4" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Qualify4" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Qualify4" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Qualify5" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Qualify5" runat="server" Label="5）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Qualify5" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Qualify5" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Qualify5" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Qualify5" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel_Attitude" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                        Title="工作态度指标" Collapsed="true" EnableCollapse="true">
                        <Items>
                            <x:SimpleForm ID="SimpleForm_Attitude1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Attitude1" runat="server" Label="1）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Attitude1" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Attitude1" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Attitude1" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Attitude1" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Attitude2" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Attitude2" runat="server" Label="2）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Attitude2" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Attitude2" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Attitude2" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Attitude2" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Attitude3" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Attitude3" runat="server" Label="3）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Attitude3" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Attitude3" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Attitude3" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Attitude3" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Attitude4" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Attitude4" runat="server" Label="4）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Attitude4" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Attitude4" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Attitude4" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Attitude4" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Attitude5" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Attitude5" runat="server" Label="5）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content1_Attitude5" runat="server" Height="50px" Label="优"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content2_Attitude5" runat="server" Height="50px" Label="良"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content3_Attitude5" runat="server" Height="50px" Label="中"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                    <x:TextArea ID="TextArea_Content4_Attitude5" runat="server" Height="50px" Label="差"
                                        Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                    <x:Panel ID="Panel_Reject" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                        Title="否决指标" EnableCollapse="true" Collapsed="true">
                        <Items>
                            <x:SimpleForm ID="SimpleForm_Reject1" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Reject1" runat="server" Label="1）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content_Reject1" runat="server" Height="50px" Label="内容" Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                            <x:SimpleForm ID="SimpleForm_Reject2" runat="server" BodyPadding="5px" Title="SimpleForm"
                                ShowHeader="false">
                                <Items>
                                    <x:TextBox ID="TextBox_Title_Reject2" runat="server" Label="2）标题" Text="">
                                    </x:TextBox>
                                    <x:TextArea ID="TextArea_Content_Reject2" runat="server" Height="50px" Label="内容" Text="" AutoGrowHeight="true">
                                    </x:TextArea>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Panel>
                    <x:Button ID="Button_Save" runat="server" Text="保存" OnClick="Button_Save_Click">
                    </x:Button>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
