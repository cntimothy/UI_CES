using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Web.Script.Serialization;
using System.IO;
using CES.Controller;
using CES.DataStructure;
using System.Data;

namespace CES.UI.Pages.StaffManagement
{
    public partial class UploadStaffInfo : PageBase
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
        /// 选择上传文件事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FileUpload_ExcelFile_FileSelected(object sender, EventArgs e)
        {
            if (FileUpload_ExcelFile.HasFile)
            {
                string fileName = FileUpload_ExcelFile.ShortFileName;

                if (!fileName.EndsWith(".xls"))
                {
                    Button_Submit.Enabled = false;
                    Label_FileName.Text = "";
                    FileUpload_ExcelFile.Reset();
                    //Alert.Show("无效的文件！", MessageBoxIcon.Error);
                    showError("无效的文件！", "您选择的不是Excel文件");
                    return;
                }

                Label_FileName.Text = fileName;
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;
                ViewState["filename"] = fileName;

                FileUpload_ExcelFile.SaveAs(Server.MapPath("~/upload/" + fileName));


                Button_Submit.Enabled = true;
                // 清空文件上传组件
                FileUpload_ExcelFile.Reset();
            }
        }

        /// <summary>
        /// 开始上传事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            string exception = "";
            string fileName = Server.MapPath("../../upload/" + ViewState["filename"].ToString());
            int createCount = 0, updateCount = 0;   //新增数量和更新数量
            if (StaffManagementCtrl.InportExcel(fileName, ref createCount, ref updateCount, ref exception))
            {
                FileUpload_ExcelFile.Reset();
                string message = "上传成功！新增" + createCount + "条记录，更新" + updateCount + "条记录。";
                showInformation(message);
                bindStaffInfoToGrid();
            }
            else
            {
                FileUpload_ExcelFile.Reset();
                showError("上传失败！", exception);
            }
        }

        /// <summary>
        /// 下载模板事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_DownloadTemplate_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.ContentType = "application/x-zip-compressed";
            Response.AddHeader("content-disposition", "attachment;filename=" + Server.UrlEncode("人员信息模板.zip"));
            string path = Server.MapPath(@"..\..\downloadfiles\template\人员信息模板.zip");
            FileInfo fi = new FileInfo(path);
            Response.AddHeader("Content_Length", fi.Length.ToString());
            Response.Filter.Close();
            Response.WriteFile(fi.FullName);
            Response.End();
        }

        /// <summary>
        /// 换页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grid1_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            syncSelectedRowIndexArrayToHiddenField();

            Grid1.PageIndex = e.NewPageIndex;

            updateSelectedRowIndexArray();

        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            syncSelectedRowIndexArrayToHiddenField();   //同步所选到hidden field
            string exception = "";
            string s = hfSelectedIDS.Text.Trim().TrimStart('[').TrimEnd(']');
            if (s == "")
            {
                //Alert.ShowInTop("请至少选择一项！", MessageBoxIcon.Information);
                showInformation("请至少选择一项！");
                return;
            }
            List<string> IDs = new List<string>();
            string[] tempIDs = s.Split(',');
            foreach (string item in tempIDs)
            {
                IDs.Add(item.Trim('"'));
            }
            if (StaffManagementCtrl.DeleteByIDs(IDs, ref exception))
            {
                showInformation("删除成功！");
                hfSelectedIDS.Text = "";
                bindStaffInfoToGrid();
            }
            else
            {
                showError("删除失败！", exception);
            }
        }

        /// <summary>
        /// 下拉列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DropDownList_StaffType_SelectedChanged(object sender, EventArgs e)
        {
            bindStaffInfoToGrid();
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window_Update_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            bindStaffInfoToGrid();
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 绑定人员信息到Grid
        /// </summary>
        private void bindStaffInfoToGrid()
        {
            string exception = "";
            DataTable table = new DataTable();
            StaffType staffType = (StaffType)Enum.Parse(typeof(StaffType), DropDownList_StaffType.SelectedValue);
            if (StaffManagementCtrl.GetAll(ref table, staffType, ref exception))
            {
                DataRow[] drs = new DataRow[table.Rows.Count];
                table.Rows.CopyTo(drs, 0);
                DataRow[] dr1 = table.Select("Role like '%领导%'");
                dr1.CopyTo(drs, 0);
                DataRow[] dr2 = table.Select("Role like '%中层干部%'");
                dr2.CopyTo(drs, dr1.Count());
                DataRow[] dr3 = table.Select("Role like '%群众%'");
                dr3.CopyTo(drs, dr1.Count()+dr2.Count());

                DataTable dt = table.Clone();
                dt.Clear();
                foreach (DataRow dr in drs)
                {
                    dt.ImportRow(dr);
                }

                DataView dv = dt.DefaultView;
                //dv.Sort = "Role ASC";                
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
            clearHiddenField();
        }

        /// <summary>
        /// 从HiddenField同步已选择的项，用于保持跨页选中
        /// </summary>
        /// <returns></returns>
        private List<string> getSelectedRowIndexArrayFromHiddenField()
        {
            List<string> ids = new List<string>();
            string currentids = hfSelectedIDS.Text.Trim();
            if (!String.IsNullOrEmpty(currentids))
            {
                try
                {
                    ids = (new JavaScriptSerializer()).Deserialize<List<string>>(currentids);
                }
                catch (Exception)
                {
                    //Alert.ShowInTop("内部错误！\n错误原因：Json反序列化错误", MessageBoxIcon.Error);
                    showError("内部错误！", "Json反序列化错误");
                    return null;
                }
            }

            return ids;
        }

        /// <summary>
        /// 向HiddenField同步已选择的项，用于保持跨页选中
        /// </summary>
        private void syncSelectedRowIndexArrayToHiddenField()
        {
            List<string> ids = getSelectedRowIndexArrayFromHiddenField();
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

            hfSelectedIDS.Text = (new JavaScriptSerializer()).Serialize(ids);
        }

        /// <summary>
        /// 更新已选择项，用于保持跨页选中
        /// </summary>
        private void updateSelectedRowIndexArray()
        {
            List<string> ids = getSelectedRowIndexArrayFromHiddenField();

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

        /// <summary>
        /// 清除HiddenField
        /// </summary>
        private void clearHiddenField()
        {
            hfSelectedIDS.Text = "";
        }
        #endregion
    }
}