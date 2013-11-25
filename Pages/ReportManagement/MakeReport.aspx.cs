using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CES.Controller;
using FineUI;
using CES.DataStructure;

namespace CES.UI.Pages.ReportManagement
{
    public partial class MakeReport : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //将UserID写入ViewState                
                WriteUserIDToViewState();

                setButton_Save();
                loadReport();
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
            loadReport();
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            string exception = "";
            string id = ViewState["UserID"].ToString();
            string report = HtmlEditor_Report.Text;
            if (ReportManagementCtrl.UpdateReportByID(id, report, ref exception))
            {
                showInformation("保存成功！");
                return;
            }
            else
            {
                showError("保存失败！", exception);
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 载入述职报告
        /// </summary>
        private void loadReport()
        {
            string exception = "";
            string id = ViewState["UserID"].ToString();
            string report = "";
            if(CommonCtrl.GetReportByID(ref report, id, ref exception)) //获取述职报告
            {
                exception = "";
                EvaluationStage evaluationStage = EvaluationStage.UNSTARTED;
                if (CommonCtrl.GetCurrentStage(ref evaluationStage, ref exception)) //获取当前考评状态
                {
                    if (evaluationStage == EvaluationStage.UNSTARTED) //如果当前考评状态是已开始，则显示HTMLEdit，否则显示Label
                    {
                        HtmlEditor_Report.Visible = true;
                        HtmlEditor_Report.Text = report;
                    }
                    else
                    {
                        Label_Report.Visible = true;
                        Label_Report.Text = report;
                    }
                }
                else
                {
                    HtmlEditor_Report.Text = "";
                    showError("获取考评状态失败！", exception);
                    return;
                }
            }
            else
            {
                HtmlEditor_Report.Text = "";
                showError("获取述职报告失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 根据考评状态设置保存按钮的可读性
        /// </summary>
        private void setButton_Save()
        {
            string exception = "";
            EvaluationStage evaluationStage = EvaluationStage.UNSTARTED;
            if (CommonCtrl.GetCurrentStage(ref evaluationStage, ref exception))
            {
                if (evaluationStage == EvaluationStage.UNSTARTED)
                {
                    Button_Save.Enabled = true;
                }
            }
            else
            {
                showError("获取考评状态失败！", exception);
            }
        }
        #endregion
    }
}