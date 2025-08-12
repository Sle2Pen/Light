using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Light
{
    //[TestClass]
    //public class AuthorizationRequestsSenderTests
    //{
    //    [TestMethod]
    //    public void SendPhone_CorrectPhone_ReturnSuccessResultDtoAndEmptyMessage()
    //    {
    //        var client = new SuccessFakeClient();
    //        var authorizationRequestsSender = new AuthorizationRequestsSender(client);
    //        var phoneNumberRequestDto = new AuthorizationRequestDto
    //        {
    //            TextPayload = "Send it"
    //        };

    //        var result = authorizationRequestsSender.SendPhoneNumberAsync(phoneNumberRequestDto);

    //        Assert.AreEqual(RequestResult.Success, result.Result);
    //    }
    //}

    //public class FakeHandler: Td.ClientResultHandler
    // {
    //    public RequestResultDto Result;

    //    public void OnResult(TdApi.BaseObject @object)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //internal class SuccessFakeClient:ISynchronizationClient
    //{
    //    public bool IsSended { get; set; }

    //    public SuccessFakeClient()
    //    {
    //    }

    //    public void Run()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Stop()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void SendRequest(TdApi.Function requestFunction, Td.ClientResultHandler requestHandler)
    //    {
    //        IsSended = true;

    //        //requestHandler.OnResult(new )
    //    }

    //    public void ResetClient()
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
}
