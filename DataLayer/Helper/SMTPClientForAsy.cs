using System;
using System.ComponentModel;
using System.Net.Mail;

/// <summary>
/// Summary description for SMTPClient
/// </summary>
public class SMTPClientForAsy
{
    public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
    {
        //Get the Original MailMessage object
        MailMessage mail = (MailMessage)e.UserState;

        //write out the subject
        string subject = mail.Subject;

        if (e.Cancelled)
        {
            Console.WriteLine("Send canceled for mail with subject [{0}].", subject);
        }
        if (e.Error != null)
        {
            Console.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
        }
        else
        {
            Console.WriteLine("Message [{0}] sent.", subject);
        }
    }
}