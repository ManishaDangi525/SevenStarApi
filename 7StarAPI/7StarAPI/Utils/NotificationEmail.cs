 
using SevenStarDtos.DTOs;
using SevenStarFramework.Repositories.Interfaces;
using SevenStarFramework.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
 

namespace SevenStar.Utils
{
    public static class NotificationEmail
         
    {
        
      public  async static Task<string> SupplierLinkCreationMail(IWebHostEnvironment _env, AppSettings _appSettings, string Mobile,string EmailAddress)
        {
            string emailAddress = "";
            string mobile = "";
            MailMessage msg = new MailMessage();

            var pathToFile = _env.ContentRootPath
                 + Path.DirectorySeparatorChar.ToString()
                   + "HtmlTemplete" 
                  + Path.DirectorySeparatorChar.ToString()
                 + "SupplierLinkCreation.html";

            StringBuilder builder = new StringBuilder();
            if (EmailAddress != null)
            {
                if (builder.ToString().Contains(EmailAddress.ToString())) { }
                else { builder.Append(EmailAddress).Append(" "); }
            }
            emailAddress = builder.ToString();

            StringBuilder builder1 = new StringBuilder();
            if (Mobile != null)
            {
                if (builder1.ToString().Contains(Mobile.ToString())) { }
                else { builder1.Append(Mobile).Append(" "); }
            }
            mobile = builder1.ToString();

            var builder5 = new BodyBuilder();
            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder5.HtmlBody = SourceReader.ReadToEnd();
            } 
            string messageBody = string.Format(builder5.HtmlBody, emailAddress, mobile
                );
            msg.BodyEncoding = Encoding.ASCII;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(_appSettings.EmailFrom);  
            msg.To.Add(EmailAddress);  
            msg.Subject = "IDEX: Registration link";
            msg.Body = messageBody;  
            var var = await EmailHelper.GetEmailAsync(msg, _appSettings);
              
            return "";
        }

        public async static Task<string> ForgotPasswordMail(IWebHostEnvironment _env,decimal? OTP, AppSettings _appSettings,string LoginName)
        {
            MailMessage msg = new MailMessage();
            string otp = "";


            var pathToFile = _env.ContentRootPath
                 + Path.DirectorySeparatorChar.ToString()
                   + "HtmlTemplete"
                  + Path.DirectorySeparatorChar.ToString()
                 + "ForgotPassword.html";
            var builder5 = new BodyBuilder();

            StringBuilder builder = new StringBuilder();
            if (OTP != null)
            {  
                if (builder.ToString().Contains(OTP.ToString())) { }
                else { builder.Append(OTP).Append(" "); }
            }
            otp = builder.ToString(); 


            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder5.HtmlBody = SourceReader.ReadToEnd();
            }
            string messageBody = string.Format(builder5.HtmlBody, otp
                );
            msg.BodyEncoding = Encoding.ASCII;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(_appSettings.EmailFrom);  
            msg.To.Add(LoginName);
            msg.Subject = "IDEX: Forgot Password OTP";
            msg.Body = messageBody;
            var var = await EmailHelper.GetEmailAsync(msg, _appSettings); 
            return "";
        }

        public async static Task<string> NewPasswordMail(IWebHostEnvironment _env, decimal? OTP, AppSettings _appSettings, string LoginName, string LoginPassword)
        {
            MailMessage msg = new MailMessage();
            string loginPassword = "";


            var pathToFile = _env.ContentRootPath
                 + Path.DirectorySeparatorChar.ToString()
                   + "HtmlTemplete"
                  + Path.DirectorySeparatorChar.ToString()
                 + "ResetPassword.html";
            var builder5 = new BodyBuilder();

            StringBuilder builder = new StringBuilder();
            if (LoginPassword != null)
            {
                if (builder.ToString().Contains(LoginPassword.ToString())) { }
                else { builder.Append(LoginPassword).Append(" "); }
            }
            loginPassword = builder.ToString();


            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder5.HtmlBody = SourceReader.ReadToEnd();
            }
            string messageBody = string.Format(builder5.HtmlBody, loginPassword
                );
            msg.BodyEncoding = Encoding.ASCII;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(_appSettings.EmailFrom);
            msg.To.Add(LoginName);
            msg.Subject = "IDEX: Reset Password"; 
            msg.Body = messageBody;
            var var = await EmailHelper.GetEmailAsync(msg, _appSettings);
            return "";
        }

        public async static Task<string> RegistrationMail(IWebHostEnvironment _env,  AppSettings _appSettings, string EmailAdderss, string SupplireName,string IsVerifyRemark)
        {
            MailMessage msg = new MailMessage();
            string emailAdderss = "";
            string supplireName = "";


            var pathToFile = _env.ContentRootPath
                 + Path.DirectorySeparatorChar.ToString()
                   + "HtmlTemplete"
                  + Path.DirectorySeparatorChar.ToString()
                 + "RegistrationMail.html";
            var builder5 = new BodyBuilder();

            StringBuilder builder = new StringBuilder();
            if (EmailAdderss != null)
            {
                if (builder.ToString().Contains(EmailAdderss.ToString())) { }
                else { builder.Append(EmailAdderss).Append(" "); }
            }

            emailAdderss = builder.ToString();

            StringBuilder builder1 = new StringBuilder();
            if (SupplireName != null)
            {
                if (builder1.ToString().Contains(SupplireName.ToString())) { }
                else { builder1.Append(SupplireName).Append(" "); }
            }
            supplireName = builder1.ToString();


            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder5.HtmlBody = SourceReader.ReadToEnd();
            }
            string messageBody = string.Format(builder5.HtmlBody, emailAdderss, supplireName
                );
            msg.BodyEncoding = Encoding.ASCII;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(_appSettings.EmailFrom);
            msg.To.Add(EmailAdderss);
            msg.Subject = "IDEX: Registration";
            msg.Body = messageBody;
            var var = await EmailHelper.GetEmailAsync(msg, _appSettings);
            return "";
        }

         
        public async static Task<string> ApprovedMail(IWebHostEnvironment _env, AppSettings _appSettings, string EmailAdderss, string SupplireName,string VerifyRemark,string IsVerify)
        {
            MailMessage msg = new MailMessage();
            string emailAdderss = "";
            string supplireName = "";


            var pathToFile = _env.ContentRootPath
                 + Path.DirectorySeparatorChar.ToString()
                   + "HtmlTemplete"
                  + Path.DirectorySeparatorChar.ToString()
                 + "ApprovedMail.html";
            var builder5 = new BodyBuilder();

            StringBuilder builder = new StringBuilder();
            if (EmailAdderss != null)
            {
                if (builder.ToString().Contains(EmailAdderss.ToString())) { }
                else { builder.Append(EmailAdderss).Append(" "); }
            }

            emailAdderss = builder.ToString();

            StringBuilder builder1 = new StringBuilder();
            if (SupplireName != null)
            {
                if (builder1.ToString().Contains(SupplireName.ToString())) { }
                else { builder1.Append(SupplireName).Append(" "); }
            }
            supplireName = builder1.ToString();


            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder5.HtmlBody = SourceReader.ReadToEnd();
            }
            string messageBody = string.Format(builder5.HtmlBody, emailAdderss, supplireName
                );
            msg.BodyEncoding = Encoding.ASCII;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(_appSettings.EmailFrom);
            msg.To.Add(EmailAdderss);
            msg.Subject = "IDEX: Approved";
            msg.Body = messageBody;
            var var = await EmailHelper.GetEmailAsync(msg, _appSettings);
            return "";
        }

        public async static Task<string> RejectedMail(IWebHostEnvironment _env, AppSettings _appSettings, string EmailAdderss, string SupplireName)
        {
            MailMessage msg = new MailMessage();
            string emailAdderss = "";
            string supplireName = "";


            var pathToFile = _env.ContentRootPath
                 + Path.DirectorySeparatorChar.ToString()
                   + "HtmlTemplete"
                  + Path.DirectorySeparatorChar.ToString()
                 + "RejectedMail.html";
            var builder5 = new BodyBuilder();

            StringBuilder builder = new StringBuilder();
            if (EmailAdderss != null)
            {
                if (builder.ToString().Contains(EmailAdderss.ToString())) { }
                else { builder.Append(EmailAdderss).Append(" "); }
            }

            emailAdderss = builder.ToString();

            StringBuilder builder1 = new StringBuilder();
            if (SupplireName != null)
            {
                if (builder1.ToString().Contains(SupplireName.ToString())) { }
                else { builder1.Append(SupplireName).Append(" "); }
            }
            supplireName = builder1.ToString();


            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder5.HtmlBody = SourceReader.ReadToEnd();
            }
            string messageBody = string.Format(builder5.HtmlBody, emailAdderss, supplireName
                );
            msg.BodyEncoding = Encoding.ASCII;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(_appSettings.EmailFrom);
            msg.To.Add(EmailAdderss);
            msg.Subject = "IDEX: Approved";
            msg.Body = messageBody;
            var var = await EmailHelper.GetEmailAsync(msg, _appSettings);
            return "";
        }
        public async static Task<string> userMail(IWebHostEnvironment _env, AppSettings _appSettings, string EmailAdderss, string UserName ,string password)
        {
            MailMessage msg = new MailMessage();
            string emailAdderss = "";
            string supplireName = "";
            string userPassword = "";


            var pathToFile = _env.ContentRootPath
                 + Path.DirectorySeparatorChar.ToString()
                   + "HtmlTemplete"
                  + Path.DirectorySeparatorChar.ToString()
                 + "userMail.html";
            var builder5 = new BodyBuilder();

            StringBuilder builder = new StringBuilder();
            if (EmailAdderss != null)
            {
                if (builder.ToString().Contains(EmailAdderss.ToString())) { }
                else { builder.Append(EmailAdderss).Append(" "); }
            }

            emailAdderss = builder.ToString();

            StringBuilder builder1 = new StringBuilder();
            if (UserName != null)
            {
                if (builder1.ToString().Contains(UserName.ToString())) { }
                else { builder1.Append(UserName).Append(" "); }
            }
            supplireName = builder1.ToString();

            StringBuilder Password = new StringBuilder();
            if (password != null)
            {
                if (builder1.ToString().Contains(password.ToString())) { }
                else { builder1.Append(password).Append(" "); }
            }
            userPassword = Password.ToString();

            using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
            {
                builder5.HtmlBody = SourceReader.ReadToEnd();
            }
            string messageBody = string.Format(builder5.HtmlBody, emailAdderss, supplireName, userPassword
                );
            msg.BodyEncoding = Encoding.ASCII;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress(_appSettings.EmailFrom);
            msg.To.Add(EmailAdderss);
            msg.Subject = "IDEX: Approved";
            msg.Body = messageBody;
            var var = await EmailHelper.GetEmailAsync(msg, _appSettings);
            return "";
        }
    }
}
 
