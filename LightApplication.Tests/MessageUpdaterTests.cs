using LightApplication.LightCachedDataRepositories;
using LightApplication.LightMessageInfo;
using LightApplication.LightMessageUpdater;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightApplication.Tests
{
    [TestFixture]
    public class MessageUpdaterTests
    {
        [Test]
        public void UpdateTextMessage_TextContent_CallMessageFactory()
        {
            var messageInfo = new TextMessageInfo
            {
                MessageInfo = new MessageInfo(),
                MessageText = new TextContent()
            };
            var fakeMessageRepository = new AlwaysNullMessageRepository();
            var messageUpdater = new MessageUpdater(fakeMessageRepository);
            var messageFactory = new FakeMessageFactory();

            messageUpdater.TextMessageUpdate(messageInfo);

            Assert.IsTrue(fakeMessageRepository.IsCalled);

        }
    }

    public class FakeMessageFactory
    {
        //public Message CreateMessage()
        //{
        //    return new Message();
        //}
    }

    public class AlwaysNullMessageRepository : IMessages
    {
        public bool IsCalled { get; set; } = false;

        public int Count => throw new NotImplementedException();

        

        public void AddTextMessageInfo(TextMessageInfo newTextMessage)
        {
            throw new NotImplementedException();
        }

        public MessageInfo GetMessageInfoWithId(long messageId)
        {
            throw new NotImplementedException();
        }

        public TextContent GetTextContentWithMessageId(long messageId)
        {
            throw new NotImplementedException();
        }

        public bool IsAlreadyContainMessageWithId(long messageId)
        {
            throw new NotImplementedException();
        }

        
    }
}
