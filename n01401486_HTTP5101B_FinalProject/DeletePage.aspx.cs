using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01401486_HTTP5101B_FinalProject
{
    public partial class DeletePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageDB db = new PageDB();

            ShowPage(db);
        }

        protected void ShowPage(PageDB db)
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

        protected void Delete_Page(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            PageDB db = new PageDB();

            if (valid)
            {
                db.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }
        }
    }
}