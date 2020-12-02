﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetNames();
        }

        //issue button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists() && CheckIfMemberExists())
            {

            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID or Member ID!');</script>");

            }
        }

        //return button
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        //user defined methods

        void IssueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"insert into book_issue_tbl 
                    (member_id,member_name,book_id,book_name,issue_date,due_date) 
                    values
                    (@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());
                

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update book_master_tbl set current_stock=current_stock-1 where book_id='"+TextBox3.Text.Trim()+"'", con);


                con.Close();
                Response.Write("<script>alert('Book Issued successfully!');</script>");
                
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool CheckIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master_tbl where book_id='" + TextBox3.Text.Trim() + "' and current_stock>0'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        bool CheckIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from member_master_tbl where member_id='" + TextBox4.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void GetNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from book_master_tbl where book_id='"+TextBox3.Text.Trim()+"'",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >=1)
                {
                    TextBox2.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID!');</script>");
                }

                cmd = new SqlCommand("select full_name from member_master_tbl where member_id='" + TextBox4.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Member ID!');</script>");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}