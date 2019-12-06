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
        //reference: Based off of SCHOOLDB and Controller classes provided by Christine Bittle https://github.com/christinebittle/crud_essentials

        //info to connect to database
        private static string User { get { return "root"; } } //username
        private static string Password { get { return "root"; } } //password
        private static string Database { get { return "page"; } } //database name
        private static string Server { get { return "localhost"; } } //connection url
        private static string Port { get { return "3306"; } } //connection port

        //ConnectionString is used to connect to a database
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

        //returns a result set of a list of dictionaries
        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

            List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();

            try
            {
                //output debugging lines to console
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);
                
                //open db connection
                Connect.Open();
                //give connection a query
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                //get resultset
                MySqlDataReader resultset = cmd.ExecuteReader();

                //loop for every row in the resultset
                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();
                    
                    //loop for every column in the row
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
                //output execption thrown to the console
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());
            }

            //close db connection
            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        public void AddPage(Page new_page)
        {
            //one method of injecting data into a string NOTE: sensitive to SQL injection
            string query = "insert into pages (pagetitle, pagebody, author, pagecol1, pagecol2) values ('{0}','{1}','{2}','{3}','{4}')";
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageBody(), new_page.GetPageAuthor(), new_page.GetPageCol1(), new_page.GetPageCol2());

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                //open db connection and execute 
                Connect.Open();
                //for executing queries that don't return data, returns number of rows affected
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the AddPage Method!");
                Debug.WriteLine(ex.ToString());
            }

            //close db connection
            Connect.Close();
        }

        public void DeletePage(int pageid)
        {
            //delete a specific page
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
            //make a blank page so the method can return something if page data can not be found
            Page result_page = new Page();

            try
            {
                //add passed in parameter to the query
                string query = "select * from pages where pageid = " + id;
                Debug.WriteLine("Connection Initialized...");
                
                Connect.Open();
                
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                
                MySqlDataReader resultset = cmd.ExecuteReader();

                //list of pages
                List<Page> pages = new List<Page>();

                //loop through each row in the result set
                while (resultset.Read())
                {
                    Page currentpage = new Page();

                    //loop for each column in a row
                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);

                        //go through each column to insert data into the right property
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
                    //add page to list
                    pages.Add(currentpage);
                }
                //get the first page
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
            //similar to addpage method but update is used in the query to update the data instead of insert into
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