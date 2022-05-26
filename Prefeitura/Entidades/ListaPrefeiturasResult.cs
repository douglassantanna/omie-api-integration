using System.Xml.Serialization;

namespace omie_api_integration.Prefeitura.Entidades
{
    [XmlRoot(ElementName = "ListaPrefeiturasResult")]
    public class ListaPrefeiturasResult
    {

        [XmlElement(ElementName = "resultado")]
        public Resultado Resultado { get; set; }
    }

}