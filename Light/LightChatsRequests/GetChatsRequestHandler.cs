using TdApi = Telegram.Td.Api;

namespace Light.LightChatsRequests
{
    public class GetChatsRequestHandler : GenericRequestHandler<ChatsIdsCollectionResult>
    {
        protected override void SetInternalResult(TdApi.BaseObject @object)
        {
            _result = new ChatsIdsCollectionResult
            {
                IdCollection = (@object as TdApi.Chats).ChatIds
            };
        }
    }
}
