using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectHTTP5101
{
    public partial class Navigation : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            navigation.InnerHtml = "";
            MyWordpressDB db = new MyWordpressDB();
            ListNavigation(db);
        }
        protected void ListNavigation(MyWordpressDB db)
        {

            string query = "select pageid, pagetitle from page_info";
            List<Dictionary<String, String>> rs = db.List_Query(query);

            foreach (Dictionary<String, String> row in rs)
            {
                string pageid = row["pageid"];
                string pagetitle = row["pagetitle"];
                navigation.InnerHtml += "<li> <a target=\"_blank\" href=\"OpenPage.aspx?pageid=" + pageid + "\"> " + pagetitle + " </a></li>";



            }
        }
    }
}