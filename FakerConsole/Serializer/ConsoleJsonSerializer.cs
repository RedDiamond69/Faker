using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FakerConsole.Serializer
{
    public static class ConsoleJsonSerializer
    {
        public static void Serialize<T>(T toSerialize)
        {
            using (var jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(Console.OpenStandardOutput(), Encoding.UTF8, ownsStream: true, indent: true))
            {
                new DataContractJsonSerializer(typeof(T)).WriteObject(jsonWriter, toSerialize);
            }
        }
    }
}
