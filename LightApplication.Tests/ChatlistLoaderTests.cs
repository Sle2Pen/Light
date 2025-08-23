using Light.LightChatsRequests;
using LightApplication.CachedDataRepositories;
using LightApplication.LightChatsRequests;
using LightApplication.LightFileRequests;
using LightApplication.LoadServices;
using LightApplication.UpdateDispatchers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightApplication.Tests
{
    [TestFixture]
    public class ChatlistLoaderTests
    {
        [Test]
        public async Task LoadChatsByLimitFromOffsetAsync_EmptyRepository_CheckingRepository()
        {
            var chatRequests = new AlwaysSuccessChatsRequests();
            var fileRequests = new AlwaysSuccessFileRequests();
            var chatsCache = new EmptyChatsCache();
            var chatsUpdatesDispatcher = new FakeChatUpdatesDispatcher();
            var chatlistLoader = new ChatlistLoader(chatRequests, fileRequests, chatsCache, chatsUpdatesDispatcher);

            await chatlistLoader.LoadChatsByLimitFromOffsetAsync();

            Assert.IsTrue(chatsCache.IsChecked);
        }

        [Test]
        public async Task LoadChatsByLimitFromOffsetAsync_EmptyRepository_CallChatsRequests()
        {
            var chatRequests = new AlwaysSuccessChatsRequests();
            var fileRequests = new AlwaysSuccessFileRequests();
            var chatsCache = new EmptyChatsCache();
            var chatsUpdatesDispatcher = new FakeChatUpdatesDispatcher();
            var chatlistLoader = new ChatlistLoader(chatRequests, fileRequests, chatsCache, chatsUpdatesDispatcher);

            await chatlistLoader.LoadChatsByLimitFromOffsetAsync();

            Assert.IsTrue(chatRequests.IsCalled);
        }

        [Test]
        public async Task LoadChatsByLimitFromOffsetAsync_EmptyRepository_CallChatUpdatesDispatcher()
        {
            var chatRequests = new AlwaysSuccessChatsRequests();
            var fileRequests = new AlwaysSuccessFileRequests();
            var chatsCache = new EmptyChatsCache();
            var chatsUpdatesDispatcher = new FakeChatUpdatesDispatcher();
            var chatlistLoader = new ChatlistLoader(chatRequests, fileRequests, chatsCache, chatsUpdatesDispatcher);

            await chatlistLoader.LoadChatsByLimitFromOffsetAsync();

            Assert.IsTrue(chatsUpdatesDispatcher.IsCalled);
        }

        [Test]
        public async Task LoadChatsByLimitFromOffsetAsync_EmptyRepository_CalledGetChatChatIdsTimes()
        {
            var chatRequests = new AlwaysSuccessChatsRequests();
            var fileRequests = new AlwaysSuccessFileRequests();
            var chatsCache = new EmptyChatsCache();
            var chatsUpdatesDispatcher = new FakeChatUpdatesDispatcher();
            var chatlistLoader = new ChatlistLoader(chatRequests, fileRequests, chatsCache, chatsUpdatesDispatcher);

            await chatlistLoader.LoadChatsByLimitFromOffsetAsync();

            Assert.IsTrue(chatRequests.IsCalledGetChat);
            Assert.AreEqual(chatRequests.RequestResults.Count, chatRequests.GetChatCalledTimes);
        }

        [Test]
        public async Task LoadChatsByLimitFromOffsetAsync_EmptyRepository_AddChatInCacheChatIdsTimes()
        {
            var chatRequests = new AlwaysSuccessChatsRequests();
            var fileRequests = new AlwaysSuccessFileRequests();
            var chatsCache = new EmptyChatsCache();
            var chatsUpdatesDispatcher = new FakeChatUpdatesDispatcher();
            var chatlistLoader = new ChatlistLoader(chatRequests, fileRequests, chatsCache, chatsUpdatesDispatcher);

            await chatlistLoader.LoadChatsByLimitFromOffsetAsync();

            Assert.IsTrue(chatRequests.IsCalledGetChat);
            Assert.AreEqual(chatRequests.RequestResults.Count, chatRequests.GetChatCalledTimes);
        }
    }

    public class AlwaysSuccessFileRequests: IFilesRequests
    {
        public AlwaysSuccessFileRequests()
        {
        }

        public Task DownloadAvatarAsync(int avatarId)
        {
            throw new NotImplementedException();
        }
    }

    public class AlwaysSuccessChatsRequests : IChatsRequests
    {
        public bool IsCalled { get; set; } = false;
        public int GetChatCalledTimes { get; set; } = 0;
        public bool IsCalledGetChat { get; set; } = false;
        public List<long> RequestResults = new List<long>
        {
            1234,
            28947384,
            2345,
            23456
        };

        //public List<ChatRequestResult> requestResults = new List<ChatRequestResult>
        //{
        //    new ChatRequestResult
        //    {
        //        Id =1234,
        //        Title ="First",
        //        IsContainPhoto=true,
        //        SmallPhotoId=5678,
        //        SmallPhotoPath=null,
        //        RealPhotoId=9876,
        //        RealPhotoPath=null,
        //        UnreadCount=0,
        //        UnreadMentionCount=1,
        //        UnreadReactionCount=2,
        //        LastMessageTime=123456789,
        //        IsOutgoingMessage=true,
        //        LastMessage=new MessageResult
        //        {
        //            Id =11234,
        //                //public long ChatId { get; set; }
        //            SenderUserId=12345,
        //            Date=1234464645,
        //            EditDate=2323424,//??
        //            IsOutgoing =true,
        //            IsContainUnreadMentions=true,
        //            IsPinned=false,

        //            IsSendedOffline=false,
        //            CanBeSaved =true,
        //            SendingState=MessageSendingState.Sent,

        //            ////about user
        //            //public bool ContainsUnreadMention { get; set; }

        //            //public MessageContentType ContentType { get; set; }
        //            MessageContent=null
        //        }
        //    },
        //    new ChatRequestResult
        //    {
        //        Id =2345,
        //        Title ="Second",
        //        IsContainPhoto=true,
        //        SmallPhotoId=65678,
        //        SmallPhotoPath=null,
        //        RealPhotoId=96876,
        //        RealPhotoPath=null,
        //        UnreadCount=0,
        //        UnreadMentionCount=1,
        //        UnreadReactionCount=2,
        //        LastMessageTime=123456789,
        //        IsOutgoingMessage=true,
        //        LastMessage=new MessageResult
        //        {
        //            Id =112354,
        //                //public long ChatId { get; set; }
        //            SenderUserId=123245,
        //            Date=1234464645,
        //            EditDate=2323424,//??
        //            IsOutgoing =true,
        //            IsContainUnreadMentions=true,
        //            IsPinned=false,

        //            IsSendedOffline=false,
        //            CanBeSaved =true,
        //            SendingState=MessageSendingState.Sent,

        //            ////about user
        //            //public bool ContainsUnreadMention { get; set; }

        //            //public MessageContentType ContentType { get; set; }
        //            MessageContent=null
        //        }
        //    },
        //    new ChatRequestResult
        //    {
        //        Id =23456,
        //        Title ="Second",
        //        IsContainPhoto=true,
        //        SmallPhotoId=56786,
        //        SmallPhotoPath=null,
        //        RealPhotoId=98676,
        //        RealPhotoPath=null,
        //        UnreadCount=0,
        //        UnreadMentionCount=1,
        //        UnreadReactionCount=2,
        //        LastMessageTime=1234656789,
        //        IsOutgoingMessage=true,
        //        LastMessage=new MessageResult
        //        {
        //            Id =112354,
        //                //public long ChatId { get; set; }
        //            SenderUserId=1232645,
        //            Date=344646645,
        //            EditDate=23263424,//??
        //            IsOutgoing =true,
        //            IsContainUnreadMentions=true,
        //            IsPinned=false,

        //            IsSendedOffline=false,
        //            CanBeSaved =true,
        //            SendingState=MessageSendingState.Sent,

        //            ////about user
        //            //public bool ContainsUnreadMention { get; set; }

        //            //public MessageContentType ContentType { get; set; }
        //            MessageContent=null
        //        }
        //    }
        //};

        public AlwaysSuccessChatsRequests()
        {
        }

        public async Task<IEnumerable<ChatRequestResult>> LoadChatsFromTelegramAsync(int offset = 0, int limit = 50)
        {
            IsCalled = true;
            await Task.Delay(100);
            return null;
        }

        public async Task<IEnumerable<long>> LoadChatIdsFromTelegramAsync(int offset = 0, int limit = 50)
        {
            IsCalled = true;
            await Task.Delay(100);
            return RequestResults;
        }

        public async Task<ChatRequestResult> LoadChatFromTelegramAsync(long item)
        {
            if (IsCalledGetChat == false)
            {
                IsCalledGetChat = !IsCalledGetChat;
            }

            GetChatCalledTimes++;
            await Task.Delay(100);

            return new ChatRequestResult
            {
                Id = 1234,
                Title = "First",
                IsContainPhoto = true,
                SmallPhotoId = 5678,
                SmallPhotoPath = null,
                RealPhotoId = 9876,
                RealPhotoPath = null,
                UnreadCount = 0,
                UnreadMentionCount = 1,
                UnreadReactionCount = 2,
                LastMessageTime = 123456789,
                IsOutgoingMessage = true,
                LastMessage = new MessageResult
                {
                    Id = 11234,
                    //public long ChatId { get; set; }
                    SenderUserId = 12345,
                    Date = 1234464645,
                    EditDate = 2323424,//??
                    IsOutgoing = true,
                    IsContainUnreadMentions = true,
                    IsPinned = false,

                    IsSendedOffline = false,
                    CanBeSaved = true,
                    SendingState = MessageSendingState.Sent,

                    ////about user
                    //public bool ContainsUnreadMention { get; set; }

                    //public MessageContentType ContentType { get; set; }
                    MessageContent = null
                }
            };
        }
    }

    public class EmptyChatsCache : ICachedChats
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

        public EmptyChatsCache()
        {
        }
    }

    public class FakeChatUpdatesDispatcher : IChatUpdatesDispatcher
    {
        public int Count
        {
            get
            {
                IsCalled = true;
                return 0;
            }
        }

        public bool IsCalled { get; set; } = false;

        public void SendChatLoadedUpdate()
        {
            IsCalled = true;
        }
    }
}
