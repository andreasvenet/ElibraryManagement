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
    public partial class adminusermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //go button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            GetMemberByID();
        }

        //Active button
        protected void Button4_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("active");
        }

        //Pending button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("pending");
        }

        //Inactive button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusByID("inactive"); 
        }

        //Delete user button
        protected void Button2_Click(object sender, EventArgs e)
        {
            DeleteMemberByID();
        }

        //user defined methods
        void GetMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox4.Text = dr.GetValue(1).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox8.Text = dr.GetValue(2).ToString();
                        TextBox1.Text = dr.GetValue(3).ToString();
                        TextBox2.Text = dr.GetValue(4).ToString();
                        TextBox9.Text = dr.GetValue(5).ToString();
                        TextBox10.Text = dr.GetValue(6).ToString();
                        TextBox11.Text = dr.GetValue(7).ToString();
                        TextBox6.Text = dr.GetValue(8).ToString();

                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void UpdateMemberStatusByID(string status)
        {
            if (CheckIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("update member_master_tbl set account_status='" + status + "' where member_id='" + TextBox3.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member status updated!');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!');</script>");
            }
            
        }

        void DeleteMemberByID()
        {
            if (CheckIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand(@"delete from member_master_tbl 
                                                  where
                                                  member_id='" + TextBox3.Text.Trim() + "'", con);




                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member deleted successfully!');</script>");
                    ClearForm();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!');</script>");
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
                SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox3.Text.Trim() + "'", con);
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
            TextBox4.Text = "";
            TextBox4.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox6.Text = "";
        }
    }
}
