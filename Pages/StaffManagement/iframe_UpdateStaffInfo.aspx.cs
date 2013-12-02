using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CES.Controller;
using CES.DataStructure;
using FineUI;

namespace CES.UI.Pages.StaffManagement
{
    public partial class iframe_UpdateStaffInfo : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                writeIDToViewState(); //将工号写入ViewState
                setButtonEvent(); //设置按钮事件

                bindJobIDNameDicToDropDownList(); //绑定职务信息到下拉列表

                loadStaffInfo(); //载入员工信息
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            loadStaffInfo();
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Save_Click(object sender, EventArgs e)
        {
            string id = ViewState["ID"].ToString();
            string name = TextBox_Name.Text.Trim();
            string sex = DropDownList_Sex.SelectedValue;
            string jobID = DropDownList_Job.SelectedValue;
            RoleType role = (RoleType)Enum.Parse(typeof(RoleType), DropDownList_Role.SelectedValue);
            string tele = NumberBox_Tele.Text;
            if (name == "" || tele == "") //检查空项
            {
                showError("保存失败", "不能有空项！");
                return;
            }

            string exception = "";
            
            //构造staffInfo
            StaffInfo staffInfo = new StaffInfo();
            staffInfo.ID = id;
            staffInfo.Name = name;
            staffInfo.Sex = sex;
            staffInfo.JobID = jobID;
            staffInfo.Role = role;
            staffInfo.Tele = tele;
            if (StaffManagementCtrl.UpdateStaffByID(ref staffInfo, id, ref exception))
            {
                showInformation("更新成功！窗口即将关闭");
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                showError("更新失败！", exception);
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定职务信息到下拉列表
        /// </summary>
        private void bindJobIDNameDicToDropDownList()
        {
            string exception = "";
            Dictionary<string, string> idNameDic = new Dictionary<string, string>();
            DropDownList_Job.Items.Clear();
            if (CommonCtrl.GetJobIDNameDic(ref idNameDic, ref exception))
            {
                DropDownList_Job.Items.Add("", "");
                foreach (string id in idNameDic.Keys)
                {
                    DropDownList_Job.Items.Add(idNameDic[id], id);
                }
            }
            else
            {
                showError("查询职务信息失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 将工号写入ViewState
        /// </summary>
        private void writeIDToViewState()
        {
            ViewState["ID"] = Request.QueryString["id"];
        }

        /// <summary>
        /// 载入员工信息
        /// </summary>
        private void loadStaffInfo()
        {
            string exception = "";
            string id = ViewState["ID"].ToString();
            StaffInfo staffInfo = new StaffInfo();
            if (StaffManagementCtrl.GetStaffByID(ref staffInfo, id, ref exception))
            {
                Label_ID.Text = staffInfo.ID;
                TextBox_Name.Text = staffInfo.Name;
                DropDownList_Sex.SelectedValue = staffInfo.Sex;
                DropDownList_Job.SelectedValue = staffInfo.JobID;
                DropDownList_Role.SelectedValue = ((int)staffInfo.Role).ToString();
                NumberBox_Tele.Text = staffInfo.Tele;
            }
            else
            {
                showError("查询员工信息失败！", exception);
                return;
            }
        }

        /// <summary>
        /// 设置按钮事件
        /// </summary>
        private void setButtonEvent()
        {
            Button_Close.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
        #endregion
    }
}