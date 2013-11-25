using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CES.Controller;
using CES.DataStructure;

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
                return;
            }
            else
            {
                showError("提交失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 内联框架关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window_Evaluate_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            bindStaffInfoToGrid();
            setEvaluationStatueLabel();
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
                Grid1.DataSource = table;
                Grid1.DataBind();
            }
            else
            {
                showError("获取员工信息失败！", exception);
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
        #endregion
    }
}