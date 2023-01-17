using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Обертка над ProtoBuf.
    /// </summary>
    public class SerializationHelper
    {
        public static MemoryStream Serialize<T>(T obj)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize<T>(ms, obj);

                    return ms;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        
        public static T Deserialize<T>(byte[] data)
        {
            try
            {
                //AsSpan превращает любой массив в так называемый Span(диапазон),диапазон памяти который занимает массив.
                T res = ProtoBuf.Serializer.Deserialize<T>(data.AsSpan());
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
