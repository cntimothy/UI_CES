using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Text;

namespace CES.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("抱歉，系统发生内部错误，错误号：" + Request.QueryString["errorno"] + "。")
                    .Append("请重试，或将错误号告知管理员。");
                Label_ErrorInfo.Text = sb.ToString();
            }
        }
        #endregion
    }
}