using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;
using System.IO;
using FineUI;

namespace CES.UI
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            StringBuilder sb = new StringBuilder();
            Random rd = new Random();
            int errorNo = rd.Next();
            sb.AppendLine(DateTime.Now.ToLocalTime().ToString() + "发生内部错误！");
            sb.AppendLine("错误号：" + errorNo);
            sb.AppendLine("内部错误:").Append(ex.InnerException.ToString());
            sb.AppendLine("堆栈:").Append(ex.StackTrace);
            sb.AppendLine("内容:").Append(ex.Message);
            sb.AppendLine("来源:").Append(ex.Source);
            sb.AppendLine();
            writelog(sb.ToString());
            Server.ClearError();
            Server.Transfer(@"..\..\ErrorPage.aspx?errorno=" + errorNo, false);
            //PageContext.Redirect(@"..\..\ErrorPage.aspx?errorno=" + errorNo, "top");
            //Alert.Show("系统发生错误");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        #region Private Method
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="content"></param>
        private void writelog(string content)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"log\UnknowException.log";
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            try
            {
                sw.WriteLine(content);
            }
            catch (Exception)
            {

            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }
        #endregion
    }
}