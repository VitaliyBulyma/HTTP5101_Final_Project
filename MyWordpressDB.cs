using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace FinalProjectHTTP5101
{
    public class MyWordpressDB
    {

        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "mywordpress"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "8889"; } }


        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }


        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);


            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();


            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                //open the db connection
                Connect.Open();
                //give the connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //grab the result set
                MySqlDataReader resultset = cmd.ExecuteReader();
                                              
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                   
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }


        public HTTP_Page FindPage(int id)
        {

            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            HTTP_Page result_page = new HTTP_Page();


            try
            {

                string query = "select * from page_info where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                
                Connect.Open();
                
                MySqlCommand cmd = new MySqlCommand(query, Connect);
               
                MySqlDataReader resultset = cmd.ExecuteReader();


                List<HTTP_Page> pages = new List<HTTP_Page>();

                
                while (resultset.Read())
                {

                    HTTP_Page currentpage = new HTTP_Page();


                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);

                        switch (key)
                        {
                            case "pagetitle":
                                currentpage.SetPtitle(value);
                                break;
                            case "pagebody":
                                currentpage.SetPbody(value);
                                break;

                        }

                    }

                    pages.Add(currentpage);
                }

                result_page = pages[0];

            }
            catch (Exception ex)
            {

                Debug.WriteLine("Something went wrong in the find Page method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }


        public void AddPage(HTTP_Page new_page)
        {


            string query = "insert into page_info (pagetitle, pagebody) values ('{0}','{1}')";
            query = String.Format(query, new_page.GetPtitle(), new_page.GetPbody());



            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddPage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }


        public void UpdatePage(int pageid, HTTP_Page new_page)
        {

            string query = "update page_info set pagetitle='{0}', pagebody='{1}' where pageid={2}";
            query = String.Format(query, new_page.GetPtitle(), new_page.GetPbody(), pageid);


            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {

                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Something went wrong in the UpdatePage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public void DeletePage(int pageid)
        {


            string removepage = "delete from page_info where pageid = {0}";
            removepage = String.Format(removepage, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            MySqlCommand cmd_removepage = new MySqlCommand(removepage, Connect);
            try
            {

                Connect.Open();

                cmd_removepage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removepage);
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Something went wrong in the delete Page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }



    }
}