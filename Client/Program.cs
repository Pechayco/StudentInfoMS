using MailKit.Net.Smtp;
using MimeKit;
using StudentInfoModel;
using StudentInfoDL;
using StudentInfoBS;

namespace StudentInfoManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================");
            Console.WriteLine("Student Information Management System");
            Console.WriteLine("======================");

            StudentGetServices gs = new StudentGetServices();
            var infos = gs.GetStudentInfos();

            foreach (var item in infos)
            {
                Console.WriteLine($"Student ID: {item.s_studentID}");
                Console.WriteLine($"Student Name: {item.s_name}");
                Console.WriteLine($"Email Address: {item.s_email}");
                Console.WriteLine($"Phone Number: {item.s_phonenum}");
                Console.WriteLine($"Address: {item.s_address}");
                Console.WriteLine("=======================");

                SendEmail(item);
            }
        }

        static void SendEmail(StudentInfo item)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FromMyNotes", "do-not-reply@frommynotes.com"));
            message.To.Add(new MailboxAddress("Dean Marc L. Pechayco", "deanmarc019@gmail.com"));
            message.Subject = "New Student Information Added";

            message.Body = new TextPart("html")
            {
                Text = $"<h1>New Student Information Added</h1>" +
                       $"<p>Student ID: {item.s_studentID}</p>" +
                       $"<p>Student Name: {item.s_name}</p>" +
                       $"<p>Email Address: {item.s_email}</p>" +
                       $"<p>Phone Number: {item.s_phonenum}</p>" +
                       $"<p>Address: {item.s_address}</p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("b4425d202b3214", "971fd5ac433a43");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully for the student.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
