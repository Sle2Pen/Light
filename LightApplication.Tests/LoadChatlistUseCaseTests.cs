using System.Collections.Generic;
using System.Threading.Tasks;
using Light.LightChatsRequests;
using LightApplication.LightUseCases;
using NUnit.Framework;

namespace LightApplication.Tests
{
    [TestFixture]
    public class LoadChatlistUseCaseTests
    {
        [Test]
        public void InitialLoadChatsAsync_EmptyChatsCache()
        {
            var cachedChats = new EmptyChats();
            var chatRequests = new FakeChatsRequests();
            var loadChatsUseCase = new LoadChatlistUseCase(chatRequests);

            var chats = loadChatsUseCase.LoadInitialChatsAsync();

            Assert.IsTrue(cachedChats.IsChecked);
        }
    }

    internal class FakeChatsRequests:IChatsRequests
    {
        public FakeChatsRequests()
        {
        }

        public Task<IEnumerable<ChatRequestResult>> LoadChatsFromTelegramAsync(int offset = 0, int limit = 50)
        {
            throw new System.NotImplementedException();
        }
    }

    public class EmptyChats
    {
        public int Count
        {
            get
            {
                IsChecked = true;
                return 0;
            }
        }

        public bool IsChecked { get; set; } = false;

        public EmptyChats()
        {
        }
    }
}
