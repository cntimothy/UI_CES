﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CES.Controller;
using CES.DataStructure;
using FineUI;

namespace CES.UI.Pages.EvaluationManagement
{
    public partial class Evaluate : PageBase
    {
        #region PageInit
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WriteUserIDToViewState();   //将UserID写入ViewState
                WriteUserIDToSession();
                bindStaffInfoToGrid();      //绑定人员信息到grid
                setEvaluationStatueLabel(); //设置当前考评状态label
                setSubmitButton(); //设置提交按钮的可用性
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindStaffInfoToGrid();
            setEvaluationStatueLabel();
        }


        /// <summary>
        /// 提交按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string evaluatorID = ViewState["UserID"].ToString();
            string exception = "";
            if (EvaluationManagementCtrl.SubmitScoreByID(evaluatorID, ref exception))
            {
                showInformation("提交成功！");
                //刷新
                bindStaffInfoToGrid();
                setEvaluationStatueLabel();
                return;
            }
            else
            {
                int place = exception.IndexOf("message:");
                exception = exception.Substring(place+8);
                showError("提交失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 内联框架关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            bindStaffInfoToGrid();
            setEvaluationStatueLabel();
        }

        /// <summary>
        /// 行预绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PreRowDataBound(object sender, FineUI.GridPreRowEventArgs e)
        {
            WindowField windowField_Evaluate = Grid1.FindColumn("WindowField_Evaluate") as WindowField;
            DataRowView row = e.DataItem as DataRowView;
            if (row["Status"].ToString() == "已提交")
            {
                windowField_Evaluate.Enabled = false;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定人员信息到Grid
        /// </summary>
        private void bindStaffInfoToGrid()
        {
            string exception = "";
            string evaluatorID = ViewState["UserID"].ToString();
            DataTable table = new DataTable();
            
            if (EvaluationManagementCtrl.GetAllForEvaluate(ref table, evaluatorID, ref exception))
            {
                table = processTable(table); //从被考评人名单中删除“朱冰”和“黄培燕”
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
            else
            {
                writeErrorToLog("获取员工信息失败！", exception);
                table.Clear();
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
        }

        /// <summary>
        /// 设定当前考评状态label
        /// </summary>
        private void setEvaluationStatueLabel()
        {
            string exception = "";
            EvaluationStage evaluationStage = EvaluationStage.UNSTARTED;
            if (CommonCtrl.GetCurrentStage(ref evaluationStage, ref exception))
            {
                switch (evaluationStage)
                {
                    case EvaluationStage.UNSTARTED:
                        Label_EvaluationStage.Text = "未开始";
                        break;
                    case EvaluationStage.STARTED:
                        Label_EvaluationStage.Text = "已开始";
                        break;
                    case EvaluationStage.FINISHED:
                        Label_EvaluationStage.Text = "已结束";
                        break;
                    default:
                        Label_EvaluationStage.Text = "未定义";
                        break;
                }
            }
            else
            {
                showError("获取考评状态失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 将UserID写入Session
        /// </summary>
        private void WriteUserIDToSession()
        {
            Session["UserID"] = Request.QueryString["userid"];
        }

        /// <summary>
        /// 设置提交按钮的可用性
        /// </summary>
        private void setSubmitButton()
        {
            string evaluatorID = ViewState["UserID"].ToString();
            Button_Submit.Enabled = EvaluationManagementCtrl.IsSubmitable(evaluatorID);
        }

        /// <summary>
        /// 从被考评人名单中删除“朱冰”和“黄培燕”
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private DataTable processTable(DataTable table)
        {
            DataTable newTable = new DataTable();
            newTable.Columns.Add("ID");
            newTable.Columns.Add("Name");
            newTable.Columns.Add("Sex");
            newTable.Columns.Add("Job");
            newTable.Columns.Add("Status");
            int year = DateTime.Now.ToLocalTime().Year;
            if (year == 2013)
            {
                foreach (DataRow row in table.Rows)
                {
                    if (row["Name"].ToString() != "朱冰" && row["Name"].ToString() != "黄培燕")
                    {
                        newTable.Rows.Add(row["ID"], row["Name"], row["Sex"], row["Job"], row["Status"]);
                    }
                }
            }
            return newTable;
        }
        #endregion
    }
}