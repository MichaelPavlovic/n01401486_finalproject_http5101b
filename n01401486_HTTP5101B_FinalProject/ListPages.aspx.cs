using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01401486_HTTP5101B_FinalProject
{
    public partial class ListPages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string query = "select * from pages";

            var db = new PageDB();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach(Dictionary<String,String> row in rs)
            {
                //start table row
                results.InnerHtml += "<div class=\"table-row\">";

                string pageID = row["pageid"];

                //table cells
                string pagetitle = row["pagetitle"];          
                results.InnerHtml += "<div class=\"table-cell\">" + pagetitle + "</div>";

                string pageauthor = row["author"];
                results.InnerHtml += "<div class=\"table-cell\">" + pageauthor + "</div>";

                //put links into one cell
                results.InnerHtml += "<div class=\"table-cell\">";
                //links to be styled as buttons
                results.InnerHtml += "<div class=\"button\"><a href=\"EditPage.aspx?pageid=" + pageID + "\">Edit</a></div>";
                results.InnerHtml += "<div class=\"button\"><a href=\"DeletePage.aspx?pageid=" + pageID + "\">Delete</a></div>";
                //close table cell
                results.InnerHtml += "</div>";

                //close table row
                results.InnerHtml += "</div>";
            }
        }
    }
}