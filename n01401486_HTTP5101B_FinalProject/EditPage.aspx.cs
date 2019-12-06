using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01401486_HTTP5101B_FinalProject
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //only show the data when the user visits for the first time
            if (!Page.IsPostBack)
            {
                //connect to database
                PageDB db = new PageDB();
                //method to show data on the page
                ShowPage(db);
            }
        }

        protected void ShowPage(PageDB db)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //if pageid is not null or empty
            if (valid)
            {

                //get page data from the database
                Page page_record = db.FindPage(Int32.Parse(pageid));

                //show data on the page
                page_title.Text = page_record.GetPageTitle();
                page_body.Text = page_record.GetPageBody();
                page_author.Text = page_record.GetPageAuthor();
                page_col1.Text = page_record.GetPageCol1();
                page_col2.Text = page_record.GetPageCol2();
            }
            else
            {
                valid = false;
            }

            //if the page can't be found show an error message
            if (!valid)
            {
                pageinfo.InnerHtml = "There was an error finding that page.";
            }
        }

        protected void Edit_Page(object sender, EventArgs e)
        {
            //connect to database
            PageDB db = new PageDB();

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            //if pagaeid is not null or empty 
            if (valid)
            {
                //make a new page
                Page new_page = new Page();
                
                //set the page data
                new_page.SetPageTitle(page_title.Text);
                new_page.SetPageBody(page_body.Text);
                new_page.SetPageAuthor(page_author.Text);
                new_page.SetPageCol1(page_col1.Text);
                new_page.SetPageCol2(page_col2.Text);

                //try to update the page data in the database
                try
                {
                    db.EditPage(Int32.Parse(pageid), new_page);
                    //redirect back to ListPages
                    Response.Redirect("ListPages.aspx?pageid=" + pageid);
                }
                catch
                {
                    valid = false;
                }

            }
            //show an error message if the page can't be updated
            if (!valid)
            {
                pageinfo.InnerHtml = "There was an error updating that page.";
            }

        }
    }
}