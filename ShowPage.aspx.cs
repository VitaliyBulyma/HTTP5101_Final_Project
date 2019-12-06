using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectHTTP5101
{
    public partial class ShowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyWordpressDB db = new MyWordpressDB();

            ShowPageInfo(db);

            if (!Page.IsPostBack)
            {

            }
        }
        protected void Delete_Page(object sender, EventArgs e)
        {
            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            MyWordpressDB db = new MyWordpressDB();

            if (valid)
            {
                db.DeletePage(Int32.Parse(pageid));
                Response.Redirect("ListPages.aspx");
            }
        }
        protected void ShowPageInfo(MyWordpressDB db)
        {

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;

            if (valid)
            {

                HTTP_Page page_record = db.FindPage(Int32.Parse(pageid));

               
                page_title.InnerHtml = page_record.GetPtitle();
                page_body.InnerHtml = page_record.GetPbody();

            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                http_page.InnerHtml = "There was an error finding that page.";
            }
        }


    }
}