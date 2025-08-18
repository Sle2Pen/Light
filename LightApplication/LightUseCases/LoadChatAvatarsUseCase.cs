using LightApplication.LightCachedDataRepositories;
using LightApplication.LightFileRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LightApplication.LightUseCases
{
    public class LoadChatAvatarsUseCase
    {
        private readonly IFilesRequests _filesRequests;

        public LoadChatAvatarsUseCase(IFilesRequests filesRequests)
        {
            _filesRequests = filesRequests;
        }

        public async Task LoadChatAvatarsAsync(IEnumerable<ChatPreviewPresentation> chatPreviews)
        {
            foreach (var item in chatPreviews)
            {
                if(item.IsContainPhoto)
                {
                    await _filesRequests.DownloadAvatarAsync(item.PhotoId);
                }
            }
            
        }
    }
}
