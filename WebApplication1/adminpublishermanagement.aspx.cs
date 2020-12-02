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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //add button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                Response.Write("<script>alert('Publisher ID already exists. You cannot add publishers with the same ID');</script>");
                ClearForm();
            }
            else
            {
                AddNewPublisher();
            }
        }

        //update button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                UpdatePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher ID does not exist!');</script>");
            }
        }

        //delete button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                DeletePublisher();
            }
            else
            {
                Response.Write("<script>alert('Publisher ID does not exist!');</script>");
            }
        }
        //go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetPublisherByID();
        }

        //user defined methods
        bool CheckIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "'", con);
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

        void AddNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"insert into publisher_master_tbl 
                    (publisher_id,publisher_name) 
                    values
                    (@a1,@a2)", con);

                cmd.Parameters.AddWithValue("@a1", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@a2", TextBox4.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher added successfully!');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void UpdatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"update publisher_master_tbl 
                                                  set
                                                  publisher_name=@publisher_name 
                                                  where
                                                  publisher_id='" + TextBox3.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher updated successfully!');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void DeletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"delete from publisher_master_tbl 
                                                  where
                                                  publisher_id='" + TextBox3.Text.Trim() + "'", con);




                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Publisher deleted successfully!');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void GetPublisherByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from publisher_master_tbl where publisher_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID!');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void ClearForm()
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
        }

    }
}