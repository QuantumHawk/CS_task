using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CS_task
{
    public class LoaderXml
    {
        public async Task<List<Trade>> XmlTextReader(string fileName)
        {
            FileStream file;
            using (file = File.OpenRead(fileName))
            {
                XmlReaderSettings settings = new XmlReaderSettings(){Async = true};
                XmlReader reader = XmlReader.Create(file, settings);
                XmlSerializer xs = new XmlSerializer(typeof(List<Trade>));
                var trades = (List<Trade>)xs.Deserialize(reader);
                return trades;

            }

        }
        
    }
    public class LoaderTxt
    {
        public async Task<List<Trade>> TextReader(string fileName)
        {
            var trades = new List<Trade>();
            FileStream file;
            using (file = File.OpenRead(fileName))
            {
                using (var reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line != "")
                        {
                            var val = line.Split(';');
                            var parsed = double.TryParse(val[3], out var num);
                            trades.Add(new Trade()
                            {
                                Id = val[0],
                                Type = (TradeType)Enum.Parse(typeof(TradeType), val[1]),
                                TradeDate = DateTime.Parse(val[2]),
                                PresentValue = parsed ? num : 0
                            });
                        }
                    }
                }
            }

            return trades;

        }
        
    }
}