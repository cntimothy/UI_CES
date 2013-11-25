using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CES.Controller;

namespace CES.UI.Pages.AccountManagement
{
    public partial class ChangePasswd : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //将UserID写入ViewState
                WriteUserIDToViewState();
            }
        }

        #region Event
        /// <summary>
        /// 修改密码按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_ChangePassword_Click(object sender, EventArgs e)
        {
            string exception = "";
            string oldPassword = TextBox1.Text.Trim();
            string newPassword = TextBox2.Text.Trim();
            if (oldPassword.Length != 6 || newPassword.Length != 6)
            {
                showError("修改失败！", "密码必须六位！");
                return;
            }
            if (checkNull(oldPassword, newPassword))
            {
                string id = Session["UserID"].ToString();
                if (AccountManagementCtrl.ChangePasswd(id, newPassword, oldPassword, ref exception))
                {
                    showInformation("修改成功！");
                }
                else
                {
                    showError("修改失败！", exception);
                }
            }
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 检查输入的字符串是否为空，都不为空返回true，否则返回false；
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool checkNull(params string[] items)
        {
            foreach (string item in items)
            {
                if (item == "")
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}