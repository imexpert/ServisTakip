using MediatR;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
                try
                {
                    SmtpClient sc = new SmtpClient();
                    sc.Port = 587;
                    sc.Host = "smtp.gmail.com";
                    sc.EnableSsl = true;
                    sc.UseDefaultCredentials = false;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;

                    sc.Credentials = new NetworkCredential("esprikli@gmail.com", "Qweasd00.");

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("esprikli@gmail.com", "Servisim - Teklif");
                    mail.IsBodyHtml = true;
                    mail.Subject = request.Konu;
                    mail.Body = request.Icerik;
                    mail.To.Add(request.AliciMail);

                    if (request.File.Length > 0)
                    {
                        MemoryStream stream = new MemoryStream();
                        stream.Write(request.File, 0, request.File.Length);

                        Attachment attachment = new Attachment(stream, "TeklifRaporu.pdf");
                        mail.Attachments.Add(attachment);
                    }

                    await sc.SendMailAsync(mail, cancellationToken);
                    return ResponseMessage<bool>.Success();
                }
                catch (Exception ex)
                {
                    return ResponseMessage<bool>.Fail(ex.Message);
                }
            }
        }
    }
}
