using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FotoABIld
{
    public static class EmailHandler
    {
        public static void SendMail()
        {
            var messageText = "Testa att skicka ett mail";
            var fromAdress = new MailAddress("Koslewblizz@gmail.com", "Koslew");
            var toAdress = new MailAddress("Johan.a.Larsson@hotmail.com", "Johan");
            var pass = "";

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587, //465
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAdress.Address, pass)
            };
            using (var message = new MailMessage(fromAdress, toAdress)
            {
                Body = messageText,
                Subject = "TestSubject"
            })
                client.Send(message);
        }
    }
}
