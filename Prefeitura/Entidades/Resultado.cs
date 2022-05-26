using System.Collections.Generic;
using System.Xml.Serialization;

namespace omie_api_integration.Prefeitura.Entidades
{
    [XmlRoot(ElementName = "resultado")]

    public class Resultado
    {

        [XmlElement(ElementName = "codigo")]
        public int Codigo { get; set; }

        [XmlElement(ElementName = "mensagem")]
        public string Mensagem { get; set; }

        [XmlElement(ElementName = "Item")]
        public List<Item> Item { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public object Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}