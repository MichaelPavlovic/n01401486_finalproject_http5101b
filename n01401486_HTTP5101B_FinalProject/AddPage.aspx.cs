using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace n01401486_HTTP5101B_FinalProject
{
    public partial class AddPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Page(object sender, EventArgs e)
        {
            //connect to database
            PageDB db = new PageDB();

            //make a new page
            Page new_page = new Page();

            //set the new page data
            new_page.SetPageTitle(page_title.Text);
            new_page.SetPageBody(page_body.Text);
            new_page.SetPageAuthor(page_author.Text);
            new_page.SetPageCol1(page_col1.Text);
            new_page.SetPageCol2(page_col2.Text);

            //add page to the database
            db.AddPage(new_page);
            
            //redirect back to ListPages
            Response.Redirect("ListPages.aspx");
        }
    }
}