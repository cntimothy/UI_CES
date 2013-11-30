using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using CES.DataStructure;
using CES.Controller;
using System.Text.RegularExpressions;

namespace CES.UI.Pages.EvaluationManagement
{
    public partial class iframe_Evaluate : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WriteUserIDToViewState();   //将UserID写入ViewState
                WriteEvaluatedIDToViewState();
                setButtonEvent();           //设置按钮事件
                loadEvaluateTbl();
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            string exception = "";
            EvaluateTbl evaluateTbl = new EvaluateTbl();
            string evaluatorID = getEvaluatorID();  //考评人ID
            string evaluatedID = ViewState["EvaluatedID"].ToString();   //被考评人ID
            if (getEvaluateTbl(ref evaluateTbl, ref exception))
            {
                if (EvaluationManagementCtrl.UpdateScoreByID(evaluateTbl, evaluatorID, evaluatedID, ref exception))
                {
                    showInformation("保存成功！");
                    return;
                }
                else
                {
                    showError("保存失败！", exception);
                    return;
                }
            }
            else
            {
                showError("保存失败！", exception);
                return;
            }
        }
        #endregion

        #region Prvate Method
        /// <summary>
        /// 设置按钮事件
        /// </summary>
        private void setButtonEvent()
        {
            Button_Close.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            Button_Close_Shadow.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }

        /// <summary>
        /// 载入考核表
        /// </summary>
        private void loadEvaluateTbl()
        {
            string exception = "";
            EvaluateTbl evaluateTbl = new EvaluateTbl();
            string evaluatorID = getEvaluatorID();
            string evaluatedID = ViewState["EvaluatedID"].ToString();
            if (EvaluationManagementCtrl.GetEvaluateTblByID(ref evaluateTbl, evaluatorID, evaluatedID, ref exception))
            {
                //关键岗位职责指标
                DataTable table1 = new DataTable();
                table1.Columns.Add("Title");
                table1.Columns.Add("Quota");
                table1.Columns.Add("Score");
                foreach (Quota item in evaluateTbl.KeyResponse)
                {
                    table1.Rows.Add(item.Title, item.Content[0], item.Score);
                }
                Grid1.DataSource = table1;
                Grid1.DataBind();

                //关键岗位胜任能力指标
                DataTable table2 = new DataTable();
                table2.Columns.Add("Title");
                table2.Columns.Add("Quota1");
                table2.Columns.Add("Quota2");
                table2.Columns.Add("Quota3");
                table2.Columns.Add("Quota4");
                table2.Columns.Add("Score");
                foreach (Quota item in evaluateTbl.KeyQualify)
                {
                    table2.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3], item.Score);
                }
                Grid2.DataSource = table2;
                Grid2.DataBind();

                //关键岗位工作态度指标
                DataTable table3 = new DataTable();
                table3.Columns.Add("Title");
                table3.Columns.Add("Quota1");
                table3.Columns.Add("Quota2");
                table3.Columns.Add("Quota3");
                table3.Columns.Add("Quota4");
                table3.Columns.Add("Score");
                foreach (Quota item in evaluateTbl.KeyAttitude)
                {
                    table3.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3], item.Score);
                }
                Grid3.DataSource = table3;
                Grid3.DataBind();

                //岗位职责指标
                DataTable table4 = new DataTable();
                table4.Columns.Add("Title");
                table4.Columns.Add("Quota");
                table4.Columns.Add("Score");
                foreach (Quota item in evaluateTbl.Response)
                {
                    table4.Rows.Add(item.Title, item.Content[0], item.Score);
                }
                Grid4.DataSource = table4;
                Grid4.DataBind();

                //岗位胜任能力指标
                DataTable table5 = new DataTable();
                table5.Columns.Add("Title");
                table5.Columns.Add("Quota1");
                table5.Columns.Add("Quota2");
                table5.Columns.Add("Quota3");
                table5.Columns.Add("Quota4");
                table5.Columns.Add("Score");
                foreach (Quota item in evaluateTbl.Qualify)
                {
                    table5.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3], item.Score);
                }
                Grid5.DataSource = table5;
                Grid5.DataBind();

                //岗位工作态度指标
                DataTable table6 = new DataTable();
                table6.Columns.Add("Title");
                table6.Columns.Add("Quota1");
                table6.Columns.Add("Quota2");
                table6.Columns.Add("Quota3");
                table6.Columns.Add("Quota4");
                table6.Columns.Add("Score");
                foreach (Quota item in evaluateTbl.Attitude)
                {
                    table6.Rows.Add(item.Title, item.Content[0], item.Content[1], item.Content[2], item.Content[3], item.Score);
                }
                Grid6.DataSource = table6;
                Grid6.DataBind();

                //否决指标
                DataTable table7 = new DataTable();
                table7.Columns.Add("Title");
                table7.Columns.Add("Quota");
                foreach (Quota item in evaluateTbl.Reject)
                {
                    table7.Rows.Add(item.Title, item.Content[0]);
                }
                Grid7.DataSource = table7;
                Grid7.DataBind();
                System.Web.UI.WebControls.DropDownList ddl = Grid7.Rows[0].FindControl("DropDownList_Reject") as System.Web.UI.WebControls.DropDownList;
                ddl.Visible = true;
                ddl.SelectedValue = evaluateTbl.Reject[0].Score.ToString();
            }
        }

        /// <summary>
        /// 将被考评人id写入ViewState
        /// </summary>
        private void WriteEvaluatedIDToViewState()
        {
            string evaluatedID = Request.QueryString["id"];
            ViewState["EvaluatedID"] = evaluatedID;
        }

        /// <summary>
        /// 获取考评人ID
        /// </summary>
        /// <returns></returns>
        private string getEvaluatorID()
        {
            string returnValue = "";
            try
            {
                returnValue = Session["UserID"].ToString();
            }
            catch (Exception)
            {
                PageContext.Redirect("../../Login.aspx");
            }
            return returnValue;
        }

        /// <summary>
        /// 检测字符串是否为表示整数,是整数返回true，否则返回false
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool isNumber(string[] items)
        {
            string pattern = @"^\d*$";
            foreach (string item in items)
            {
                if (!Regex.IsMatch(item, pattern))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检测字符串表示的数字是否在0~10之间（包括0和10），是则返回true，否则返回false
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool isProperty(string[] items)
        {
            foreach (string item in items)
            {
                if (item == "") //如果为空，也认为是正确的
                {
                    return true;
                }
                int i = Convert.ToInt32(item);
                if (i < 0 || i > 100)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 从页面中获取分数并检查分数是否合法，合法返回true，否则返回false
        /// </summary>
        /// <param name="evaluateTbl"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private bool getEvaluateTbl(ref EvaluateTbl evaluateTbl, ref string exception)
        {
            bool returnValue = true;
            List<string> tempScores = new List<string>(); //临时存储分数的List
            //关键岗位职责指标
            for (int i = 0; i < Grid1.Rows.Count; i++)
            {
                GridRow row = Grid1.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score1") as System.Web.UI.WebControls.TextBox;
                tempScores.Add(tb.Text.Trim());
            }
            if (!checkScores(tempScores, ref exception))
            {
                returnValue = false;
                return returnValue;
            }
            else
            {
                foreach (string score in tempScores)
                {
                    evaluateTbl.KeyResponse.Add(new Quota("", new string[] { "" }, getScoreFormStr(score)));
                }
                tempScores.Clear();
            }

            //关键岗位胜任能力指标
            for (int i = 0; i < Grid2.Rows.Count; i++)
            {
                GridRow row = Grid2.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score2") as System.Web.UI.WebControls.TextBox;
                tempScores.Add(tb.Text.Trim());
            }
            if (!checkScores(tempScores, ref exception))
            {
                returnValue = false;
                return returnValue;
            }
            else
            {
                foreach (string score in tempScores)
                {
                    evaluateTbl.KeyQualify.Add(new Quota("", new string[] { "" }, getScoreFormStr(score)));
                }
                tempScores.Clear();
            }

            //关键工作态度指标
            for (int i = 0; i < Grid3.Rows.Count; i++)
            {
                GridRow row = Grid3.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score3") as System.Web.UI.WebControls.TextBox;
                tempScores.Add(tb.Text.Trim());
            }
            if (!checkScores(tempScores, ref exception))
            {
                returnValue = false;
                return returnValue;
            }
            else
            {
                foreach (string score in tempScores)
                {
                    evaluateTbl.KeyAttitude.Add(new Quota("", new string[] { "" }, getScoreFormStr(score)));
                }
                tempScores.Clear();
            }

            //岗位职责指标
            for (int i = 0; i < Grid4.Rows.Count; i++)
            {
                GridRow row = Grid4.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score4") as System.Web.UI.WebControls.TextBox;
                tempScores.Add(tb.Text.Trim());
            }
            if (!checkScores(tempScores, ref exception))
            {
                returnValue = false;
                return returnValue;
            }
            else
            {
                foreach (string score in tempScores)
                {
                    evaluateTbl.Response.Add(new Quota("", new string[] { "" }, getScoreFormStr(score)));
                }
                tempScores.Clear();
            }

            //岗位胜任能力指标
            for (int i = 0; i < Grid5.Rows.Count; i++)
            {
                GridRow row = Grid5.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score5") as System.Web.UI.WebControls.TextBox;
                tempScores.Add(tb.Text.Trim());
            }
            if (!checkScores(tempScores, ref exception))
            {
                returnValue = false;
                return returnValue;
            }
            else
            {
                foreach (string score in tempScores)
                {
                    evaluateTbl.Qualify.Add(new Quota("", new string[] { "" }, getScoreFormStr(score)));
                }
                tempScores.Clear();
            }

            //工作态度指标
            for (int i = 0; i < Grid6.Rows.Count; i++)
            {
                GridRow row = Grid6.Rows[i];
                System.Web.UI.WebControls.TextBox tb = row.FindControl("TextBox_Score6") as System.Web.UI.WebControls.TextBox;
                tempScores.Add(tb.Text.Trim());
            }
            if (!checkScores(tempScores, ref exception))
            {
                returnValue = false;
                return returnValue;
            }
            else
            {
                foreach (string score in tempScores)
                {
                    evaluateTbl.Attitude.Add(new Quota("", new string[] { "" }, getScoreFormStr(score)));
                }
                tempScores.Clear();
            }

            //否决指标
            GridRow gridRow = Grid7.Rows[0];
            System.Web.UI.WebControls.DropDownList ddl = gridRow.FindControl("DropDownList_Reject") as System.Web.UI.WebControls.DropDownList;
            tempScores.Add(ddl.SelectedValue);
            if (!checkScores(tempScores, ref exception))
            {
                returnValue = false;
                return returnValue;
            }
            else
            {
                evaluateTbl.Reject.Add(new Quota("", new string[] { "" }, getScoreFormStr(tempScores[0])));
                tempScores.Clear();
            }

            return returnValue;
        }

        /// <summary>
        /// 检查分数是否合法，不合法返回false，并在exception中注明原因
        /// </summary>
        /// <param name="scoreList"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private bool checkScores(List<string> scoreList, ref string exception)
        {
            if (!isNumber(scoreList.ToArray()))
            {
                exception = "有项目为非数字！";
                return false;
            }
            if (!isProperty(scoreList.ToArray()))
            {
                exception = "有项目的分数不在0~10之间！";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 从字符串中获取整型分数，如果是空字符串，返回-1
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        private int getScoreFormStr(string score)
        {
            if (score == "")
            {
                return -1;
            }
            else
            {
                return Int32.Parse(score);
            }
        }
        #endregion
    }
}