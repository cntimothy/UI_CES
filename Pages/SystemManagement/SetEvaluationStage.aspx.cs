using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CES.Controller;
using CES.DataStructure;

namespace CES.UI.Pages.SystemManagement
{
    public partial class SetEvaluationStage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //将UserID写入ViewState
                WriteUserIDToViewState();
                refreshGridLabelButton(); //查询当前考评状态并根据其设置Grid、Button和Label
            }
        }

        #region Event
        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            refreshGridLabelButton(); //刷新Grid、Label和Button
        }

        /// <summary>
        /// 初始化按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Init_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (SystemManagementCtrl.InitSystem(ref exception))
            {
                showInformation("设置成功！");
            }
            else
            {
                showError("设置失败！", exception);
            }
            refreshGridLabelButton(); //刷新Grid、Label和Button
        }

        /// <summary>
        /// 开始按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Start_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (SystemManagementCtrl.StartEvaluation(ref exception))
            {
                showInformation("设置成功！");
            }
            else
            {
                showError("设置失败！", exception);
            }
            refreshGridLabelButton(); //刷新Grid、Label和Button
        }

        /// <summary>
        /// 结束按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Stop_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (SystemManagementCtrl.StopEvaluation(ref exception))
            {
                showInformation("设置成功！");
            }
            else
            {
                showError("设置失败！", exception);
            }
            refreshGridLabelButton(); //刷新Grid、Label和Button
        }

        /// <summary>
        /// 内联框架关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            //查看述职报告后什么都不做
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定员工信息到Grid
        /// </summary>
        private void bindStaffInfoToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            if (SystemManagementCtrl.GetAll(ref table, ref exception))
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
        /// 载入考评的当前状态
        /// </summary>
        private void loadEvaluationStageToViewStage()
        {
            string exception = "";
            EvaluationStage evaluationStage = EvaluationStage.UNSTARTED;
            if (CommonCtrl.GetCurrentStage(ref evaluationStage, ref exception))
            {
                ViewState["EvaluationStage"] = evaluationStage.ToString();
            }
            else
            {
                showError("获取考评状态失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 设置当前考评状态Label
        /// </summary>
        private void setEvaluationStageLabel()
        {
            try
            {
                EvaluationStage evaluationStage = (EvaluationStage)Enum.Parse(typeof(EvaluationStage), ViewState["EvaluationStage"].ToString());
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
            catch (Exception)   //如果未能获取当前考评状态，则显示状态为未知
            {
                Label_EvaluationStage.Text = "未知！";
            }
        }

        /// <summary>
        /// 根据当前考评状态设置按钮的可用性
        /// </summary>
        private void setButtonEnabled()
        {
            try
            {
                EvaluationStage evaluationStage = (EvaluationStage)Enum.Parse(typeof(EvaluationStage), ViewState["EvaluationStage"].ToString());
                switch (evaluationStage)
                {
                    case EvaluationStage.UNSTARTED:
                        Button_Start.Enabled = true;
                        Button_Init.Enabled = false;
                        Button_Stop.Enabled = false;
                        break;
                    case EvaluationStage.STARTED:
                        Button_Stop.Enabled = true;
                        Button_Init.Enabled = false;
                        Button_Start.Enabled = false;
                        break;
                    case EvaluationStage.FINISHED:
                        Button_Init.Enabled = true;
                        Button_Start.Enabled = false;
                        Button_Stop.Enabled = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception) //如果未能获取当前考评状态，则按钮都不可用
            { 
                
            }
        }

        /// <summary>
        /// 刷新表格、标签和按钮
        /// </summary>
        private void refreshGridLabelButton()
        {
            loadEvaluationStageToViewStage(); //将当前考评状态写入ViewState
            bindStaffInfoToGrid();  //员工信息
            setEvaluationStageLabel();  //当前考评状态Label
            setButtonEnabled(); //按钮
        }
        #endregion
    }
}