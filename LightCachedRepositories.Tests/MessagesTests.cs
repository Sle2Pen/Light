// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using LightApplication.LightMessageInfo;
using LightCachedRepositories.MessageRepository;
using NUnit.Framework;

namespace LightCachedRepositories.Tests
{
    [TestFixture]
    public class MessagesTests
    {
        [Test]
        public void Count_EmptyRepository_Zero()
        {
            var messages = new Messages();

            Assert.That(messages.Count == 0);
        }

        [Test]
        public void AddTextMessageInfo_EmptyRepositoryNewMessage_CountChanged()
        {
            var newTextMessage = new TextMessageInfo
            {
                MessageInfo = new MessageInfo
                {
                    MessageId = 12345
                },

                MessageText = new TextContent
                {
                    Text = "Hello and i'm tired from this"
                }
            };
            var messages = new Messages();

            messages.AddTextMessageInfo(newTextMessage);

            Assert.That(messages.Count == 1);
        }
        
        [Test]
        public void IsAlreadyContainMessageWithId_EmptyRepository_False()
        {
            var messageId = 29387387234;
            var messages = new Messages();

            var result = messages.IsAlreadyContainMessageWithId(messageId);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsAlreadyContainMessageWithId_RepositoryDidntContainMessage_False()
        {
            var messageId = 29387387234;
            //var messagesArray = new[] 
            //{
            //    new Message { Id=12345 },
            //    new Message { Id = 6789 },
            //    new Message { Id = 1234567 },
            //    new Message { Id = 9876 },
            //    new Message { Id = 564738 }
            //};
            var messages = new Messages();
            //foreach(var item in messagesArray)
            //{
            //    messages.Add(item);
            //}

            var result = messages.IsAlreadyContainMessageWithId(messageId);

            Assert.IsFalse(result);
        }

        [Test]
        public void IsAlreadyContainMessageWithId_RepositoryContainMessage_False()
        {
            var messageId = 29387387234;
            //var messagesArray = new[]
            //{
            //    new Message { Id=12345 },
            //    new Message { Id = 6789 },
            //    new Message { Id = 1234567 },
            //    new Message { Id = 29387387234 },
            //    new Message { Id = 564738 }
            //};
            var messages = new Messages();
            //foreach (var item in messagesArray)
            //{
            //    messages.Add(item);
            //}

            var result = messages.IsAlreadyContainMessageWithId(messageId);

            Assert.IsTrue(result);
        }

        [Test]
        public void GetMessageWithId__ReturnMessageWithId()
        {
            var messageId = 123456778;
            //var message = new Message { Id = messageId };
            var messages = new Messages();
            //messages.Add(message);

            //var result = messages.GetMessageWithId(messageId);

            //Assert.That(messageId==result.Id);
        }
    }
}
