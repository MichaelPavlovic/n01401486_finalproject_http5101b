using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01401486_HTTP5101B_FinalProject
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageDB db = new PageDB();

            ShowPageInfo(db);
        }

        protected void ShowPageInfo(PageDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {

                Page page_record = db.FindPage(Int32.Parse(pageid));


                page_title.InnerHtml = page_record.GetPageTitle();
                page_body.InnerHtml = page_record.GetPageBody();
                page_author.InnerHtml = page_record.GetPageAuthor();
                page_col1.InnerHtml = page_record.GetPageCol1();
                page_col2.InnerHtml = page_record.GetPageCol2();
            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                pageinfo.InnerHtml = "There was an error finding that page.";
            }
        }
    }
}