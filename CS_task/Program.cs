using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CS_task
{
    class Program
    {
        static async Task Main(string[] args)
        { 
            string xml = "data.xml";
            string txt = "NewFile1.txt";

            var list = new List<Trade>();

            LoaderTxt loaderTxt = new LoaderTxt();
            var task1 =  loaderTxt.TextReader(txt);
            LoaderXml loaderXml = new LoaderXml();
            var task2 = loaderXml.XmlTextReader(xml);
            var tasks = new List<Task<List<Trade>>>();
            tasks.Add(task1);
            tasks.Add(task2);

            var res = Task.WhenAll(tasks);
            foreach (var l in await res)
            {
                list.AddRange(l);
            }

            Console.ReadLine();
        }
    }
}