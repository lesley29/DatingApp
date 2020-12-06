using Domain.Aggregates.Users.ValueObjects;
using NodaTime;

namespace Application.Messages
{
    public class MessageDto
    {
        public MessageDto(string sender, Photo? senderPhoto, string recipient,
            Photo? recipientPhoto, string content, Instant sendDate, Instant? readDate)
        {
            Sender = sender;
            SenderPhotoUrl = senderPhoto?.Url;
            Recipient = recipient;
            RecipientPhotoUrl = recipientPhoto?.Url;
            Content = content;
            SendDate = sendDate;
            ReadDate = readDate;

        }

        public string Sender { get; private set; }

        public string? SenderPhotoUrl { get; private set; }

        public string Recipient { get; private set; }

        public string? RecipientPhotoUrl { get; private set; }

        public string Content { get; private set; }

        public Instant SendDate { get; private set; }

        public Instant? ReadDate { get; private set; }
    }
}
