using System.Xml.Serialization;

#pragma warning disable CS8618

namespace Rub2KztRatesBot.Entities;

[XmlRoot(ElementName="ValCurs")]
public class ValCurs {
    [XmlElement(ElementName="Valute")]
    public List<Valute> Valute { get; set; }
    [XmlAttribute(AttributeName="Date")]
    public string Date { get; set; }
    [XmlAttribute(AttributeName="name")]
    public string Name { get; set; }

    public static ValCurs FromXml(string xml)
    {
        if (xml == null) throw new ArgumentNullException(nameof(xml));
        xml = xml.Replace(',', '.'); //replace decimal point
        var serializer = new XmlSerializer(typeof(ValCurs));
        using var reader = new StringReader(xml);
        return (ValCurs) serializer.Deserialize(reader)!;
    }
    
    public decimal Kzt 
        => Valute.Single(it => it.CharCode == "KZT").GetCurrencyPerRubRate();
}