using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                Response.Write("<script>alert('Author with this ID already Exists. You cannot another Author with the same Author ID');</script>");
            }
            else
            {
                AddNewAuthor();
            }
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                UpdateAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist.');</script>");
            }
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                DeleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('Author does not exist.');</script>");
            }
        }

        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetAuthorByID();
        }

        //user defined methods
        void DeleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"delete from author_master_tbl 
                                                  where
                                                  author_id='" + TextBox3.Text.Trim() + "'", con);

                


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author deleted successfully!');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void GetAuthorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Authod ID!');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }

        void UpdateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"update author_master_tbl 
                                                  set
                                                  author_name=@author_name 
                                                  where
                                                  author_id='"+TextBox3.Text.Trim()+"'", con);

                cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author updated successfully!');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void AddNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"insert into author_master_tbl 
                    (author_id,author_name) 
                    values
                    (@a1,@a2)", con);

                cmd.Parameters.AddWithValue("@a1", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@a2", TextBox4.Text.Trim());
                
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added successfully!');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool CheckIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from author_master_tbl where author_id='" + TextBox3.Text.Trim() + "'", con);
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

        void ClearForm()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
    }
}