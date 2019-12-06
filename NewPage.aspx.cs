using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectHTTP5101
{
    public partial class NewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add_Page(object sender, EventArgs e)
        {
            //create connection
            MyWordpressDB db = new MyWordpressDB();


            HTTP_Page new_page = new HTTP_Page();

            new_page.SetPtitle(page_title.Text);
            new_page.SetPbody(page_body.Text);



            db.AddPage(new_page);


            Response.Redirect("ListPages.aspx");
        }
    }
}