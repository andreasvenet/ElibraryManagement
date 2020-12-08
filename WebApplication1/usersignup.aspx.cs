using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace WebApplication1
{
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        // When the sign up button is clicked
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (CheckMemberExists())
                {
                    Response.Write("<script>alert('Member already exists with this Member ID, please try another Member ID');</script>");
                }
                else
                {
                    SignUpNewUser();
                }
            }
        }

        //user defined method
        bool CheckMemberExists()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"select * from member_master_tbl 
                                              where
                                              member_id='" + TextBox1.Text.Trim() + "';", con);
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

        //user defined method
        void SignUpNewUser()
        {
            //Response.Write("<script>alert('Testing');</script>");
            string pwd = TextBox9.Text.Trim();
            string salt = CreateSalt(pwd.Length);
            pwd += salt;
            pwd = ComputeHash(pwd);
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand(@"insert into member_master_tbl 
                    (full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status,salt) 
                    values
                    (@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status,@salt)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@salt", salt);
                cmd.Parameters.AddWithValue("@password", pwd);
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        //salt method
        string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rand.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        // hash method
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