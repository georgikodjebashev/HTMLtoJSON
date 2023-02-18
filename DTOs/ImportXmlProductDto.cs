namespace HTMLtoJSON.DTOs
{
    using System.Xml.Serialization;

    [XmlType(null)]
    public class ImportXmlProductDto
    {
         [XmlElement("productName")]
        public string ProductName { get; set; } = null!;
        
        [XmlElement("price")]
        public decimal Price { get; set; } 

        [XmlAttribute("rating")]
        public decimal Rating { get; set; }
        
    }
}
