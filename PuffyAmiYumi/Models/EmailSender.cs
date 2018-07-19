//using Microsoft.Extensions.Configuration;
//using System.Threading.Tasks;
//using SendGrid;
//using SendGrid.Helpers.Mail;

//namespace PuffyAmiYumi.Models
////: IEmailSender
//{
//    public class EmailSender
//    {
//        private IConfiguration Configuration { get; }

//        public EmailSender(IConfiguration configuration)
//        {
//        Configuration = configuration;
//        }

//        public Task SendEmailAsync(string email, string subject, string htmlMessage)
//        {
//        var msg = new SendGridMessage();

//        msg.SetFrom("admin@busmall.com", "Bus Mall Admin");

//        msg.AddTo(email);
//        msg.SetSubject(subject);
//        msg.AddContent(Mimetype.Html, htmlMessage);

//        var client = new SendGridClient(Configuration["SendGrid: Api_Key"]);
//        }
//    }
//}
