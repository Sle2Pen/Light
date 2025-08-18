using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightApplication.LightFileRequests
{
    public interface IFilesRequests
    {
        Task DownloadAvatarAsync(int avatarId);
    }
}
