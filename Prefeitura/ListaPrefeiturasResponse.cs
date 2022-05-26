using System.Collections.Generic;
using System.Xml.Serialization;
using omie_api_integration.Prefeitura.Entidades;

namespace omie_api_integration.Prefeitura
{
    [XmlRoot(ElementName = "ListaPrefeiturasResponse")]
    public class ListaPrefeiturasResponse
    {

        [XmlElement(ElementName = "ListaPrefeiturasResult")]
        public ListaPrefeiturasResult ListaPrefeiturasResult { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}