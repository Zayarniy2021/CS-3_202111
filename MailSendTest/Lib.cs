using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Diagnostics;
using System.Collections;
using System.Net.Mime;

namespace MailSendTest
{
    public class Library
    {

        static public void MailSend(string _from, string _to, string _subject, string _body, string _login,string _password, IEnumerable attachments=null)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(_from);
            // кому отправляем
            MailAddress to = new MailAddress(_to);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = _subject;
            // текст письма
            m.Body = _body;
            // письмо представляет код html
            m.IsBodyHtml = true;
            _password = System.IO.File.ReadAllText("C:\\temp\\1.txt");
            if (attachments!=null)
            {

                foreach (var el in attachments)
                {
                    System.Diagnostics.Debug.WriteLine(el.ToString());
                    Attachment attachment = new Attachment(el.ToString());
                    m.Attachments.Add(attachment);
                }
            }
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(_login, _password);
            smtp.EnableSsl = true;
            smtp.Send(m);
            Debug.WriteLine("Message has sent");

        }


    }
}
