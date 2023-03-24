using MediatR;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.Settings;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;

namespace ServisTakip.Business.Handlers.MailSenders.Commands
{
    public class MailSenderCommand : IRequest<ResponseMessage<bool>>
    {
        public string AliciMail { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }
        public byte[] File { get; set; }

        public class MailSenderCommandHandler : IRequestHandler<MailSenderCommand, ResponseMessage<bool>>
        {
            private readonly MailSettings _mailSettings;

            public MailSenderCommandHandler(IOptions<MailSettings> options)
            {
                _mailSettings = options.Value;
            }

            public async Task<ResponseMessage<bool>> Handle(MailSenderCommand request, CancellationToken cancellationToken)
            {
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                sc.UseDefaultCredentials = false;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;

                sc.Credentials = new NetworkCredential("esprikli@gmail.com", "ujmuuirdwkgfnfqo");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("esprikli@gmail.com", "Servisim - Teklif");
                mail.IsBodyHtml = true;
                mail.Subject = request.Konu;
                mail.Body = request.Icerik;
                mail.To.Add(request.AliciMail);

                if (request.File.Length > 0)
                {
                    Stream stream = GetAttachmentStream(request.File);

                    Attachment attachment = new Attachment(stream, "TeklifRaporu.pdf", "application/pdf");
                    mail.Attachments.Add(attachment);
                }

                await sc.SendMailAsync(mail, cancellationToken);
                return ResponseMessage<bool>.Success();
            }

            private Stream GetAttachmentStream(byte[] file)
            {
                byte[] fileImageByteArray = new byte[file.Length];

                Stream fileStream = new MemoryStream(file);
                fileStream.Read(fileImageByteArray, 0, file.Length);
                fileStream.Seek(0, SeekOrigin.Begin);

                return fileStream;
            }
        }
    }
}
