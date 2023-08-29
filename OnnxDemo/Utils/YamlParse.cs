using System.Text;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace OnnxDemo.Utils
{
    public class YamlParse
    {

        private readonly StringReader stringReader;
        public YamlParse(string yamlPath)
        {
            stringReader = new(File.ReadAllText(yamlPath));
        }
        public YamlParse(byte[] yamlContext)
        {
            stringReader = new(Encoding.UTF8.GetString(yamlContext));
        }

        public List<T> ParseList<T>()
        {
            IDeserializer deserializer = new DeserializerBuilder().Build();
            Parser parser = new(stringReader);

            parser.Consume<StreamStart>();
            List<T> configs = new();
            while (parser.TryConsume(out DocumentStart _))
            {
                T config = deserializer.Deserialize<T>(parser);
                configs.Add(config);
                parser.MoveNext();
            }
            return configs;
        }

        public Dictionary<string, T> ParseDict<T>()
        {
            IDeserializer deserializer = new DeserializerBuilder().Build();
            Parser parser = new(stringReader);

            parser.Consume<StreamStart>();
            Dictionary<string, T> configs = new();
            while (parser.TryConsume(out DocumentStart _))
            {
                Dictionary<string, T> config = deserializer.Deserialize<Dictionary<string, T>>(parser);
                configs = configs.Concat(config).ToDictionary(d => d.Key, d => d.Value);

                parser.MoveNext();
            }
            return configs;
        }

    }
}
