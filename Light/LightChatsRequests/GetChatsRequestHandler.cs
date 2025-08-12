using TdApi = Telegram.Td.Api;

namespace Light.LightChatsRequests
{
    public class GetChatsRequestHandler : GenericRequestHandler<ChatsIdsCollectionResult>
    {
        protected override void SetInternalResult(TdApi.BaseObject @object)
        {
            var chatIds = @object as TdApi.Chats;

            _result = new ChatsIdsCollectionResult
            {
                IdCollection = chatIds.ChatIds
            };
        }
    }
}
