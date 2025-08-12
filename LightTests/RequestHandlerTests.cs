using Light.LightAuthorizationRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TdApi = Telegram.Td.Api;

namespace LightTests
{
    [TestClass]
    public class RequestHandlerTests
    {
        [TestMethod]
        public void GetResult_TdApiError_RequestErrorResultDto()
        {
            var handler = new AuthorizationRequestHandler();
            int code = 435;
            string message = "Hello world";
            var error = new TdApi.Error
            {
                Code = code,
                Message = message
            };

            handler.OnResult(error);

            //var resultDto = handler.Result;
            //Assert.AreEqual(RequestResult.Fail, resultDto.Result);
            //Assert.AreEqual(code, resultDto.Payload.ErrorCode);
            //Assert.AreEqual(message, resultDto.Payload.Message);
        }

        [TestMethod]
        public void GetResult_TdApiOk_RequestOkResultDto()
        {
            var handler = new AuthorizationRequestHandler();
            var ok = new TdApi.Ok();

            handler.OnResult(ok);

            //var resultDto = handler.Result;
            //Assert.AreEqual(RequestResult.Success, resultDto.Result);
            //Assert.IsNull(resultDto.Payload);
        }
    }
}
