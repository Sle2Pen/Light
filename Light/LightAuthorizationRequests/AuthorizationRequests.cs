using Light.LightSynchronizationClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;

namespace Light.LightAuthorizationRequests
{
    public class AuthorizationRequests:IAuthorizationRequests
    {
        private readonly ISynchronizationClient _synchronizationClientService;

        public AuthorizationRequests(ISynchronizationClient synchronizationClientService)
        {
            _synchronizationClientService = synchronizationClientService;
        }

        public async Task<RequestResult> SendPhoneNumberAsync(AuthorizationRequest phoneNumber)
        {
            var handler = new AuthorizationRequestHandler();
            var request = new TdApi.SetAuthenticationPhoneNumber(phoneNumber.TextPayload, null);
            _synchronizationClientService.SendRequest(request, handler);

            return await handler.Task;
        }

        public async Task<RequestResult> SendCodeAsync(AuthorizationRequest code)
        {
            var handler = new AuthorizationRequestHandler();
            var request = new TdApi.CheckAuthenticationCode(code.TextPayload);
            _synchronizationClientService.SendRequest(request, handler);
            return await handler.Task;
        }

        public async Task<RequestResult> SendPasswordAsync(AuthorizationRequest password)
        {
            var handler = new AuthorizationRequestHandler();
            var request = new TdApi.CheckAuthenticationPassword(password.TextPayload);
            _synchronizationClientService.SendRequest(request, handler);
            return await handler.Task;
        }
    }
}
