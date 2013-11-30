using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CES.Controller;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CES.UI.Pages.MsgManagement
{
    public partial class SendMsg : PageBase
    {
        #region Page Init
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //将UserID写入ViewState
                WriteUserIDToViewState();

                bindStaffInfoToGrid();
            }
        }
        #endregion

        #region Event
        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Refresh_Click(object sender, EventArgs e)
        {
            bindStaffInfoToGrid();
        }

        /// <summary>
        /// 发送按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Send_Click(object sender, EventArgs e)
        {
            string msg = TextArea_Msg.Text.Trim();
            if (msg == "")
            {
                showError("发送失败！", "发送内容为空");
                return;
            }
            //同步当前页已选择的项到hiddenfield
            SyncSelectedRowIndexArrayToHiddenField();

            //从hiddenfield中获取已选择的ID列表
            List<string> idList = GetSelectedRowIndexArrayFromHiddenField();

            string exception = "";
            bool addMsg = CheckBox_AddMsg.Checked;
            if (MsgManagementCtrl.SendMsgByIDs(idList, msg, addMsg, ref exception))
            {
                showInformation("发送成功！");
                return;
            }
            else
            {
                showError("发送失败！", exception);
                return;
            }

        }

        /// <summary>
        /// 换页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField();

            Grid1.PageIndex = e.NewPageIndex;

            UpdateSelectedRowIndexArray();

        }

        /// <summary>
        /// 只显示未提交CheckBox事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CheckBox_OnlyShowUnsubmitted_CheckedChanged(object sender, EventArgs e)
        {
            bindStaffInfoToGrid();
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
            bool onlyShowUnsubmitted = CheckBox_OnlyShowUnsubmitted.Checked;
            if (MsgManagementCtrl.GetAll(ref table, onlyShowUnsubmitted, ref exception))
            {
                DataView dv = table.DefaultView;
                dv.Sort = "Role ASC";
                Grid1.DataSource = dv;
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
        /// 从hiddenfield中获取已选择的ID列表
        /// 用于保持跨页选中
        /// </summary>
        /// <returns></returns>
        private List<string> GetSelectedRowIndexArrayFromHiddenField()
        {
            JArray idsArray = new JArray();

            string currentIDS = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentIDS))
            {
                idsArray = JArray.Parse(currentIDS);
            }
            else
            {
                idsArray = new JArray();
            }

            return new List<string>(idsArray.ToObject<string[]>());
        }

        /// <summary>
        /// 同步当前已选择的ID到hiddenfield
        /// 用于保持跨页选中
        /// </summary>
        private void SyncSelectedRowIndexArrayToHiddenField()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            List<int> selectedRows = new List<int>();
            if (Grid1.SelectedRowIndexArray != null && Grid1.SelectedRowIndexArray.Length > 0)
            {
                selectedRows = new List<int>(Grid1.SelectedRowIndexArray);
            }

            int startPageIndex = Grid1.PageIndex * Grid1.PageSize;
            for (int i = startPageIndex, count = Math.Min(startPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
            {
                string id = Grid1.DataKeys[i][0].ToString();
                if (selectedRows.Contains(i - startPageIndex))
                {
                    if (!ids.Contains(id))
                    {
                        ids.Add(id);
                    }
                }
                else
                {
                    if (ids.Contains(id))
                    {
                        ids.Remove(id);
                    }
                }

            }

            hfSelectedIDS.Text = new JArray(ids).ToString(Formatting.None);
        }

        /// <summary>
        /// 将已选择的项目恢复到grid
        /// 用于保持跨页选中
        /// </summary>
        private void UpdateSelectedRowIndexArray()
        {
            List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

            List<int> nextSelectedRowIndexArray = new List<int>();
            int nextStartPageIndex = Grid1.PageIndex * Grid1.PageSize;
            for (int i = nextStartPageIndex, count = Math.Min(nextStartPageIndex + Grid1.PageSize, Grid1.RecordCount); i < count; i++)
            {
                string id = Grid1.DataKeys[i][0].ToString();
                if (ids.Contains(id))
                {
                    nextSelectedRowIndexArray.Add(i - nextStartPageIndex);
                }
            }
            Grid1.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
        }

        #endregion
    }
}