using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CES.DataStructure;
using CES.Controller;

namespace CES.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void IBLogin_Click(object sender, ImageClickEventArgs e)
        {
            string exception = "";
            UserInfo userInfo = new UserInfo();
            string id = TextBox_UserName.Text; ;
            string passWord = TextBox_Password.Text;
            LoginType loginType = (LoginType)Enum.Parse(typeof(LoginType), DropDownList_LoginType.SelectedValue);

            if (id == "" || passWord == "")
            {
                ErrorMessage.Text = "用户名、密码不能为空！";
                ErrorMessage.Visible = true;
                return;
            }

            if (LoginManagementCtrl.Loginin(ref userInfo, id, passWord, loginType, ref exception))
            {
                Session["UserID"] = userInfo.ID;
                Session["UserName"] = userInfo.Name;
                Session["UserType"] = userInfo.UserType;
                Response.Redirect("Pages/HomePage.aspx");
            }
            else
            {
                ErrorMessage.Text = exception + "\n请输入正确的用户名密码并选择正确的身份！";
                ErrorMessage.Visible = true;
            }
        }
    }
}