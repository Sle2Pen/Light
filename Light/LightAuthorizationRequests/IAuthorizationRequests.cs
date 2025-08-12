using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light.LightAuthorizationRequests
{
    public interface IAuthorizationRequests
    {
        Task<RequestResult> SendPhoneNumberAsync(AuthorizationRequest phoneNumber);
        Task<RequestResult> SendCodeAsync(AuthorizationRequest code);
        Task<RequestResult> SendPasswordAsync(AuthorizationRequest password);
    }
}
