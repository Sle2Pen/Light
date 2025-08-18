using Light.LightSynchronizationServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

using TdApi = Telegram.Td.Api;

namespace LightTests
{
    internal class TDFakeUpdatesHandler : IUpdatesHandler
    {
        IUpdatesHandler _nextHandler;

        public TDFakeUpdatesHandler(IUpdatesHandler nextHandler = null)
        {
            if (nextHandler != null)
            {
                _nextHandler = nextHandler;
            }

            IsGetHandleEvent = false;
        }

        public bool IsGetHandleEvent { get; set; }

        public void HandleUpdates(TdApi.BaseObject updates)
        {
            IsGetHandleEvent = true;
        }
    }

    [TestClass]
    public class TDUpdatesReceiverTests
    {
        [TestMethod]
        public void PassDataToHandlers_ConditionsNotMetContextIsNull_NothingToDo()
        {
            TdApi.Message mes = new TdApi.Message();
            //TdApi.MessageVideo mv;mv.
            //TdApi.MessagePhoto ph;

            SynchronizationContext context = null;
            var handler = new TDFakeUpdatesHandler();
            var updatesReceiver = new UpdatesReceiver(context, handler);

            updatesReceiver.OnResult(null);

            Assert.IsFalse(handler.IsGetHandleEvent);
        }

        //[TestMethod]
        //public void PassDataToHandlers_ConditionsAreMet_HandlingUpdates()
        //{
        //    SynchronizationContext context = SynchronizationContext.Current;
        //    var handler = new TDFakeUpdatesHandler();
        //    var updatesReceiver = new UpdatesReceiver(context, handler);

        //    updatesReceiver.OnResult(null);

        //    Assert.IsTrue(handler.IsGetHandleEvent);
        //}
    }
}
