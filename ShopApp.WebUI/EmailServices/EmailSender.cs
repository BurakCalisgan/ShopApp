﻿using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using ShopApp.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private IConfigKeyService _configKeyService;
        private static string SendGridKey;

        public EmailSender(IConfigKeyService configKeyService)
        {
            _configKeyService = configKeyService;

            if (String.IsNullOrEmpty(SendGridKey))
            {
                SendGridKey = _configKeyService.GetConfigValueByKey("SendGridKey");
            }

        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            return Execute(SendGridKey, subject, htmlMessage, email);
        }

        private Task Execute(string sendGridKey, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("info@shopapp.com", "Shop App"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message

            };


            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);

        }
    }
}
