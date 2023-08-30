using LaBook_Planet.Library.Core.Services.Interfaces;

//namespace LaBook_Planet.Library.Core.Services.Implementations
//{
//    public class EmailService : IEmailService
//    {
//         private readonly IConfiguration _config;
//        public EmailService(IConfiguration config)
//        {
//            _config = config;
//        }

//        public Task<bool> SenderAsync(string recipientEmail, string subject, string body)
//        {
//            var sender = _config.GetSection("EmailSettings:sender").Value;
//            var port = _config.GetSection("EmailSettings:sender:port").Value;
//            var post = _config.GetSection("EmailSettings:sender:host").Value;
//            var appPassword = _config.GetSection("EmailSettings:sender:appPassword").Value;

//        }
//    }
//}
