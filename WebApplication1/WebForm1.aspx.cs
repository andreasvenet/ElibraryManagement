using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitForm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SendMail();
            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }
        //mail method
        void SendMail()
        {
            MailMessage msg = new MailMessage("fromMail", "toMail");

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("fromMail", "toMail");
            

            msg.Subject = "eLibraryManagement";
            msg.Body = "Account created Successfully!";
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }
    }
}