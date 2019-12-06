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
            //connect to the database
            PageDB db = new PageDB();

            //method to list the existing pages
            ListPages(db);
        }

        public void ListPages(PageDB db)
        {
            //get all the pages from the database
            string query = "select * from pages";
            //make a list of all the rows
            List<Dictionary<String, String>> rs = db.List_Query(query);

            //loop for each row in the list
            foreach(Dictionary<String,String> row in rs)
            {
                string pageid = row["pageid"];

                //show the page title on the page and create a link based on pageid to the page
                page_viewer.InnerHtml += "<li><a href=\"ShowPage.aspx?pageid=" + pageid + "\">" + row["pagetitle"] + "</a></li>";
            }
        }
    }
}