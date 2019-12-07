using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectHTTP5101
{
    public partial class ListPages : System.Web.UI.Page
    {

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
        protected void Page_Load(object sender, EventArgs e)
        {

            pages_result.InnerHtml = "";

            string searchkey = "";
            if (Page.IsPostBack)
            {

                searchkey = page_search.Text;
            }


            string query = "select * from page_info";

            if (searchkey != "")
            {
                query += " WHERE pagetitle like '%" + searchkey + "%' ";
                query += " or pagebody like '%" + searchkey + "%' ";

            }
            //sql_debugger.InnerHtml = query;

            var db = new MyWordpressDB();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                pages_result.InnerHtml += "<div class=\"listitem\">";

                string pageid = row["pageid"];

                string custom_pagetitle = row["pagetitle"];
                pages_result.InnerHtml += "<div class=\"col5\"> " + custom_pagetitle + " </div>";

                string custom_pagebody = row["pagebody"];
                pages_result.InnerHtml += "<div class=\"col5\">" + custom_pagebody + "</div>";

                pages_result.InnerHtml += "<div class=\"col5\"><a class=\"right\" target=\"_blank\" href=\"OpenPage.aspx?pageid=" + pageid + "\">Open</a></div>";

                pages_result.InnerHtml += "<div class=\"col5\"><a href=\"ShowPage.aspx?pageid=" + pageid + "\">Edit/Delete</a></div>";


                pages_result.InnerHtml += "<div class=\"col5last\"><a class=\"right\" href=\"UpdatePage.aspx?pageid=" + pageid + "\">Update</a></div>";



                pages_result.InnerHtml += "</div>";
            }


        }

    }
}