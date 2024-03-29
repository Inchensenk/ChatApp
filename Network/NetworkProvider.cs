﻿using Common;
using Common.Messages;

namespace Network
{
    public class NetworkProvider
    {
        /// <summary>
        /// Хост
        /// </summary>
        private readonly string _host;

        /// <summary>
        /// Порт
        /// </summary>
        private readonly int _port;

        public NetworkProvider(string host = "localhost", int port = 8888)
        {
            _host = host;
            _port = port;
        }

        public async Task<ResponseMessage> GetAsync(RequestMessage requestData)
        {
            var connection = new Connection(_host, _port);

            var data = SerializationHelper.Serialize(requestData);

            var response = await connection.RequestAsync(data.ToArray());

            connection.Release();

            if (response != null)
            {
                return SerializationHelper.Deserialize<ResponseMessage>(response);
            }

            throw new Exception("Response is null");
        }
    }
}