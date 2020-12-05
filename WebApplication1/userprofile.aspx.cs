﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication1
{
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired. Please Login Again.');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                    GetUserBookData();
                    if (!Page.IsPostBack)
                    {
                        GetUserByID();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired. Please Login Again.');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }
        //gridview event
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //check if return time has exceeded today
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                throw;
            }
        }
        //update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"].ToString() == "" || Session["username"] == null)
                {
                    Response.Write("<script>alert('Session Expired. Please Login Again.');</script>");
                    Response.Redirect("userlogin.aspx");
                }
                else
                {
                   
                    UpdateUserByID();
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired. Please Login Again.');</script>");
                Response.Redirect("userlogin.aspx");
            }
        }

        //user defined methods

        void UpdateUserByID()
        {
            string password = "";
            if (TextBox10.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox10.Text.Trim();
            }

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand(@"update member_master_tbl set
                                 full_name=@full_name, dob=@dob, contact_no=@contact_no,
                                 email=@email, state=@state, city=@city, pincode=@pincode,
                                 full_address=@full_address, password=@password, account_status=@account_status
                                 where member_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@full_name",TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Details Updated Successfully!');</script>");
                    GetUserByID();
                    GetUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Entry!');</script>");
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void GetUserByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox3.Text = dt.Rows[0]["full_name"].ToString();
                TextBox4.Text = dt.Rows[0]["dob"].ToString();
                TextBox5.Text = dt.Rows[0]["contact_no"].ToString();
                TextBox6.Text = dt.Rows[0]["email"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                TextBox2.Text = dt.Rows[0]["city"].ToString();
                TextBox7.Text = dt.Rows[0]["pincode"].ToString();
                TextBox8.Text = dt.Rows[0]["full_address"].ToString();
                TextBox1.Text = dt.Rows[0]["member_id"].ToString();
                TextBox9.Text = dt.Rows[0]["password"].ToString();

                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "inactive")
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-danger");
                }
                else 
                {
                    Label1.Attributes.Add("class", "badge badge-pill badge-secondary");
                }
                


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void GetUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tbl where member_id='" + Session["username"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        

        
    }
}