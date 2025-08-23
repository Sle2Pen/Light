using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light.LightChatsRequests
{
    public interface IChatsRequests
    {
        Task<IEnumerable<ChatRequestResult>> LoadChatsFromTelegramAsync(int offset = 0,int limit = 50);

        Task<IEnumerable<long>> LoadChatIdsFromTelegramAsync(int offset = 0, int limit = 50);
        Task<ChatRequestResult> LoadChatFromTelegramAsync(long item);
    }
}
