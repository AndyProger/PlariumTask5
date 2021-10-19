using System;
using UserSpace;

namespace LetterSpace
{
    class Letter
    {
        public User Sender { private get; set; }
        public User Recipient { private get; set; }
        public DateTime SendingDate { get; set; }
        public string Topic { get; private set; } = string.Empty;
        public string Text { get; private set; } = string.Empty;

        public Letter(string topic, string text)
        {
            Topic = topic;
            Text = text;
        }

        public Letter(Letter other)
        {
            Sender = other.Sender;
            Recipient = other.Recipient;
            Topic = other.Topic;
            Text = other.Text;
        }

        public override string ToString()
        {
            return $"Sender:\n{Sender}\nRecipient:\n{Recipient}\nTopic: {Topic}\nText: {Text}\nDate: {SendingDate}";
        }
    }
}
