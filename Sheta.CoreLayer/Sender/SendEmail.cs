using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;
using Sheta.CoreLayer.Convertor;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Generator;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Sender
{
    public class SendEmail
    {
        BodyBuilder builder = new BodyBuilder();

        #region sendemai;
        public void Send(User user,string subject,string BodyText)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("SHETAweb", "amirsh137751@gmail.com"));
                message.To.Add(new MailboxAddress(user.UserName, user.Email));
                message.Subject = subject;

                body(user,BodyText);
                message.Body = builder.ToMessageBody();

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {

                    client.Connect("smtp.gmail.com", 587, false);

                    //SMTP server authentication if needed
                    client.Authenticate("shetawebinfo@gmail.com", "amir1272801128");

                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region body
        public void body(User user,string text)
        {
            // Set the html version of the message text
            builder.HtmlBody = text;

            // Now we just need to set the message body and we're done


            
        }
        #endregion
    }
}



//نحوه تعریف متن
//        string.Format(
//            @"<h1>SHETAweb</h1>
//<h4>{0}عزیز ممنون از ثبت نام شما در سایت ما </h4>
//<table><h4>اطلاعات حساب کاربری شما:</h4><ul><li><p> ایمیل:{1}</p></li><li> نام کاربری: {2}</li><li> زمان ثبت نام {3}</li></ul></table>
//<hr/>
//<h3> جهت فعالسازی حساب خود وارد لینک زیر شوید </h3>
//<a href='https://localhost:44303/Account/ActiveAccount/{4}'>فعالسازی اکانت</a>", user.UserName, user.Email, user.UserName, user.RegisterDate, user.ActiveCode);

