using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01401486_HTTP5101B_FinalProject
{
    public partial class ViewPages : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageDB db = new PageDB();
            ListPages(db);
        }

        public void ListPages(PageDB db)
        {
            string query = "select * from pages";
            List<Dictionary<String, String>> rs = db.List_Query(query);

            foreach(Dictionary<String,String> row in rs)
            {

                string pageid = row["pageid"];

                page_viewer.InnerHtml += "<li><a href=\"ShowPage.aspx?pageid=" + pageid + "\">" + row["pagetitle"] + "</a></li>";
            }
        }
    }
}