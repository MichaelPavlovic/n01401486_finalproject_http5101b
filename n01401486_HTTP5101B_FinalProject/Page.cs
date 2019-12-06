using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace n01401486_HTTP5101B_FinalProject
{
    public class Page
    {
        private string PageTitle;
        private string PageBody;
        private string PageAuthor;
        private string PageCol1;
        private string PageCol2;

        public string GetPageTitle()
        {
            return PageTitle;
        }
        public string GetPageBody()
        {
            return PageBody;
        }
        public string GetPageAuthor()
        {
            return PageAuthor;
        }
        public string GetPageCol1()
        {
            return PageCol1;
        }
        public string GetPageCol2()
        {
            return PageCol2;
        }

        public void SetPageTitle(string value)
        {
            PageTitle = value;
        }
        public void SetPageBody(string value)
        {
            PageBody = value;
        }
        public void SetPageAuthor(string value)
        {
            PageAuthor = value;
        }
        public void SetPageCol1(string value)
        {
            PageCol1 = value;
        }
        public void SetPageCol2(string value)
        {
            PageCol2 = value;
        }
    }
}