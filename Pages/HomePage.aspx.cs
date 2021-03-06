﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using FineUI;
using System.Xml;
using CES.DataStructure;

namespace CES.UI
{
    public partial class HomePage : PageBase
    {
        #region Page_Init
        protected new void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
            // 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
            JObject ids = GetClientIDS(mainTabStrip);

            //从Session中读取UserID和UserType
            try
            {
                string userID = Session["UserID"].ToString();
                UserType userType = (UserType)Session["UserType"];

                Accordion accordionMenu = InitAccordionMenu(userID, userType);
                ids.Add("mainMenu", accordionMenu.ClientID);
                ids.Add("menuType", "accordion");
            }
            catch (Exception)
            { 
                
            }


            // 只在页面第一次加载时注册客户端用到的脚本
            if (!Page.IsPostBack)
            {
                string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
                PageContext.RegisterStartupScript(idsScriptStr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID">用户名</param>
        /// <returns></returns>
        private Accordion InitAccordionMenu(string userID, UserType userType)
        {
            Accordion accordionMenu = new Accordion();
            accordionMenu.ID = "accordionMenu";
            accordionMenu.EnableFill = true;
            accordionMenu.ShowBorder = false;
            accordionMenu.ShowHeader = false;
            Region2.Items.Add(accordionMenu);


            XmlDocument xmlDoc = new XmlDocument();
            switch (userType)
            {
                case UserType.SUPER:
                    xmlDoc = XmlDataSource_Super.GetXmlDocument();
                    break;
                case UserType.MANAGER:
                    xmlDoc = XmlDataSource_Manager.GetXmlDocument();
                    break;
                case UserType.EVALUATOR:
                    xmlDoc = XmlDataSource_Evaluator.GetXmlDocument();
                    break;
                case UserType.EVALUATED:
                    xmlDoc = XmlDataSource_Evaluated.GetXmlDocument();
                    break;
            }
            XmlNodeList xmlNodes = xmlDoc.SelectNodes("/Tree/TreeNode");
            foreach (XmlNode xmlNode in xmlNodes)
            {
                if (xmlNode.HasChildNodes)
                {
                    AccordionPane accordionPane = new AccordionPane();
                    accordionPane.Title = xmlNode.Attributes["Text"].Value;
                    accordionPane.Layout = Layout.Fit;
                    accordionPane.ShowBorder = false;
                    accordionPane.BodyPadding = "2px 0 0 0";
                    accordionMenu.Items.Add(accordionPane);

                    Tree innerTree = new Tree();
                    innerTree.EnableArrows = true;
                    innerTree.ShowBorder = false;
                    innerTree.ShowHeader = false;
                    innerTree.EnableIcons = false;
                    innerTree.AutoScroll = true;
                    accordionPane.Items.Add(innerTree);

                    //将xml文件地址中的占位符换成真实的UserID
                    XmlDocument innerXmlDoc = new XmlDocument();
                    innerXmlDoc.LoadXml(String.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><Tree>{0}</Tree>", xmlNode.InnerXml.Replace("[UserID]", userID)));

                    // 绑定AccordionPane内部的树控件
                    innerTree.DataSource = innerXmlDoc;
                    innerTree.DataBind();

                    // 重新设置每个节点的图标
                    ResolveTreeNode(innerTree.Nodes);
                }
            }

            return accordionMenu;

        }

        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }

            return jo;
        }
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (!checkSession()) //检查Session
                //{
                //    PageContext.Redirect("../Login.aspx", "top");
                //    return;
                //}
                if (Session["UserName"] != null)
                {
                    UserName.Text += Session["UserName"].ToString(); 
                }
            }
        }
        #endregion

        #region Event
        public void LoginOut_Click(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["UserType"] = null;
            Response.Redirect("../Login.aspx");
        }

        private string GetSelectedMenuID(MenuButton menuButton)
        {
            foreach (FineUI.MenuItem item in menuButton.Menu.Items)
            {
                if (item is MenuCheckBox && (item as MenuCheckBox).Checked)
                {
                    return item.ID;
                }
            }
            return null;
        }

        private void SetSelectedMenuID(MenuButton menuButton, string selectedMenuID)
        {
            foreach (FineUI.MenuItem item in menuButton.Menu.Items)
            {
                MenuCheckBox menu = (item as MenuCheckBox);
                if (menu != null && menu.ID == selectedMenuID)
                {
                    menu.Checked = true;
                }
                else
                {
                    menu.Checked = false;
                }
            }
        }


        private void SaveToCookieAndRefresh(string cookieName, string cookieValue)
        {
            HttpCookie cookie = new HttpCookie(cookieName, cookieValue);
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);

            PageContext.Refresh();
        }


        #endregion

        #region Tree
        /// <summary>
        /// 重新设置每个节点的图标
        /// </summary>
        /// <param name="nodes"></param>
        private void ResolveTreeNode(FineUI.TreeNodeCollection nodes)
        {
            foreach (FineUI.TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    if (!String.IsNullOrEmpty(node.NavigateUrl))
                    {
                        node.IconUrl = GetIconForTreeNode(node.NavigateUrl);
                    }
                }
                else
                {
                    ResolveTreeNode(node.Nodes);
                }
            }
        }

        /// <summary>
        /// 根据链接地址返回相应的图标
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetIconForTreeNode(string url)
        {
            string iconUrl = "~/images/filetype/vs_unknow.png";
            url = url.ToLower();
            int lastDotIndex = url.LastIndexOf('.');
            string fileType = url.Substring(lastDotIndex + 1);
            if (fileType == "txt")
            {
                iconUrl = "~/images/filetype/vs_txt.png";
            }
            else if (fileType == "htm" || fileType == "html")
            {
                iconUrl = "~/images/filetype/vs_htm.png";
            }
            else
            {
                iconUrl = "~/images/filetype/vs_aspx.png";
            }

            return iconUrl;
        }

        #endregion
        /// <summary>
        /// 检查Session，如果session没问题，则返回true，否则返回false
        /// </summary>
        /// <returns></returns>
        #region Private Method
        private bool checkSession()
        {
            if (Session["UserID"] == null || Session["UserName"] == null || Session["UserType"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}