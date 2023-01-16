using System.Net.Sockets;

namespace Common
{
    /// <summary>
    /// Обертка над HTTP соединением
    /// </summary>
    public class Connection
    {
        private readonly TcpClient _client;

        private readonly NetworkStream _stream;

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="host">Хост</param>
        /// <param name="port">Порт</param>
        public Connection(string host, int port)
        {
            _client = new TcpClient(host, port);
            _stream = _client.GetStream();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="client">Конструктор принимает существующий TcpClient</param>
        public Connection(TcpClient client)
        {
            _client = client;
            //GetStream Возвращает объект NetworkStream, используемый для отправки и получения данных.
            _stream = _client.GetStream();
        }

        /// <summary>
        /// Метод возвращает массив байт, но может и не вернуть
        /// </summary>
        /// <param name="data">Данные</param>
        /// <returns>Возврат результата метода ReceiveAsync()</returns>
        public async Task<byte[]?> RequestAsync(byte[] data)
        {
            await _stream.WriteAsync(data);

            return await ReceiveAsync();
        }

        /// <summary>
        /// Закрытие подключения
        /// </summary>
        public void Release()
        {
            _client.Close();
        }

        public async Task<byte[]?> ReceiveAsync()
        {
            byte[] data = new byte[256];

            int bytes;

            CancellationTokenSource source = new CancellationTokenSource(100);

            do
            {
                bytes = await _stream.ReadAsync(data, 0, data.Length, source.Token);

            } while (_stream.DataAvailable);

            byte[] res = new byte[bytes];

            var list = data.ToList();

            list.RemoveRange(bytes, 256 - bytes);

            list.CopyTo(res);

            return res;
        }

        public async Task SendAsync(byte[] data)
        {
            await _stream.WriteAsync(data);
        }
    }
}