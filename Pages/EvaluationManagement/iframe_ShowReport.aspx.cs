using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using CES.Controller;

namespace CES.UI.Pages.EvaluationManagement
{
    public partial class iframe_ShowReport : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                writeEvaluatedIDNameToViewState(); //将被考评人ID姓名写入ViewState
                loadEvaluatedName();
                loadReport();
            }
        }
        #endregion

        #region Event
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