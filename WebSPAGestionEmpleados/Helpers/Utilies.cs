using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace WebSPAGestionEmpleados.Helpers
{
    public class Utilies
    {
      public class ResponseResult
        {
            public string Message { get; set; }
            public TypeResponse MessageType { get; set; }
            public object Data { get; set; }

            public static ResponseResult GetResponse(string Message, TypeResponse MessageType, object Data)
            {
                return new ResponseResult { Message = Message, MessageType = MessageType, Data = Data };
            }

            public static ResponseResult GetResponseJson(string Message, TypeResponse MessageType, object Data)
            {
                return new ResponseResult { Message = Message, MessageType = MessageType, Data = JsonConvert.SerializeObject(Data) };
            }
        }


        public  static string ObjectToJson(Object obj)
        {
            if (obj == null)
                return null;

            return JsonConvert.SerializeObject(obj);
        }

        // Convert a byte array to an Object
        public  static object DeserializeJson<T>(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
              return JsonConvert.DeserializeObject<T>(json);
            }
            return null;
        }

    }

    public enum TypeResponse
    {
        Succes = 'S',
        Error = 'E',
        Warning = 'W'
    }
}
