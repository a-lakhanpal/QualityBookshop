﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;


namespace QualityBooks.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        //public Task SendEmailAsync(string email, string subject, string message)
        //{
        //    return Task.CompletedTask;
        //}

        public Task SendEmailAsync(string email, string subject, string message)
        {

            var mes = new MimeMessage();
            mes.From.Add(new MailboxAddress("QualityBooks", "ankur.lakhan@gmail.com"));
            mes.To.Add(new MailboxAddress("User", email));
            mes.Subject = subject;

            mes.Body = new TextPart("html")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;


                client.Connect("smtp.live.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("ankur.lakhan@gmail.com", "Pprateek@1234#");

                client.Send(mes);
                client.Disconnect(true);
            }
            // Plug in your email service here to send an email.
            return Task.CompletedTask;
        }
    }
}
