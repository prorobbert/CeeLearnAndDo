using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

namespace CeeLearnAndDo
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerzenden_Click(object sender, EventArgs e)
        {
            //Code om een mail te versturen met de vraag

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add("ruben_bos40@protonmail.com");
            mail.From = new MailAddress("smoothboardsmailer@gmail.com", tbEmail.Text, System.Text.Encoding.UTF8);
            mail.Subject = "CeeLearnAndDo vraag";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = " Time: " + DateTime.Now.ToString("h:mm:ss tt") + "Van: " + tbName.Text + "Vraag: " + tbVraag.Text;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("smoothboardsmailer@gmail.com", "MyPassword123");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch
            {

                Response.Write("RIP, everything fails today, i wanted to send myself a mail with what just happend but even that part failed :'(");
            }
        }
    }
}