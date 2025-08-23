using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightApplication.LoadServices
{
    public interface IChatlistLoader
    {
        Task LoadChatsByLimitFromOffsetAsync(int offset=0,int limit=50);
    }
}
