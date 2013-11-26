using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using CES.Controller;

namespace CES.UI.Pages.SystemManagement
{
    public partial class iframe_ShowReport : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                writeEvaluatedIDNameToViewState(); //将被考评人ID姓名写入ViewState
                Button_Close.OnClientClick = ActiveWindow.GetHidePostBackReference(); //注册关闭按钮事件
                loadEvaluatedName();
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
        protected void Button_Refresh_Close(object sender, EventArgs e)
        {
            loadReport();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 载入
        /// </summary>
        private void loadReport()
        {
            string exception = "";
            string evaluatedID = ViewState["EvaluatedID"].ToString();
            string report = "";
            if (CommonCtrl.GetReportByID(ref report, evaluatedID, ref exception))
            {
                Label_Report.Text = report;
                return;
            }
            else
            {
                showError("述职报告载入失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 将被考评人ID姓名写入ViewState
        /// </summary>
        private void writeEvaluatedIDNameToViewState()
        {
            ViewState["EvaluatedID"] = Request.QueryString["id"];
            ViewState["EvaluatedName"] = Request.QueryString["name"];
        }

        /// <summary>
        /// 将被考评人姓名显示出来
        /// </summary>
        private void loadEvaluatedName()
        {
            Panel2.Title = ViewState["EvaluatedName"].ToString() + "的述职报告";
        }
        #endregion
    }
}