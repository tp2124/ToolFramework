using System;
using System.Collections.Generic;
using System.Text;

namespace TP.Services.Notification.Email
{
    /// <summary>
    /// Mail object to be populated with the contents of the e-mail.
    /// </summary>
    public class Message
    {
        public string Body;
        public string Subject;
        public IEnumerable<string> Recipients;
        public IEnumerable<string> CCRecipients;
        public IEnumerable<string> BCCRecipients;
        public string Sender;
    }
}