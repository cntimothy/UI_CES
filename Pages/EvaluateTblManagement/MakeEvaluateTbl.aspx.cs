using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CES.Controller;
using CES.DataStructure;
using FineUI;

namespace CES.UI.Pages.EvaluateTblManagement
{
    public partial class MakeEvaluateTbl : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WriteUserIDToViewState(); //将用户ID写入ViewState
                bindJobToDropDownList(); //绑定职务到下拉列表
            }
        }
        #endregion

        #region Event
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            string exception = "";
            EvaluateTbl evaluateTbl = new EvaluateTbl();
            string jobID = DropDownList_Job.SelectedValue;
            //关键岗位责任指标
            foreach (ControlBase cb in Panel_KeyResponse.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                string title = (sf.Items[0] as FineUI.TextBox).Text.Trim();
                if (title != "")//当标题不为空时才有效
                {
                    string[] content = new string[] { (sf.Items[1] as FineUI.TextArea).Text.Trim() };
                    evaluateTbl.KeyResponse.Add(new Quota(title, content, 0));
                }
            }
            //关键岗位胜任能力指标
            foreach (ControlBase cb in Panel_KeyQualify.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                string title = (sf.Items[0] as FineUI.TextBox).Text.Trim();
                if (title != "")//当标题不为空时才有效
                {
                    string[] content = new string[] {
                        (sf.Items[1] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[2] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[3] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[4] as FineUI.TextArea).Text.Trim(),
                    };
                    evaluateTbl.KeyQualify.Add(new Quota(title, content, 0));
                }
            }
            //关键工作态度指标
            foreach (ControlBase cb in Panel_KeyAttitude.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                string title = (sf.Items[0] as FineUI.TextBox).Text.Trim();
                if (title != "")//当标题不为空时才有效
                {
                    string[] content = new string[] {
                        (sf.Items[1] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[2] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[3] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[4] as FineUI.TextArea).Text.Trim(),
                    };
                    evaluateTbl.KeyAttitude.Add(new Quota(title, content, 0));
                }
            }
            //岗位责任指标
            foreach (ControlBase cb in Panel_Response.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                string title = (sf.Items[0] as FineUI.TextBox).Text.Trim();
                if (title != "")//当标题不为空时才有效
                {
                    string[] content = new string[] { (sf.Items[1] as FineUI.TextArea).Text.Trim() };
                    evaluateTbl.Response.Add(new Quota(title, content, 0));
                }
            }
            //岗位胜任能力指标
            foreach (ControlBase cb in Panel_Qualify.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                string title = (sf.Items[0] as FineUI.TextBox).Text.Trim();
                if (title != "")//当标题不为空时才有效
                {
                    string[] content = new string[] {
                        (sf.Items[1] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[2] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[3] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[4] as FineUI.TextArea).Text.Trim(),
                    };
                    evaluateTbl.Qualify.Add(new Quota(title, content, 0));
                }
            }
            //工作态度指标
            foreach (ControlBase cb in Panel_Attitude.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                string title = (sf.Items[0] as FineUI.TextBox).Text.Trim();
                if (title != "")//当标题不为空时才有效
                {
                    string[] content = new string[] {
                        (sf.Items[1] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[2] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[3] as FineUI.TextArea).Text.Trim(),
                        (sf.Items[4] as FineUI.TextArea).Text.Trim(),
                    };
                    evaluateTbl.Attitude.Add(new Quota(title, content, 0));
                }
            }
            //否决指标
            foreach (ControlBase cb in Panel_Reject.Items)
            {
                SimpleForm sf = cb as SimpleForm;
                string title = (sf.Items[0] as FineUI.TextBox).Text.Trim();
                if (title != "") //当标题不为空时才有效
                { 
                    string[] content = new string[] {(sf.Items[1] as FineUI.TextArea).Text.Trim()};
                    evaluateTbl.Reject.Add(new Quota(title, content, 0));
                }
            }

            if (EvaluateTblManagementCtrl.UpdateEvaluateTbl(jobID, evaluateTbl, ref exception))
            {
                showInformation("更新成功！");
                return;
            }
            else
            {
                showError("更新失败！", exception);
                return;
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定职务到下拉列表
        /// </summary>
        private void bindJobToDropDownList()
        {
            DropDownList_Job.Items.Clear(); //清空职务下拉列表
            string exception = "";
            Dictionary<string, string> idNameDic = new Dictionary<string, string>();
            if (CommonCtrl.GetJobIDNameDic(ref idNameDic, ref exception))
            {
                foreach (string id in idNameDic.Keys)
                {
                    DropDownList_Job.Items.Add(id + idNameDic[id], id);
                }
            }
        }
        #endregion
    }
}