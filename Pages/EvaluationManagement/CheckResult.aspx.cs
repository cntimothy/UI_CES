using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CES.Controller;
using CES.DataStructure;
using FineUI;
using System.Data;
using System.Text;
using System.IO;

namespace CES.UI.Pages.EvaluationManagement
{
    public partial class CheckResult : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WriteUserIDToViewState(); //将UserID写入ViewState
                bindStaffInfoToGrid();  //绑定人员信息到grid
                setEvaluationStatueLabel(); //设置当前考评状态Label
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 查看详细按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Check")
            {
                object[] keys = Grid1.DataKeys[e.RowIndex];
                Label_Name.Text = keys[1].ToString();
                string id = keys[0].ToString();
                string exception = "";
                List<float> scoreList = new List<float>();
                if (EvaluationManagementCtrl.GetScoresByID(ref scoreList, id, ref exception))
                {
                    StringBuilder sb = new StringBuilder();
                    scoreList.Sort();
                    foreach (float score in scoreList)
                    {
                        sb.Append(score.ToString("F2") + " ");
                    }
                    Label_Scores.Text = sb.ToString();
                }
                else
                {
                    showError("获取详细信息失败！", exception);
                }
            }
        }

        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Refresh_Click(object sender, EventArgs e)
        {

            bindStaffInfoToGrid();  //绑定人员信息到grid
            setEvaluationStatueLabel(); //设置当前考评状态Label
        }

        /// <summary>
        /// 导出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Export_Click(object sender, EventArgs e)
        {
            string exception = "";
            DataTable table = getDataTableFromGrid();
            string fileName = "";
            if (EvaluationManagementCtrl.ExportToExcel(ref fileName, table, ref exception))
            {
                Response.ClearContent();
                Response.ContentType = "application/excel";
                Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode(fileName));
                string path = Server.MapPath(@"..\..\downloadfiles\" + fileName);
                FileInfo fi = new FileInfo(path);
                Response.AddHeader("Content_Length", fi.Length.ToString());
                Response.Filter.Close();
                Response.WriteFile(fi.FullName);
                Response.End();
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
            DataTable table = new DataTable();

            if (EvaluationManagementCtrl.GetAllForCheck(ref table, ref exception))
            {
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
        /// 将Grid中的数据转化为table
        /// </summary>
        /// <returns></returns>
        private DataTable getDataTableFromGrid()
        {
            DataTable table = new DataTable();
            foreach (GridColumn column in Grid1.Columns)
            {
                if (column.HeaderText == "操作")
                {
                    continue;
                }
                table.Columns.Add(column.HeaderText);
            }
            foreach (GridRow gridRow in Grid1.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < gridRow.Values.Length - 1; i++)    //去掉最后一列
                {
                    dataRow[i] = gridRow.Values[i];
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }
        #endregion
    }
}