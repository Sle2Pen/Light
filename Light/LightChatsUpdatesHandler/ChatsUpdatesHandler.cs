using Light.LightSynchronizationServices;
using LightApplication.LightChatlistUpdatesDispatcher;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdApi=Telegram.Td.Api;

namespace Light.LightChatsUpdatesHandler
{
    public class ChatsUpdatesHandler : IUpdatesHandler
    {
        private readonly IChatlistUpdatesDispatcher _chatlistUpdatesDispatcher;
        private readonly IUpdatesHandler _nextUpdatesHandler;

        public ChatsUpdatesHandler(
            IChatlistUpdatesDispatcher chatlistUpdatesDispatcher, 
            IUpdatesHandler nextUpdatesHandler)
        {
            _chatlistUpdatesDispatcher = chatlistUpdatesDispatcher;
            _nextUpdatesHandler = nextUpdatesHandler;

            if (nextUpdatesHandler != null)
            {
                _nextUpdatesHandler = nextUpdatesHandler;
            }
        }

        public void HandleUpdates(TdApi.BaseObject updates)
        {
            switch (updates)
            {
                case TdApi.UpdateNewChat newChat:
                    // AddChat(newChat.Chat);
                    //Debug
                    var fmtString = string.Format("\n-----------------------------------------\nChats  Updates - not handled:\n{0}\n-----------------------------------------\n", updates.ToString());
                    Debug.WriteLine(fmtString);
                    //end Debug
                    break;

                case TdApi.UpdateChatLastMessage lastMsg:
                    //Debug
                    //и в отдельном диспетчере
                    fmtString = string.Format("\n-----------------------------------------\nChats  Updates - not handled:\n{0}\n-----------------------------------------\n", updates.ToString());
                    Debug.WriteLine(fmtString);
                    //end Debug
                    //_chatsUpdatesDispatcher.UpdateLastMessage(lastMsg.ChatId, lastMsg.LastMessage,lastMsg.LastMessage.);
                    break;

                case TdApi.UpdateChatPosition order:
                    //Reorder(order.ChatId, order.Position);
                    break;

                case TdApi.UpdateChatPhoto photo:
                    //UpdatePhoto(photo.ChatId, photo.Photo);
                    break;

                case TdApi.UpdateChatTitle title:
                    //UpdateTitle(title.ChatId, title.Title);
                    break;
            }
            //    _authorizationStateUpdatesDispatcher.SetAuthorizationState(GetAuthorizationStateFrom(authState));
            //}
            //else if (_nextUpdatesHandler != null)
            //{
            //    _nextUpdatesHandler.HandleUpdates(updates);
            //}



            
        }
    }
}
