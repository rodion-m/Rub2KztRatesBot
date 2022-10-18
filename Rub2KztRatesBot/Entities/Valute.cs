using System.Xml.Serialization;

namespace Rub2KztRatesBot.Entities;

#pragma warning disable CS8618
[XmlRoot(ElementName="Valute")]
public class Valute {
    [XmlElement(ElementName="NumCode")]
    public string NumCode { get; set; }
    [XmlElement(ElementName="CharCode")]
    public string CharCode { get; set; }
    [XmlElement(ElementName="Nominal")]
    public string Nominal { get; set; }
    [XmlElement(ElementName="Name")]
    public string Name { get; set; }
    [XmlElement(ElementName="Value")]
    public string Value { get; set; }
    [XmlAttribute(AttributeName="ID")]
    public string ID { get; set; }

    public decimal GetCurrencyPerRubRate()
    {
        return 1m / GetOneRubPerCurrencyRate();
    }

    private decimal GetOneRubPerCurrencyRate()
    {
        return decimal.Parse(Value) / decimal.Parse(Nominal);
    }
}