using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace n01401486_HTTP5101B_FinalProject
{
    public class PageDB
    {
        //reference:

        //info to connect to database
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "page"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //
        protected static string ConnectionString
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
                
                Connect.Open();
                
                MySqlCommand cmd = new MySqlCommand(query, Connect);

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

        public void AddPage(Page new_page)
        {

            string query = "insert into pages (pagetitle, pagebody, author, pagecol1, pagecol2) values ('{0}','{1}','{2}','{3}','{4}')";
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageBody(), new_page.GetPageAuthor(), new_page.GetPageCol1(), new_page.GetPageCol2());

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

        public void DeletePage(int pageid)
        {
            
            string query = "delete from pages where pageid = {0}";
            query = String.Format(query, pageid);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the DeletePage Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

        public Page FindPage(int id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            Page result_page = new Page();

            try
            {
                
                string query = "select * from pages where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                
                Connect.Open();
                
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                
                MySqlDataReader resultset = cmd.ExecuteReader();

                
                List<Page> pages = new List<Page>();

                while (resultset.Read())
                {
                    Page currentpage = new Page();

                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);

                        switch (key)
                        {
                            case "pagetitle":
                                currentpage.SetPageTitle(value);
                                break;
                            case "pagebody":
                                currentpage.SetPageBody(value);
                                break;
                            case "author":
                                currentpage.SetPageAuthor(value);
                                break;
                            case "pagecol1":
                                currentpage.SetPageCol1(value);
                                break;
                            case "pagecol2":
                                currentpage.SetPageCol2(value);
                                break;
                        }

                    }
                    
                    pages.Add(currentpage);
                }

                result_page = pages[0];

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the FindPage method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }

        public void EditPage(int pageid, Page new_page)
        {
            string query = "update pages set pagetitle='{0}', pagebody='{1}', author='{2}', pagecol1='{3}', pagecol2='{4}' where pageid={5}";
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageBody(), new_page.GetPageAuthor(), new_page.GetPageCol1(), new_page.GetPageCol2(), pageid);

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
                Debug.WriteLine("Something went wrong in the EditPage method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
    }
}