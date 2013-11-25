using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CES.Controller;

namespace CES.UI.Pages.SystemManagement
{
    public partial class DeleteFiles : PageBase
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
        protected void Button_ClearAll_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (SystemManagementCtrl.ClearDataBase(ref exception))
            {
                showInformation("清空成功！");
            }
            else
            {
                showError("清空失败！", exception);
            }
        }


        protected void Button_DeleteTempFiles_Click(object sender, EventArgs e)
        {
            string exception = "";
            if (SystemManagementCtrl.ClearTempFiles(ref exception))
            {
                showInformation("删除成功！");
            }
            else
            {
                showError("清空失败！", exception);
            }
        }
        #endregion
    }
}