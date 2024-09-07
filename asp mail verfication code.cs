using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Default : System.Web.UI.Page
    {
        public String randomcode;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody, to;
            Random random = new Random();
            randomcode = (random.Next(999999)).ToString();
            Session["randomcode"] = randomcode;
            MailMessage message = new MailMessage();
            to = (TextBox1.Text).ToString();
            from = "kalaivanan7787@gmail.com";
            pass = "zwxy kipi rgma gydf";
            messageBody = "Your OTP Verification Code : " + randomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Employee Management Verification";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                Response.Write("<script>alert('OTP Sended Success')</script>");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["randomcode"] .ToString()== (TextBox2.Text).ToString())
            {
                Response.Write("<script>alert('OTP Verified Successfully')</script>");
            }
            else
            {
                Response.Write("<script>alert('Invalid OTP')</script>");
            }
        }
    }
}