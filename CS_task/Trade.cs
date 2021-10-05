using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CS_task
{
    public class Trade
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("type")]
        public TradeType Type { get; set; }
        [XmlElement("tradeDate")]
        public DateTime TradeDate { get; set; }
        [XmlElement("presentValue")]
        public double PresentValue { get; set; }

    }

    public enum TradeType
    {
        Equity,
        Credit
    }

}