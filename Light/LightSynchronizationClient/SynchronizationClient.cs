using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdApi = Telegram.Td.Api;
using Td = Telegram.Td;
using System.Threading;
using Light.LightInitialApplicationSettings;

namespace Light.LightSynchronizationClient
{
    public class SynchronizationClient : ISynchronizationClient
    {
        private readonly LightSettings _lightSettings;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly Td.ClientResultHandler _updateListener;

        private Td.Client _client;

        public SynchronizationClient(
            LightSettings lightSettings,
            CancellationTokenSource cancellationTokenSource,
            Td.ClientResultHandler updateListener)
        {
            _lightSettings = lightSettings;
            _cancellationTokenSource = cancellationTokenSource;
            _updateListener = updateListener;
        }

        private void CreateClient()
        {
            _client = Td.Client.Create(_updateListener);
            var request = SetClientRequestParameters();

            try
            {
                _client.Send(request, null);
            }
            catch (Exception)
            {
                Debug.WriteLine("Smth wrong");
            }
        }

        private TdApi.SetTdlibParameters SetClientRequestParameters()
        {
            var request = new TdApi.SetTdlibParameters
            {
                DatabaseDirectory = _lightSettings.DatabaseDirectory,
                UseSecretChats = _lightSettings.UseSecretChats,
                UseMessageDatabase = _lightSettings.UseMessageDatabase,
                ApiId = _lightSettings.ApiId,
                ApiHash = _lightSettings.ApiHash,
                SystemLanguageCode = _lightSettings.SystemLanguageCode,
                DeviceModel = _lightSettings.DeviceModel,
                ApplicationVersion = _lightSettings.ApplicationVersion
            };

            return request;
        }

        public void Run()
        {
            //Task _tdListeningTask;

            //Td.Client.Execute(new TdApi.SetLogVerbosityLevel(0));
            //Td.Client.Execute(new TdApi.SetLogStream(new TdApi.LogStreamFile(Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "log"), 1 << 27, false)));
            //Td.Client.SetLogMessageCallback(100, LogMessageCallback);

            Task _tdListeningTask = Task.Factory.StartNew(() =>
            {
                Td.Client.Run();
            }, _cancellationTokenSource.Token);

            CreateClient();
        }

        public void ResetClient()
        {
            CreateClient();
        }


        public void SendRequest(TdApi.Function requestFunction, Td.ClientResultHandler requestHandler)
        {
            _client.Send(requestFunction, requestHandler);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
