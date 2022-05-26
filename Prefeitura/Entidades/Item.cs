using System.Xml.Serialization;

namespace omie_api_integration.Prefeitura.Entidades
{

    [XmlRoot(ElementName = "Item")]
    public class Item
    {
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "desc")]
        public string Desc { get; set; }
    }

}