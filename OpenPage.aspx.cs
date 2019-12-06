using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectHTTP5101
{
    public partial class OpenPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyWordpressDB db = new MyWordpressDB();

            ShowPageInfo(db);

            if (!Page.IsPostBack)
            {

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

                
                customtitle.Text += page_record.GetPtitle();
                custom_page_main_heading.InnerHtml += page_record.GetPtitle();
                custombody.InnerHtml += page_record.GetPbody();

            }
            else
            {
                valid = false;
            }


            if (!valid)
            {
                custombody.InnerHtml = "There was an error finding that page.";
            }
        }

    }
}