using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectHTTP5101
{
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                MyWordpressDB db = new MyWordpressDB();
                ShowPageInfo(db);
            }
        }
        protected void Update_Page(object sender, EventArgs e)
        {

            MyWordpressDB db = new MyWordpressDB();

            bool valid = true;
            string pageid = Request.QueryString["pageid"];
            if (String.IsNullOrEmpty(pageid)) valid = false;
            if (valid)
            {
                HTTP_Page new_page = new HTTP_Page();
                new_page.SetPtitle(page_title.Text);
                new_page.SetPbody(page_body.Text);

                try
                {
                    db.UpdatePage(Int32.Parse(pageid), new_page);
                    Response.Redirect("ShowPage.aspx?pageid=" + pageid);
                }
                catch
                {
                    valid = false;
                }

            }

            if (!valid)
            {
                http_page.InnerHtml = "There was an error updating that page.";
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
                page_title_main.InnerHtml = page_record.GetPtitle();
                page_title.Text = page_record.GetPtitle();
                page_body.Text = page_record.GetPbody();

            }

            if (!valid)
            {
                http_page.InnerHtml = "There was an error finding that page.";
            }
        }
    }
}