using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    string salt = dt.Rows[0]["salt"].ToString();
                    string pwd = TextBox2.Text.Trim() + salt;
                    pwd = ComputeHash(pwd);

                    cmd = new SqlCommand("select * from member_master_tbl where member_id='" + TextBox1.Text.Trim() + "' and password='" + pwd + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Response.Write("<script>alert('Login Successful!');</script>");
                            Session["username"] = dr.GetValue(0).ToString();
                            Session["fullname"] = dr.GetValue(1).ToString();
                            Session["role"] = "user";
                            Session["status"] = dr.GetValue(10).ToString();
                        }
                        Response.Redirect("homepage.aspx");
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
                //Response.Write("<script>alert('Button Click');</script>");
            }
        }
        

        string ComputeHash(string pwd)
        {
            HashAlgorithm alg = new SHA256CryptoServiceProvider();
            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(pwd);
            byte[] byteHash = alg.ComputeHash(byteValue);
            pwd = Convert.ToBase64String(byteHash);

            return pwd;

        }
    }
}